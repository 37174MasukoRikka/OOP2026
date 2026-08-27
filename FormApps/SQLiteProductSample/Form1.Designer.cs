namespace SQLiteProductSample;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblTitle = null!;
    private Label lblName = null!;
    private Label lblPrice = null!;
    private TextBox tbName = null!;
    private TextBox tbPrice = null!;
    private Button btAdd = null!;
    private Button btUpdate = null!;
    private Button btDelete = null!;
    private Button btClear = null!;
    private DataGridView dgvProducts = null!;
    private StatusStrip statusStrip1 = null!;
    private ToolStripStatusLabel tsslMessage = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblName = new Label();
        lblPrice = new Label();
        tbName = new TextBox();
        tbPrice = new TextBox();
        btAdd = new Button();
        btUpdate = new Button();
        btDelete = new Button();
        btClear = new Button();
        dgvProducts = new DataGridView();
        statusStrip1 = new StatusStrip();
        tsslMessage = new ToolStripStatusLabel();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(24, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(235, 32);
        lblTitle.Text = "SQLite 商品管理サンプル";

        lblName.AutoSize = true;
        lblName.Location = new Point(28, 77);
        lblName.Name = "lblName";
        lblName.Size = new Size(55, 15);
        lblName.Text = "商品名";

        tbName.Location = new Point(95, 73);
        tbName.Name = "tbName";
        tbName.Size = new Size(236, 23);

        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(365, 77);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(31, 15);
        lblPrice.Text = "価格";

        tbPrice.Location = new Point(410, 73);
        tbPrice.Name = "tbPrice";
        tbPrice.Size = new Size(130, 23);
        tbPrice.TextAlign = HorizontalAlignment.Right;

        btAdd.Location = new Point(28, 116);
        btAdd.Name = "btAdd";
        btAdd.Size = new Size(105, 36);
        btAdd.Text = "登録";
        btAdd.UseVisualStyleBackColor = true;
        btAdd.Click += btAdd_Click;

        btUpdate.Location = new Point(145, 116);
        btUpdate.Name = "btUpdate";
        btUpdate.Size = new Size(105, 36);
        btUpdate.Text = "修正";
        btUpdate.UseVisualStyleBackColor = true;
        btUpdate.Click += btUpdate_Click;

        btDelete.Location = new Point(262, 116);
        btDelete.Name = "btDelete";
        btDelete.Size = new Size(105, 36);
        btDelete.Text = "削除";
        btDelete.UseVisualStyleBackColor = true;
        btDelete.Click += btDelete_Click;

        btClear.Location = new Point(379, 116);
        btClear.Name = "btClear";
        btClear.Size = new Size(105, 36);
        btClear.Text = "新規入力";
        btClear.UseVisualStyleBackColor = true;
        btClear.Click += btClear_Click;

        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Location = new Point(28, 174);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(648, 287);
        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

        statusStrip1.Items.AddRange(new ToolStripItem[] { tsslMessage });
        statusStrip1.Location = new Point(0, 481);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(704, 22);

        tsslMessage.Name = "tsslMessage";
        tsslMessage.Size = new Size(0, 17);

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(704, 503);
        Controls.Add(dgvProducts);
        Controls.Add(btClear);
        Controls.Add(btDelete);
        Controls.Add(btUpdate);
        Controls.Add(btAdd);
        Controls.Add(tbPrice);
        Controls.Add(lblPrice);
        Controls.Add(tbName);
        Controls.Add(lblName);
        Controls.Add(lblTitle);
        Controls.Add(statusStrip1);
        MinimumSize = new Size(720, 542);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SQLite 商品管理サンプル";
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
