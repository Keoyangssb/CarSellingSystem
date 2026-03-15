namespace CarSellingSystem.Customer
{
    partial class frmBrowseCustomer
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.col_cus_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_village = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_district = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_passport_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1460, 692);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtFullName);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1454, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ຄົ້ນຫາ...";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(424, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "ເບີໂທ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(487, 31);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(255, 37);
            this.txtTel.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(2, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 29);
            this.label10.TabIndex = 52;
            this.label10.Text = "ຊື່ ແລະ ນາມສະກຸນ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(150, 31);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(273, 37);
            this.txtFullName.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(751, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(142, 47);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_data);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1454, 599);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ຂໍ້ມູນລູກຄ້າ";
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
            this.col_passport_id,
            this.col_select});
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(3, 33);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowTemplate.Height = 30;
            this.dgv_data.Size = new System.Drawing.Size(1448, 563);
            this.dgv_data.TabIndex = 26;
            this.dgv_data.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseUp);
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
            this.col_full_name.Width = 250;
            // 
            // col_village
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_village.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_village.HeaderText = "ບ້ານ";
            this.col_village.Name = "col_village";
            this.col_village.ReadOnly = true;
            this.col_village.Width = 150;
            // 
            // col_district
            // 
            this.col_district.HeaderText = "ເມືອງ";
            this.col_district.Name = "col_district";
            this.col_district.ReadOnly = true;
            this.col_district.Width = 150;
            // 
            // col_province
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_province.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_province.HeaderText = "ແຂວງ";
            this.col_province.Name = "col_province";
            this.col_province.ReadOnly = true;
            this.col_province.Width = 150;
            // 
            // col_tel
            // 
            this.col_tel.HeaderText = "ເບີໂທ";
            this.col_tel.Name = "col_tel";
            this.col_tel.ReadOnly = true;
            this.col_tel.Width = 150;
            // 
            // col_age
            // 
            this.col_age.HeaderText = "ອາຍຸ";
            this.col_age.Name = "col_age";
            this.col_age.ReadOnly = true;
            this.col_age.Width = 80;
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
            // frmBrowseCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBrowseCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse Customer";
            this.Load += new System.EventHandler(this.frmBrowseCustomer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cus_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_village;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_district;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_province;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_passport_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_select;
    }
}