namespace CarSellingSystem.CarsInfo
{
    partial class frmBrowseCar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_tank_code = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_machine_code = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMake = new System.Windows.Forms.ComboBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.col_car_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_buy_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fuel_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_transmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_engine_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_car_body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cushion_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_machine_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tan_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_data);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1534, 719);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ຂໍ້ມູນລົດ";
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.AllowUserToResizeRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_car_id,
            this.col_buy_date,
            this.col_make,
            this.col_model,
            this.col_year,
            this.col_color,
            this.col_fuel_type,
            this.col_transmission,
            this.col_engine_size,
            this.col_car_body,
            this.col_cushion_type,
            this.col_machine_code,
            this.col_tan_code,
            this.col_language,
            this.col_sell_price,
            this.col_currency,
            this.col_status,
            this.col_select});
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(3, 33);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowTemplate.Height = 30;
            this.dgv_data.Size = new System.Drawing.Size(1528, 683);
            this.dgv_data.TabIndex = 26;
            this.dgv_data.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1540, 812);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_tank_code);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_machine_code);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboMake);
            this.groupBox2.Controls.Add(this.cboModel);
            this.groupBox2.Controls.Add(this.cboYear);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1534, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ຄົ້ນຫາ...";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(915, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "ເລກຖັງ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_tank_code
            // 
            this.txt_tank_code.Location = new System.Drawing.Point(993, 36);
            this.txt_tank_code.Name = "txt_tank_code";
            this.txt_tank_code.Size = new System.Drawing.Size(210, 37);
            this.txt_tank_code.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(636, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 29);
            this.label10.TabIndex = 52;
            this.label10.Text = "ເລກຈັກ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_machine_code
            // 
            this.txt_machine_code.Location = new System.Drawing.Point(715, 36);
            this.txt_machine_code.Name = "txt_machine_code";
            this.txt_machine_code.Size = new System.Drawing.Size(193, 37);
            this.txt_machine_code.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Phetsarath OT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1401, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 47);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "ຄົ້ນຫາ...";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "ຍີ່ຫໍ່";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(250, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 29);
            this.label3.TabIndex = 45;
            this.label3.Text = "ລູ້ນ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(479, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "ປີຜະລິດ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMake
            // 
            this.cboMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMake.FormattingEnabled = true;
            this.cboMake.Location = new System.Drawing.Point(44, 36);
            this.cboMake.Name = "cboMake";
            this.cboMake.Size = new System.Drawing.Size(202, 37);
            this.cboMake.TabIndex = 47;
            this.cboMake.SelectedIndexChanged += new System.EventHandler(this.cboMake_SelectedIndexChanged);
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(287, 36);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(189, 37);
            this.cboModel.TabIndex = 48;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(545, 36);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(85, 37);
            this.cboYear.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1205, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 29);
            this.label5.TabIndex = 55;
            this.label5.Text = "ສະຖານະ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1276, 36);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(118, 37);
            this.cboStatus.TabIndex = 56;
            // 
            // col_car_id
            // 
            this.col_car_id.HeaderText = "car_id";
            this.col_car_id.Name = "col_car_id";
            this.col_car_id.ReadOnly = true;
            this.col_car_id.Visible = false;
            // 
            // col_buy_date
            // 
            this.col_buy_date.HeaderText = "ວັນທີ່ຊື້";
            this.col_buy_date.Name = "col_buy_date";
            this.col_buy_date.ReadOnly = true;
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
            this.col_fuel_type.Width = 110;
            // 
            // col_transmission
            // 
            this.col_transmission.HeaderText = "ລະບົບເກຍ";
            this.col_transmission.Name = "col_transmission";
            this.col_transmission.ReadOnly = true;
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
            // col_cushion_type
            // 
            this.col_cushion_type.HeaderText = "ປະເພດເບາະ";
            this.col_cushion_type.Name = "col_cushion_type";
            this.col_cushion_type.ReadOnly = true;
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
            // col_language
            // 
            this.col_language.HeaderText = "ພາສາ";
            this.col_language.Name = "col_language";
            this.col_language.ReadOnly = true;
            this.col_language.Visible = false;
            // 
            // col_sell_price
            // 
            this.col_sell_price.HeaderText = "ລາຄາ";
            this.col_sell_price.Name = "col_sell_price";
            this.col_sell_price.ReadOnly = true;
            // 
            // col_currency
            // 
            this.col_currency.HeaderText = "ສະກຸນເງິນ";
            this.col_currency.Name = "col_currency";
            this.col_currency.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "ສະຖານະ";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // col_select
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SpringGreen;
            this.col_select.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col_select.HeaderText = "ເລືອກ";
            this.col_select.Name = "col_select";
            this.col_select.ReadOnly = true;
            // 
            // frmBrowseCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 812);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBrowseCar";
            this.Text = "Browse Car";
            this.Load += new System.EventHandler(this.frmBrowseCar_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMake;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_machine_code;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_tank_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_car_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_make;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fuel_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_transmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_engine_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_car_body;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cushion_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_machine_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tan_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_language;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sell_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewButtonColumn col_select;
    }
}