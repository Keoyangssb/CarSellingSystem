namespace CarSellingSystem.Stocks
{
    partial class bfrmCheckSPPBalance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtName_filter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSellType_filter = new System.Windows.Forms.ComboBox();
            this.cboType_filter = new System.Windows.Forms.ComboBox();
            this.col_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currency_buy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currency_sell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_balance_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvData, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1555, 656);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_item_id,
            this.col_sell_type,
            this.col_type,
            this.col_name,
            this.col_buy_price,
            this.col_currency_buy,
            this.col_sell_price,
            this.col_currency_sell,
            this.col_balance_qty,
            this.col_unit});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 84);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.Size = new System.Drawing.Size(1549, 569);
            this.dgvData.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.txtName_filter);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboSellType_filter);
            this.groupBox2.Controls.Add(this.cboType_filter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1549, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ຄົ້ນຫາ...";
            // 
            // txtName_filter
            // 
            this.txtName_filter.Location = new System.Drawing.Point(590, 29);
            this.txtName_filter.Name = "txtName_filter";
            this.txtName_filter.Size = new System.Drawing.Size(184, 37);
            this.txtName_filter.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(785, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 47);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(5, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 29);
            this.label10.TabIndex = 44;
            this.label10.Text = "ປະເພດຂາຍ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(257, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 29);
            this.label11.TabIndex = 45;
            this.label11.Text = "ປະເພດອາໄຫຼ່";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(535, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 29);
            this.label12.TabIndex = 46;
            this.label12.Text = "ຊື່ອາໄຫຼ່";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSellType_filter
            // 
            this.cboSellType_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSellType_filter.FormattingEnabled = true;
            this.cboSellType_filter.Location = new System.Drawing.Point(82, 28);
            this.cboSellType_filter.Name = "cboSellType_filter";
            this.cboSellType_filter.Size = new System.Drawing.Size(170, 37);
            this.cboSellType_filter.TabIndex = 47;
            // 
            // cboType_filter
            // 
            this.cboType_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType_filter.FormattingEnabled = true;
            this.cboType_filter.Location = new System.Drawing.Point(343, 28);
            this.cboType_filter.Name = "cboType_filter";
            this.cboType_filter.Size = new System.Drawing.Size(189, 37);
            this.cboType_filter.TabIndex = 48;
            // 
            // col_item_id
            // 
            this.col_item_id.HeaderText = "item_id";
            this.col_item_id.Name = "col_item_id";
            this.col_item_id.ReadOnly = true;
            this.col_item_id.Visible = false;
            // 
            // col_sell_type
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_sell_type.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_sell_type.HeaderText = "ປະເພດຂາຍ";
            this.col_sell_type.Name = "col_sell_type";
            this.col_sell_type.ReadOnly = true;
            this.col_sell_type.Width = 150;
            // 
            // col_type
            // 
            this.col_type.HeaderText = "ປະເພດອາໄຫຼ່";
            this.col_type.Name = "col_type";
            this.col_type.ReadOnly = true;
            this.col_type.Width = 150;
            // 
            // col_name
            // 
            this.col_name.HeaderText = "ຊື່ອາໄຫຼ່";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 250;
            // 
            // col_buy_price
            // 
            this.col_buy_price.HeaderText = "ລາຄາຊື້";
            this.col_buy_price.Name = "col_buy_price";
            this.col_buy_price.ReadOnly = true;
            // 
            // col_currency_buy
            // 
            this.col_currency_buy.HeaderText = "ສະກຸນເງິນຊື້";
            this.col_currency_buy.Name = "col_currency_buy";
            this.col_currency_buy.ReadOnly = true;
            // 
            // col_sell_price
            // 
            this.col_sell_price.HeaderText = "ລາຄາຂາຍ";
            this.col_sell_price.Name = "col_sell_price";
            this.col_sell_price.ReadOnly = true;
            // 
            // col_currency_sell
            // 
            this.col_currency_sell.HeaderText = "ສະກຸນເງິນຂາຍ";
            this.col_currency_sell.Name = "col_currency_sell";
            this.col_currency_sell.ReadOnly = true;
            // 
            // col_balance_qty
            // 
            this.col_balance_qty.HeaderText = "ຈຳນວນຍັງເຫຼືອ";
            this.col_balance_qty.Name = "col_balance_qty";
            this.col_balance_qty.ReadOnly = true;
            this.col_balance_qty.Width = 120;
            // 
            // col_unit
            // 
            this.col_unit.HeaderText = "ຫົວໜ່ວຍ";
            this.col_unit.Name = "col_unit";
            this.col_unit.ReadOnly = true;
            this.col_unit.Width = 80;
            // 
            // bfrmCheckSPPBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 656);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "bfrmCheckSPPBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bfrmCheckSPPBalance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.bfrmCheckSPPBalance_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtName_filter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSellType_filter;
        private System.Windows.Forms.ComboBox cboType_filter;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currency_buy;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currency_sell;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_balance_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit;
    }
}