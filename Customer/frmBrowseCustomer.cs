using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;

namespace CarSellingSystem.Customer
{
    public partial class frmBrowseCustomer : Form
    {
        public frmBrowseCustomer()
        {
            InitializeComponent();
        }

        private void frmBrowseCustomer_Load(object sender, EventArgs e)
        {
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
                string sql = "SELECT * FROM tbl_customer ";
                sql = sql + " Where status_id=1 ";
                if (!string.IsNullOrEmpty(txtFullName.Text))
                {
                    sql = sql + " AND cus_full_name LIKE N'%" + txtFullName.Text + "%' ";
                }
                else if (!string.IsNullOrEmpty(txtTel.Text))
                {
                    sql = sql + " AND cus_tel LIKE '%" + txtTel.Text + "%' ";
                }
                sql = sql + " Order by cus_full_name ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_cus_id"].Value = reader["cus_id"];
                    dgv_data.Rows[rowIndex].Cells["col_full_name"].Value = reader["cus_full_name"];
                    dgv_data.Rows[rowIndex].Cells["col_village"].Value = reader["cus_village"];
                    dgv_data.Rows[rowIndex].Cells["col_district"].Value = reader["cus_district"];
                    dgv_data.Rows[rowIndex].Cells["col_province"].Value = reader["cus_province"];
                    dgv_data.Rows[rowIndex].Cells["col_tel"].Value = reader["cus_tel"];
                    dgv_data.Rows[rowIndex].Cells["col_age"].Value = reader["cus_age"];
                    dgv_data.Rows[rowIndex].Cells["col_card_id"].Value = reader["cus_card_id"];
                    dgv_data.Rows[rowIndex].Cells["col_passport_id"].Value = reader["cus_passport_id"];
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

            string columnName = dgv_data.Columns[e.ColumnIndex].Name;

            if (columnName == "col_select")
            {
                DataGridViewRow row = dgv_data.Rows[e.RowIndex];
                globalVariable.selling_customer_id = Convert.ToInt32(row.Cells["col_cus_id"].Value);
                this.Dispose();
            }
        }

    }
}
