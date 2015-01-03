using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT60EDL2014
{
    /// <summary>
    /// Functor to parse data from UT60E.
    /// </summary>
    class UT60EDataParser : IParseable<IUT60EData>
    {
        enum offset { NIB_1_OFFSET, DIG1_OFFSET, DIG2_OFFSET = 3, DIG3_OFFSET = 5, DIG4_OFFSET = 7, NIB_A_OFFSET = 9, NIB_B_OFFSET, NIB_C_OFFSET, NIB_D_OFFSET, NIB_E_OFFSET };
        static class UT60EDefinition
        {
            public const byte NIB_E_UNKNOWN = 0xe;
            public const byte NIB_E_CELCIUS = 0x1;
            public const byte NIB_D_HERTZ = 0x2;
            public const byte NIB_D_VOLT = 0x4;
            public const byte NIB_D_AMP = 0x8;
            public const byte NIB_C_DELTA = 0x2;
            public const byte NIB_C_OHM = 0x4;
            public const byte NIB_C_FARAD = 0x8;
            public const byte NIB_B_PERCENT = 0x4;
            public const byte NIB_A_KILO = 0x2;
            public const byte NIB_A_NANO = 0x4;
            public const byte NIB_A_MICRO = 0x8;
            public const byte NIB_B_MEGA = 0x2;
            public const byte NIB_B_MILLI = 0x8;
        }
        UT60EPacket package;
        int value, scale;
        public UT60EDataParser(UT60EPacket package)
        {
            this.package = package;
        }
        byte ParseDigit(int d_offset)
        {
            byte result = 0;
            byte fix = (byte)((package.Data[d_offset] << 4) | (package.Data[d_offset + 1] & 0xF));
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
        void ParseNumber()
        {
            bool negative = false;
            byte[] digits = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                digits[i] = ParseDigit(((int)offset.DIG4_OFFSET) - (i << 1)); //need to check for 10
                if ((digits[i] & 0x80) != 0) //flag negative and decimal places
                {
                    if (i == 3)
                        negative = true;
                    else
                        scale = -(i + 1);
                    digits[i] &= 0x7F; //rid of first bit
                }
            }
            value = ConvertDigitsToInteger(digits);
            if (negative)
                value = -Math.Abs(value);

            if ((package.Data[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_NANO) != 0)
                scale -= 9;
            else if ((package.Data[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_MICRO) != 0)
                scale -= 6;
            else if ((package.Data[(int)offset.NIB_B_OFFSET] & UT60EDefinition.NIB_B_MILLI) != 0)
                scale -= 3;
            else if ((package.Data[(int)offset.NIB_A_OFFSET] & UT60EDefinition.NIB_A_KILO) != 0)
                scale += 3;
            else if ((package.Data[(int)offset.NIB_B_OFFSET] & UT60EDefinition.NIB_B_MEGA) != 0)
                scale += 6;
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
        public IUT60EData Parse()
        {
            ParseNumber();
            IUT60EData data;
            if ((package.Data[(int)offset.NIB_C_OFFSET] & UT60EDefinition.NIB_C_FARAD) != 0)
                data = new UT60ETemperatrueF(package.Time, value, scale);
            else if ((package.Data[(int)offset.NIB_C_OFFSET] & UT60EDefinition.NIB_C_OHM) != 0)
                data = new UT60EResistance(package.Time, value, scale);
            else if ((package.Data[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_AMP) != 0)
                data = new UT60ECurrent(package.Time, value, scale);
            else if ((package.Data[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_VOLT) != 0)
                data = new UT60EVoltage(package.Time, value, scale);
            else if ((package.Data[(int)offset.NIB_D_OFFSET] & UT60EDefinition.NIB_D_HERTZ) != 0)
                data = new UT60EFrequnecy(package.Time, value, scale);
            else if ((package.Data[(int)offset.NIB_E_OFFSET] & UT60EDefinition.NIB_E_CELCIUS) != 0)
                data = new UT60ETemperatrueC(package.Time, value, scale);
            else
                throw new FormatException();
            return data;
        }
    }
}
