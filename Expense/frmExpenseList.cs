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

namespace CarSellingSystem.Expense
{
    public partial class frmExpenseList : Form
    {
        public frmExpenseList()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmExpenseList_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-7);
            getData();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnExpenseList");

            if (globalVariable.can_add)
            {
                btnAddNew.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
            }
            if (globalVariable.can_edit)
            {
                btnEdit.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            frm.ShowDialog();
            getData();
        }

        private void getData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tblExpense Where status_id=1 ";
                if (txtTranNo.Text != "")
                {
                    sql = sql + " And exp_no LIKE N'%" + txtTranNo.Text + "%' ";
                }
                else
                {
                    sql = sql + " And exp_date Between '" + dtFrom.Value + "' And '" + dtTo.Value + "' ";
                }
                sql = sql + " Order By exp_date DESC";
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
                        row2.Cells["col_tran_id"].Value = reader["expId"].ToString();
                        row2.Cells["col_item_no"].Value = i.ToString();
                        row2.Cells["col_tran_date"].Value = Convert.ToDateTime(reader["exp_date"]).ToString(globalVariable.format_date);
                        row2.Cells["col_tran_no"].Value = reader["exp_no"].ToString();
                        row2.Cells["col_remark"].Value = reader["exp_description"].ToString();

                        decimal paid_kip = db.XSum("expense_amount", "tblExpenseDetail", "exp_id=" + reader["expId"] + " And currency_id=1 And status_id=1");
                        decimal paid_bath = db.XSum("expense_amount", "tblExpenseDetail", "exp_id=" + reader["expId"] + " And currency_id=2 And status_id=1");
                        decimal paid_usd = db.XSum("expense_amount", "tblExpenseDetail", "exp_id=" + reader["expId"] + " And currency_id=3 And status_id=1");

                        row2.Cells["col_paid_kip"].Value = paid_kip.ToString(globalVariable.format_currency_lak);
                        row2.Cells["col_paid_bath"].Value = paid_bath.ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_paid_usd"].Value = paid_usd.ToString(globalVariable.format_currency_usd);

                        row2.Cells["col_del"].Value = "ລົບອອກ";
                        i = i + 1;
                    }
                }
                conn.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;
                DataGridViewRow row = dgvData.Rows[rowIndex];
                frmExpense frm = new frmExpense();
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

            frmExpense frm = new frmExpense();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }

    }
}
