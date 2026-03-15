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
    public partial class frmBrowseExpenseCode : Form
    {
        public frmBrowseExpenseCode()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmBrowseExpenseCode_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboType, "tblExpenseTypeCode", "type_name", "type_id", "", "type_name", true);
            getData();
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
                string sql = "SELECT * FROM v_expenseCode ";
                sql = sql + " Where status_id=1 ";
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    sql = sql + " And item_name LIKE N'%" + txtName.Text + "%' ";
                }
                else
                {
                    if (cboType.SelectedIndex > 0)
                    {
                        sql = sql + " And type_id=" + cboType.SelectedValue;
                    }
                }

                sql = sql + " Order by item_name ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_item_id"].Value = reader["item_id"];
                    dgv_data.Rows[rowIndex].Cells["col_type"].Value = reader["type_name"];
                    dgv_data.Rows[rowIndex].Cells["col_name"].Value = reader["item_name"];
                    dgv_data.Rows[rowIndex].Cells["col_select"].Value = "ເລືອກເອົາ";
                }
                reader.Close();
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
            if (dgv_data.Rows.Count > 0)
            {
                string columnName = dgv_data.Columns[e.ColumnIndex].Name;

                if (columnName == "col_select")
                {
                    DataGridViewRow row = dgv_data.Rows[e.RowIndex];
                    globalVariable.get_free_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    this.Dispose();
                }
            }
        }

    }
}
