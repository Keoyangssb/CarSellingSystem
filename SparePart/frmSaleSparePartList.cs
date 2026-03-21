using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.SparePart
{
    public partial class frmSaleSparePartList : Form
    {
        public frmSaleSparePartList()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();

        private void frmSaleSparePartList_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-7);
            getData();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnSaleSparePartList");

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
            getData();
        }

        private void getData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_sell_sparePart Where status_id=1 ";
                if (txtTranNo.Text != "")
                {
                    sql = sql + " And sale_no LIKE N'%" + txtTranNo.Text + "%' ";
                }
                else if (txtCustomer.Text != "")
                {
                    sql = sql + " And cus_full_name LIKE N'%" + txtCustomer.Text + "%' OR cus_tel LIKE N'%" + txtCustomer.Text + "%' ";
                }
                else
                {
                    sql = sql + " And sale_date Between '" + dtFrom.Value + "' And '" + dtTo.Value + "' ";
                }
                sql = sql + " Order By sale_date DESC";
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
                        row2.Cells["col_tran_id"].Value = reader["sale_id"].ToString();
                        row2.Cells["col_item_no"].Value = i.ToString();
                        row2.Cells["col_tran_date"].Value = Convert.ToDateTime(reader["sale_date"]).ToString(globalVariable.format_date);
                        row2.Cells["col_tran_no"].Value = reader["sale_no"].ToString();
                        row2.Cells["col_remark"].Value = reader["remarks"].ToString();

                        row2.Cells["col_customer"].Value = reader["cus_full_name"].ToString();
                        row2.Cells["col_tel"].Value = reader["cus_tel"].ToString();

                        decimal total = db.XSum("sell_price * sell_qty", "tbl_sell_sparePart_item", "sale_id=" + reader["sale_id"] + " And status_id=1");
                        decimal total_paid = db.XSum("pay_amount_in_currency", "tbl_sell_sparePart_payment", "sale_id=" + reader["sale_id"] + " And status_id=1");
                        decimal balance = total - total_paid;

                        row2.Cells["col_total"].Value = total.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_paid"].Value = total_paid.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_balance"].Value = balance.ToString(globalVariable.format_currency_usd);

                        row2.Cells["col_del"].Value = "ລົບອອກ";
                        i = i + 1;
                    }
                }
                conn.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmSaleSparePart frm = new frmSaleSparePart();
            frm.ShowDialog();
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;
                DataGridViewRow row = dgvData.Rows[rowIndex];
                frmSaleSparePart frm = new frmSaleSparePart();
                frm.transaction_id = Convert.ToInt32(row.Cells["col_tran_id"].Value);
                frm.ShowDialog();
                getData();
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

            frmSaleSparePart frm = new frmSaleSparePart();
            frm.transaction_id = Convert.ToInt32(row.Cells["col_tran_id"].Value);
            frm.ShowDialog();
            getData();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvData.CurrentCell.RowIndex;
            DataGridViewRow row = dgvData.Rows[rowIndex];
            frmSaleSparePartPayment frm = new frmSaleSparePartPayment();
            frm.transaction_id = Convert.ToInt32(row.Cells["col_tran_id"].Value);
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

        private void dgvData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

    }
}
