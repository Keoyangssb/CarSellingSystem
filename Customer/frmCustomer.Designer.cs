namespace CarSellingSystem.Customer
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTel_search = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFullName_search = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_passport_id = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txt_card_id = new System.Windows.Forms.TextBox();
            this.txt_district = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_cusFullName = new System.Windows.Forms.TextBox();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.txt_province = new System.Windows.Forms.TextBox();
            this.txt_village = new System.Windows.Forms.TextBox();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.col_cus_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_village = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_district = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_passport_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 495F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1647, 821);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.txt_passport_id);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.txt_card_id);
            this.groupBox1.Controls.Add(this.txt_district);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txt_cusFullName);
            this.groupBox1.Controls.Add(this.txt_age);
            this.groupBox1.Controls.Add(this.txt_province);
            this.groupBox1.Controls.Add(this.txt_village);
            this.groupBox1.Controls.Add(this.txt_tel);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1152, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 809);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ບັນທຶກ / ແກ້ໄຂຂໍ້ມູນລູກຄ້າ";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(253, 366);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 64);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "ລົບອອກ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(389, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 64);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "ອອກ";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(117, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 64);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ບັນທຶກ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.DeepPink;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(12, 366);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(99, 64);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "ສ້າງໃໝ່";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1137, 809);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTel_search);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtFullName_search);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1131, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ຄົ້ນຫາ...";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(456, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "ເບີໂທ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTel_search
            // 
            this.txtTel_search.Location = new System.Drawing.Point(524, 31);
            this.txtTel_search.Name = "txtTel_search";
            this.txtTel_search.Size = new System.Drawing.Size(255, 42);
            this.txtTel_search.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(2, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 33);
            this.label10.TabIndex = 52;
            this.label10.Text = "ຊື່ ແລະ ນາມສະກຸນ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName_search
            // 
            this.txtFullName_search.Location = new System.Drawing.Point(182, 31);
            this.txtFullName_search.Name = "txtFullName_search";
            this.txtFullName_search.Size = new System.Drawing.Size(273, 42);
            this.txtFullName_search.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(788, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 47);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_data);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1131, 716);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ຂໍ້ມູນລູກຄ້າ";
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.AllowUserToResizeRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_cus_id,
            this.col_full_name,
            this.col_village,
            this.col_district,
            this.col_province,
            this.col_tel,
            this.col_age,
            this.col_card_id,
            this.col_passport_id});
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(3, 38);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowTemplate.Height = 30;
            this.dgv_data.Size = new System.Drawing.Size(1125, 675);
            this.dgv_data.TabIndex = 26;
            this.dgv_data.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseUp);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Location = new System.Drawing.Point(-38, 299);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(189, 40);
            this.label31.TabIndex = 68;
            this.label31.Text = "Passport ເລກທີ";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_passport_id
            // 
            this.txt_passport_id.Location = new System.Drawing.Point(157, 297);
            this.txt_passport_id.Name = "txt_passport_id";
            this.txt_passport_id.Size = new System.Drawing.Size(323, 42);
            this.txt_passport_id.TabIndex = 7;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Location = new System.Drawing.Point(-38, 256);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(189, 40);
            this.label30.TabIndex = 66;
            this.label30.Text = "ບັດປະຈຳຕົວເລກທີ";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_card_id
            // 
            this.txt_card_id.Location = new System.Drawing.Point(157, 256);
            this.txt_card_id.Name = "txt_card_id";
            this.txt_card_id.Size = new System.Drawing.Size(323, 42);
            this.txt_card_id.TabIndex = 6;
            // 
            // txt_district
            // 
            this.txt_district.Location = new System.Drawing.Point(157, 134);
            this.txt_district.Name = "txt_district";
            this.txt_district.Size = new System.Drawing.Size(323, 42);
            this.txt_district.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(238, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 29);
            this.label16.TabIndex = 63;
            this.label16.Text = "ເບີໂທ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(-38, 216);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(189, 40);
            this.label29.TabIndex = 60;
            this.label29.Text = "ອາຍຸ";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(-38, 175);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(189, 40);
            this.label28.TabIndex = 61;
            this.label28.Text = "ແຂວງ";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(-38, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(189, 40);
            this.label17.TabIndex = 62;
            this.label17.Text = "ປະຈຸບັນຢູ່ບ້ານ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(-31, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(182, 40);
            this.label18.TabIndex = 59;
            this.label18.Text = "ຊື່ ແລະ ນາມສະກຸນ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_cusFullName
            // 
            this.txt_cusFullName.Location = new System.Drawing.Point(157, 52);
            this.txt_cusFullName.Name = "txt_cusFullName";
            this.txt_cusFullName.Size = new System.Drawing.Size(323, 42);
            this.txt_cusFullName.TabIndex = 0;
            // 
            // txt_age
            // 
            this.txt_age.Location = new System.Drawing.Point(157, 215);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(75, 42);
            this.txt_age.TabIndex = 4;
            this.txt_age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_province
            // 
            this.txt_province.Location = new System.Drawing.Point(157, 174);
            this.txt_province.Name = "txt_province";
            this.txt_province.Size = new System.Drawing.Size(322, 42);
            this.txt_province.TabIndex = 3;
            // 
            // txt_village
            // 
            this.txt_village.Location = new System.Drawing.Point(157, 93);
            this.txt_village.Name = "txt_village";
            this.txt_village.Size = new System.Drawing.Size(322, 42);
            this.txt_village.TabIndex = 1;
            // 
            // txt_tel
            // 
            this.txt_tel.Location = new System.Drawing.Point(304, 215);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(176, 42);
            this.txt_tel.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(-38, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(189, 40);
            this.label21.TabIndex = 69;
            this.label21.Text = "ເມືອງ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // col_cus_id
            // 
            this.col_cus_id.HeaderText = "car_id";
            this.col_cus_id.Name = "col_cus_id";
            this.col_cus_id.ReadOnly = true;
            this.col_cus_id.Visible = false;
            // 
            // col_full_name
            // 
            this.col_full_name.HeaderText = "ຊື່ ແລະ ນາມສະກຸນ";
            this.col_full_name.Name = "col_full_name";
            this.col_full_name.ReadOnly = true;
            this.col_full_name.Width = 220;
            // 
            // col_village
            // 
            this.col_village.HeaderText = "ບ້ານ";
            this.col_village.Name = "col_village";
            this.col_village.ReadOnly = true;
            this.col_village.Width = 120;
            // 
            // col_district
            // 
            this.col_district.HeaderText = "ເມືອງ";
            this.col_district.Name = "col_district";
            this.col_district.ReadOnly = true;
            this.col_district.Width = 120;
            // 
            // col_province
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_province.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_province.HeaderText = "ແຂວງ";
            this.col_province.Name = "col_province";
            this.col_province.ReadOnly = true;
            this.col_province.Width = 120;
            // 
            // col_tel
            // 
            this.col_tel.HeaderText = "ເບີໂທ";
            this.col_tel.Name = "col_tel";
            this.col_tel.ReadOnly = true;
            this.col_tel.Width = 120;
            // 
            // col_age
            // 
            this.col_age.HeaderText = "ອາຍຸ";
            this.col_age.Name = "col_age";
            this.col_age.ReadOnly = true;
            this.col_age.Width = 70;
            // 
            // col_card_id
            // 
            this.col_card_id.HeaderText = "ບັດປະຈຳຕົວເລກທີ";
            this.col_card_id.Name = "col_card_id";
            this.col_card_id.ReadOnly = true;
            this.col_card_id.Width = 150;
            // 
            // col_passport_id
            // 
            this.col_passport_id.HeaderText = "Passport ເລກທີ";
            this.col_passport_id.Name = "col_passport_id";
            this.col_passport_id.ReadOnly = true;
            this.col_passport_id.Width = 200;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1647, 821);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Saysettha OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTel_search;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFullName_search;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txt_passport_id;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txt_card_id;
        private System.Windows.Forms.TextBox txt_district;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_cusFullName;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.TextBox txt_province;
        private System.Windows.Forms.TextBox txt_village;
        private System.Windows.Forms.TextBox txt_tel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cus_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_village;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_district;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_province;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_passport_id;
    }
}