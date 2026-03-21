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

namespace CarSellingSystem.SparePart
{
    public partial class frmBuySparePartList : Form
    {
        public frmBuySparePartList()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        private void frmBuySparePartList_Load(object sender, EventArgs e)
        {
            //db.FillCombo(cboSppSellType, "tbl_spare_part_sell_type", "spp_sell_type_name", "spp_sell_type_id", "", "", true);
            //db.FillCombo(cboSppType, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "", true);

            loadData();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnBuySparePartList");

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

            //if (globalVariable.can_delete)
            //{
            //    dgv_data.Columns["col_item_del"].Visible = true;
            //}
            //else
            //{
            //    dgv_data.Columns["col_item_del"].Visible = false;
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_buy_spare_part Where status_id=1 ";
                if (txtBuyNo.Text != "")
                {
                    sql = sql + " And buy_no LIKE N'%" + txtBuyNo.Text + "%'";
                }
                else
                {
                    sql = sql + " And buy_date Between '" + dtFrom.Value + "' And '" + dtTo.Value + "' ";
                    //if (cboSppSellType.SelectedIndex > 0)
                    //{
                    //    sql = sql + " And spp_sell_type_id=" + cboSppSellType.SelectedValue;
                    //}
                    //if (cboSppSellType.SelectedIndex > 0)
                    //{
                    //    sql = sql + " And spp_type_id=" + cboSppType.SelectedValue;
                    //}
                }

                sql = sql + " Order By buy_date DESC";
                int i = 1;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        DataGridViewRow row2 = dgvData.Rows[rowIndex];
                        row2.Cells["col_buy_id"].Value = reader["buy_id"].ToString();
                        row2.Cells["col_item_no"].Value = i.ToString();
                        row2.Cells["col_buy_date"].Value = Convert.ToDateTime(reader["buy_date"]).ToString(globalVariable.format_date);
                        row2.Cells["col_buy_no"].Value = reader["buy_no"].ToString();
                        row2.Cells["col_remark"].Value = reader["remarks"].ToString();

                        decimal total_buy = db.XSum("buy_price * buy_qty", "tbl_buy_spare_part_item", "buy_id=" + reader["buy_id"] + " And status_id=1");
                        decimal total_paid = db.XSum("pay_amount_in_currency", "tbl_buy_spare_part_payment", "buy_id=" + reader["buy_id"] + " And pay_item_id=1 And status_id=1");
                        decimal balance = total_buy - total_paid;

                        row2.Cells["col_total_buy"].Value = total_buy.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_total_buy_paid"].Value = total_paid.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_total_buy_balance"].Value = balance.ToString(globalVariable.format_currency_usd);

                        decimal total_fee = Convert.ToDecimal(reader["transport_fee"]);
                        decimal fee_paid = db.XSum("pay_amount_in_currency", "tbl_buy_spare_part_payment", "buy_id=" + reader["buy_id"] + " And pay_item_id=2 And status_id=1");
                        decimal fee_balance = total_fee - fee_paid;

                        row2.Cells["col_fee"].Value = total_fee.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_fee_paid"].Value = fee_paid.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_fee_balance"].Value = fee_balance.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_item_del"].Value = "ລົບອອກ";
                        i = i + 1;
                    }
                }
                conn.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmBuySparePart frm = new frmBuySparePart();
            frm.ShowDialog();
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;
                DataGridViewRow row = dgvData.Rows[rowIndex];
                frmBuySparePart frm = new frmBuySparePart();
                frm.transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);
                frm.ShowDialog();
                loadData();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;
                DataGridViewRow row = dgvData.Rows[rowIndex];
                frmBuySparePartPayment frm = new frmBuySparePartPayment();
                frm.buy_transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value); ;
                frm.ShowDialog();
                loadData();
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

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dgvData.Rows[e.RowIndex];

            frmBuySparePart frm = new frmBuySparePart();
            frm.transaction_id = Convert.ToInt32(row.Cells["col_buy_id"].Value);
            frm.ShowDialog();
            loadData();
        }

    }
}
