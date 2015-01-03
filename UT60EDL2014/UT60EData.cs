using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT60EDL2014
{
    public interface IUT60EData : ITimedObject
    {
        int Value { get; }
        int Scale { get; }
        int Unit { get; }
    }

    abstract class UT60EData : IUT60EData
    {
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }
        public int Value
        {
            get
            {
                return this.value;
            }
        }
        public int Scale
        {
            get
            {
                return this.scale;
            }
        }
        public abstract int Unit { get; }
        readonly DateTime time;
        readonly int value;
        readonly int scale;
        public UT60EData(DateTime time, int value, int scale)
        {
            this.time = time;
            this.value = value;
            this.scale = scale;
        }
        public override string ToString()
        {
            int scale = this.scale;
            int unit = 0;
            while (scale > 0)
            {
                unit += 1;
                scale -= 3;
            }
            while (scale < -3)
            {
                unit -= 1;
                scale += 3;
            }
            Decimal actualValue = new Decimal(this.value * Math.Pow(10, scale));
            StringBuilder temp = new StringBuilder();
            StringBuilder fmt = new StringBuilder();
            for (int i = 0; i < (4 + scale); ++i)
                fmt.Append("0");
            if (scale != 0)
            {
                fmt.Append(".");
                for (int i = 0; i < Math.Abs(scale); ++i)
                    fmt.Append("0");
            }
            temp.Append(actualValue.ToString(fmt.ToString()));
            if (Enum.IsDefined(typeof(Modifier), unit))
                temp.Append(((Modifier)unit).ToString());
            temp.Append(((log_units)Unit).ToString());
            return temp.ToString();
        }
    }
    class UT60ETemperatrueF : UT60EData
    {
        public UT60ETemperatrueF(DateTime time, int value, int scale)
            : base(time, value, scale)
        {
        }
        public override int Unit
        {
            get
            {
                return 3;
            }
        }
    }
    class UT60ETemperatrueC : UT60EData
    {
        public UT60ETemperatrueC(DateTime time, int value, int scale)
            : base(time, value, scale)
        {
        }
        public override int Unit
        {
            get
            {
                return 2;
            }
        }
    }
    class UT60ECurrent : UT60EData
    {
        public UT60ECurrent(DateTime time, int value, int scale)
            : base(time, value, scale)
        {

        }
        public override int Unit
        {
            get
            {
                return 1;
            }
        }
    }
    class UT60EResistance : UT60EData
    {
        public UT60EResistance(DateTime time, int value, int scale)
            : base(time, value, scale)
        {
        }
        public override int Unit
        {
            get
            {
                return 4;
            }
        }
    }
    class UT60EVoltage : UT60EData
    {
        public UT60EVoltage(DateTime time, int value, int scale)
            : base(time, value, scale)
        {
        }
        public override int Unit
        {
            get
            {
                return 0;
            }
        }
    }
    class UT60EFrequnecy : UT60EData
    {
        public UT60EFrequnecy(DateTime time, int value, int scale)
            : base(time, value, scale)
        {
        }
        public override int Unit
        {
            get
            {
                return 5;
            }
        }
    }
}
