using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.MasterData
{
    public partial class frmEngineSize : Form
    {
        public frmEngineSize()
        {
            InitializeComponent();
        }

        int master_id = 0;
        private myClass db = new myClass();

        private void frmEngineSize_Load(object sender, EventArgs e)
        {
            getData();
            clear_new();
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT engine_size_id, engine_size_name FROM dbo.tbl_engine_size where status_id=1 order by engine_size_name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgv_data.Rows.Add(reader["engine_size_id"], 0, reader["engine_size_name"], "ລົບອອກ");
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
            try
            {
                if (master_id == 0)
                {
                    using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                    {
                        string sql = "INSERT INTO dbo.tbl_engine_size (engine_size_name, status_id) VALUES (@engine_size_name, @status_id)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@engine_size_name", txt_name.Text);
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
                        string sql = "UPDATE dbo.tbl_engine_size SET engine_size_name = @engine_size_name WHERE engine_size_id = @engine_size_id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@engine_size_id", master_id);
                        cmd.Parameters.AddWithValue("@engine_size_name", txt_name.Text);
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
                        string exc_qry = "update tbl_engine_size set status_id=2 where engine_size_id=" + get_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    dgv_data.Rows.RemoveAt(e.RowIndex);
                    set_free_item_rowNo();
                    clear_new();
                    return;
                }
            }
            else
            {
                master_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                txt_name.Text = row.Cells["col_item_name"].Value.ToString();
                txt_name.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

    }
}
