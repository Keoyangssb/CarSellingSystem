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

namespace CarSellingSystem.Stocks
{
    public partial class bfrmCheckSPPBalance : Form
    {
        public bfrmCheckSPPBalance()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void bfrmCheckSPPBalance_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboSellType_filter, "tbl_spare_part_sell_type", "spp_sell_type_name", "spp_sell_type_id", "", "spp_sell_type_id", true);
            db.FillCombo(cboType_filter, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "spp_type_name", true);
            loadData();
        }

        private void loadData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_sparePart Where status_id=1 ";
                if (txtName_filter.Text != "")
                {
                    sql = sql + " And spp_name LIKE N'%" + txtName_filter.Text + "%'";
                }
                else
                {
                    if (cboSellType_filter.SelectedIndex > 0)
                    {
                        sql = sql + " And spp_sell_type_id =" + cboSellType_filter.SelectedValue + " ";
                    }
                    if (cboType_filter.SelectedIndex > 0)
                    {
                        sql = sql + " And spp_type_id =" + cboType_filter.SelectedValue + "";
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
                        dgvData.Rows[rowIndex].Cells["col_item_id"].Value = reader["spp_id"];
                        dgvData.Rows[rowIndex].Cells["col_sell_type"].Value = reader["spp_sell_type_name"];
                        dgvData.Rows[rowIndex].Cells["col_type"].Value = reader["spp_type_name"];
                        dgvData.Rows[rowIndex].Cells["col_name"].Value = reader["spp_name"];
                        dgvData.Rows[rowIndex].Cells["col_unit"].Value = reader["unit_name"];

                        dgvData.Rows[rowIndex].Cells["col_buy_price"].Value = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                        dgvData.Rows[rowIndex].Cells["col_sell_price"].Value = Convert.ToDecimal(reader["sell_price"]).ToString(globalVariable.format_currency_usd);

                        dgvData.Rows[rowIndex].Cells["col_currency_buy"].Value = reader["cur_name"];
                        dgvData.Rows[rowIndex].Cells["col_currency_sell"].Value = db.XLookup("cur_name", "tbl_currency", "cur_id=" + reader["sell_currency_id"]);

                        dgvData.Rows[rowIndex].Cells["col_balance_qty"].Value = db.GetSparePartBalanceQty(Convert.ToInt32(reader["spp_id"]));
                    }
                }
                conn.Close();
                //set_item_rowNo();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

    }
}
