using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value.Date;   //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today;  //ç°ì˙ÇÃì˙ït

            //int age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}
            tbOut.Text = $"Ç†Ç»ÇΩÇÕ{GetAge(birth, today)}çŒÇ≈Ç∑";

            TimeSpan diff = today.Date - birth.Date;
            tbOut2.Text = $"ê∂Ç‹ÇÍÇƒÇ©ÇÁ{diff.Days.ToString()}ì˙ñ⁄Ç≈Ç∑";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);
            tbOut3.Text = $"ê∂Ç‹ÇÍÇΩ{birth.Month}åé{birth.Day}ì˙ÇÕëÊ{NthWeek(birth)}èTÇÃ{dayOfWeek}Ç≈Ç∑";

            //ç°îNÇÃíaê∂ì˙ÇçÏê¨Ç∑ÇÈ
            DateTime thisYearBirthday = new DateTime(today.Year, birth.Month, birth.Day);
            //ä˘Ç…íaê∂ì˙Ç™âﬂÇ¨ÇΩÇ©
            if (thisYearBirthday < today) {
                //óàîNÇÃíaê∂ì˙Çî‰ärÇ∑ÇÈ
                thisYearBirthday = thisYearBirthday.AddYears(1);
            }
            var span = thisYearBirthday - today;

            if (span.Days == 0) {
                tbOut4.Text = "íaê∂ì˙ÇÕç°ì˙Ç≈Ç∑";
            } else {
                tbOut4.Text = $"íaê∂ì˙Ç‹Ç≈Ç†Ç∆{span.Days}ì˙Ç≈Ç∑";
            }
        }

        //îNóÓÇãÅÇﬂÇÈÉÅÉ\ÉbÉh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        //éwíËÇµÇΩì˙Ç™ëÊâΩèTÇ©ãÅÇﬂÇÈ
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }
    }
}





