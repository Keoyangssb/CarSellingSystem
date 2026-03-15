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

namespace CarSellingSystem.Stocks
{
    public partial class frmCheckCarBalance : Form
    {
        public frmCheckCarBalance()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmCheckCarBalance_Load(object sender, EventArgs e)
        {
            from_date.Value = DateTime.Now.AddDays(-7);
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", true);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", true);
            //db.FillCombo(cboStatus, "tbl_cars_status", "status_name", "status_id", "status_id=1 OR status_id=2", "status_id", true);
            getData();
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                DateTime fromDate = from_date.Value;
                DateTime toDate = to_date.Value;
                fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc);
                toDate = DateTime.SpecifyKind(toDate, DateTimeKind.Utc);
                string sql = "SELECT * FROM v_buy_car ";
                sql = sql + " Where buy_status_id= 2 And sell_status_id=0 And buy_date Between '" + fromDate + "' And '" + toDate + "'";
                if (cboMake.SelectedIndex > 0)
                {
                    sql = sql + " And make_id=" + cboMake.SelectedValue;
                }
                if (cboModel.SelectedIndex > 0)
                {
                    sql = sql + " And model_id=" + cboModel.SelectedValue;
                }
                if (cboYear.SelectedIndex > 0)
                {
                    sql = sql + " And made_year=" + cboYear.SelectedValue;
                }
                sql = sql + " Order by buy_date ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Decimal totalBuyPaid = 0;
                    Decimal totalFeePaid = 0;
                    Decimal totalKotaPaid = 0;

                    Decimal totalBuyBalance = 0;
                    Decimal totalFeeBalance = 0;
                    Decimal totalKotaBalance = 0;

                    int buy_transaction_id = Convert.ToInt32(reader["buy_id"]);

                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_buy_id"].Value = reader["buy_id"];
                    dgv_data.Rows[rowIndex].Cells["col_date"].Value = Convert.ToDateTime(reader["buy_date"]).ToString(globalVariable.format_date);
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
                    dgv_data.Rows[rowIndex].Cells["col_fee_price"].Value = Convert.ToDecimal(reader["fee_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_kota_price"].Value = Convert.ToDecimal(reader["kota_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_sell_price"].Value = Convert.ToDecimal(reader["sale_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_remark"].Value = reader["remarks"];

                }
                reader.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
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
