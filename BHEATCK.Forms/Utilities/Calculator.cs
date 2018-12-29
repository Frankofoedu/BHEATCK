using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHEATCK.Forms.Utilities
{
    class Calculator
    {
        public static void getStake(double odds1, double odds2, out double PercentageStake1, out double PercentageStake2, out double gain)
        {
            var totalOdd = odds1 + odds2;
            PercentageStake1 = (1.0 / totalOdd * odds2) * 100.0;
            PercentageStake2 = (1.0 / totalOdd * odds1) * 100.0;

            gain = (odds1 * PercentageStake1) - 100.0;
        }
    }
}
