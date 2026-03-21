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
    public partial class frmAddEditExpense : Form
    {
        public frmAddEditExpense()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        int item_id = 0;
        private void frmAddEditExpense_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboType, "tblExpenseTypeCode", "type_name", "type_id", "", "type_name", false);
            db.FillCombo(cboTypeFilter, "tblExpenseTypeCode", "type_name", "type_id", "", "type_name", true);
            loadData();
            clear_text();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnExpenseCode");

            if (globalVariable.can_add)
            {
                btnAddNew.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
            }
            if (globalVariable.can_edit || globalVariable.can_add)
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }
            if (globalVariable.can_delete)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        private void loadData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_expenseCode Where status_id=1 ";
                if (txtName_filter.Text != "")
                {
                    sql = sql + " And item_name LIKE N'%" + txtName_filter.Text + "%'";
                }
                else
                {
                    if (cboTypeFilter.SelectedIndex > 0)
                    {
                        sql = sql + " And type_id =" + cboTypeFilter.SelectedValue + " ";
                    }
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        dgvData.Rows[rowIndex].Cells["col_item_id"].Value = reader["item_id"];
                        dgvData.Rows[rowIndex].Cells["col_type"].Value = reader["type_name"];
                        dgvData.Rows[rowIndex].Cells["col_name"].Value = reader["item_name"];
                        dgvData.Rows[rowIndex].Cells["col_user"].Value = reader["modify_user"];
                        dgvData.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                //set_item_rowNo();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_text();
        }

        private void clear_text()
        {
            txtName.Text = "";
            item_id = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປະເພດລາຍຈ່າຍກ່ອນ.");
                cboType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ລາຍຈ່າຍກ່ອນ.");
                txtName.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    if (item_id == 0)
                    {
                        string query = @"
                            INSERT INTO [dbo].[tblExpenseCode] (
                                [type_id], [item_name], [status_id], [modify_date], [modify_user]
                            )
                            VALUES (
                                @type_id, @item_name, @status_id, @modify_date, @modify_user);";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@type_id", cboType.SelectedValue);
                            cmd.Parameters.AddWithValue("@item_name", txtName.Text);
                            cmd.Parameters.AddWithValue("@status_id", 1);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"
                                UPDATE [dbo].[tblExpenseCode]
                                SET
                                [type_id] = @type_id,
                                [item_name] = @item_name,
                                [modify_date] = @modify_date,
                                [modify_user] = @modify_user
                                WHERE [item_id] = @item_id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@item_id", item_id);
                            cmd.Parameters.AddWithValue("@type_id", cboType.SelectedValue);
                            cmd.Parameters.AddWithValue("@item_name", txtName.Text);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    conn.Close();
                    clear_text();
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (item_id > 0)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string exc_qry = "update tblExpenseCode set status_id=2 where item_id=" + item_id;
                    int exc = db.sqlExecute(exc_qry);
                    clear_text();
                    loadData();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }

            item_id = 0;

            DataGridViewRow row = dgvData.Rows[e.RowIndex];

            string columnName = dgvData.Columns[e.ColumnIndex].Name;

            if (columnName == "col_item_del")
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int get_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    if (get_item_id > 0)
                    {
                        string exc_qry = "update tblExpenseCode set status_id=2 where item_id=" + get_item_id;
                        int exc = db.sqlExecute(exc_qry);
                        dgvData.Rows.RemoveAt(e.RowIndex);
                        clear_text();
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    string sql = "SELECT * FROM tblExpenseCode Where item_id=" + item_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cboType.SelectedValue = reader["type_id"];
                            txtName.Text = reader["item_name"].ToString();
                            txtName.Focus();
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            frmAddEditExpenseType frm = new frmAddEditExpenseType();
            frm.ShowDialog();
            db.FillCombo(cboType, "tblExpenseTypeCode", "type_name", "type_id", "", "type_name", false);
            db.FillCombo(cboTypeFilter, "tblExpenseTypeCode", "type_name", "type_id", "", "type_name", true);
        }
    }
}
