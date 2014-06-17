using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT60EDL2014
{
    class UT60EDataParser
    {
        bool synced;
        byte[] readBuffer = new byte[14];
        public EventHandler dataReadyEventHandler;

        enum offset { NIB_1_OFFSET, DIG1_OFFSET, DIG2_OFFSET = 3, DIG3_OFFSET = 5, DIG4_OFFSET = 7, NIB_A_OFFSET = 9, NIB_B_OFFSET, NIB_C_OFFSET, NIB_D_OFFSET, NIB_E_OFFSET };
        static class UT60EDefinition {
            public const byte NIB_E_UNKNOWN = 0xe;
            public const byte NIB_E_CELCIUS = 0x1;
            public const byte NIB_D_HERTZ	= 0x2;
            public const byte NIB_D_VOLT = 0x4;
            public const byte NIB_D_AMP = 0x8;
            public const byte NIB_C_DELTA = 0x2;
            public const byte NIB_C_OHM = 0x4;
            public const byte NIB_C_FARAD = 0x8;
            public const byte NIB_B_PERCENT	= 0x4;
            public const byte NIB_A_KILO = 0x2;
            public const byte NIB_A_NANO = 0x4;
            public const byte NIB_A_MICRO = 0x8;
            public const byte NIB_B_MEGA = 0x2;
            public const byte NIB_B_MILLI = 0x8;
        }

        public void DataReceived(byte[] buf)
        {
            if (buf.Length > 0)
            {
                int startByte = 0;
                int first_byte_index = ((buf[0] & 0xF0) >> 4) - 1;

                if (!synced)
                {
                    if (first_byte_index == 0)
                        synced = true;
                    else if (first_byte_index + buf.Length < 14)
                        return;
                    else
                    {
                        startByte = 14 - first_byte_index;
                        first_byte_index = 0;
                        synced = true;
                    }
                }

                lock (readBuffer)
                {
                    Read2Buffer(startByte, first_byte_index, buf);
                }
            }
        }

        void Read2Buffer(int startIndex, int bufIndex, byte[] buf)
        {
            int lastIndex = Math.Min(startIndex + 14 - bufIndex, buf.Length);
            for (int i = startIndex; i < lastIndex; ++i)
            {
                readBuffer[bufIndex++] = buf[i];
                if (bufIndex >= 14)
                {
                    DataReady(buf, i);
                    break;
                }
            }
        }

        byte ParseDigit(int d_offset)
        {
            byte result = 0;
            byte fix = (byte)((readBuffer[d_offset] << 4) | (readBuffer[d_offset + 1] & 0xF));
            if ((fix & 0x80) != 0)
            {
                fix &= 0x7F;
                result |= 0x80;
            }
            switch (fix)
            {
                case 0x7d: return result;
                case 0x05: return (byte)(result | 1);
                case 0x5b: return (byte)(result | 2);
                case 0x1f: return (byte)(result | 3);
                case 0x27: return (byte)(result | 4);
                case 0x3e: return (byte)(result | 5);
                case 0x7e: return (byte)(result | 6);
                case 0x15: return (byte)(result | 7);
                case 0x7f: return (byte)(result | 8);
                case 0x3f: return (byte)(result | 9);
                case 0x68: throw new ArgumentOutOfRangeException();
                default: throw new FormatException();
            }
        }

        void ParseNumber(UT60EDataBase data)
        {
            bool negative = false;
            byte scale = 0;
            byte[] digits = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                digits[i] = ParseDigit(((int)offset.DIG4_OFFSET) - (i << 1)); //need to check for 10
                if ((digits[i] & 0x80) != 0) //flag negative and decimal places
                {
                    if (i == 0)
                        negative = true;
                    else
                        scale = (byte)i;
                    digits[i] &= 0x7F; //rid of first bit
                }
            }
            data.value = ConvertDigitsToInteger(digits);
            if (negative)
                data.value = -Math.Abs(data.value);
            data.scale = scale;
        }

        int ConvertDigitsToInteger(byte[] digits)
        {
            int result = 0;
            for (int i = 0; i < 4; ++i)
            {
                result += digits[i] * (int)Math.Pow(10, i);
            }
            return result;
        }

        UT60EDataBase Parse()
        {
            UT60EDataBase data;
            if ((readBuffer[(int)offset.NIB_C_OFFSET] & UT60EDefinition.NIB_C_FARAD) != 0)
                data = new UT60ETemperatrue(0);
            else if ((readBuffer[(int)offset.NIB_C_OFFSET] & UT60EDefinition.NIB_C_OHM) != 0)
                data = new UT60EResistance();
            else if ((readBuffer[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_AMP) != 0)
                data = new UT60ECurrent();
            else if ((readBuffer[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_VOLT) != 0)
                data = new UT60EVoltage();
            else if ((readBuffer[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_HERTZ) != 0)
                data = new UT60EFrequnecy();
            else if ((readBuffer[(int)offset.NIB_E_OFFSET] & UT60EDefinition.NIB_E_CELCIUS) != 0)
                data = new UT60ETemperatrue(1);
            else
                throw new FormatException();

            ParseNumber(data);

            if ((readBuffer[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_NANO) != 0)
                data.scale += 9;
            else if ((readBuffer[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_MICRO) != 0)
                data.scale += 6;
            else if ((readBuffer[(int)offset.NIB_B_OFFSET] & UT60EDefinition.NIB_B_MILLI) != 0)
                data.scale += 3;
            else if ((readBuffer[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_KILO) != 0)
                data.scale -= 3;
            else if ((readBuffer[(int)offset.NIB_B_OFFSET] & UT60EDefinition.NIB_B_MEGA) != 0)
                data.scale -= 6;
            return data;
        }

        void ClearBuffer()
        {
            readBuffer = new byte[14];
        }

        void DataReady(byte[] buf, int lastIndex)
        {
            UT60EDataBase data = null;
            try
            {
                data = Parse();
            }
            catch
            {
                Read2Buffer(lastIndex + 1, 0, buf);
            }
            finally
            {
                if (dataReadyEventHandler != null)
                    dataReadyEventHandler.BeginInvoke(data, null, null, null);
                Read2Buffer(lastIndex + 1, 0, buf); //recursively process remaining bytes
            }
        }
    }
}
