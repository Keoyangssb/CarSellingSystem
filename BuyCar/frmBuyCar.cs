using CarSellingSystem.MasterData;
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
using System.Windows.Forms;

namespace CarSellingSystem.BuyCar
{
    public partial class frmBuyCar : Form
    {
        public frmBuyCar()
        {
            InitializeComponent();
        }

        public long buy_transaction_id = 0;

        private myClass db = new myClass();
        long car_id = 0;

        double exc_bath_usd = 0;
        double exc_kip_usd = 0;

        private void frmBuyCar_Load(object sender, EventArgs e)
        {
            lblBuyKipBath.Text = "0 ກີບ | 0.00 ບາດ";
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1","", false);
            //db.FillCombo(cboModel, "tbl_model", "make_name", "make_id", "", false);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", false);
            db.FillCombo(cboColor, "tbl_color", "color_name", "color_id", "status_id=1", "", false);
            db.FillCombo(cboFuelType, "tbl_fuel_type", "fuel_type_name", "fuel_type_id", "status_id=1", "", false);
            db.FillCombo(cboTransmission, "tbl_transmission", "transmission_name", "transmission_id", "", "", false);
            db.FillCombo(cboBodyType, "tbl_body_type", "body_type_name", "body_type_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboEngineSize, "tbl_engine_size", "engine_size_name", "engine_size_id", "status_id=1", "engine_size_name", false);
            db.FillCombo(cboCarStatus, "tbl_cars_status", "status_name", "status_id", "status_id=1 OR status_id=2", "status_id", false);
            cboCarStatus.SelectedIndex = -1;

            car_picture.Image = null;
            car_picture.Tag = "";

            txt_free_itemName.Text = "";
            txt_free_itemName.Tag = 0;
            globalVariable.get_free_item_id = 0;
            globalVariable.get_free_item_name = "";

            exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
            exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

            if (buy_transaction_id > 0)
            {
                getBuyData();
                getBuyFreeItem();
            }
            cboCurrency.SelectedValue = 3;
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnBuyCarList");
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

        private void getBuyData()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_buy_car Where buy_id=" + buy_transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        date_buy.Value = Convert.ToDateTime(reader["buy_date"].ToString());
                        cboMake.SelectedValue = reader["make_id"];
                        cboModel.SelectedValue = reader["model_id"];
                        cboYear.SelectedValue = reader["made_year"];
                        cboColor.SelectedValue = reader["car_color_id"];
                        cboFuelType.SelectedValue = reader["car_color_id"];
                        cboTransmission.SelectedValue = reader["transmission_id"];
                        cboEngineSize.SelectedValue = reader["engine_size_id"];
                        cboBodyType.SelectedValue = reader["body_type_id"];
                        cboCarStatus.SelectedValue = reader["buy_status_id"];
                        txt_machine_code.Text = reader["machine_code"].ToString();
                        txt_tank_code.Text = reader["tank_code"].ToString();
                        txt_cushion_type.Text = reader["cushion_type"].ToString();
                        txt_language.Text = reader["car_language"].ToString();
                        cboCurrency.SelectedValue = reader["currency_id"];
                        txt_buy_price.Text = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                        txt_fee_price.Text = Convert.ToDecimal(reader["fee_price"]).ToString(globalVariable.format_currency_usd);
                        txt_kota_price.Text = Convert.ToDecimal(reader["kota_price"]).ToString(globalVariable.format_currency_usd);
                        txt_sell_price.Text = Convert.ToDecimal(reader["sale_price"]).ToString(globalVariable.format_currency_usd);
                        txtTax.Text = Convert.ToDecimal(reader["tax_price"]).ToString(globalVariable.format_currency_usd);
                        txt_remark.Text = reader["remarks"].ToString();
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
                        decimal totalBuyKip = Convert.ToDecimal(reader["buy_price"]) * Convert.ToDecimal(reader["buy_rate_kip2usd"]);
                        decimal totalBuyBath = Convert.ToDecimal(reader["buy_price"]) * Convert.ToDecimal(reader["buy_rate_bath2usd"]);
                        lblBuyKipBath.Text = totalBuyKip.ToString(globalVariable.format_currency_lak) + " ກີບ | " + totalBuyBath.ToString(globalVariable.format_currency_usd) + " ບາດ";
                    }
                }
                conn.Close();
            }
        }

        private void getBuyFreeItem()
        {
            dgv_free_item.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_buy_cars_free_items Where buy_id=" + buy_transaction_id + " And status_id=1 order by free_item_id";
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
                        dgv_free_item.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                set_free_item_rowNo();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMake.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຍີ່ຫໍ່ກ່ອນ.");
                cboMake.Focus();
                return;
            }
            if (cboModel.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກລຸ້ນລົດກ່ອນ.");
                cboModel.Focus();
                return;
            }
            if (cboYear.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປີກ່ອນ.");
                cboYear.Focus();
                return;
            }
            if (cboColor.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກສີກ່ອນ.");
                cboColor.Focus();
                return;
            }
            if (cboFuelType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປະເພດນ້ຳມັນກ່ອນ.");
                cboFuelType.Focus();
                return;
            }
            if (cboTransmission.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກລະບົບເກຍກ່ອນ.");
                cboTransmission.Focus();
                return;
            }
            if (cboEngineSize.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຂະໜາດຈັກກ່ອນ.");
                cboEngineSize.Focus();
                return;
            }
            if (cboBodyType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປະເພດຕົວລົດກ່ອນ.");
                cboBodyType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_machine_code.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນເລກຈັກກ່ອນ.");
                txt_machine_code.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_tank_code.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນເລກຖັງກ່ອນ.");
                txt_tank_code.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_cushion_type.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນປະເພດເບາະກ່ອນ.");
                txt_cushion_type.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_language.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນພາສາກ່ອນ.");
                txt_language.Focus();
                return;
            }

            if (cboCarStatus.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກສະຖານະກ່ອນ.");
                cboCarStatus.Focus();
                return;
            }

            double buy_price = db.ToNumber(txt_buy_price.Text);

            if (buy_price == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນລາຄາຊື້ກ່ອນ.");
                txt_buy_price.Focus();
                return;
            }

            double tax_price = db.ToNumber(txtTax.Text);

            double fee_price = db.ToNumber(txt_fee_price.Text);

            if (fee_price == 0)
            {
                MessageBox.Show("ກະລຸນາປ້ອນຄ່າທຳນຽນກ່ອນ.");
                txt_fee_price.Focus();
                return;
            }

            double kota_price = db.ToNumber(txt_kota_price.Text);
            double sell_price = db.ToNumber(txt_sell_price.Text);
            string fullPath = "";

            DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການບັນທຶກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.No)
            {
                return;
            }

            //upload image
            string targetPath = globalVariable.target_cars_path;

            try
            {
                if (car_picture.Image != null)
                {
                    if (buy_transaction_id == 0)
                    {
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        string originalPath = car_picture.Tag.ToString();
                        string extension = ".jpg"; // default
                        if (!string.IsNullOrEmpty(originalPath))
                        {
                            extension = Path.GetExtension(originalPath);
                        }
                        string fileName = "CarImage_" + globalVariable.g_user_id.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                        fullPath = Path.Combine(targetPath, fileName);
                        car_picture.Image.Save(fullPath);
                    }
                    else
                    {
                        string originalPath = car_picture.Tag.ToString();
                        string image_old_path = db.XLookup("car_image_path", "v_buy_car", "buy_id=" + buy_transaction_id);
                        if (!string.IsNullOrEmpty(image_old_path))
                        {
                            if (originalPath == image_old_path)
                            {
                                fullPath = image_old_path;
                            }
                            else
                            {
                                string extension = ".jpg"; // default
                                if (!string.IsNullOrEmpty(originalPath))
                                {
                                    extension = Path.GetExtension(originalPath);
                                }
                                string fileName = "CarImage_" + globalVariable.g_user_id.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                                fullPath = Path.Combine(targetPath, fileName);
                                car_picture.Image.Save(fullPath);
                            }
                        }
                        else
                        {
                            string extension = ".jpg"; // default
                            if (!string.IsNullOrEmpty(originalPath))
                            {
                                extension = Path.GetExtension(originalPath);
                            }
                            string fileName = "CarImage_" + globalVariable.g_user_id.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                            fullPath = Path.Combine(targetPath, fileName);
                            car_picture.Image.Save(fullPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload ຮູບມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
            }


            if (buy_transaction_id == 0)
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    string sql = @"
                    INSERT INTO [dbo].[tbl_cars_info] (
                        car_id, model_id, made_year, car_color_id, fuel_type_id, transmission_id, 
                        engine_size_id, body_type_id, machine_code, tank_code, cushion_type, 
                        car_language, currency_id, buy_rate_bath2usd, buy_rate_kip2usd, 
                        sell_rate_bath2usd, sell_rate_kip2usd, buy_price, fee_price, kota_price, 
                        sale_price, remarks, car_image_path, status_id, buy_status_id,sell_status_id,tax_price)
                    VALUES (
                        @car_id, @model_id, @made_year, @car_color_id, @fuel_type_id, @transmission_id, 
                        @engine_size_id, @body_type_id, @machine_code, @tank_code, @cushion_type, 
                        @car_language, @currency_id, @buy_rate_bath2usd, @buy_rate_kip2usd, 
                        @sell_rate_bath2usd, @sell_rate_kip2usd, @buy_price, @fee_price, @kota_price, 
                        @sale_price, @remarks, @car_image_path, @status_id, @buy_status_id,@sell_status_id,@tax_price);
                    ";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
                    exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

                    car_id = db.XMax("tbl_cars_info", "car_id", "", 0) + 1;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@car_id", car_id);
                    cmd.Parameters.AddWithValue("@model_id", cboModel.SelectedValue);
                    cmd.Parameters.AddWithValue("@made_year", cboYear.Text);
                    cmd.Parameters.AddWithValue("@car_color_id", cboColor.SelectedValue);
                    cmd.Parameters.AddWithValue("@fuel_type_id", cboFuelType.SelectedValue);
                    cmd.Parameters.AddWithValue("@transmission_id", cboTransmission.SelectedValue);
                    cmd.Parameters.AddWithValue("@engine_size_id", cboEngineSize.SelectedValue);
                    cmd.Parameters.AddWithValue("@body_type_id", cboBodyType.SelectedValue);
                    cmd.Parameters.AddWithValue("@machine_code", txt_machine_code.Text);
                    cmd.Parameters.AddWithValue("@tank_code", txt_tank_code.Text);
                    cmd.Parameters.AddWithValue("@cushion_type", txt_cushion_type.Text);
                    cmd.Parameters.AddWithValue("@car_language", txt_language.Text);
                    cmd.Parameters.AddWithValue("@currency_id", cboCurrency.SelectedValue);
                    cmd.Parameters.AddWithValue("@buy_rate_bath2usd", exc_bath_usd);
                    cmd.Parameters.AddWithValue("@buy_rate_kip2usd", exc_kip_usd);
                    cmd.Parameters.AddWithValue("@sell_rate_bath2usd", exc_bath_usd);
                    cmd.Parameters.AddWithValue("@sell_rate_kip2usd", exc_kip_usd);
                    cmd.Parameters.AddWithValue("@buy_price", buy_price);
                    cmd.Parameters.AddWithValue("@fee_price", fee_price);
                    cmd.Parameters.AddWithValue("@kota_price", kota_price);
                    cmd.Parameters.AddWithValue("@sale_price", sell_price);
                    cmd.Parameters.AddWithValue("@remarks", string.IsNullOrEmpty(txt_remark.Text) ? "" : txt_remark.Text);
                    cmd.Parameters.AddWithValue("@car_image_path", fullPath);
                    cmd.Parameters.AddWithValue("@status_id", 1);
                    cmd.Parameters.AddWithValue("@buy_status_id", cboCarStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@sell_status_id", 0);
                    cmd.Parameters.AddWithValue("@tax_price", tax_price);

                    string sql_buy_car = @"
                    INSERT INTO [dbo].[tbl_buy_cars]
                    (   
                        [buy_id],
                        [buy_no],
                        [buy_date],
                        [car_id],
                        [remarks],
                        [status_id],
                        [created_date],
                        [created_user]
                    )
                    VALUES
                    (
                        @buy_id,
                        @buy_no,
                        @buy_date,
                        @car_id,
                        @remarks,
                        @status_id,
                        @created_date,
                        @created_user
                    );";

                    buy_transaction_id = db.XMax("tbl_buy_cars", "buy_id", "", 0) + 1;

                    SqlCommand cmd_buy_car = new SqlCommand(sql_buy_car, conn);
                    cmd_buy_car.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                    cmd_buy_car.Parameters.AddWithValue("@buy_no", "");
                    cmd_buy_car.Parameters.AddWithValue("@buy_date", date_buy.Value);
                    cmd_buy_car.Parameters.AddWithValue("@car_id", car_id);
                    cmd_buy_car.Parameters.AddWithValue("@remarks", string.IsNullOrEmpty(txt_remark.Text) ? "" : txt_remark.Text);
                    cmd_buy_car.Parameters.AddWithValue("@status_id", 1);
                    cmd_buy_car.Parameters.AddWithValue("@created_date", DateTime.Now);
                    cmd_buy_car.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        int exc_buy_car = cmd_buy_car.ExecuteNonQuery();

                        if (dgv_free_item.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgv_free_item.Rows[i];
                                int item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                                string item_name = row.Cells["col_item_name"].Value.ToString();
                                int item_qty = Convert.ToInt32(row.Cells["col_item_qty"].Value);
                                string item_desc = "";
                                if (!string.IsNullOrEmpty(row.Cells["col_item_des"].Value.ToString()))
                                {
                                    item_desc = row.Cells["col_item_des"].Value.ToString();
                                }

                                string sql_free_item = @"
                                INSERT INTO [dbo].[tbl_buy_cars_free_items]
                                (
                                    [buy_id],
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
                                    @buy_id,
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

                                cmd_free_item.Parameters.AddWithValue("@buy_id", buy_transaction_id);                      // Example buy_id
                                cmd_free_item.Parameters.AddWithValue("@item_id", item_id);                   // Example item_id
                                cmd_free_item.Parameters.AddWithValue("@item_name", item_name);
                                cmd_free_item.Parameters.AddWithValue("@item_price", 0);
                                cmd_free_item.Parameters.AddWithValue("@item_qty", item_qty);
                                cmd_free_item.Parameters.AddWithValue("@item_description", item_desc);
                                cmd_free_item.Parameters.AddWithValue("@status_id", 1);
                                cmd_free_item.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                cmd_free_item.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                cmd_free_item.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");

                        conn.Close();
                        clear_form();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                        conn.Close();
                    }
                }
            }
            else
            {
                car_id = db.nLookup("car_id", "tbl_buy_cars", "buy_id=" + buy_transaction_id);

                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    string sql = @"
                    UPDATE [dbo].[tbl_cars_info]
                    SET 
                        model_id = @model_id,
                        made_year = @made_year,
                        car_color_id = @car_color_id,
                        fuel_type_id = @fuel_type_id,
                        transmission_id = @transmission_id,
                        engine_size_id = @engine_size_id,
                        body_type_id = @body_type_id,
                        machine_code = @machine_code,
                        tank_code = @tank_code,
                        cushion_type = @cushion_type,
                        car_language = @car_language,
                        buy_price = @buy_price,
                        fee_price = @fee_price,
                        kota_price = @kota_price,
                        sale_price = @sale_price,
                        remarks = @remarks,
                        car_image_path = @car_image_path,
                        buy_status_id = @buy_status_id,
                        tax_price = @tax_price
                        WHERE car_id = @car_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@car_id", car_id);
                    cmd.Parameters.AddWithValue("@model_id", cboModel.SelectedValue);
                    cmd.Parameters.AddWithValue("@made_year", cboYear.Text);
                    cmd.Parameters.AddWithValue("@car_color_id", cboColor.SelectedValue);
                    cmd.Parameters.AddWithValue("@fuel_type_id", cboFuelType.SelectedValue);
                    cmd.Parameters.AddWithValue("@transmission_id", cboTransmission.SelectedValue);
                    cmd.Parameters.AddWithValue("@engine_size_id", cboEngineSize.SelectedValue);
                    cmd.Parameters.AddWithValue("@body_type_id", cboBodyType.SelectedValue);
                    cmd.Parameters.AddWithValue("@machine_code", txt_machine_code.Text);
                    cmd.Parameters.AddWithValue("@tank_code", txt_tank_code.Text);
                    cmd.Parameters.AddWithValue("@cushion_type", txt_cushion_type.Text);
                    cmd.Parameters.AddWithValue("@car_language", txt_language.Text);
                    cmd.Parameters.AddWithValue("@buy_price", buy_price);
                    cmd.Parameters.AddWithValue("@fee_price", fee_price);
                    cmd.Parameters.AddWithValue("@kota_price", kota_price);
                    cmd.Parameters.AddWithValue("@sale_price", sell_price);
                    cmd.Parameters.AddWithValue("@remarks", string.IsNullOrEmpty(txt_remark.Text) ? "" : txt_remark.Text);
                    cmd.Parameters.AddWithValue("@car_image_path", fullPath);
                    cmd.Parameters.AddWithValue("@buy_status_id", cboCarStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@tax_price", tax_price);

                    string sql_buy_car = @"
                        UPDATE [dbo].[tbl_buy_cars]
                        SET buy_date = @buy_date,
                            remarks = @remarks,
                            modify_date = @modify_date,
                            modify_user = @modify_user
                        WHERE buy_id = @buy_id";

                    SqlCommand cmd_buy_car = new SqlCommand(sql_buy_car, conn);
                    cmd_buy_car.Parameters.AddWithValue("@buy_id", buy_transaction_id);
                    cmd_buy_car.Parameters.AddWithValue("@buy_date", date_buy.Value);
                    cmd_buy_car.Parameters.AddWithValue("@remarks", string.IsNullOrEmpty(txt_remark.Text) ? "" : txt_remark.Text);
                    cmd_buy_car.Parameters.AddWithValue("@modify_date", DateTime.Now);
                    cmd_buy_car.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        int exc_buy_car = cmd_buy_car.ExecuteNonQuery();

                        if (dgv_free_item.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                            {
                                DataGridViewRow row = dgv_free_item.Rows[i];

                                int free_item_id = Convert.ToInt32(row.Cells["col_save_item_id"].Value);

                                int item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                                string item_name = row.Cells["col_item_name"].Value.ToString();
                                int item_qty = Convert.ToInt32(row.Cells["col_item_qty"].Value);
                                string item_desc = "";
                                if (!string.IsNullOrEmpty(row.Cells["col_item_des"].Value.ToString()))
                                {
                                    item_desc = row.Cells["col_item_des"].Value.ToString();
                                }

                                string sql_free_item = "";

                                if (free_item_id == 0)
                                {
                                    sql_free_item = @"
                                    INSERT INTO [dbo].[tbl_buy_cars_free_items]
                                    (
                                        [buy_id],
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
                                        @buy_id,
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

                                    cmd_free_item.Parameters.AddWithValue("@buy_id", buy_transaction_id);
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
                                    UPDATE [dbo].[tbl_buy_cars_free_items]
                                    SET 
                                        buy_id = @buy_id,
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
                                    cmd_free_item.Parameters.AddWithValue("@buy_id", buy_transaction_id);
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

                        MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                        conn.Close();
                        return;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboModel.DataSource = null;
            cboModel.EndUpdate();
            if (cboMake.SelectedIndex != -1)
            {
                int selected_id = Convert.ToInt32(cboMake.SelectedValue);
                db.FillCombo(cboModel, "tbl_model", "model_name", "model_id", "make_id=" + selected_id, "", false);
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void clear_form()
        {
            buy_transaction_id = 0;
            car_id = 0;
            txt_machine_code.Text = "";
            txt_tank_code.Text = "";
            txt_cushion_type.Text = "";
            txt_language.Text = "";
            txt_buy_price.Text = "";
            txt_kota_price.Text = "";
            txt_fee_price.Text = "";
            txt_sell_price.Text = "";
            txt_remark.Text = "";

            cboCarStatus.SelectedIndex = -1;

            car_picture.Image = null;
            car_picture.Tag = "";
            dgv_free_item.Rows.Clear();


        }

        private void btn_add_buy_free_item_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_id = Convert.ToInt32(txt_free_itemName.Tag);

                if (selected_id == 0)
                {
                    MessageBox.Show("ກະລຸນາເລືອກຊື່ຂອງແຖມກ່ອນ.");
                    btnSelectFreeItem.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txt_free_itemName.Text) || selected_id == 0)
                {
                    MessageBox.Show("ກະລຸນາເລືອກຊື່ຂອງແຖມກ່ອນ.");
                    btn_add_buy_free_item.Focus();
                    return;
                }

                int item_qty;
                string des = "";

                if (!int.TryParse(txt_free_item_qty.Text, out item_qty))
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເປັນຕົວເລກກ່ອນ.");
                    txt_free_item_qty.Focus();
                    return;
                }

                if (item_qty == 0)
                {
                    item_qty = 1;
                }

                if (!string.IsNullOrEmpty(txt_free_description.Text))
                {
                    des = txt_free_description.Text;
                }

                for (int i = 0; i < dgv_free_item.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_free_item.Rows[i];

                    // Skip the new row
                    if (row.IsNewRow) continue;

                    int check_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    if (check_id == selected_id)
                    {
                        int add_item_qty = Convert.ToInt32(row.Cells["col_item_qty"].Value);
                        add_item_qty = add_item_qty + 1;
                        row.Cells["col_item_qty"].Value = add_item_qty.ToString();
                        return;
                    }
                }

                string add_item_name = txt_free_itemName.Text;
                dgv_free_item.Rows.Add(0, selected_id, 0, add_item_name, item_qty, des, "ລົບອອກ");
                set_free_item_rowNo();
                txt_free_description.Text = "";
                txt_free_item_qty.Text = "";
                txt_free_itemName.Text = "";
                txt_free_itemName.Tag = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ເພີ່ມມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
            }
        }

        private void set_free_item_rowNo()
        {
            for (int i = 0; i < dgv_free_item.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_free_item.Rows[i];
                row.Cells["col_item_no"].Value = i + 1;
            }
        }

        private void btn_upload_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                car_picture.Image = null;
                car_picture.Tag = "";
                car_picture.Refresh();
                try
                {
                    car_picture.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    car_picture.Tag = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void btn_delete_pic_Click(object sender, EventArgs e)
        {
            car_picture.Image = null;
            car_picture.Tag = "";
        }

        private void txt_buy_price_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txt_buy_price.Text);
            txt_buy_price.Text = c_amount.ToString(globalVariable.format_currency_usd);
            double totalBuyKip = c_amount * exc_kip_usd;
            double totalBuyBath = c_amount * exc_bath_usd;
            lblBuyKipBath.Text = totalBuyKip.ToString(globalVariable.format_currency_lak) + " ກີບ | " + totalBuyBath.ToString(globalVariable.format_currency_usd) + " ບາດ";
        }

        private void txt_fee_price_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txt_fee_price.Text);
            txt_fee_price.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

        private void txt_kota_price_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txt_kota_price.Text);
            txt_kota_price.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

        private void txt_sell_price_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txt_sell_price.Text);
            txt_sell_price.Text = c_amount.ToString(globalVariable.format_currency_usd);
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

            if (e.ColumnIndex == 6)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = dgv_free_item.Rows[e.RowIndex];
                    int free_item_id = Convert.ToInt32(row.Cells["col_save_item_id"].Value);
                    if (free_item_id > 0)
                    {
                        string exc_qry = "update tbl_buy_cars_free_items set status_id=2 where free_item_id=" + free_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    dgv_free_item.Rows.RemoveAt(e.RowIndex);
                    set_free_item_rowNo();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboModel.DataSource = null;
            cboMake.DataSource = null;
            frmMake frm = new frmMake();
            frm.ShowDialog();
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboModel.DataSource = null;
            frmModel frm = new frmModel();
            frm.ShowDialog();
            if (cboMake.SelectedIndex != -1)
            {
                int selected_id = Convert.ToInt32(cboMake.SelectedValue);
                db.FillCombo(cboModel, "tbl_model", "model_name", "model_id", "make_id=" + selected_id, "", false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (buy_transaction_id > 0)
            {
                car_id = db.nLookup("car_id", "tbl_buy_cars", "buy_id=" + buy_transaction_id);
                long chk_status = db.nLookup("sell_status_id", "tbl_cars_info", "car_id=" + car_id);
                if (chk_status > 0)
                {
                    MessageBox.Show("ລົດຄັນນີ້ໄດ້ຂາຍອອກແລ້ວ ບໍ່ສາມາດລົບອອກໄດ້.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບຂໍ້ມູນຊື້ລົດອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int del_car = db.sqlExecute("Update tbl_cars_info Set status_id=2 Where car_id=" + car_id);
                    int del_buy = db.sqlExecute("Update tbl_buy_cars Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where buy_id=" + buy_transaction_id);
                    int del_freeItem = db.sqlExecute("Update tbl_buy_cars_free_items Set status_id=2 Where buy_id=" + buy_transaction_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    this.Dispose();
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (buy_transaction_id == 0)
            {
                return;
            }

            frmBuyCarPayment frm = new frmBuyCarPayment();
            frm.buy_transaction_id = buy_transaction_id;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cboYear.DataSource = null;
            frmYear frm = new frmYear();
            frm.ShowDialog();
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cboColor.DataSource = null;
            frmColor frm = new frmColor();
            frm.ShowDialog();
            db.FillCombo(cboColor, "tbl_color", "color_name", "color_id", "status_id=1", "", false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cboEngineSize.DataSource = null;
            frmEngineSize frm = new frmEngineSize();
            frm.ShowDialog();
            db.FillCombo(cboEngineSize, "tbl_engine_size", "engine_size_name", "engine_size_id", "status_id=1", "engine_size_name", false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cboBodyType.DataSource = null;
            frmBodyType frm = new frmBodyType();
            frm.ShowDialog();
            db.FillCombo(cboBodyType, "tbl_body_type", "body_type_name", "body_type_id", "status_id=1", "", false);
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

        private void btnSelectFreeItem_Click(object sender, EventArgs e)
        {
            frmBrowseSparePart frm = new frmBrowseSparePart();
            frm.ShowDialog();
            if (globalVariable.get_free_item_id > 0)
            {
                txt_free_itemName.Text = globalVariable.get_free_item_name;
                txt_free_itemName.Tag = globalVariable.get_free_item_id;
                if (string.IsNullOrEmpty(txt_free_item_qty.Text))
                {
                    txt_free_item_qty.Text = "1";
                }
                txt_free_itemName.Focus();
            }
        }

        private void txtTax_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTax.Text);
            txtTax.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }      
    }
}
