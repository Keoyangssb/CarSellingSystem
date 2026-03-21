using CarSellingSystem.CarsInfo;
using CarSellingSystem.Customer;
using CarSellingSystem.SparePart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;

namespace CarSellingSystem.SaleCar
{
    public partial class frmSaleCar : Form
    {
        public frmSaleCar()
        {
            InitializeComponent();
        }

        public long sell_transaction_id = 0;
        private myClass db = new myClass();
        int car_id = 0;
        double exc_bath_usd = 0;
        double exc_kip_usd = 0;
        int customer_id = 0;

        string targetPath = globalVariable.target_sell_cars_path;

        private void frmSaleCar_Load(object sender, EventArgs e)
        {
            car_id = 0;
            customer_id = 0;

            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", false);
            db.FillCombo(cboModel, "tbl_model", "model_name", "model_id", "", "", false);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", false);
            db.FillCombo(cboColor, "tbl_color", "color_name", "color_id", "status_id=1", "", false);
            db.FillCombo(cboFuelType, "tbl_fuel_type", "fuel_type_name", "fuel_type_id", "status_id=1", "", false);
            db.FillCombo(cboTransmission, "tbl_transmission", "transmission_name", "transmission_id", "", "", false);
            db.FillCombo(cboBodyType, "tbl_body_type", "body_type_name", "body_type_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboEngineSize, "tbl_engine_size", "engine_size_name", "engine_size_id", "status_id=1", "engine_size_name", false);

            db.FillCombo(cbo_pay_full, "tbl_sale_pay_type", "sale_pay_type_name", "sale_pay_type_id", "", "", false);

            db.FillCombo(cboPrint, "tbl_printTitle", "print_name", "print_id", "", "print_id", false);

            //db.FillCombo(cboStatus, "tbl_cars_status", "status_name", "status_id", "", "status_id", false);
            //cboStatus.SelectedIndex = -1;

            if (sell_transaction_id > 0) // edit sell car
            {
                getSellCarInfo();
            }
            else
            {
                clear_form();
                getMasterData();
            }

            dgv_free_item.RowTemplate.Height = 30;
            dgv_attach_file.RowTemplate.Height = 30;
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnSaleCarHistory");
            if (globalVariable.can_add || globalVariable.can_edit)
            {
                btnAddNew.Visible = true;
                btnSave.Visible = true;
                btnPayment.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnPayment.Visible = false;
                db.SetControlsEnabled(this, false);
            }
            if (globalVariable.can_delete)
            {
                btnDelete.Visible = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnDelete.Enabled = true;
            }
            btnClose.Enabled = true;
        }


        private void clear_form()
        {
            sell_transaction_id = 0;
            car_id = 0;

            cboMake.SelectedIndex = -1;
            cboModel.SelectedIndex = -1;
            cboYear.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            cboFuelType.SelectedIndex = -1;
            cboTransmission.SelectedIndex = -1;
            cboBodyType.SelectedIndex = -1;
            cboCurrency.SelectedIndex = -1;
            cboEngineSize.SelectedIndex = -1;
            cboCarStatus.SelectedIndex = -1;

            txt_transaction_no.Text = "";

            customer_id = 0;
            txt_village.Text = "";
            txt_cusFullName.Text = "";
            txt_tel.Text = "";
            txt_district.Text = "";
            txt_province.Text = "";
            txt_card_id.Text = "";
            txt_passport_id.Text = "";
            txt_age.Text = "";

            txt_cushion_type.Text = "";
            txt_language.Text = "";
            txt_machine_code.Text = "";
            txt_sell_price.Text = "";
            txt_tank_code.Text = "";
            car_picture.Image = null;
            car_picture.Tag = "";

            cbo_pay_full.SelectedIndex = 0;
            txt_pay_percent.Text = "";
            txt_pay_detail.Text = "";
            chk_customer_car.Checked = false;

            dgv_attach_file.Rows.Clear();
            dgv_free_item.Rows.Clear();

            dt_customer_car.Enabled = false;

        }

        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            globalVariable.selling_car_id = 0;
            frmBrowseCar frm = new frmBrowseCar();
            frm.ShowDialog();
            if (globalVariable.selling_car_id > 0)
            {
                car_id = globalVariable.selling_car_id;
                getCarInfo();
            }
        }

        private void getSellCarInfo()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_sell_car ";
                sql = sql + " Where sale_id = " + sell_transaction_id;
                
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    car_id = Convert.ToInt32(reader["car_id"]);
                    customer_id = Convert.ToInt32(reader["customer_id"]);

                    txt_transaction_no.Text = reader["sale_no"].ToString();
                    dt_sell_date.Value = Convert.ToDateTime(reader["sale_date"]);

                    txt_war_year.Text = reader["warranty_year"].ToString();
                    txt_war_km.Text = reader["warranty_km"].ToString();
                    cbo_pay_full.SelectedValue = Convert.ToInt32(reader["sale_pay_type_id"]);
                    txt_pay_percent.Text = reader["sale_pay_percent"].ToString();
                    txt_pay_detail.Text = reader["pay_detail"].ToString();
                    if (!string.IsNullOrEmpty(reader["customer_car_date"].ToString()))
                    {
                        chk_customer_car.Checked = true;
                        dt_customer_car.Value = Convert.ToDateTime(reader["customer_car_date"]);
                        dt_customer_car.Enabled = true;
                    }
                    else
                    {
                        dt_customer_car.Enabled = false;
                    }
                    
                    cboCarStatus.SelectedValue = Convert.ToInt32(reader["sell_status_id"]);

                    getCarInfo();
                    getCustomerInfo();
                    getFreeItemInfo();
                    getAttachFileInfo();
                }
                reader.Close();
            }
        }

        private void getFreeItemInfo()
        {
            dgv_free_item.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_sell_car_free_items Where sell_id=" + sell_transaction_id + " And status_id=1 order by free_item_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgv_free_item.Rows.Add();
                        dgv_free_item.Rows[rowIndex].Cells["col_save_item_id"].Value = reader["free_item_id"];
                        dgv_free_item.Rows[rowIndex].Cells["col_item_id"].Value = reader["item_id"];
                        dgv_free_item.Rows[rowIndex].Cells["col_item_name"].Value = reader["item_name"];
                        dgv_free_item.Rows[rowIndex].Cells["col_item_qty"].Value = reader["item_qty"];
                        dgv_free_item.Rows[rowIndex].Cells["col_item_des"].Value = reader["item_description"];
                    }
                }
                conn.Close();
                set_free_item_rowNo();
            }
        }

        private void getAttachFileInfo()
        {
            dgv_attach_file.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_sell_car_attach_file Where sell_id=" + sell_transaction_id + " And status_id=1 order by sell_car_attach_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgv_attach_file.Rows.Add();
                        dgv_attach_file.Rows[rowIndex].Cells["col_attach_item_id"].Value = reader["sell_car_attach_id"];
                        dgv_attach_file.Rows[rowIndex].Cells["col_attach_des"].Value = reader["attach_des"];
                        dgv_attach_file.Rows[rowIndex].Cells["col_fileName"].Value = reader["attach_file_path"];
                    }
                }
                conn.Close();
                set_attachFile_item_rowNo();
            }
        }

        private void getCarInfo()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                if (cboCarStatus.DataSource != null)
                {
                    cboCarStatus.DataSource = null;
                }
                
                string sql = "SELECT * FROM v_buy_car Where car_id=" + car_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        cboMake.SelectedValue = reader["make_id"];
                        cboModel.SelectedValue = reader["model_id"];
                        cboYear.SelectedValue = reader["made_year"];
                        cboColor.SelectedValue = reader["car_color_id"];
                        cboFuelType.SelectedValue = reader["car_color_id"];
                        cboTransmission.SelectedValue = reader["transmission_id"];
                        cboEngineSize.SelectedValue = reader["engine_size_id"];
                        cboBodyType.SelectedValue = reader["body_type_id"];
                        txt_machine_code.Text = reader["machine_code"].ToString();
                        txt_tank_code.Text = reader["tank_code"].ToString();
                        txt_cushion_type.Text = reader["cushion_type"].ToString();
                        txt_language.Text = reader["car_language"].ToString();
                        cboCurrency.SelectedValue = reader["currency_id"];
                        txt_sell_price.Text = Convert.ToDecimal(reader["sale_price"]).ToString(globalVariable.format_currency_lak);
                        if (!string.IsNullOrEmpty(reader["car_image_path"].ToString()))
                        {
                            car_picture.Image = Image.FromFile(reader["car_image_path"].ToString());
                            car_picture.Tag = reader["car_image_path"].ToString();
                        }
                        else
                        {
                            car_picture.Image = null;
                            car_picture.Tag = "";
                        }

                        db.FillCombo(cboCarStatus, "tbl_cars_status", "status_name", "status_id", "status_id=3 OR status_id=" + reader["buy_status_id"], "status_id", false);

                        if (Convert.ToInt32(reader["sell_status_id"]) == 0)
                        {
                            cboCarStatus.SelectedValue = reader["buy_status_id"];
                        }
                        else
                        {
                            cboCarStatus.SelectedValue = reader["sell_status_id"];
                        }
                        calcPercentAmount();
                    }
                }
                conn.Close();
            }
        }

        private void getCustomerInfo()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_customer Where cus_id=" + customer_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txt_cusFullName.Tag = reader["cus_id"].ToString();
                        txt_cusFullName.Text = reader["cus_full_name"].ToString();
                        txt_village.Text = reader["cus_village"].ToString();
                        txt_district.Text = reader["cus_district"].ToString();
                        txt_province.Text = reader["cus_province"].ToString();
                        txt_age.Text = reader["cus_age"].ToString();
                        txt_tel.Text = reader["cus_tel"].ToString();
                        txt_card_id.Text = reader["cus_card_id"].ToString();
                        txt_passport_id.Text = reader["cus_passport_id"].ToString();
                    }
                }
                conn.Close();
            }
        }

        private void getMasterData()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_master Where master_id=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txt_war_year.Text = reader["warranty_year"].ToString();
                        txt_war_km.Text = Convert.ToDecimal(reader["warranty_km"]).ToString(globalVariable.format_currency_lak);
                    }
                }
                conn.Close();
            }
        }

        private void car_picture_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(car_picture.Tag.ToString()))
            {
                frmPreviewImage frm = new frmPreviewImage();
                frm.image_path = car_picture.Tag.ToString();
                frm.ShowDialog();
            }
        }

        private void set_free_item_rowNo()
        {
            for (int i = 0; i < dgv_free_item.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_free_item.Rows[i];
                if (row.Cells["col_save_item_id"].Value == null)
                {
                    row.Cells["col_save_item_id"].Value = 0;
                }
                row.Cells["col_item_no"].Value = i + 1;
                row.Cells["col_browse_item"].Value = "ເລືອກລາຍການ";
                row.Cells["col_item_del"].Value = "ລົບອອກ";

                //row.Cells["col_add_free_item"].Style.BackColor = Color.DarkGray;

            }
        }

        private void dgv_free_item_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }

            string columnName = dgv_free_item.Columns[e.ColumnIndex].Name;

            if (columnName == "col_browse_item")
            {
                globalVariable.get_free_item_id = 0;
                frmBrowseSparePart frm = new frmBrowseSparePart();
                frm.ShowDialog();
                if (globalVariable.get_free_item_id > 0)
                {
                    for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgv_free_item.Rows[i];
                        int existing_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                        if (globalVariable.get_free_item_id == existing_item_id)
                        {
                            if (row.Cells["col_item_qty"].Value != null)
                            {
                                row.Cells["col_item_qty"].Value = Convert.ToInt32(row.Cells["col_item_qty"].Value) + 1;
                            }
                            return;
                        }
                    }

                    DataGridViewRow row2 = dgv_free_item.Rows[e.RowIndex];
                    row2.Cells["col_item_id"].Value = globalVariable.get_free_item_id;
                    row2.Cells["col_item_name"].Value = globalVariable.get_free_item_name;
                    if (row2.Cells["col_item_qty"].Value == null)
                    {
                        row2.Cells["col_item_qty"].Value = 1;
                    }
                }
            }else if (columnName == "col_item_del")
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow row = dgv_free_item.Rows[e.RowIndex];
                        int free_item_id = Convert.ToInt32(row.Cells["col_save_item_id"].Value);
                        if (free_item_id > 0)
                        {
                            string exc_qry = "update tbl_sell_car_free_items set status_id=2,modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "' where free_item_id=" + free_item_id;
                            int exc = db.sqlExecute(exc_qry);
                        }
                        dgv_free_item.Rows.RemoveAt(e.RowIndex);
                        set_free_item_rowNo();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void dgv_free_item_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            set_free_item_rowNo();
            //DataGridViewRow row = dgv_free_item.Rows[e.RowIndex];
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (car_id == 0 || cboMake.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກລົດກ່ອນ.");
                btnSelectCar.Focus();
                return;
            }
            if (customer_id == 0 || txt_cusFullName.Text == "")
            {
                MessageBox.Show("ກະລຸນາເລືອກລູກຄ້າກ່ອນ.");
                txt_cusFullName.Focus();
                return;
            }

            double car_war_year = db.ToNumber(txt_war_year.Text);

            if (car_war_year == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນປີຮັບປະກັນກ່ອນ.");
                txt_war_year.Focus();
                return;
            }

            double car_war_km = db.ToNumber(txt_war_km.Text);

            if (car_war_km == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນປະກັນເປັນກິໂລແມັດກ່ອນ.");
                txt_war_km.Focus();
                return;
            }
            if (cboCarStatus.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກສະຖານະກ່ອນ.");
                cboCarStatus.Focus();
                return;
            }
            if (cbo_pay_full.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກການຊຳລະຄ່າລົດກ່ອນ.");
                cbo_pay_full.Focus();
                return;
            }

            double payPercent = 0;

            int pay_type = Convert.ToInt32(cbo_pay_full.SelectedValue);
            if (pay_type == 2 || pay_type == 3)
            {
                payPercent = db.ToNumber(txt_pay_percent.Text);
                if (payPercent == 0)
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຈ່າຍກ່ອນເປັນເປີເຊັນກ່ອນ.");
                    txt_pay_percent.Focus();
                    return;
                }
            }

            //check free item 
            if (dgv_free_item.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_free_item.Rows[i];
                    if (row.Cells["col_item_name"].Value == null)
                    {
                        MessageBox.Show("ກະລຸນາເລືອກລາຍການເຄື່ອງແຖມໃຫ້ຄົບກ່ອນ.");
                        return;
                    }
                    if (row.Cells["col_item_qty"].Value == null)
                    {
                        MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເຄື່ອງແຖມໃຫ້ຄົບກ່ອນ.");
                        return;
                    }
                }
            }

            if (dgv_attach_file.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_attach_file.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_attach_file.Rows[i];
                    if (row.Cells["col_attach_des"].Value == null)
                    {
                        MessageBox.Show("ກະລຸນາໃສ່ຄຳອະທິບາຍໄຟລ໌ເອກະສານໃຫ້ຄົບກ່ອນ.");
                        return;
                    }
                    if (row.Cells["col_fileName"].Value == null)
                    {
                        MessageBox.Show("ກະລຸນາເລືອກໄຟລ໌ເອກະສານໃຫ້ຄົບກ່ອນ.");
                        return;
                    }
                }
            }


            DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການບັນທຶກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    try
                    {

                        if (dgv_attach_file.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_attach_file.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgv_attach_file.Rows[i];
                                int attach_item_id = 0;
                                string item_fileName = row.Cells["col_fileName"].Value.ToString();

                                if (row.Cells["col_attach_item_id"].Value != null)
                                {
                                    attach_item_id = Convert.ToInt32(row.Cells["col_attach_item_id"].Value);
                                }

                                if (attach_item_id == 0)
                                {
                                    ////if (!Directory.Exists(targetPath))
                                    ////{
                                    ////    Directory.CreateDirectory(targetPath);
                                    ////}
                                    ////string originalPath = item_fileName;
                                    ////File.Copy(targetPath, originalPath, overwrite: true);
                                }
                            }
                        }

                        if (sell_transaction_id == 0)
                        {
                            exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
                            exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

                            string insertQuery = @"
                            INSERT INTO [dbo].[tbl_sell_car] (
                                [sale_id], [run_num], [sale_no], [sale_date], [car_id], 
                                [customer_id], [warranty_year], [warranty_km], [sale_pay_type_id], 
                                [sale_pay_percent], [pay_detail], [customer_car_date], [remarks], 
                                [rate_kip2usd],[rate_bath2usd],[amount_in_text],[status_id], [created_date], [created_user]) 
                            VALUES (
                                @sale_id, @run_num, @sale_no, @sale_date, @car_id, 
                                @customer_id, @warranty_year, @warranty_km, @sale_pay_type_id, 
                                @sale_pay_percent, @pay_detail, @customer_car_date, @remarks, 
                                @rate_kip2usd,@rate_bath2usd,@amount_in_text,@status_id, @created_date, @created_user)";

                            sell_transaction_id = db.XMax("tbl_sell_car", "sale_id", "", 0) + 1;
                            long run_no = db.XMax("tbl_sell_car", "run_num", "", 0) + 1;
                            string sale_no = "";

                            sale_no = run_no.ToString("D3");

                            using (SqlCommand command = new SqlCommand(insertQuery, conn))
                            {
                                command.Parameters.AddWithValue("@sale_id", sell_transaction_id);
                                command.Parameters.AddWithValue("@run_num", run_no);
                                command.Parameters.AddWithValue("@sale_no", sale_no);
                                command.Parameters.AddWithValue("@sale_date", dt_sell_date.Value);
                                command.Parameters.AddWithValue("@car_id", car_id);
                                command.Parameters.AddWithValue("@customer_id", customer_id);
                                command.Parameters.AddWithValue("@warranty_year", car_war_year);
                                command.Parameters.AddWithValue("@warranty_km", car_war_km);
                                command.Parameters.AddWithValue("@sale_pay_type_id", cbo_pay_full.SelectedValue);
                                command.Parameters.AddWithValue("@sale_pay_percent", payPercent);
                                command.Parameters.AddWithValue("@pay_detail", txt_pay_detail.Text == "" ? "" : txt_pay_detail.Text);
                                command.Parameters.AddWithValue("@customer_car_date", chk_customer_car.Checked ? dt_customer_car.Value : (object)DBNull.Value);
                                command.Parameters.AddWithValue("@remarks", "");
                                command.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                                command.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                                command.Parameters.AddWithValue("@amount_in_text", txtAmountInText.Text == "" ? "" : txtAmountInText.Text);
                                command.Parameters.AddWithValue("@status_id", 1);
                                command.Parameters.AddWithValue("@created_date", DateTime.Now);
                                command.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                                conn.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sql = @"
                            UPDATE [dbo].[tbl_sell_car]
                            SET 
                                sale_date = @sale_date,
                                car_id = @car_id,
                                customer_id = @customer_id,
                                warranty_year = @warranty_year,
                                warranty_km = @warranty_km,
                                sale_pay_type_id = @sale_pay_type_id,
                                sale_pay_percent = @sale_pay_percent,
                                pay_detail = @pay_detail,
                                customer_car_date = @customer_car_date,
                                remarks = @remarks,amount_in_text=@amount_in_text,
                                modify_date = @modify_date,
                                modify_user = @modify_user
                            WHERE sale_id = @sale_id";

                            using (SqlCommand command = new SqlCommand(sql, conn))
                            {
                                command.Parameters.AddWithValue("@sale_id", sell_transaction_id);
                                command.Parameters.AddWithValue("@sale_date", dt_sell_date.Value);
                                command.Parameters.AddWithValue("@car_id", car_id);
                                command.Parameters.AddWithValue("@customer_id", customer_id);
                                command.Parameters.AddWithValue("@warranty_year", car_war_year);
                                command.Parameters.AddWithValue("@warranty_km", car_war_km);
                                command.Parameters.AddWithValue("@sale_pay_type_id", cbo_pay_full.SelectedValue);
                                command.Parameters.AddWithValue("@sale_pay_percent", payPercent);
                                command.Parameters.AddWithValue("@pay_detail", txt_pay_detail.Text == "" ? "" : txt_pay_detail.Text);
                                command.Parameters.AddWithValue("@customer_car_date", chk_customer_car.Checked ? dt_customer_car.Value : (object)DBNull.Value);
                                command.Parameters.AddWithValue("@remarks", "");
                                command.Parameters.AddWithValue("@amount_in_text", txtAmountInText.Text == "" ? "" : txtAmountInText.Text);
                                command.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                command.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                conn.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                            }
                        }

                        if (dgv_free_item.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgv_free_item.Rows[i];
                                int free_item_id = Convert.ToInt32(row.Cells["col_save_item_id"].Value);
                                int item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                                string item_name = row.Cells["col_item_name"].Value.ToString();
                                double item_qty = db.ToNumber(row.Cells["col_item_qty"].Value.ToString());
                                if (item_qty == 0)
                                {
                                    item_qty = 1;
                                }
                                string item_desc = "";
                                if (row.Cells["col_item_des"].Value != null)
                                {
                                    item_desc = row.Cells["col_item_des"].Value.ToString();
                                }

                                string sql_free_item = "";

                                if (free_item_id == 0)
                                {
                                    sql_free_item = @"
                                    INSERT INTO [dbo].[tbl_sell_car_free_items]
                                    (
                                        [sell_id],
                                        [item_id],
                                        [item_name],
                                        [item_price],
                                        [item_qty],
                                        [item_description],
                                        [status_id],
                                        [modify_date],
                                        [modify_user]
                                    )
                                    VALUES
                                    (
                                        @sell_id,
                                        @item_id,
                                        @item_name,
                                        @item_price,
                                        @item_qty,
                                        @item_description,
                                        @status_id,
                                        @modify_date,
                                        @modify_user
                                    );";

                                    SqlCommand cmd_free_item = new SqlCommand(sql_free_item, conn);

                                    cmd_free_item.Parameters.AddWithValue("@sell_id", sell_transaction_id);
                                    cmd_free_item.Parameters.AddWithValue("@item_id", item_id);
                                    cmd_free_item.Parameters.AddWithValue("@item_name", item_name);
                                    cmd_free_item.Parameters.AddWithValue("@item_price", 0);
                                    cmd_free_item.Parameters.AddWithValue("@item_qty", item_qty);
                                    cmd_free_item.Parameters.AddWithValue("@item_description", item_desc);
                                    cmd_free_item.Parameters.AddWithValue("@status_id", 1);
                                    cmd_free_item.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                    cmd_free_item.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                    cmd_free_item.ExecuteNonQuery();
                                }
                                else
                                {
                                    sql_free_item = @"
                                    UPDATE [dbo].[tbl_sell_car_free_items]
                                    SET 
                                        sell_id = @sell_id,
                                        item_id = @item_id,
                                        item_name = @item_name,
                                        item_price = @item_price,
                                        item_qty = @item_qty,
                                        item_description = @item_description,
                                        modify_date = @modify_date,
                                        modify_user = @modify_user
                                        WHERE free_item_id = @free_item_id";

                                    SqlCommand cmd_free_item = new SqlCommand(sql_free_item, conn);

                                    cmd_free_item.Parameters.AddWithValue("@free_item_id", free_item_id);
                                    cmd_free_item.Parameters.AddWithValue("@sell_id", sell_transaction_id);
                                    cmd_free_item.Parameters.AddWithValue("@item_id", item_id);
                                    cmd_free_item.Parameters.AddWithValue("@item_name", item_name);
                                    cmd_free_item.Parameters.AddWithValue("@item_price", 0);
                                    cmd_free_item.Parameters.AddWithValue("@item_qty", item_qty);
                                    cmd_free_item.Parameters.AddWithValue("@item_description", item_desc);
                                    cmd_free_item.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                    cmd_free_item.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                    cmd_free_item.ExecuteNonQuery();
                                }
                            }
                        }

                        if (dgv_attach_file.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_attach_file.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgv_attach_file.Rows[i];
                                int attach_item_id = 0;
                                string item_desc = row.Cells["col_attach_des"].Value.ToString();
                                string item_fileName = row.Cells["col_fileName"].Value.ToString();

                                if (row.Cells["col_attach_item_id"].Value != null)
                                {
                                    attach_item_id = Convert.ToInt32(row.Cells["col_attach_item_id"].Value);
                                }

                                string sql_attach_item = "";
                                //string fullPath = "";

                                if (attach_item_id == 0)
                                {
                                    //if (!Directory.Exists(targetPath))
                                    //{
                                    //    Directory.CreateDirectory(targetPath);
                                    //}

                                    //string originalPath = item_fileName;
                                    //File.Copy(targetPath, originalPath, overwrite: true);

                                    sql_attach_item = @"
                                    INSERT INTO [dbo].[tbl_sell_car_attach_file]
                                    (
                                        [sell_id],
                                        [attach_des],
                                        [attach_file_path],
                                        [status_id]
                                    )
                                    VALUES
                                    (
                                        @sell_id,
                                        @attach_des,
                                        @attach_file_path,
                                        @status_id
                                    );";

                                    SqlCommand cmd_free_item = new SqlCommand(sql_attach_item, conn);

                                    cmd_free_item.Parameters.AddWithValue("@sell_id", sell_transaction_id);
                                    cmd_free_item.Parameters.AddWithValue("@attach_des", item_desc);
                                    cmd_free_item.Parameters.AddWithValue("@attach_file_path", item_fileName);
                                    cmd_free_item.Parameters.AddWithValue("@status_id", 1);
                                    cmd_free_item.ExecuteNonQuery();
                                }
                                else
                                {
                                    sql_attach_item = @"
                                    UPDATE [dbo].[tbl_sell_car_attach_file]
                                    SET 
                                        attach_des = @attach_des
                                        WHERE sell_car_attach_id = @sell_car_attach_id";

                                    SqlCommand cmd_free_item = new SqlCommand(sql_attach_item, conn);

                                    cmd_free_item.Parameters.AddWithValue("@sell_car_attach_id", attach_item_id);
                                    cmd_free_item.Parameters.AddWithValue("@attach_des", item_desc);
                                    cmd_free_item.ExecuteNonQuery();
                                }
                            }
                        }

                        string sql_update = @"UPDATE [dbo].[tbl_cars_info] SET sell_status_id = @sell_status_id WHERE car_id = @car_id";

                        SqlCommand cmd_update = new SqlCommand(sql_update, conn);

                        cmd_update.Parameters.AddWithValue("@car_id", car_id);
                        cmd_update.Parameters.AddWithValue("@sell_status_id", cboCarStatus.SelectedValue);
                        cmd_update.ExecuteNonQuery();

                        MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                        conn.Close();
                        getSellCarInfo();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                        conn.Close();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (sell_transaction_id > 0)
            {
                long paymentId = db.nLookup("pay_id", "tbl_sell_car_payment", "status_id = 1 And sell_id=" + sell_transaction_id);
                if (paymentId > 0)
                {
                    MessageBox.Show("ໄດ້ມີການຊຳລະແລ້ວ ບໍ່ສາມາດລົບອອກໄດ້.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບຂໍ້ມູນຂາຍລົດລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int del_car = db.sqlExecute("Update tbl_cars_info Set sell_status_id=0 Where car_id=" + car_id);
                    int del_freeItem = db.sqlExecute("Update tbl_sell_car_free_items Set status_id=2 Where sell_id=" + sell_transaction_id);
                    int del_attachFile = db.sqlExecute("Update tbl_sell_car_attach_file Set status_id=2 Where sell_id=" + sell_transaction_id);
                    int del_buy = db.sqlExecute("Update tbl_sell_car Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where sale_id=" + sell_transaction_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    clear_form();
                }
            }
        }

        private void btnSaveToReceipt_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbo_pay_full_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pay_type = Convert.ToInt32(cbo_pay_full.SelectedValue);
            if (pay_type == 2 || pay_type == 3)
            {
                txt_pay_percent.ReadOnly = false;
            }
            else
            {
                txt_pay_percent.Text = "";
                txt_pay_percent.ReadOnly = true;
            }
            calcPercentAmount();
        }

        private void dgv_attach_file_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }

            string columnName = dgv_attach_file.Columns[e.ColumnIndex].Name;

            if (columnName == "col_upload_file")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select a file...",
                    Filter = "Image and PDF Files|*.jpg;*.jpeg;*.png;*.pdf;"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataGridViewRow row = dgv_attach_file.Rows[e.RowIndex];
                        row.Cells["col_fileName"].Value = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
            else if (columnName == "col_open_file")
            {
                DataGridViewRow row = dgv_attach_file.Rows[e.RowIndex];
                if (row.Cells["col_fileName"].Value != null)
                {
                    string filePath = row.Cells["col_fileName"].Value.ToString();
                    string extension = Path.GetExtension(filePath).ToLower();
                    if (extension == ".pdf")
                    {
                        // It's a PDF
                        System.Diagnostics.Process.Start("explorer", filePath);
                    }
                    else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {
                        frmPreviewImage frm = new frmPreviewImage();
                        frm.image_path = filePath;
                        frm.ShowDialog();
                    }
                }
            }
            else if (columnName == "col_del_file")
            {
                DataGridViewRow row = dgv_attach_file.Rows[e.RowIndex];
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (row.Cells["col_attach_item_id"].Value != null)
                        {
                            int free_item_id = Convert.ToInt32(row.Cells["col_attach_item_id"].Value);
                            if (free_item_id > 0)
                            {
                                string exc_qry = "update tbl_sell_car_attach_file set status_id=2 where sell_car_attach_id=" + free_item_id;
                                int exc = db.sqlExecute(exc_qry);
                            }
                        }
                        dgv_attach_file.Rows.RemoveAt(e.RowIndex);
                        set_attachFile_item_rowNo();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void set_attachFile_item_rowNo()
        {
            for (int i = 0; i < dgv_attach_file.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_attach_file.Rows[i];
                row.Cells["col_attach_no"].Value = i + 1;
                row.Cells["col_upload_file"].Value = "ອັບໂລດໄຟລ໌";
                row.Cells["col_open_file"].Value = "ເປີດໄຟລ໌";
                row.Cells["col_del_file"].Value = "ລົບໄຟລ໌";
            }
        }

        private void btnAddItemFree_Click(object sender, EventArgs e)
        {
            dgv_free_item.Rows.Add();
            set_free_item_rowNo();
        }

        private void btnAddItemAttchFile_Click(object sender, EventArgs e)
        {
            dgv_attach_file.Rows.Add();
            set_attachFile_item_rowNo();
        }

        private void txt_pay_percent_TextChanged(object sender, EventArgs e)
        {
            calcPercentAmount();
        }

        private void calcPercentAmount()
        {
            txt_pay_percentAmount.Text = "";
            if (Convert.ToInt32(cbo_pay_full.SelectedValue) == 2 || Convert.ToInt32(cbo_pay_full.SelectedValue) == 3)
            {
                double c_amount = db.ToNumber(txt_sell_price.Text);
                double perc_num = 0;
                double payAmount = 0;
                if (txt_pay_percent.Text != "")
                {
                    perc_num = db.ToNumber(txt_pay_percent.Text);
                }
                payAmount = (c_amount * perc_num) / 100;
                txt_pay_percentAmount.Text = payAmount.ToString(globalVariable.format_currency_usd);
            }
        }

        private void btnBrowseCustomer_Click(object sender, EventArgs e)
        {
            frmBrowseCustomer frm = new frmBrowseCustomer();
            frm.ShowDialog();
            if (globalVariable.selling_customer_id > 0)
            {
                customer_id = globalVariable.selling_customer_id;
                getCustomerInfo();
            }
        }
       
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (sell_transaction_id > 0)
            {
                frmSaleCarPayment frm = new frmSaleCarPayment();
                frm.sale_transaction_id = sell_transaction_id;
                frm.ShowDialog();
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (sell_transaction_id == 0)
            {
                return;
            }

            int prinId = Convert.ToInt32(cboPrint.SelectedValue);
            frmPrintPreview frm = new frmPrintPreview();
            frm.print_transaction_id = sell_transaction_id;

            decimal salePrice = db.ToNumberDecimal(txt_sell_price.Text);
            string saleCarPriceText = "";
            if (salePrice > 0)
            {
                saleCarPriceText = db.NumberToCurrencyDollar(salePrice);
            }

            if (prinId == 1)
            {
                frm.report_name = "SalesAndWarrantyAgreement";
                frm.report_query = "select * from v_sell_car where sale_id=" + sell_transaction_id;
                frm.report_query2 = "select * from v_sell_car_payment where sale_id=" + sell_transaction_id;
                frm.report_query3 = "select * from tbl_sell_car_free_items where sell_id=" + sell_transaction_id + " And status_id=1 Order by free_item_id";
            }
            else if (prinId == 2)
            {
                frm.report_name = "rptSalesReceipt";
                frm.report_query = "select *,N'" + saleCarPriceText + "' as saleCarPriceText from v_sell_car where sale_id=" + sell_transaction_id;
                frm.report_query2 = "select * from v_sell_car_payment where sale_id=" + sell_transaction_id;
            }
            else if (prinId == 3)
            {
                frm.report_name = "SaleFreeItemAndWarranty";
                frm.report_query = "select * from tbl_sell_car_free_items where sell_id=" + sell_transaction_id + " And status_id=1 Order by free_item_id";
            }
            else if (prinId == 4)
            {
                string salePrice_format = "";
                string paid_date = "";
                string paid_amount = "";
                string paid_amount_text = "";
                string balance = "";
                string balance_text = "";

                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    string sql = "SELECT * FROM tbl_sell_car_payment Where sell_pay_type_id = 2 And status_id = 1 And sell_id=" + sell_transaction_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            decimal paid_amount_num = Convert.ToDecimal(reader["total_pay_in_usd"]);
                            decimal car_balance = salePrice - paid_amount_num;

                            saleCarPriceText = "(" + db.NumberToCurrencyDollar(salePrice) + "ສະຫາລັດຖ້ວນ)";
                            paid_amount_text = "(" +  db.NumberToCurrencyDollar(paid_amount_num) + "ສະຫາລັດຖ້ວນ)";
                            balance_text = "(" + db.NumberToCurrencyDollar(car_balance) + "ສະຫາລັດຖ້ວນ)";

                            paid_date = Convert.ToDateTime(reader["pay_date"]).ToString(globalVariable.format_date);
                            salePrice_format = salePrice.ToString(globalVariable.format_currency_lak) + " $";
                            paid_amount = paid_amount_num.ToString(globalVariable.format_currency_lak) + " $";
                            balance = car_balance.ToString(globalVariable.format_currency_lak) + " $";

                        }
                    }
                }
                frm.report_name = "rptOrderCarDepositAgreement";
                string rptSql = "select *,N'" + saleCarPriceText + "' as saleCarPriceText,N'" + paid_amount_text + "' as paid_amount_text,N'" + balance_text + "' as balance_text, " +
                " N'" + paid_date + "' as paid_date,N'" + salePrice_format + "' as salePrice_format,N'" + paid_amount + "' as paid_amount, N'" + balance + "' as car_balance from v_sell_car " +
                " where sale_id=" + sell_transaction_id;
                frm.report_query = rptSql;
            }
            else if (prinId == 5)
            {
                string salePrice_format = "";
                string paid_date = "";
                string paid_amount = "";
                string paid_amount_text = "";
                string balance = "";
                string balance_text = "";

                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    string sql = "SELECT * FROM tbl_sell_car_payment Where sell_pay_type_id = 2 And status_id = 1 And sell_id=" + sell_transaction_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            decimal paid_amount_num = Convert.ToDecimal(reader["total_pay_in_usd"]);
                            decimal car_balance = salePrice - paid_amount_num;

                            saleCarPriceText = "(" + db.NumberToCurrencyDollar(salePrice) + "ສະຫາລັດຖ້ວນ)";
                            paid_amount_text = "(" + db.NumberToCurrencyDollar(paid_amount_num) + "ສະຫາລັດຖ້ວນ)";
                            balance_text = "(" + db.NumberToCurrencyDollar(car_balance) + "ສະຫາລັດຖ້ວນ)";

                            paid_date = Convert.ToDateTime(reader["pay_date"]).ToString(globalVariable.format_date);
                            salePrice_format = salePrice.ToString(globalVariable.format_currency_lak) + " $";
                            paid_amount = paid_amount_num.ToString(globalVariable.format_currency_lak) + " $";
                            balance = car_balance.ToString(globalVariable.format_currency_lak) + " $";

                        }
                    }
                }
                frm.report_name = "rptDepositAgreement";
                string rptSql = "select *,N'" + saleCarPriceText + "' as saleCarPriceText,N'" + paid_amount_text + "' as paid_amount_text,N'" + balance_text + "' as balance_text, " +
                " N'" + paid_date + "' as paid_date,N'" + salePrice_format + "' as salePrice_format,N'" + paid_amount + "' as paid_amount, N'" + balance + "' as car_balance from v_sell_car " +
                 " where sale_id=" + sell_transaction_id;
                frm.report_query = rptSql;
            }
            frm.ShowDialog();
        }

        private void chk_customer_car_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_customer_car.Checked)
            {
                dt_customer_car.Enabled = true;
                dt_customer_car.Value = DateTime.Now.Date;
                dt_customer_car.Checked = true;
            }
            else
            {
                dt_customer_car.Enabled = false;
                dt_customer_car.CustomFormat = " ";
                dt_customer_car.Checked = false;
            }
        }

        private void txt_pay_percentAmount_TextChanged(object sender, EventArgs e)
        {
            decimal amount = db.ToNumberDecimal(txt_pay_percentAmount.Text);
            txtAmountInText.Text = "";
            if (amount > 0)
            {
                txtAmountInText.Text = db.NumberToCurrencyDollar(amount);
            }
        }
    }
}
