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
        int unitSetting;
        readonly string[] Units = { "F", "C" };
        protected virtual string[] units { get { return Units; } }
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
