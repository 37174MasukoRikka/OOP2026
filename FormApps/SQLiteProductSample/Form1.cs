using System.ComponentModel;

namespace SQLiteProductSample;

public partial class Form1 : Form
{
    // DataGridViewへ表示する商品の一覧
    private readonly BindingList<Product> _products = new();
    // DB操作を担当するRepository
    private readonly ProductRepository _repository = new();

    public Form1()
    {
        InitializeComponent();

        //ProductsクラスのプロパティからDataGridView列を自動生成する
        dgvProducts.AutoGenerateColumns = true;
        //DataGridViewの元データとしてBindingListを設定する
        dgvProducts.DataSource = _products;
        //起動直後にDBから商品一覧を読み込む
        ReloadProducts();

        //使用中のDBファイルの場所をステータスバーへ表示する
        tsslMessage.Text = $"DB: {Database.FilePath}";
    }

    private void btAdd_Click(object sender, EventArgs e)
    {
     
    }

    private void btUpdate_Click(object sender, EventArgs e)
    {
     
    }

    private void btDelete_Click(object sender, EventArgs e)
    {
       
    }

    private void btClear_Click(object sender, EventArgs e)
    {
       
    }

    private void dgvProducts_SelectionChanged(object sender, EventArgs e)
    {
       
    }

    private void ReloadProducts()
    {
        _products.Clear();
        foreach (var product in _repository.GetAll()) {
            _products.Add(product);
        }
        dgvProducts.ClearSelection();
    }

    private bool TryGetInput(out string name, out int price)
    {
        name = tbName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            price = 0;
            tsslMessage.Text = "商品名を入力してください。";
            tbName.Focus();
            return false;
        }

        if (!int.TryParse(tbPrice.Text, out price) || price < 0)
        {
            tsslMessage.Text = "価格は0以上の整数で入力してください。";
            tbPrice.Focus();
            tbPrice.SelectAll();
            return false;
        }

        return true;
    }

    private void ClearInput()
    {
        tbName.Clear();
        tbPrice.Clear();
        tbName.Focus();
    }

    private void ShowError(string title, Exception ex)
    {
        tsslMessage.Text = title;
        MessageBox.Show(
            ex.Message,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
