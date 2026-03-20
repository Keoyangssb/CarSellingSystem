namespace CarSellingSystem.BuyCar
{
    partial class frmBuyCarPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.col_pay_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_payer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dt_paid = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCurrency_pay_kota = new System.Windows.Forms.ComboBox();
            this.cboCurrency_pay_fee = new System.Windows.Forms.ComboBox();
            this.cboCurrency_pay_car = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTotalKota_payType = new System.Windows.Forms.ComboBox();
            this.cboTotalFee_payType = new System.Windows.Forms.ComboBox();
            this.cboTotalBuy_payType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTotalKota_payer = new System.Windows.Forms.ComboBox();
            this.cboTotalFee_payer = new System.Windows.Forms.ComboBox();
            this.cboTotalBuy_payer = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalKota_balance = new System.Windows.Forms.TextBox();
            this.txtTotalFee_balance = new System.Windows.Forms.TextBox();
            this.txtTotalBuy_balance = new System.Windows.Forms.TextBox();
            this.txtTotalKota_paid = new System.Windows.Forms.TextBox();
            this.txtTotalFee_paid = new System.Windows.Forms.TextBox();
            this.txtTotalBuy_paid = new System.Windows.Forms.TextBox();
            this.txtTotalKota_paying = new System.Windows.Forms.TextBox();
            this.txtTotalFee_paying = new System.Windows.Forms.TextBox();
            this.txtTotalBuy_paying = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalKota = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalFee = new System.Windows.Forms.TextBox();
            this.txtTotalBuy = new System.Windows.Forms.TextBox();
            this.cboCurrency_pay_tax = new System.Windows.Forms.ComboBox();
            this.cboTotalTax_payType = new System.Windows.Forms.ComboBox();
            this.cboTotalTax_payer = new System.Windows.Forms.ComboBox();
            this.txtTotalTax_balance = new System.Windows.Forms.TextBox();
            this.txtTotalTax_paid = new System.Windows.Forms.TextBox();
            this.txtTotalTax_paying = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalTax = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 288F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1355, 799);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvData);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(3, 291);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1349, 505);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemExpandedBackground;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionText;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "ປະຫວັດການຊຳລະເງິນ";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_pay_id,
            this.col_item_no,
            this.col_pay_date,
            this.col_pay_des,
            this.col_pay_amount,
            this.col_currency,
            this.col_pay_type_name,
            this.col_payer,
            this.col_user,
            this.col_item_del});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.Size = new System.Drawing.Size(1343, 473);
            this.dgvData.TabIndex = 25;
            this.dgvData.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseUp);
            // 
            // col_pay_id
            // 
            this.col_pay_id.HeaderText = "save_item_id";
            this.col_pay_id.Name = "col_pay_id";
            this.col_pay_id.Visible = false;
            // 
            // col_item_no
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_item_no.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_item_no.HeaderText = "ລ/ດ";
            this.col_item_no.Name = "col_item_no";
            this.col_item_no.Width = 50;
            // 
            // col_pay_date
            // 
            this.col_pay_date.HeaderText = "ວັນທີ່ຊຳລະ";
            this.col_pay_date.Name = "col_pay_date";
            this.col_pay_date.Width = 200;
            // 
            // col_pay_des
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_pay_des.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_pay_des.HeaderText = "ລາຍການຊຳລະ";
            this.col_pay_des.Name = "col_pay_des";
            this.col_pay_des.Width = 150;
            // 
            // col_pay_amount
            // 
            this.col_pay_amount.HeaderText = "ຈຳນວນເງິນຊຳລະ";
            this.col_pay_amount.Name = "col_pay_amount";
            this.col_pay_amount.Width = 120;
            // 
            // col_currency
            // 
            this.col_currency.HeaderText = "ສະກຸນເງິນ";
            this.col_currency.Name = "col_currency";
            // 
            // col_pay_type_name
            // 
            this.col_pay_type_name.HeaderText = "ຮູບແບບຊຳລະ";
            this.col_pay_type_name.Name = "col_pay_type_name";
            this.col_pay_type_name.Width = 120;
            // 
            // col_payer
            // 
            this.col_payer.HeaderText = "ຜູ້ຊຳລະເງິນ";
            this.col_payer.Name = "col_payer";
            this.col_payer.Width = 200;
            // 
            // col_user
            // 
            this.col_user.HeaderText = "ຢູເຊີ";
            this.col_user.Name = "col_user";
            this.col_user.Width = 200;
            // 
            // col_item_del
            // 
            this.col_item_del.HeaderText = "ລົບອອກ";
            this.col_item_del.Name = "col_item_del";
            this.col_item_del.Width = 72;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboCurrency_pay_tax);
            this.groupPanel1.Controls.Add(this.cboTotalTax_payType);
            this.groupPanel1.Controls.Add(this.cboTotalTax_payer);
            this.groupPanel1.Controls.Add(this.txtTotalTax_balance);
            this.groupPanel1.Controls.Add(this.txtTotalTax_paid);
            this.groupPanel1.Controls.Add(this.txtTotalTax_paying);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.txtTotalTax);
            this.groupPanel1.Controls.Add(this.dt_paid);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.cboCurrency_pay_kota);
            this.groupPanel1.Controls.Add(this.cboCurrency_pay_fee);
            this.groupPanel1.Controls.Add(this.cboCurrency_pay_car);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.cboTotalKota_payType);
            this.groupPanel1.Controls.Add(this.cboTotalFee_payType);
            this.groupPanel1.Controls.Add(this.cboTotalBuy_payType);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cboTotalKota_payer);
            this.groupPanel1.Controls.Add(this.cboTotalFee_payer);
            this.groupPanel1.Controls.Add(this.cboTotalBuy_payer);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.txtTotalKota_balance);
            this.groupPanel1.Controls.Add(this.txtTotalFee_balance);
            this.groupPanel1.Controls.Add(this.txtTotalBuy_balance);
            this.groupPanel1.Controls.Add(this.txtTotalKota_paid);
            this.groupPanel1.Controls.Add(this.txtTotalFee_paid);
            this.groupPanel1.Controls.Add(this.txtTotalBuy_paid);
            this.groupPanel1.Controls.Add(this.txtTotalKota_paying);
            this.groupPanel1.Controls.Add(this.txtTotalFee_paying);
            this.groupPanel1.Controls.Add(this.txtTotalBuy_paying);
            this.groupPanel1.Controls.Add(this.label18);
            this.groupPanel1.Controls.Add(this.txtTotalKota);
            this.groupPanel1.Controls.Add(this.label17);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.txtTotalFee);
            this.groupPanel1.Controls.Add(this.txtTotalBuy);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1349, 282);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "ບັນທຶກການຊຳລະເງິນ";
            // 
            // dt_paid
            // 
            this.dt_paid.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_paid.Location = new System.Drawing.Point(106, 179);
            this.dt_paid.Name = "dt_paid";
            this.dt_paid.Size = new System.Drawing.Size(150, 31);
            this.dt_paid.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(9, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 60;
            this.label8.Text = "ວັນທີ່ຈ່າຍ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(444, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 50;
            this.label6.Text = "ສະກຸນເງິນ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCurrency_pay_kota
            // 
            this.cboCurrency_pay_kota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency_pay_kota.FormattingEnabled = true;
            this.cboCurrency_pay_kota.Location = new System.Drawing.Point(444, 102);
            this.cboCurrency_pay_kota.Name = "cboCurrency_pay_kota";
            this.cboCurrency_pay_kota.Size = new System.Drawing.Size(94, 32);
            this.cboCurrency_pay_kota.TabIndex = 47;
            this.cboCurrency_pay_kota.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_pay_kota_SelectedIndexChanged);
            // 
            // cboCurrency_pay_fee
            // 
            this.cboCurrency_pay_fee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency_pay_fee.FormattingEnabled = true;
            this.cboCurrency_pay_fee.Location = new System.Drawing.Point(444, 65);
            this.cboCurrency_pay_fee.Name = "cboCurrency_pay_fee";
            this.cboCurrency_pay_fee.Size = new System.Drawing.Size(94, 32);
            this.cboCurrency_pay_fee.TabIndex = 48;
            this.cboCurrency_pay_fee.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_pay_fee_SelectedIndexChanged);
            // 
            // cboCurrency_pay_car
            // 
            this.cboCurrency_pay_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency_pay_car.Enabled = false;
            this.cboCurrency_pay_car.FormattingEnabled = true;
            this.cboCurrency_pay_car.Location = new System.Drawing.Point(444, 28);
            this.cboCurrency_pay_car.Name = "cboCurrency_pay_car";
            this.cboCurrency_pay_car.Size = new System.Drawing.Size(94, 32);
            this.cboCurrency_pay_car.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(544, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 29);
            this.label5.TabIndex = 46;
            this.label5.Text = "ເລືອກຮູບແບບຊຳລະ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTotalKota_payType
            // 
            this.cboTotalKota_payType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalKota_payType.FormattingEnabled = true;
            this.cboTotalKota_payType.Location = new System.Drawing.Point(544, 103);
            this.cboTotalKota_payType.Name = "cboTotalKota_payType";
            this.cboTotalKota_payType.Size = new System.Drawing.Size(159, 32);
            this.cboTotalKota_payType.TabIndex = 43;
            // 
            // cboTotalFee_payType
            // 
            this.cboTotalFee_payType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalFee_payType.FormattingEnabled = true;
            this.cboTotalFee_payType.Location = new System.Drawing.Point(544, 66);
            this.cboTotalFee_payType.Name = "cboTotalFee_payType";
            this.cboTotalFee_payType.Size = new System.Drawing.Size(159, 32);
            this.cboTotalFee_payType.TabIndex = 44;
            // 
            // cboTotalBuy_payType
            // 
            this.cboTotalBuy_payType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalBuy_payType.FormattingEnabled = true;
            this.cboTotalBuy_payType.Location = new System.Drawing.Point(544, 29);
            this.cboTotalBuy_payType.Name = "cboTotalBuy_payType";
            this.cboTotalBuy_payType.Size = new System.Drawing.Size(159, 32);
            this.cboTotalBuy_payType.TabIndex = 45;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1185, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 64);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "ອອກ";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(1180, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 29);
            this.label4.TabIndex = 42;
            this.label4.Text = "ເງິນທີ່ຍັງເຫຼືອ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1024, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 41;
            this.label3.Text = "ຊຳລະເງິນແລ້ວ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(709, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 29);
            this.label2.TabIndex = 40;
            this.label2.Text = "ເລືອກຜູ້ຊຳລະເງິນ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(262, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 39;
            this.label1.Text = "ປ້ອນຈຳນວນເງິນຊຳລະ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTotalKota_payer
            // 
            this.cboTotalKota_payer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalKota_payer.FormattingEnabled = true;
            this.cboTotalKota_payer.Location = new System.Drawing.Point(709, 103);
            this.cboTotalKota_payer.Name = "cboTotalKota_payer";
            this.cboTotalKota_payer.Size = new System.Drawing.Size(314, 32);
            this.cboTotalKota_payer.TabIndex = 38;
            // 
            // cboTotalFee_payer
            // 
            this.cboTotalFee_payer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalFee_payer.FormattingEnabled = true;
            this.cboTotalFee_payer.Location = new System.Drawing.Point(709, 66);
            this.cboTotalFee_payer.Name = "cboTotalFee_payer";
            this.cboTotalFee_payer.Size = new System.Drawing.Size(314, 32);
            this.cboTotalFee_payer.TabIndex = 38;
            // 
            // cboTotalBuy_payer
            // 
            this.cboTotalBuy_payer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalBuy_payer.FormattingEnabled = true;
            this.cboTotalBuy_payer.Location = new System.Drawing.Point(709, 29);
            this.cboTotalBuy_payer.Name = "cboTotalBuy_payer";
            this.cboTotalBuy_payer.Size = new System.Drawing.Size(314, 32);
            this.cboTotalBuy_payer.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1029, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 64);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ບັນທຶກ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalKota_balance
            // 
            this.txtTotalKota_balance.Location = new System.Drawing.Point(1185, 103);
            this.txtTotalKota_balance.Name = "txtTotalKota_balance";
            this.txtTotalKota_balance.ReadOnly = true;
            this.txtTotalKota_balance.Size = new System.Drawing.Size(150, 31);
            this.txtTotalKota_balance.TabIndex = 36;
            this.txtTotalKota_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalFee_balance
            // 
            this.txtTotalFee_balance.Location = new System.Drawing.Point(1185, 66);
            this.txtTotalFee_balance.Name = "txtTotalFee_balance";
            this.txtTotalFee_balance.ReadOnly = true;
            this.txtTotalFee_balance.Size = new System.Drawing.Size(150, 31);
            this.txtTotalFee_balance.TabIndex = 34;
            this.txtTotalFee_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBuy_balance
            // 
            this.txtTotalBuy_balance.Location = new System.Drawing.Point(1185, 29);
            this.txtTotalBuy_balance.Name = "txtTotalBuy_balance";
            this.txtTotalBuy_balance.ReadOnly = true;
            this.txtTotalBuy_balance.Size = new System.Drawing.Size(150, 31);
            this.txtTotalBuy_balance.TabIndex = 35;
            this.txtTotalBuy_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalKota_paid
            // 
            this.txtTotalKota_paid.Location = new System.Drawing.Point(1029, 103);
            this.txtTotalKota_paid.Name = "txtTotalKota_paid";
            this.txtTotalKota_paid.ReadOnly = true;
            this.txtTotalKota_paid.Size = new System.Drawing.Size(150, 31);
            this.txtTotalKota_paid.TabIndex = 33;
            this.txtTotalKota_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalFee_paid
            // 
            this.txtTotalFee_paid.Location = new System.Drawing.Point(1029, 66);
            this.txtTotalFee_paid.Name = "txtTotalFee_paid";
            this.txtTotalFee_paid.ReadOnly = true;
            this.txtTotalFee_paid.Size = new System.Drawing.Size(150, 31);
            this.txtTotalFee_paid.TabIndex = 31;
            this.txtTotalFee_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBuy_paid
            // 
            this.txtTotalBuy_paid.Location = new System.Drawing.Point(1029, 29);
            this.txtTotalBuy_paid.Name = "txtTotalBuy_paid";
            this.txtTotalBuy_paid.ReadOnly = true;
            this.txtTotalBuy_paid.Size = new System.Drawing.Size(150, 31);
            this.txtTotalBuy_paid.TabIndex = 32;
            this.txtTotalBuy_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalKota_paying
            // 
            this.txtTotalKota_paying.Location = new System.Drawing.Point(262, 103);
            this.txtTotalKota_paying.Name = "txtTotalKota_paying";
            this.txtTotalKota_paying.Size = new System.Drawing.Size(176, 31);
            this.txtTotalKota_paying.TabIndex = 2;
            this.txtTotalKota_paying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalKota_paying.Leave += new System.EventHandler(this.txtTotalKota_paying_Leave);
            // 
            // txtTotalFee_paying
            // 
            this.txtTotalFee_paying.Location = new System.Drawing.Point(262, 66);
            this.txtTotalFee_paying.Name = "txtTotalFee_paying";
            this.txtTotalFee_paying.Size = new System.Drawing.Size(176, 31);
            this.txtTotalFee_paying.TabIndex = 1;
            this.txtTotalFee_paying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalFee_paying.Leave += new System.EventHandler(this.txtTotalFee_paying_Leave);
            // 
            // txtTotalBuy_paying
            // 
            this.txtTotalBuy_paying.Location = new System.Drawing.Point(262, 29);
            this.txtTotalBuy_paying.Name = "txtTotalBuy_paying";
            this.txtTotalBuy_paying.Size = new System.Drawing.Size(176, 31);
            this.txtTotalBuy_paying.TabIndex = 0;
            this.txtTotalBuy_paying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalBuy_paying.Leave += new System.EventHandler(this.txtTotalBuy_paying_Leave);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(17, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 29);
            this.label18.TabIndex = 27;
            this.label18.Text = "ຄ່າໂຄຕ່າ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalKota
            // 
            this.txtTotalKota.Location = new System.Drawing.Point(106, 103);
            this.txtTotalKota.Name = "txtTotalKota";
            this.txtTotalKota.ReadOnly = true;
            this.txtTotalKota.Size = new System.Drawing.Size(150, 31);
            this.txtTotalKota.TabIndex = 26;
            this.txtTotalKota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(7, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 29);
            this.label17.TabIndex = 24;
            this.label17.Text = "ຄ່າທຳນຽນ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(26, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 29);
            this.label16.TabIndex = 25;
            this.label16.Text = "ລາຄາຊື້";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalFee
            // 
            this.txtTotalFee.Location = new System.Drawing.Point(106, 66);
            this.txtTotalFee.Name = "txtTotalFee";
            this.txtTotalFee.ReadOnly = true;
            this.txtTotalFee.Size = new System.Drawing.Size(150, 31);
            this.txtTotalFee.TabIndex = 22;
            this.txtTotalFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBuy
            // 
            this.txtTotalBuy.Location = new System.Drawing.Point(106, 29);
            this.txtTotalBuy.Name = "txtTotalBuy";
            this.txtTotalBuy.ReadOnly = true;
            this.txtTotalBuy.Size = new System.Drawing.Size(150, 31);
            this.txtTotalBuy.TabIndex = 23;
            this.txtTotalBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCurrency_pay_tax
            // 
            this.cboCurrency_pay_tax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency_pay_tax.FormattingEnabled = true;
            this.cboCurrency_pay_tax.Location = new System.Drawing.Point(444, 139);
            this.cboCurrency_pay_tax.Name = "cboCurrency_pay_tax";
            this.cboCurrency_pay_tax.Size = new System.Drawing.Size(94, 32);
            this.cboCurrency_pay_tax.TabIndex = 68;
            // 
            // cboTotalTax_payType
            // 
            this.cboTotalTax_payType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalTax_payType.FormattingEnabled = true;
            this.cboTotalTax_payType.Location = new System.Drawing.Point(544, 140);
            this.cboTotalTax_payType.Name = "cboTotalTax_payType";
            this.cboTotalTax_payType.Size = new System.Drawing.Size(159, 32);
            this.cboTotalTax_payType.TabIndex = 67;
            // 
            // cboTotalTax_payer
            // 
            this.cboTotalTax_payer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTotalTax_payer.FormattingEnabled = true;
            this.cboTotalTax_payer.Location = new System.Drawing.Point(709, 140);
            this.cboTotalTax_payer.Name = "cboTotalTax_payer";
            this.cboTotalTax_payer.Size = new System.Drawing.Size(314, 32);
            this.cboTotalTax_payer.TabIndex = 66;
            // 
            // txtTotalTax_balance
            // 
            this.txtTotalTax_balance.Location = new System.Drawing.Point(1185, 140);
            this.txtTotalTax_balance.Name = "txtTotalTax_balance";
            this.txtTotalTax_balance.ReadOnly = true;
            this.txtTotalTax_balance.Size = new System.Drawing.Size(150, 31);
            this.txtTotalTax_balance.TabIndex = 65;
            this.txtTotalTax_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalTax_paid
            // 
            this.txtTotalTax_paid.Location = new System.Drawing.Point(1029, 140);
            this.txtTotalTax_paid.Name = "txtTotalTax_paid";
            this.txtTotalTax_paid.ReadOnly = true;
            this.txtTotalTax_paid.Size = new System.Drawing.Size(150, 31);
            this.txtTotalTax_paid.TabIndex = 64;
            this.txtTotalTax_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalTax_paying
            // 
            this.txtTotalTax_paying.Location = new System.Drawing.Point(262, 140);
            this.txtTotalTax_paying.Name = "txtTotalTax_paying";
            this.txtTotalTax_paying.Size = new System.Drawing.Size(176, 31);
            this.txtTotalTax_paying.TabIndex = 61;
            this.txtTotalTax_paying.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalTax_paying.Leave += new System.EventHandler(this.txtTotalTax_paying_Leave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(17, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 29);
            this.label7.TabIndex = 63;
            this.label7.Text = "ຄ່າພາສີ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalTax
            // 
            this.txtTotalTax.Location = new System.Drawing.Point(106, 140);
            this.txtTotalTax.Name = "txtTotalTax";
            this.txtTotalTax.ReadOnly = true;
            this.txtTotalTax.Size = new System.Drawing.Size(150, 31);
            this.txtTotalTax.TabIndex = 62;
            this.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBuyCarPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1355, 799);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBuyCarPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ຊຳລະເງິນຊື້ລົດ";
            this.Load += new System.EventHandler(this.frmBuyCarPayment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTotalKota;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotalFee;
        private System.Windows.Forms.TextBox txtTotalBuy;
        private System.Windows.Forms.TextBox txtTotalKota_paying;
        private System.Windows.Forms.TextBox txtTotalFee_paying;
        private System.Windows.Forms.TextBox txtTotalBuy_paying;
        private System.Windows.Forms.TextBox txtTotalKota_balance;
        private System.Windows.Forms.TextBox txtTotalFee_balance;
        private System.Windows.Forms.TextBox txtTotalBuy_balance;
        private System.Windows.Forms.TextBox txtTotalKota_paid;
        private System.Windows.Forms.TextBox txtTotalFee_paid;
        private System.Windows.Forms.TextBox txtTotalBuy_paid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboTotalBuy_payer;
        private System.Windows.Forms.ComboBox cboTotalKota_payer;
        private System.Windows.Forms.ComboBox cboTotalFee_payer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTotalKota_payType;
        private System.Windows.Forms.ComboBox cboTotalFee_payType;
        private System.Windows.Forms.ComboBox cboTotalBuy_payType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCurrency_pay_kota;
        private System.Windows.Forms.ComboBox cboCurrency_pay_fee;
        private System.Windows.Forms.ComboBox cboCurrency_pay_car;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_des;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_payer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.DataGridViewButtonColumn col_item_del;
        private System.Windows.Forms.DateTimePicker dt_paid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCurrency_pay_tax;
        private System.Windows.Forms.ComboBox cboTotalTax_payType;
        private System.Windows.Forms.ComboBox cboTotalTax_payer;
        private System.Windows.Forms.TextBox txtTotalTax_balance;
        private System.Windows.Forms.TextBox txtTotalTax_paid;
        private System.Windows.Forms.TextBox txtTotalTax_paying;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalTax;
    }
}