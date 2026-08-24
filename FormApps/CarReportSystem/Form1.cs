using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのオブジェクトを生成
        Settings settings = new Settings();


        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //設定ファイルを読み込み背景色を設定する（逆シリアル化）
            //P286以降を参考にする（ファイル名:setting.xml)

            //ファイルが存在するか？
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        //背景色設定
                        BackColor = Color.FromArgb(settings.MainFormBackColor);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//←より具体的なエラーを出力
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty; //メッセージ領域のクリア
            //if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text))
            if (cbAuthor.Text == String.Empty || cbCarName.Text == String.Empty) {
                tsslbMessage.Text = "記録者、または社名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text.Trim(),
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            //入力履歴を登録
            SetCbAuthor(cbAuthor.Text);
            SetCbCarName(cbCarName.Text);

            dgvRecords.ClearSelection(); //セルの選択を解除する
            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;

            return MakerGroup.その他;
        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemsAllClear();

        }
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = String.Empty;
            rbOther.Checked = true;
            cbCarName.Text = String.Empty;
            tbReport.Text = String.Empty;
            pbPicture.Image = null;

            dgvRecords.ClearSelection(); //セルの選択を解除する
        }

        private void SetRaidButtonMaker(MakerGroup targetMaker) {

            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }
        //記録者の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbAuthor(string author) {
            //未登録なら登録
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //車名の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null)
                || (!dgvRecords.CurrentRow.Selected)) return;

            //選択されているインデックスを取得
            //削除したいインデックスを指定してリストから削除
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);

            //InputItemsAllClear();
        }

        //データグリッドビューを更新したら呼ぶメソッド
        private void InputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {

            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            if (String.IsNullOrWhiteSpace(cbAuthor.Text)
                || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または社名が未入力です";
            }

            //カーレポート管理用リストの該当する要素のデータを書き換える
            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbAuthor(cbCarName.Text.Trim());

            dgvRecords.Refresh();  //データグリッドビューの更新
            tsslbMessage.Text = "レポートを修正しました";
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRaidButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate();//データグリッドビューを更新したら呼ぶメソッド
        }

        private void 終了ToolStripMenuItem1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            //cdColor = new ColorDialog();
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //Color selectedColor = cdColor.Color;
                BackColor = cdColor.Color;
                //変更された色の情報を保存
                settings.MainFormBackColor = cdColor.Color.ToArgb();
            }
        }

        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルジェ色情報を保存する処理(シリアル化)
            //p284以降を参考にする(ファイル名:setting.xml)

            using (var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        //ファイルサーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName,
                        FileMode.Create
                        )) {
                        bf.Serialize(fs,listCarReports);

                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);

                }
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {

        }

    }
}