using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHEATCK.Forms.Utilities
{
    class BetForcast
    {
        public string Match { get; set; }
        public double OverOdd { get; set; }
        public double UnderOdd { get; set; }
        public double PercentageStake1 { get; set; }
        public double PercentageStake2 { get; set; }
        public double Gain { get; set; }

        public static BetForcast GetForcast(string m, double overOdd, double underOdd)
        {
            var ps1 = 0.0;
            var ps2 = 0.0;
            var g = 0.0;

            Calculator.getStake(overOdd, underOdd, out ps1, out ps2, out g);

            var rtn = new BetForcast()
            {
                Gain = g,
                Match=m,
                OverOdd= overOdd,
                UnderOdd = underOdd,
                PercentageStake1 = ps1,
                PercentageStake2=ps2,
            };

            return rtn;
        }
        

    }
}
