namespace CarSellingSystem.BuyCar
{
    partial class frmBuyCarList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuyCarList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMake = new System.Windows.Forms.ComboBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.col_buy_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fuel_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_transmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_engine_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_car_body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_machine_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tan_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cushion_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_price_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_price_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fee_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fee_price_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fee_price_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kota_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kota_price_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kota_price_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1791, 789);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnPayment);
            this.groupPanel3.Controls.Add(this.btnClose);
            this.groupPanel3.Controls.Add(this.btnEdit);
            this.groupPanel3.Controls.Add(this.btnAddNew);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(6, 713);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1779, 70);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel3.TabIndex = 7;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(405, 0);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(195, 64);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "ການຊຳລະເງິນ";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(620, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 64);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "ອອກ";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(243, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(142, 64);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "ແກ້ໄຂ";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.DeepPink;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(82, 0);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(142, 64);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "ສ້າງໃໝ່";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.cboStatus);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.cboMake);
            this.groupPanel1.Controls.Add(this.cboModel);
            this.groupPanel1.Controls.Add(this.cboYear);
            this.groupPanel1.Controls.Add(this.to_date);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.from_date);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1779, 82);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "ຄົ້ນຫາ...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1035, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 29);
            this.label5.TabIndex = 42;
            this.label5.Text = "ສະຖານະ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1106, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(118, 37);
            this.cboStatus.TabIndex = 43;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1231, -5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 47);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(408, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 29);
            this.label2.TabIndex = 35;
            this.label2.Text = "ຍີ່ຫໍ່";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(652, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 29);
            this.label3.TabIndex = 36;
            this.label3.Text = "ລູ້ນ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(881, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 29);
            this.label4.TabIndex = 37;
            this.label4.Text = "ປີຜະລິດ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMake
            // 
            this.cboMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMake.FormattingEnabled = true;
            this.cboMake.Location = new System.Drawing.Point(446, 5);
            this.cboMake.Name = "cboMake";
            this.cboMake.Size = new System.Drawing.Size(202, 37);
            this.cboMake.TabIndex = 38;
            this.cboMake.SelectedIndexChanged += new System.EventHandler(this.cboMake_SelectedIndexChanged);
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(689, 5);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(189, 37);
            this.cboModel.TabIndex = 39;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(947, 5);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(85, 37);
            this.cboYear.TabIndex = 40;
            // 
            // to_date
            // 
            this.to_date.CustomFormat = "dd/MM/yyyy";
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(258, 5);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(147, 37);
            this.to_date.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(221, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "ຫາ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // from_date
            // 
            this.from_date.CustomFormat = "dd/MM/yyyy";
            this.from_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from_date.Location = new System.Drawing.Point(70, 5);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(147, 37);
            this.from_date.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(-2, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 29);
            this.label10.TabIndex = 33;
            this.label10.Text = "ຈາກວັນທີ່";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgv_data);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(6, 97);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1779, 607);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel2.Text = "ປະຫວັດຊື້ລົດຜ່ານມາ";
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_buy_id,
            this.col_date,
            this.col_make,
            this.col_model,
            this.col_year,
            this.col_color,
            this.col_fuel_type,
            this.col_transmission,
            this.col_engine_size,
            this.col_car_body,
            this.col_machine_code,
            this.col_tan_code,
            this.col_cushion_type,
            this.col_language,
            this.col_currency,
            this.col_buy_price,
            this.col_buy_price_paid,
            this.col_buy_price_balance,
            this.col_fee_price,
            this.col_fee_price_paid,
            this.col_fee_price_balance,
            this.col_kota_price,
            this.col_kota_price_paid,
            this.col_kota_price_balance,
            this.col_sell_price,
            this.col_remark,
            this.col_user,
            this.col_status,
            this.col_item_del});
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(0, 0);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowTemplate.Height = 30;
            this.dgv_data.Size = new System.Drawing.Size(1773, 569);
            this.dgv_data.TabIndex = 25;
            this.dgv_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseDoubleClick);
            this.dgv_data.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseUp);
            // 
            // col_buy_id
            // 
            this.col_buy_id.HeaderText = "buy_id";
            this.col_buy_id.Name = "col_buy_id";
            this.col_buy_id.ReadOnly = true;
            this.col_buy_id.Visible = false;
            // 
            // col_date
            // 
            this.col_date.HeaderText = "ວັນທີ່";
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            // 
            // col_make
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_make.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_make.HeaderText = "ຍີ່ຫໍ່";
            this.col_make.Name = "col_make";
            this.col_make.ReadOnly = true;
            // 
            // col_model
            // 
            this.col_model.HeaderText = "ລຸ້ນ";
            this.col_model.Name = "col_model";
            this.col_model.ReadOnly = true;
            // 
            // col_year
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_year.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_year.HeaderText = "ປີຜະລິດ";
            this.col_year.Name = "col_year";
            this.col_year.ReadOnly = true;
            this.col_year.Width = 70;
            // 
            // col_color
            // 
            this.col_color.HeaderText = "ສີ";
            this.col_color.Name = "col_color";
            this.col_color.ReadOnly = true;
            this.col_color.Width = 90;
            // 
            // col_fuel_type
            // 
            this.col_fuel_type.HeaderText = "ປະເພດນ້ຳມັນ";
            this.col_fuel_type.Name = "col_fuel_type";
            this.col_fuel_type.ReadOnly = true;
            this.col_fuel_type.Visible = false;
            this.col_fuel_type.Width = 110;
            // 
            // col_transmission
            // 
            this.col_transmission.HeaderText = "ລະບົບເກຍ";
            this.col_transmission.Name = "col_transmission";
            this.col_transmission.ReadOnly = true;
            this.col_transmission.Visible = false;
            this.col_transmission.Width = 120;
            // 
            // col_engine_size
            // 
            this.col_engine_size.HeaderText = "ຂະໜາດຈັກ";
            this.col_engine_size.Name = "col_engine_size";
            this.col_engine_size.ReadOnly = true;
            this.col_engine_size.Visible = false;
            // 
            // col_car_body
            // 
            this.col_car_body.HeaderText = "ປະເພດຕົວລົດ";
            this.col_car_body.Name = "col_car_body";
            this.col_car_body.ReadOnly = true;
            this.col_car_body.Visible = false;
            this.col_car_body.Width = 120;
            // 
            // col_machine_code
            // 
            this.col_machine_code.HeaderText = "ເລກຈັກ";
            this.col_machine_code.Name = "col_machine_code";
            this.col_machine_code.ReadOnly = true;
            // 
            // col_tan_code
            // 
            this.col_tan_code.HeaderText = "ເລກຖັງ";
            this.col_tan_code.Name = "col_tan_code";
            this.col_tan_code.ReadOnly = true;
            // 
            // col_cushion_type
            // 
            this.col_cushion_type.HeaderText = "ປະເພດເບາະ";
            this.col_cushion_type.Name = "col_cushion_type";
            this.col_cushion_type.ReadOnly = true;
            this.col_cushion_type.Visible = false;
            // 
            // col_language
            // 
            this.col_language.HeaderText = "ພາສາ";
            this.col_language.Name = "col_language";
            this.col_language.ReadOnly = true;
            this.col_language.Visible = false;
            // 
            // col_currency
            // 
            this.col_currency.HeaderText = "ສະກຸນເງິນ";
            this.col_currency.Name = "col_currency";
            this.col_currency.ReadOnly = true;
            // 
            // col_buy_price
            // 
            this.col_buy_price.HeaderText = "ລາຄາຊື້";
            this.col_buy_price.Name = "col_buy_price";
            this.col_buy_price.ReadOnly = true;
            // 
            // col_buy_price_paid
            // 
            this.col_buy_price_paid.HeaderText = "ຈ່າຍແລ້ວ";
            this.col_buy_price_paid.Name = "col_buy_price_paid";
            this.col_buy_price_paid.ReadOnly = true;
            // 
            // col_buy_price_balance
            // 
            this.col_buy_price_balance.HeaderText = "ຍັງເຫຼືອ";
            this.col_buy_price_balance.Name = "col_buy_price_balance";
            this.col_buy_price_balance.ReadOnly = true;
            // 
            // col_fee_price
            // 
            this.col_fee_price.HeaderText = "ຄ່າທຳນຽມ";
            this.col_fee_price.Name = "col_fee_price";
            this.col_fee_price.ReadOnly = true;
            // 
            // col_fee_price_paid
            // 
            this.col_fee_price_paid.HeaderText = "ຈ່າຍແລ້ວ";
            this.col_fee_price_paid.Name = "col_fee_price_paid";
            this.col_fee_price_paid.ReadOnly = true;
            // 
            // col_fee_price_balance
            // 
            this.col_fee_price_balance.HeaderText = "ຍັງເຫຼືອ";
            this.col_fee_price_balance.Name = "col_fee_price_balance";
            this.col_fee_price_balance.ReadOnly = true;
            // 
            // col_kota_price
            // 
            this.col_kota_price.HeaderText = "ຄ່າໂຄຕ່າ";
            this.col_kota_price.Name = "col_kota_price";
            this.col_kota_price.ReadOnly = true;
            // 
            // col_kota_price_paid
            // 
            this.col_kota_price_paid.HeaderText = "ຈ່າຍແລ້ວ";
            this.col_kota_price_paid.Name = "col_kota_price_paid";
            this.col_kota_price_paid.ReadOnly = true;
            // 
            // col_kota_price_balance
            // 
            this.col_kota_price_balance.HeaderText = "ຍັງເຫຼືອ";
            this.col_kota_price_balance.Name = "col_kota_price_balance";
            this.col_kota_price_balance.ReadOnly = true;
            // 
            // col_sell_price
            // 
            this.col_sell_price.HeaderText = "ລາຄາຂາຍ";
            this.col_sell_price.Name = "col_sell_price";
            this.col_sell_price.ReadOnly = true;
            this.col_sell_price.Visible = false;
            // 
            // col_remark
            // 
            this.col_remark.HeaderText = "ໝາຍເຫດ";
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            // 
            // col_user
            // 
            this.col_user.HeaderText = "ຢູເຊີ";
            this.col_user.Name = "col_user";
            this.col_user.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "ສະຖານະ";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // col_item_del
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            this.col_item_del.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_item_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col_item_del.HeaderText = "ລົບອອກ";
            this.col_item_del.Name = "col_item_del";
            this.col_item_del.ReadOnly = true;
            this.col_item_del.Width = 72;
            // 
            // frmBuyCarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1791, 789);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBuyCarList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buy Car List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuyCarList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DateTimePicker from_date;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_make;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fuel_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_transmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_engine_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_car_body;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_machine_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tan_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cushion_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_language;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_price_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_price_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fee_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fee_price_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fee_price_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kota_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kota_price_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kota_price_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewButtonColumn col_item_del;
        private System.Windows.Forms.ComboBox cboMake;

    }
}