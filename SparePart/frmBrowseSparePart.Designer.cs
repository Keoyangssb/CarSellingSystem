namespace CarSellingSystem.SparePart
{
    partial class frmBrowseSparePart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.col_spp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_spp_sell_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_spp_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_spp_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_cur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_cur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSppSellType = new System.Windows.Forms.ComboBox();
            this.cboSppType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_data, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1717, 655);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.AllowUserToResizeRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_spp_id,
            this.col_spp_sell_type,
            this.col_spp_type,
            this.col_spp_name,
            this.col_buy_price,
            this.col_buy_cur,
            this.col_sell_price,
            this.col_sell_cur,
            this.col_select});
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(3, 99);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowTemplate.Height = 30;
            this.dgv_data.Size = new System.Drawing.Size(1711, 553);
            this.dgv_data.TabIndex = 27;
            this.dgv_data.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseUp);
            // 
            // col_spp_id
            // 
            this.col_spp_id.HeaderText = "sppId";
            this.col_spp_id.Name = "col_spp_id";
            this.col_spp_id.ReadOnly = true;
            this.col_spp_id.Visible = false;
            // 
            // col_spp_sell_type
            // 
            this.col_spp_sell_type.HeaderText = "ປະເພດຂາຍ";
            this.col_spp_sell_type.Name = "col_spp_sell_type";
            this.col_spp_sell_type.ReadOnly = true;
            this.col_spp_sell_type.Width = 150;
            // 
            // col_spp_type
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_spp_type.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_spp_type.HeaderText = "ປະເພດອາໄຫຼ່";
            this.col_spp_type.Name = "col_spp_type";
            this.col_spp_type.ReadOnly = true;
            this.col_spp_type.Width = 150;
            // 
            // col_spp_name
            // 
            this.col_spp_name.HeaderText = "ຊື່ອາໄຫຼ່";
            this.col_spp_name.Name = "col_spp_name";
            this.col_spp_name.ReadOnly = true;
            this.col_spp_name.Width = 250;
            // 
            // col_buy_price
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_buy_price.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_buy_price.HeaderText = "ລາຄາຊື້";
            this.col_buy_price.Name = "col_buy_price";
            this.col_buy_price.ReadOnly = true;
            // 
            // col_buy_cur
            // 
            this.col_buy_cur.HeaderText = "ສະກຸນເງິນ";
            this.col_buy_cur.Name = "col_buy_cur";
            this.col_buy_cur.ReadOnly = true;
            // 
            // col_sell_price
            // 
            this.col_sell_price.HeaderText = "ລາຄາຂາຍ";
            this.col_sell_price.Name = "col_sell_price";
            this.col_sell_price.ReadOnly = true;
            // 
            // col_sell_cur
            // 
            this.col_sell_cur.HeaderText = "ສະກຸນເງິນ";
            this.col_sell_cur.Name = "col_sell_cur";
            this.col_sell_cur.ReadOnly = true;
            // 
            // col_select
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SpringGreen;
            this.col_select.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col_select.HeaderText = "ເລືອກ";
            this.col_select.Name = "col_select";
            this.col_select.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboSppSellType);
            this.groupBox1.Controls.Add(this.cboSppType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1711, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ເລືອກຂໍ້ມູນຄົ້ນຫາ...";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(827, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 29);
            this.label10.TabIndex = 63;
            this.label10.Text = "ຊື່ອາໄຫຼ່";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(902, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(346, 37);
            this.txtName.TabIndex = 62;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1257, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 47);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "ປະເພດຂາຍ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(391, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "ປະເພດອາໄຫຼ່";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSppSellType
            // 
            this.cboSppSellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSppSellType.FormattingEnabled = true;
            this.cboSppSellType.Location = new System.Drawing.Point(108, 36);
            this.cboSppSellType.Name = "cboSppSellType";
            this.cboSppSellType.Size = new System.Drawing.Size(277, 37);
            this.cboSppSellType.TabIndex = 58;
            // 
            // cboSppType
            // 
            this.cboSppType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSppType.FormattingEnabled = true;
            this.cboSppType.Location = new System.Drawing.Point(495, 36);
            this.cboSppType.Name = "cboSppType";
            this.cboSppType.Size = new System.Drawing.Size(326, 37);
            this.cboSppType.TabIndex = 59;
            // 
            // frmBrowseSparePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 655);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBrowseSparePart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse Spare Part";
            this.Load += new System.EventHandler(this.frmBrowseSparePart_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSppSellType;
        private System.Windows.Forms.ComboBox cboSppType;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_spp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_spp_sell_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_spp_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_spp_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_cur;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_cur;
        private System.Windows.Forms.DataGridViewButtonColumn col_select;
    }
}