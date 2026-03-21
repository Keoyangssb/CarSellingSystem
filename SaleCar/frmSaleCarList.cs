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

namespace CarSellingSystem.SaleCar
{
    public partial class frmSaleCarList : Form
    {
        public frmSaleCarList()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        private void frmSaleCarList_Load(object sender, EventArgs e)
        {
            from_date.Value = DateTime.Now.AddDays(-7);
            db.FillCombo(cboMake, "tbl_make", "make_name", "make_id", "status_id=1", "", true);
            db.FillCombo(cboYear, "tbl_years", "year_name", "year_id", "status_id=1", "", true);

            getData();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnSaleCarHistory");

            if (globalVariable.can_add)
            {
                btnAddNew.Visible = true;
                btnPayment.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
                btnPayment.Visible = false;
            }
            if (globalVariable.can_edit)
            {
                btnEdit.Visible = true;
                btnPayment.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
                btnPayment.Visible = false;
            }

            if (globalVariable.can_add || globalVariable.can_edit)
            {
                btnPayment.Visible = true;
            }
            else
            {
                btnPayment.Visible = false;
            }

            if (globalVariable.can_delete)
            {
                dgv_data.Columns["col_item_del"].Visible = true;
            }
            else
            {
                dgv_data.Columns["col_item_del"].Visible = false;
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
                string sql = "SELECT * FROM v_sell_car ";
                sql = sql + " Where status_id = 1 ";
                if (txt_cusFullName.Text != "")
                {
                    sql = sql + " And (cus_full_name LIKE N'%" + txt_cusFullName.Text + "%' OR cus_tel LIKE N'%" + txt_cusFullName.Text + "%')";
                }
                else
                {
                    sql = sql + " And sale_date Between '" + fromDate + "' And '" + toDate + "'";
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
                }
                sql = sql + " Order by sale_date ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Decimal totalPaid = 0;
                    Decimal totalBalance = 0;

                    int sell_transaction_id = Convert.ToInt32(reader["sale_id"]);

                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_sell_id"].Value = reader["sale_id"];
                    dgv_data.Rows[rowIndex].Cells["col_sell_no"].Value = reader["sale_no"];

                    dgv_data.Rows[rowIndex].Cells["col_cusName"].Value = reader["cus_full_name"];
                    dgv_data.Rows[rowIndex].Cells["col_cusTel"].Value = reader["cus_tel"];

                    dgv_data.Rows[rowIndex].Cells["col_date"].Value = Convert.ToDateTime(reader["sale_date"]).ToString(globalVariable.format_date);
                    dgv_data.Rows[rowIndex].Cells["col_make"].Value = reader["make_name"];
                    dgv_data.Rows[rowIndex].Cells["col_model"].Value = reader["model_name"];
                    dgv_data.Rows[rowIndex].Cells["col_year"].Value = reader["made_year"];
                    dgv_data.Rows[rowIndex].Cells["col_color"].Value = reader["color_name"];
                    dgv_data.Rows[rowIndex].Cells["col_machine_code"].Value = reader["machine_code"];
                    dgv_data.Rows[rowIndex].Cells["col_tan_code"].Value = reader["tank_code"];
                    dgv_data.Rows[rowIndex].Cells["col_currency"].Value = reader["cur_name"];
                    dgv_data.Rows[rowIndex].Cells["col_sell_price"].Value = Convert.ToDecimal(reader["sale_price"]).ToString(globalVariable.format_currency_usd);
                    
                    dgv_data.Rows[rowIndex].Cells["col_user"].Value = reader["created_user"];

                    if (!string.IsNullOrEmpty(reader["customer_car_date"].ToString()))
                    {
                        dgv_data.Rows[rowIndex].Cells["col_cusCarDate"].Value = Convert.ToDateTime(reader["customer_car_date"]).ToString(globalVariable.format_date);
                    }
                    
                    totalPaid = db.XSum("total_pay_in_usd", "tbl_sell_car_payment", "sell_id=" + sell_transaction_id + " And status_id=1");
                    totalBalance = Convert.ToDecimal(reader["sale_price"]) - totalPaid; 

                    dgv_data.Rows[rowIndex].Cells["col_sell_price_paid"].Value = totalPaid.ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_sell_price_balance"].Value = totalBalance.ToString(globalVariable.format_currency_usd);
                   
                    dgv_data.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                }
                reader.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (frmMain.Instance.tcl.SelectedTab != null)
            {
                frmMain.Instance.tcl.Tabs.Remove(frmMain.Instance.tcl.SelectedTab);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmSaleCar frm = new frmSaleCar();
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

            frmSaleCar frm = new frmSaleCar();
            frm.sell_transaction_id = Convert.ToInt32(row.Cells["col_sell_id"].Value);
            frm.ShowDialog();
            getData();
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
                int sell_id = Convert.ToInt32(row.Cells["col_sell_id"].Value);
                long car_id = db.nLookup("car_id", "tbl_sell_car", "sale_id=" + sell_id);
                //long chk_status = db.nLookup("sell_status_id", "tbl_cars_info", "car_id=" + car_id);
                //if (chk_status == 2)
                //{
                //    MessageBox.Show("ລົດຄັນນີ້ໄດ້ຂາຍອອກແລ້ວ ບໍ່ສາມາດລົບອອກໄດ້.");
                //    return;
                //}

                long paymentId = db.nLookup("pay_id", "tbl_sell_car_payment", "status_id = 1 And sell_id=" + sell_id);
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
                    int del_freeItem = db.sqlExecute("Update tbl_sell_car_free_items Set status_id=2 Where sell_id=" + sell_id);
                    int del_attachFile = db.sqlExecute("Update tbl_sell_car_attach_file Set status_id=2 Where sell_id=" + sell_id);
                    int del_buy = db.sqlExecute("Update tbl_sell_car Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where sale_id=" + sell_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    getData();
                }

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

            frmSaleCar frm = new frmSaleCar();
            frm.sell_transaction_id = Convert.ToInt32(row.Cells["col_sell_id"].Value);
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

            frmSaleCarPayment frm = new frmSaleCarPayment();
            frm.sale_transaction_id = Convert.ToInt32(row.Cells["col_sell_id"].Value);
            frm.ShowDialog();
            getData();
        }



    }
}
