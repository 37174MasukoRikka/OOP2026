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
