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

namespace CarSellingSystem.BuyCar
{
    public partial class frmBuyCarList : Form
    {
        public frmBuyCarList()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        private void frmBuyCarList_Load(object sender, EventArgs e)
        {
            from_date.Value = DateTime.Now.AddDays(-7);
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", true);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", true);
            db.FillCombo(cboStatus, "tbl_cars_status", "status_name", "status_id", "status_id=1 OR status_id=2", "status_id", true);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
                sql = sql + " Where buy_date Between '" + fromDate + "' And '" + toDate + "'";
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
                if (cboStatus.SelectedIndex > 0)
                {
                    sql = sql + " And cars_status_id=" + cboStatus.SelectedValue;
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
                    Decimal totalTaxPaid = 0;

                    Decimal totalBuyBalance = 0;
                    Decimal totalFeeBalance = 0;
                    Decimal totalKotaBalance = 0;
                    Decimal totalTaxBalance = 0;

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
                    dgv_data.Rows[rowIndex].Cells["col_tax_price"].Value = Convert.ToDecimal(reader["tax_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_remark"].Value = reader["remarks"];
                    dgv_data.Rows[rowIndex].Cells["col_user"].Value = reader["created_user"];
                    dgv_data.Rows[rowIndex].Cells["col_status"].Value = reader["status_name"];
                    
                    totalBuyPaid = db.XSum("pay_amount", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=1 And status_id=1");
                    totalFeePaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=2 And status_id=1");
                    totalKotaPaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=3 And status_id=1");
                    totalTaxPaid = db.XSum("payAmountInUsd", "tbl_buy_cars_payment", "buy_id=" + buy_transaction_id + " And pay_item_id=4 And status_id=1");

                    dgv_data.Rows[rowIndex].Cells["col_buy_price_paid"].Value = totalBuyPaid.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_fee_price_paid"].Value = totalFeePaid.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_kota_price_paid"].Value = totalKotaPaid.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_tax_price_paid"].Value = totalTaxPaid.ToString(globalVariable.format_currency_usd);

                    totalBuyBalance = Convert.ToDecimal(reader["buy_price"]) - totalBuyPaid;
                    totalFeeBalance = Convert.ToDecimal(reader["fee_price"]) - totalFeePaid;
                    totalKotaBalance = Convert.ToDecimal(reader["kota_price"]) - totalKotaPaid;
                    totalTaxBalance = Convert.ToDecimal(reader["tax_price"]) - totalTaxPaid;

                    dgv_data.Rows[rowIndex].Cells["col_buy_price_balance"].Value = totalBuyBalance.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_fee_price_balance"].Value = totalFeeBalance.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_kota_price_balance"].Value = totalKotaBalance.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_tax_price_balance"].Value = totalTaxBalance.ToString(globalVariable.format_currency_usd);

                    dgv_data.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                }
                reader.Close();
            }
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

            frmBuyCar frm = new frmBuyCar();
            frm.buy_transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);
            frm.ShowDialog();
            getData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmBuyCar frm = new frmBuyCar();
            frm.buy_transaction_id = 0;
            frm.ShowDialog();
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv_data.Rows.Count == 0)
            {
                return;
            }

            int rowIndex = dgv_data.CurrentCell.RowIndex;
            DataGridViewRow row = dgv_data.Rows[rowIndex];

            frmBuyCar frm = new frmBuyCar();
            frm.buy_transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);
            frm.ShowDialog();
            getData();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgv_data.Rows.Count == 0)
            {
                return;
            }

            int rowIndex = dgv_data.CurrentCell.RowIndex;
            DataGridViewRow row = dgv_data.Rows[rowIndex];

            frmBuyCarPayment frm = new frmBuyCarPayment();
            frm.buy_transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);
            frm.ShowDialog();
            getData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (frmMain.Instance.tcl.SelectedTab != null)
            {
                frmMain.Instance.tcl.Tabs.Remove(frmMain.Instance.tcl.SelectedTab);
            }
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

            string columnName = dgv_data.Columns[e.ColumnIndex].Name;

            if (columnName == "col_item_del")
            {
                DataGridViewRow row = dgv_data.Rows[e.RowIndex];
                int buy_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);

                long car_id = db.nLookup("car_id", "tbl_buy_cars", "buy_id=" + buy_id);
                long chk_status = db.nLookup("sell_status_id", "tbl_cars_info", "car_id=" + car_id);
                if (chk_status > 0)
                {
                    MessageBox.Show("ລົດຄັນນີ້ໄດ້ຂາຍອອກແລ້ວ ບໍ່ສາມາດລົບອອກໄດ້.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບຂໍ້ມູນຊື້ລົດລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int del_car = db.sqlExecute("Update tbl_cars_info Set status_id=2 Where car_id=" + car_id);
                    int del_buy = db.sqlExecute("Update tbl_buy_cars Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where buy_id=" + buy_id);
                    int del_freeItem = db.sqlExecute("Update tbl_buy_cars_free_items Set status_id=2 Where buy_id=" + buy_id);

                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    getData();
                }

            }


        }

    }
}
