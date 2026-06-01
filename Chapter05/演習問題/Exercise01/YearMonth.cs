using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        private int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }
        //5.1.2
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            if (Month == 12) {
                var y1 = new YearMonth(Year + 1, 1);
                return y1;
            } else {
                var y2 = new YearMonth(Year, Month + 1);
                return y2;
            }
        }

        //5.1.4
        //public override string ToString() =>
 }
}
