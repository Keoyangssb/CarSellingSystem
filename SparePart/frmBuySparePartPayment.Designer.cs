namespace CarSellingSystem.SparePart
{
    partial class frmBuySparePartPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuySparePartPayment));
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
            this.label6 = new System.Windows.Forms.Label();
            this.cboCurPayFee = new System.Windows.Forms.ComboBox();
            this.cboCurPaySPP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPayTypeFee = new System.Windows.Forms.ComboBox();
            this.cboPayTypeSPP = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPayerForFee = new System.Windows.Forms.ComboBox();
            this.cboPayerForSpp = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalFee_balance = new System.Windows.Forms.TextBox();
            this.txtTotalBuy_balance = new System.Windows.Forms.TextBox();
            this.txtTotalFee_paid = new System.Windows.Forms.TextBox();
            this.txtTotalBuy_paid = new System.Windows.Forms.TextBox();
            this.txtPayingFee = new System.Windows.Forms.TextBox();
            this.txtPayingSPP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTransportFee = new System.Windows.Forms.TextBox();
            this.txtTotalSPP = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1384, 741);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvData);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(3, 228);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1378, 510);
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
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.Size = new System.Drawing.Size(1372, 472);
            this.dgvData.TabIndex = 25;
            this.dgvData.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseUp);
            // 
            // col_pay_id
            // 
            this.col_pay_id.HeaderText = "save_item_id";
            this.col_pay_id.Name = "col_pay_id";
            this.col_pay_id.ReadOnly = true;
            this.col_pay_id.Visible = false;
            // 
            // col_item_no
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_item_no.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_item_no.HeaderText = "ລ/ດ";
            this.col_item_no.Name = "col_item_no";
            this.col_item_no.ReadOnly = true;
            this.col_item_no.Width = 50;
            // 
            // col_pay_date
            // 
            this.col_pay_date.HeaderText = "ວັນທີ່ຊຳລະ";
            this.col_pay_date.Name = "col_pay_date";
            this.col_pay_date.ReadOnly = true;
            this.col_pay_date.Width = 200;
            // 
            // col_pay_des
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_pay_des.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_pay_des.HeaderText = "ລາຍການຊຳລະ";
            this.col_pay_des.Name = "col_pay_des";
            this.col_pay_des.ReadOnly = true;
            this.col_pay_des.Width = 150;
            // 
            // col_pay_amount
            // 
            this.col_pay_amount.HeaderText = "ຈຳນວນເງິນຊຳລະ";
            this.col_pay_amount.Name = "col_pay_amount";
            this.col_pay_amount.ReadOnly = true;
            this.col_pay_amount.Width = 120;
            // 
            // col_currency
            // 
            this.col_currency.HeaderText = "ສະກຸນເງິນ";
            this.col_currency.Name = "col_currency";
            this.col_currency.ReadOnly = true;
            // 
            // col_pay_type_name
            // 
            this.col_pay_type_name.HeaderText = "ຮູບແບບຊຳລະ";
            this.col_pay_type_name.Name = "col_pay_type_name";
            this.col_pay_type_name.ReadOnly = true;
            this.col_pay_type_name.Width = 120;
            // 
            // col_payer
            // 
            this.col_payer.HeaderText = "ຜູ້ຊຳລະເງິນ";
            this.col_payer.Name = "col_payer";
            this.col_payer.ReadOnly = true;
            this.col_payer.Width = 200;
            // 
            // col_user
            // 
            this.col_user.HeaderText = "ຢູເຊີ";
            this.col_user.Name = "col_user";
            this.col_user.ReadOnly = true;
            this.col_user.Width = 200;
            // 
            // col_item_del
            // 
            this.col_item_del.HeaderText = "ລົບອອກ";
            this.col_item_del.Name = "col_item_del";
            this.col_item_del.ReadOnly = true;
            this.col_item_del.Width = 72;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.cboCurPayFee);
            this.groupPanel1.Controls.Add(this.cboCurPaySPP);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.cboPayTypeFee);
            this.groupPanel1.Controls.Add(this.cboPayTypeSPP);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cboPayerForFee);
            this.groupPanel1.Controls.Add(this.cboPayerForSpp);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.txtTotalFee_balance);
            this.groupPanel1.Controls.Add(this.txtTotalBuy_balance);
            this.groupPanel1.Controls.Add(this.txtTotalFee_paid);
            this.groupPanel1.Controls.Add(this.txtTotalBuy_paid);
            this.groupPanel1.Controls.Add(this.txtPayingFee);
            this.groupPanel1.Controls.Add(this.txtPayingSPP);
            this.groupPanel1.Controls.Add(this.label17);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.txtTransportFee);
            this.groupPanel1.Controls.Add(this.txtTotalSPP);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1378, 219);
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
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(483, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 29);
            this.label6.TabIndex = 50;
            this.label6.Text = "ສະກຸນເງິນ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCurPayFee
            // 
            this.cboCurPayFee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurPayFee.FormattingEnabled = true;
            this.cboCurPayFee.Location = new System.Drawing.Point(483, 66);
            this.cboCurPayFee.Name = "cboCurPayFee";
            this.cboCurPayFee.Size = new System.Drawing.Size(107, 37);
            this.cboCurPayFee.TabIndex = 48;
            this.cboCurPayFee.SelectedIndexChanged += new System.EventHandler(this.cboCurFee_SelectedIndexChanged);
            // 
            // cboCurPaySPP
            // 
            this.cboCurPaySPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurPaySPP.FormattingEnabled = true;
            this.cboCurPaySPP.Location = new System.Drawing.Point(483, 29);
            this.cboCurPaySPP.Name = "cboCurPaySPP";
            this.cboCurPaySPP.Size = new System.Drawing.Size(107, 37);
            this.cboCurPaySPP.TabIndex = 49;
            this.cboCurPaySPP.SelectedIndexChanged += new System.EventHandler(this.cboCurSPP_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(596, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 29);
            this.label5.TabIndex = 46;
            this.label5.Text = "ເລືອກຮູບແບບຊຳລະ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboPayTypeFee
            // 
            this.cboPayTypeFee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayTypeFee.FormattingEnabled = true;
            this.cboPayTypeFee.Location = new System.Drawing.Point(596, 66);
            this.cboPayTypeFee.Name = "cboPayTypeFee";
            this.cboPayTypeFee.Size = new System.Drawing.Size(159, 37);
            this.cboPayTypeFee.TabIndex = 44;
            // 
            // cboPayTypeSPP
            // 
            this.cboPayTypeSPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayTypeSPP.FormattingEnabled = true;
            this.cboPayTypeSPP.Location = new System.Drawing.Point(596, 29);
            this.cboPayTypeSPP.Name = "cboPayTypeSPP";
            this.cboPayTypeSPP.Size = new System.Drawing.Size(159, 37);
            this.cboPayTypeSPP.TabIndex = 45;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1214, 111);
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
            this.label4.Location = new System.Drawing.Point(1209, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 29);
            this.label4.TabIndex = 42;
            this.label4.Text = "ເງິນທີ່ຍັງເຫຼືອ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1053, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 41;
            this.label3.Text = "ຊຳລະເງິນແລ້ວ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(761, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 29);
            this.label2.TabIndex = 40;
            this.label2.Text = "ເລືອກຜູ້ຊຳລະເງິນ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(301, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 39;
            this.label1.Text = "ປ້ອນຈຳນວນເງິນຊຳລະ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboPayerForFee
            // 
            this.cboPayerForFee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayerForFee.FormattingEnabled = true;
            this.cboPayerForFee.Location = new System.Drawing.Point(761, 66);
            this.cboPayerForFee.Name = "cboPayerForFee";
            this.cboPayerForFee.Size = new System.Drawing.Size(291, 37);
            this.cboPayerForFee.TabIndex = 38;
            // 
            // cboPayerForSpp
            // 
            this.cboPayerForSpp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayerForSpp.FormattingEnabled = true;
            this.cboPayerForSpp.Location = new System.Drawing.Point(761, 29);
            this.cboPayerForSpp.Name = "cboPayerForSpp";
            this.cboPayerForSpp.Size = new System.Drawing.Size(291, 37);
            this.cboPayerForSpp.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1058, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 64);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ບັນທຶກ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalFee_balance
            // 
            this.txtTotalFee_balance.Location = new System.Drawing.Point(1214, 66);
            this.txtTotalFee_balance.Name = "txtTotalFee_balance";
            this.txtTotalFee_balance.ReadOnly = true;
            this.txtTotalFee_balance.Size = new System.Drawing.Size(150, 37);
            this.txtTotalFee_balance.TabIndex = 34;
            this.txtTotalFee_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBuy_balance
            // 
            this.txtTotalBuy_balance.Location = new System.Drawing.Point(1214, 29);
            this.txtTotalBuy_balance.Name = "txtTotalBuy_balance";
            this.txtTotalBuy_balance.ReadOnly = true;
            this.txtTotalBuy_balance.Size = new System.Drawing.Size(150, 37);
            this.txtTotalBuy_balance.TabIndex = 35;
            this.txtTotalBuy_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalFee_paid
            // 
            this.txtTotalFee_paid.Location = new System.Drawing.Point(1058, 66);
            this.txtTotalFee_paid.Name = "txtTotalFee_paid";
            this.txtTotalFee_paid.ReadOnly = true;
            this.txtTotalFee_paid.Size = new System.Drawing.Size(150, 37);
            this.txtTotalFee_paid.TabIndex = 31;
            this.txtTotalFee_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBuy_paid
            // 
            this.txtTotalBuy_paid.Location = new System.Drawing.Point(1058, 29);
            this.txtTotalBuy_paid.Name = "txtTotalBuy_paid";
            this.txtTotalBuy_paid.ReadOnly = true;
            this.txtTotalBuy_paid.Size = new System.Drawing.Size(150, 37);
            this.txtTotalBuy_paid.TabIndex = 32;
            this.txtTotalBuy_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPayingFee
            // 
            this.txtPayingFee.Location = new System.Drawing.Point(301, 66);
            this.txtPayingFee.Name = "txtPayingFee";
            this.txtPayingFee.Size = new System.Drawing.Size(176, 37);
            this.txtPayingFee.TabIndex = 1;
            this.txtPayingFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPayingFee.Leave += new System.EventHandler(this.txtPayingFee_Leave);
            // 
            // txtPayingSPP
            // 
            this.txtPayingSPP.Location = new System.Drawing.Point(301, 29);
            this.txtPayingSPP.Name = "txtPayingSPP";
            this.txtPayingSPP.Size = new System.Drawing.Size(176, 37);
            this.txtPayingSPP.TabIndex = 0;
            this.txtPayingSPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPayingSPP.Leave += new System.EventHandler(this.txtPayingSPP_Leave);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(45, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 29);
            this.label17.TabIndex = 24;
            this.label17.Text = "ຄ່າຂົນສົ່ງ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(5, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 29);
            this.label16.TabIndex = 25;
            this.label16.Text = "ລວມມູນຄ່າອາໄຫຼ່";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransportFee
            // 
            this.txtTransportFee.Location = new System.Drawing.Point(143, 66);
            this.txtTransportFee.Name = "txtTransportFee";
            this.txtTransportFee.ReadOnly = true;
            this.txtTransportFee.Size = new System.Drawing.Size(150, 37);
            this.txtTransportFee.TabIndex = 22;
            this.txtTransportFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalSPP
            // 
            this.txtTotalSPP.Location = new System.Drawing.Point(143, 29);
            this.txtTotalSPP.Name = "txtTotalSPP";
            this.txtTotalSPP.ReadOnly = true;
            this.txtTotalSPP.Size = new System.Drawing.Size(150, 37);
            this.txtTotalSPP.TabIndex = 23;
            this.txtTotalSPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBuySparePartPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBuySparePartPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmBuySparePartPayment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DataGridView dgvData;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPayTypeFee;
        private System.Windows.Forms.ComboBox cboPayTypeSPP;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPayerForFee;
        private System.Windows.Forms.ComboBox cboPayerForSpp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTotalFee_balance;
        private System.Windows.Forms.TextBox txtTotalBuy_balance;
        private System.Windows.Forms.TextBox txtTotalFee_paid;
        private System.Windows.Forms.TextBox txtTotalBuy_paid;
        private System.Windows.Forms.TextBox txtPayingFee;
        private System.Windows.Forms.TextBox txtPayingSPP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTransportFee;
        private System.Windows.Forms.TextBox txtTotalSPP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCurPayFee;
        private System.Windows.Forms.ComboBox cboCurPaySPP;
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
    }
}