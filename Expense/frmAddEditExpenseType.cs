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
    public partial class frmAddEditExpenseType : Form
    {
        public frmAddEditExpenseType()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        int item_id = 0;
        private void frmAddEditExpenseType_Load(object sender, EventArgs e)
        {
            loadData();
            clear_form();
        }

        private void clear_form()
        {
            item_id = 0;
            txtName.Text = "";
            txtName.Focus();
        }

        private void loadData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tblExpenseTypeCode order by type_name ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        dgvData.Rows[rowIndex].Cells["col_item_id"].Value = reader["type_id"];
                        dgvData.Rows[rowIndex].Cells["col_type"].Value = reader["type_name"];
                        dgvData.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                //set_item_rowNo();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    if (item_id == 0)
                    {
                        string query = @"INSERT INTO tblExpenseTypeCode (type_name) VALUES (@type_name);";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@type_name", txtName.Text);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"
                                UPDATE [dbo].[tblExpenseTypeCode]
                                SET
                                [type_name] = @type_name
                                WHERE [type_id] = @type_id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@type_id", item_id);
                            cmd.Parameters.AddWithValue("@type_name", txtName.Text);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    conn.Close();
                    clear_form();
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
                long chk_id = db.nLookup("item_id", "tblExpenseCode", "status_id=1 And type_id=" + item_id);
                if (chk_id > 0)
                {
                    MessageBox.Show("ບໍ່ສາມາດລົບອອກໄດ້ ເພາະໄດ້ບັນທຶກໃສ່ລາຍການລາຍຈ່າຍແລ້ວ.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string exc_qry = "Delete From tblExpenseTypeCode where type_id=" + item_id;
                    int exc = db.sqlExecute(exc_qry);
                    clear_form();
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
                int get_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                long chk_id = db.nLookup("item_id", "tblExpenseCode", "status_id=1 And type_id=" + get_item_id);
                if (chk_id > 0)
                {
                    MessageBox.Show("ບໍ່ສາມາດລົບອອກໄດ້ ເພາະໄດ້ບັນທຶກໃສ່ລາຍການລາຍຈ່າຍແລ້ວ.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    if (get_item_id > 0)
                    {
                        string exc_qry = "Delete From tblExpenseTypeCode where type_id=" + get_item_id;
                        int exc = db.sqlExecute(exc_qry);
                        clear_form();
                        loadData();
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    string sql = "SELECT * FROM tblExpenseTypeCode Where type_id=" + item_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["type_name"].ToString();
                            txtName.Focus();
                        }
                    }
                }
            }
        }
    }
}
