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
    public partial class frmBrowseSparePart : Form
    {
        public frmBrowseSparePart()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmBrowseSparePart_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboSppSellType, "tbl_spare_part_sell_type", "spp_sell_type_name", "spp_sell_type_id", "", "", true);
            db.FillCombo(cboSppType, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "", true);
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
                string sql = "SELECT * FROM v_sparePart ";
                sql = sql + " Where status_id=1 ";
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    sql = sql + " And spp_name LIKE N'%" + txtName.Text + "%' ";
                }
                else
                {
                    if (cboSppSellType.SelectedIndex > 0)
                    {
                        sql = sql + " And spp_sell_type_id=" + cboSppSellType.SelectedValue;
                    }
                    if (cboSppType.SelectedIndex > 0)
                    {
                        sql = sql + " And spp_type_id=" + cboSppType.SelectedValue;
                    }
                }

                sql = sql + " Order by spp_name ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = dgv_data.Rows.Add();
                    dgv_data.Rows[rowIndex].Cells["col_spp_id"].Value = reader["spp_id"];
                    dgv_data.Rows[rowIndex].Cells["col_spp_sell_type"].Value = reader["spp_sell_type_name"];
                    dgv_data.Rows[rowIndex].Cells["col_spp_type"].Value = reader["spp_type_name"];
                    dgv_data.Rows[rowIndex].Cells["col_spp_name"].Value = reader["spp_name"];
                    dgv_data.Rows[rowIndex].Cells["col_buy_price"].Value = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                    dgv_data.Rows[rowIndex].Cells["col_buy_cur"].Value = reader["cur_name"];
                    dgv_data.Rows[rowIndex].Cells["col_sell_price"].Value = Convert.ToDecimal(reader["sell_price"]).ToString(globalVariable.format_currency_usd);
                    //dgv_data.Rows[rowIndex].Cells["col_sell_cur"].Value = reader["sell_currency"];

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
                    globalVariable.get_free_item_id = Convert.ToInt32(row.Cells["col_spp_id"].Value);
                    globalVariable.get_free_item_name = row.Cells["col_spp_name"].Value.ToString();
                    this.Dispose();
                }
            }
        }


    }
}
