using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;

namespace CarSellingSystem.Cars
{
    public partial class frmCarList : Form
    {
        public frmCarList()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        long car_id = 0;
        private void frmCarList_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboMake_search, "tbl_make", "make_name", "make_id", "status_id=1", "", true);
            db.FillCombo(cboYear_search, "tbl_years", "year_name", "year_id", "status_id=1", "", true);
            db.FillCombo(cboStatus_search, "tbl_cars_status", "status_name", "status_id", "status_id=1 OR status_id=2", "status_id", true);

            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", false);
            //db.FillCombo(cboModel, "tbl_model", "make_name", "make_id", "", false);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", false);
            db.FillCombo(cboColor, "tbl_color", "color_name", "color_id", "status_id=1", "", false);
            db.FillCombo(cboFuelType, "tbl_fuel_type", "fuel_type_name", "fuel_type_id", "status_id=1", "", false);
            db.FillCombo(cboTransmission, "tbl_transmission", "transmission_name", "transmission_id", "", "", false);
            db.FillCombo(cboBodyType, "tbl_body_type", "body_type_name", "body_type_id", "status_id=1", "", false);
            db.FillCombo(cboCurrency, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            db.FillCombo(cboEngineSize, "tbl_engine_size", "engine_size_name", "engine_size_id", "status_id=1", "engine_size_name", false);
            db.FillCombo(cboCarStatus, "tbl_cars_status", "status_name", "status_id", "status_id=1 OR status_id=2", "status_id", false);

            cboMake.SelectedIndex = -1;
            cboYear.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            cboFuelType.SelectedIndex = -1;
            cboTransmission.SelectedIndex = -1;
            cboBodyType.SelectedIndex = -1;
            cboCurrency.SelectedIndex = -1;
            cboEngineSize.SelectedIndex = -1;
            cboCarStatus.SelectedIndex = -1;

            getData();
        }

        private void cboMake_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboModel_search.DataSource = null;
            cboModel_search.EndUpdate();
            if (cboMake_search.SelectedIndex > 0)
            {
                int selected_id = Convert.ToInt32(cboMake_search.SelectedValue);
                db.FillCombo(cboModel_search, "tbl_model", "model_name", "model_id", "make_id=" + selected_id, "", true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_buy_car ";
                sql = sql + " Where status_id=1 ";
                if (!string.IsNullOrEmpty(txtMachineNumber.Text) || !string.IsNullOrEmpty(txtTanNumber.Text))
                {
                    if (!string.IsNullOrEmpty(txtMachineNumber.Text))
                    {
                        sql = sql + " And machine_code LIKE '%" + txtMachineNumber.Text + "%' ";
                    }
                    else if (!string.IsNullOrEmpty(txtTanNumber.Text))
                    {
                        sql = sql + " And tank_code LIKE '%" + txtTanNumber.Text + "%' ";
                    }
                }
                else
                {
                    if (cboMake_search.SelectedIndex > 0)
                    {
                        sql = sql + " And make_id=" + cboMake_search.SelectedValue;
                    }
                    if (cboModel_search.SelectedIndex > 0)
                    {
                        sql = sql + " And model_id=" + cboModel_search.SelectedValue;
                    }
                    if (cboYear_search.SelectedIndex > 0)
                    {
                        sql = sql + " And made_year=" + cboYear_search.SelectedValue;
                    }
                }

                if (cboStatus_search.SelectedIndex > 0)
                {
                    sql = sql + " And buy_status_id=" + cboStatus_search.SelectedValue;
                }

                sql = sql + " Order by buy_date ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_car_id"].Value = reader["car_id"];
                    dgv_data.Rows[rowIndex].Cells["col_buy_date"].Value = Convert.ToDateTime(reader["buy_date"]).ToString(globalVariable.format_date);
                    dgv_data.Rows[rowIndex].Cells["col_make"].Value = reader["make_name"];
                    dgv_data.Rows[rowIndex].Cells["col_model"].Value = reader["model_name"];
                    dgv_data.Rows[rowIndex].Cells["col_year"].Value = reader["made_year"];
                    dgv_data.Rows[rowIndex].Cells["col_color"].Value = reader["color_name"];
                    dgv_data.Rows[rowIndex].Cells["col_fuel_type"].Value = reader["fuel_type_name"];
                    dgv_data.Rows[rowIndex].Cells["col_transmission"].Value = reader["transmission_name"];
                    dgv_data.Rows[rowIndex].Cells["col_engine_size"].Value = reader["engine_size_name"];
                    dgv_data.Rows[rowIndex].Cells["col_car_body"].Value = reader["body_type_name"];
                    dgv_data.Rows[rowIndex].Cells["col_machine_code"].Value = reader["machine_code"];
                    dgv_data.Rows[rowIndex].Cells["col_tan_code"].Value = reader["tank_code"];
                    dgv_data.Rows[rowIndex].Cells["col_cushion_type"].Value = reader["cushion_type"];
                    dgv_data.Rows[rowIndex].Cells["col_language"].Value = reader["car_language"];
                    dgv_data.Rows[rowIndex].Cells["col_currency"].Value = reader["cur_name"];
                    dgv_data.Rows[rowIndex].Cells["col_buy_price"].Value = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_fee"].Value = Convert.ToDecimal(reader["fee_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_kota"].Value = Convert.ToDecimal(reader["kota_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_sell_price"].Value = Convert.ToDecimal(reader["sale_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_status"].Value = reader["status_name"];

                }
                reader.Close();
            }
        }

        private void getCarInfo()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_buy_car Where car_id=" + car_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                       // date_buy.Value = Convert.ToDateTime(reader["buy_date"].ToString());
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
                    }
                }
                conn.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgv_data_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgv_data.Rows[e.RowIndex];
            car_id = Convert.ToInt32(row.Cells["col_car_id"].Value);
            getCarInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (car_id > 0)
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    try
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
                        sale_price = @sale_price,
                        remarks = @remarks,
                        buy_status_id = @buy_status_id
                        WHERE car_id = @car_id";

                        double sell_price = db.ToNumber(txt_sell_price.Text);

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
                        cmd.Parameters.AddWithValue("@sale_price", sell_price);
                        cmd.Parameters.AddWithValue("@buy_status_id", cboCarStatus.SelectedValue);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        private void car_picture_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(car_picture.Tag.ToString()))
            {
                frmPreviewImage frm = new frmPreviewImage();
                frm.image_path = car_picture.Tag.ToString();
                frm.ShowDialog();
            }
        }

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboModel.DataSource = null;
            cboModel.EndUpdate();
            if (cboMake.SelectedIndex > 0)
            {
                int selected_id = Convert.ToInt32(cboMake.SelectedValue);
                db.FillCombo(cboModel, "tbl_model", "model_name", "model_id", "make_id=" + selected_id, "", true);
            }
        }

    }
}
