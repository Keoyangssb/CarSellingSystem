namespace CarSellingSystem.SaleCar
{
    partial class frmSaleCarPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.col_pay_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_payer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_select_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_kip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pay_bath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rate_kip_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rate_bath_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSellPayType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPayer = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBalanceBath = new System.Windows.Forms.Label();
            this.lblBalanceKip = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPaid = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPayingBath = new System.Windows.Forms.TextBox();
            this.txtPayingKip = new System.Windows.Forms.TextBox();
            this.txtPayingUSD = new System.Windows.Forms.TextBox();
            this.dt_paid = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1543, 855);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvData);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(3, 334);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1537, 517);
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
            this.col_payer,
            this.col_select_pay,
            this.col_pay_type,
            this.col_pay_usd,
            this.col_pay_kip,
            this.col_pay_bath,
            this.col_remark,
            this.col_rate_kip_usd,
            this.col_rate_bath_usd,
            this.col_user,
            this.col_item_del});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.Size = new System.Drawing.Size(1531, 485);
            this.dgvData.TabIndex = 0;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_item_no.DefaultCellStyle = dataGridViewCellStyle7;
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
            // col_payer
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_payer.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_payer.HeaderText = "ຜູ້ຊຳລະ";
            this.col_payer.Name = "col_payer";
            this.col_payer.Width = 150;
            // 
            // col_select_pay
            // 
            this.col_select_pay.HeaderText = "ເລືອກຈ່າຍ";
            this.col_select_pay.Name = "col_select_pay";
            this.col_select_pay.Width = 120;
            // 
            // col_pay_type
            // 
            this.col_pay_type.HeaderText = "ຮູບແບບຊຳລະ";
            this.col_pay_type.Name = "col_pay_type";
            // 
            // col_pay_usd
            // 
            this.col_pay_usd.HeaderText = "ຈ່າຍເງິນໂດລ່າ";
            this.col_pay_usd.Name = "col_pay_usd";
            // 
            // col_pay_kip
            // 
            this.col_pay_kip.HeaderText = "ຈ່າຍເງິນກີບ";
            this.col_pay_kip.Name = "col_pay_kip";
            // 
            // col_pay_bath
            // 
            this.col_pay_bath.HeaderText = "ຈ່າຍເງິນບາດ";
            this.col_pay_bath.Name = "col_pay_bath";
            // 
            // col_remark
            // 
            this.col_remark.HeaderText = "ໝາຍເຫດ";
            this.col_remark.Name = "col_remark";
            this.col_remark.Width = 150;
            // 
            // col_rate_kip_usd
            // 
            this.col_rate_kip_usd.HeaderText = "ເລດກີບ-ໂດລ່າ";
            this.col_rate_kip_usd.Name = "col_rate_kip_usd";
            // 
            // col_rate_bath_usd
            // 
            this.col_rate_bath_usd.HeaderText = "ເລດບາດ-ໂດລ່າ";
            this.col_rate_bath_usd.Name = "col_rate_bath_usd";
            // 
            // col_user
            // 
            this.col_user.HeaderText = "ຢູເຊີ";
            this.col_user.Name = "col_user";
            this.col_user.Width = 150;
            // 
            // col_item_del
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.OrangeRed;
            this.col_item_del.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_item_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col_item_del.HeaderText = "ລົບອອກ";
            this.col_item_del.Name = "col_item_del";
            this.col_item_del.Width = 72;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dt_paid);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.txtRemark);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboSellPayType);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.cboPayer);
            this.groupPanel1.Controls.Add(this.groupBox3);
            this.groupPanel1.Controls.Add(this.groupBox2);
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.cboPayType);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.txtPayingBath);
            this.groupPanel1.Controls.Add(this.txtPayingKip);
            this.groupPanel1.Controls.Add(this.txtPayingUSD);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(3, 4);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1537, 322);
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
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(513, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 42);
            this.label7.TabIndex = 56;
            this.label7.Text = "ໝາຍເຫດ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(615, 153);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(275, 120);
            this.txtRemark.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(508, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 42);
            this.label2.TabIndex = 54;
            this.label2.Text = "ເລືອກຈ່າຍ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSellPayType
            // 
            this.cboSellPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSellPayType.FormattingEnabled = true;
            this.cboSellPayType.Location = new System.Drawing.Point(614, 111);
            this.cboSellPayType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSellPayType.Name = "cboSellPayType";
            this.cboSellPayType.Size = new System.Drawing.Size(193, 35);
            this.cboSellPayType.TabIndex = 1;
            this.cboSellPayType.SelectedIndexChanged += new System.EventHandler(this.cboFull_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(61, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 42);
            this.label6.TabIndex = 52;
            this.label6.Text = "ເລືອກຜູ້ຊຳລະເງິນ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPayer
            // 
            this.cboPayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayer.FormattingEnabled = true;
            this.cboPayer.Location = new System.Drawing.Point(233, 111);
            this.cboPayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPayer.Name = "cboPayer";
            this.cboPayer.Size = new System.Drawing.Size(275, 35);
            this.cboPayer.TabIndex = 0;
            this.cboPayer.SelectedIndexChanged += new System.EventHandler(this.cboPayer_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Controls.Add(this.lblBalanceBath);
            this.groupBox3.Controls.Add(this.lblBalanceKip);
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(451, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(720, 93);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ຍັງເຫຼືອ";
            // 
            // lblBalanceBath
            // 
            this.lblBalanceBath.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceBath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBalanceBath.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceBath.Location = new System.Drawing.Point(498, 39);
            this.lblBalanceBath.Name = "lblBalanceBath";
            this.lblBalanceBath.Size = new System.Drawing.Size(214, 46);
            this.lblBalanceBath.TabIndex = 28;
            this.lblBalanceBath.Text = "10,000,000 ฿";
            this.lblBalanceBath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalanceKip
            // 
            this.lblBalanceKip.BackColor = System.Drawing.Color.Transparent;
            this.lblBalanceKip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBalanceKip.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceKip.Location = new System.Drawing.Point(225, 39);
            this.lblBalanceKip.Name = "lblBalanceKip";
            this.lblBalanceKip.Size = new System.Drawing.Size(261, 46);
            this.lblBalanceKip.TabIndex = 27;
            this.lblBalanceKip.Text = "1,000,000,000 K";
            this.lblBalanceKip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalance
            // 
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBalance.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(7, 39);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(204, 46);
            this.lblBalance.TabIndex = 26;
            this.lblBalance.Text = "25,000.00 $";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox2.Controls.Add(this.lblPaid);
            this.groupBox2.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(233, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(217, 93);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ຈ່າຍແລ້ວ";
            // 
            // lblPaid
            // 
            this.lblPaid.BackColor = System.Drawing.Color.Transparent;
            this.lblPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPaid.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.Location = new System.Drawing.Point(7, 39);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(204, 46);
            this.lblPaid.TabIndex = 26;
            this.lblPaid.Text = "0";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(217, 93);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ມູນຄ່າລົດ";
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrice.Font = new System.Drawing.Font("Phetsarath OT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(7, 39);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(204, 46);
            this.lblPrice.TabIndex = 25;
            this.lblPrice.Text = "25,000.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(811, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 42);
            this.label5.TabIndex = 46;
            this.label5.Text = "ເລືອກຮູບແບບຊຳລະ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPayType
            // 
            this.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Location = new System.Drawing.Point(993, 111);
            this.cboPayType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(170, 35);
            this.cboPayType.TabIndex = 2;
            this.cboPayType.SelectedIndexChanged += new System.EventHandler(this.cboPayType_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1043, 199);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 75);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "ອອກ";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(59, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 42);
            this.label4.TabIndex = 39;
            this.label4.Text = "ຈ່າຍເງິນບາດ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(84, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 42);
            this.label3.TabIndex = 39;
            this.label3.Text = "ຈ່າຍເງິນກີບ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(78, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 42);
            this.label1.TabIndex = 39;
            this.label1.Text = "ຈ່າຍເງິນໂດລ່າ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(896, 199);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 75);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "ບັນທຶກ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPayingBath
            // 
            this.txtPayingBath.Location = new System.Drawing.Point(233, 233);
            this.txtPayingBath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPayingBath.Name = "txtPayingBath";
            this.txtPayingBath.Size = new System.Drawing.Size(275, 35);
            this.txtPayingBath.TabIndex = 5;
            this.txtPayingBath.TextChanged += new System.EventHandler(this.txtPayingBath_TextChanged);
            this.txtPayingBath.Leave += new System.EventHandler(this.txtPayingBath_Leave);
            // 
            // txtPayingKip
            // 
            this.txtPayingKip.Location = new System.Drawing.Point(233, 193);
            this.txtPayingKip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPayingKip.Name = "txtPayingKip";
            this.txtPayingKip.Size = new System.Drawing.Size(275, 35);
            this.txtPayingKip.TabIndex = 4;
            this.txtPayingKip.TextChanged += new System.EventHandler(this.txtPayingKip_TextChanged);
            this.txtPayingKip.Leave += new System.EventHandler(this.txtPayingKip_Leave);
            // 
            // txtPayingUSD
            // 
            this.txtPayingUSD.Location = new System.Drawing.Point(233, 153);
            this.txtPayingUSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPayingUSD.Name = "txtPayingUSD";
            this.txtPayingUSD.Size = new System.Drawing.Size(275, 35);
            this.txtPayingUSD.TabIndex = 3;
            this.txtPayingUSD.TextChanged += new System.EventHandler(this.txtPayingUSD_TextChanged);
            this.txtPayingUSD.Leave += new System.EventHandler(this.txtPayingUSD_Leave);
            // 
            // dt_paid
            // 
            this.dt_paid.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_paid.Location = new System.Drawing.Point(993, 150);
            this.dt_paid.Name = "dt_paid";
            this.dt_paid.Size = new System.Drawing.Size(170, 35);
            this.dt_paid.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(896, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 58;
            this.label8.Text = "ວັນທີ່ຈ່າຍ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSaleCarPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 855);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmSaleCarPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Payment";
            this.Load += new System.EventHandler(this.frmSaleCarPayment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DataGridView dgvData;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPayingUSD;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.ComboBox cboPayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSellPayType;
        private System.Windows.Forms.Label lblBalanceBath;
        private System.Windows.Forms.Label lblBalanceKip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPayingBath;
        private System.Windows.Forms.TextBox txtPayingKip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_payer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_select_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_kip;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_bath;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rate_kip_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rate_bath_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.DataGridViewButtonColumn col_item_del;
        private System.Windows.Forms.DateTimePicker dt_paid;
        private System.Windows.Forms.Label label8;
    }
}