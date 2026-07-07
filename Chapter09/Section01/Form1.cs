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
            DateTime birth = dtpBirth.Value;   //生まれた日付
            DateTime today = DateTime.Today;  //今日の日付
            
            //int age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}
            tbOut.Text = $"あなたは{GetAge(birth, today)}歳です";

            TimeSpan diff = today.Date - birth.Date;
            tbOut2.Text = $"生まれてから{diff.Days.ToString()}日目です";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);
            tbOut3.Text = $"生まれた{birth.Month}月{birth.Day}日は第{NthWeek(birth)}週の{dayOfWeek}です";
        }

        //年齢を求めるメソッド
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }
    }
}



