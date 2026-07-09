using System.Globalization;


namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            //p200
            tbOut1.Text = dateTime.ToString("yyyy/MM/dd HH:mm");
        }

        private void btButton2_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            tbOut2.Text = dateTime.ToString("yyyy”NMMŒdd“ú@HHmm•ªdd•b");
        }

        private void btButton3_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            
            tbOut3.Text =  dateTime.ToString("gg y”N MŒ d“ú(dddd)",culture);
        }
    }
}
