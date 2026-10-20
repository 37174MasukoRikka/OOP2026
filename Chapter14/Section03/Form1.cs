using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            //Thread.Sleep(5000);
            //MessageBox.Show("Š®—¹");

            //await Task.Delay(5000);
            //MessageBox.Show("Š®—¹");

            var elasped = await DoLongTimeWork(5000);
            MessageBox.Show(elasped + "ƒ~ƒŠ•b");
        }
        //–ß‚è’l‚È‚µ
        private async Task DoLongTimeWork() {
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
        }
        //–ß‚è’l‚ ‚è
        private async Task<long> DoLongTimeWork(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
