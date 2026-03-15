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

namespace CarSellingSystem.MasterData
{
    public partial class frmFreeItem : Form
    {
        public frmFreeItem()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();
        int master_id = 0;
        private void frmFreeItem_Load(object sender, EventArgs e)
        {
            db.FillCombo(cbo_free_item_type, "tbl_free_item_type", "item_type_name", "item_type_id", "status_id=1", "item_type_name", false);
            db.FillCombo(cboFilter, "tbl_free_item_type", "item_type_name", "item_type_id", "status_id=1", "item_type_name", true);
            getData();
            clear_new();
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_free_item";
                if (cboFilter.SelectedIndex > 0)
                {
                    sql = sql + " Where item_type_id=" + cboFilter.SelectedValue;
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgv_data.Rows.Add(reader["item_id"], 0, reader["item_name"], reader["item_type_id"], reader["item_type_name"], "ລົບອອກ");
                }
                reader.Close();
                set_free_item_rowNo();
            }
        }

        private void clear_new()
        {
            master_id = 0;
            txt_name.Text = "";
            txt_name.Focus();
        }

        private void set_free_item_rowNo()
        {
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_data.Rows[i];
                row.Cells["col_item_no"].Value = i + 1;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_new();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                txt_name.Focus();
                return;
            }
            if (cbo_free_item_type.SelectedIndex == -1)
            {
                cbo_free_item_type.Focus();
                return;
            }

            try
            {
                if (master_id == 0)
                {
                    using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                    {
                        string sql = "INSERT INTO dbo.tbl_free_item(item_type_id,item_name, status_id) VALUES (@item_type_id,@item_name, @status_id)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@item_type_id", cbo_free_item_type.SelectedValue);
                        cmd.Parameters.AddWithValue("@item_name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@status_id", 1);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                    {
                        string sql = "UPDATE dbo.tbl_free_item SET item_type_id=@item_type_id, item_name = @item_name WHERE item_id = @item_id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@item_id", master_id);
                        cmd.Parameters.AddWithValue("@item_type_id", cbo_free_item_type.SelectedValue);
                        cmd.Parameters.AddWithValue("@item_name", txt_name.Text);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                MessageBox.Show("ບັນທຶກສຳເລັດ.");
                getData();
                set_free_item_rowNo();
                clear_new();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
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

            DataGridViewRow row = dgv_data.Rows[e.RowIndex];

            string columnName = dgv_data.Columns[e.ColumnIndex].Name;

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
                        string exc_qry = "update tbl_free_item set status_id=2 where item_id=" + get_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    dgv_data.Rows.RemoveAt(e.RowIndex);
                    set_free_item_rowNo();
                    clear_new();
                }
            }
            else
            {
                master_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                txt_name.Text = row.Cells["col_item_name"].Value.ToString();
                int make_id = Convert.ToInt32(row.Cells["col_make_id"].Value);
                cbo_free_item_type.SelectedValue = make_id;
                txt_name.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }


    }
}
