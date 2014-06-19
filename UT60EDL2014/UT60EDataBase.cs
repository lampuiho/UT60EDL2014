using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT60EDL2014
{
    abstract class UT60EDataBase
    {
        public DateTime time { get; set; }
        public int scale { get; set; }
        public int value { get; set; }
        public abstract string getUnit();
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
            temp.Append(getUnit());
            return temp.ToString();
        }
    }

    abstract class UT60EDataMUnits : UT60EDataBase
    {
        int unitSetting;
        protected virtual string[] units { get { return null; } }
        public UT60EDataMUnits(int unitSetting)
        {
            this.unitSetting = unitSetting;
        }
        public override string getUnit()
        {
            return units[unitSetting];
        }
    }

    class UT60ETemperatrue : UT60EDataMUnits
    {
        readonly string[] Units = { "F", "C" };
        protected override string[] units { get { return Units; } }
        public UT60ETemperatrue(int unitSetting)
            : base(unitSetting)
        {
        }
    }
    class UT60ECurrent : UT60EDataBase
    {
        public override string getUnit()
        {
            return "A";
        }
    }
    class UT60EResistance : UT60EDataBase
    {
        public override string getUnit()
        {
            return "Ohm";
        }
    }
    class UT60EVoltage : UT60EDataBase
    {
        public override string getUnit()
        {
            return "V";
        }
    }
    class UT60EFrequnecy : UT60EDataBase
    {
        public override string getUnit()
        {
            return "Hz";
        }
    }
}
