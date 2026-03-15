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

namespace CarSellingSystem.Customer
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        int customer_id = 0;
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            getData();
            clear_form();
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_customer ";
                sql = sql + " Where status_id=1 ";
                if (!string.IsNullOrEmpty(txtFullName_search.Text))
                {
                    sql = sql + " AND cus_full_name LIKE N'%" + txtFullName_search.Text + "%' ";
                }
                else if (!string.IsNullOrEmpty(txtTel_search.Text))
                {
                    sql = sql + " AND cus_tel LIKE '%" + txtTel_search.Text + "%' ";
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
                }
                reader.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void clear_form()
        {
            customer_id = 0;
            txt_cusFullName.Text = "";
            txt_age.Text = "";
            txt_district.Text = "";
            txt_passport_id.Text = "";
            txt_province.Text = "ນະຄອນຫຼວງວຽງຈັນ";
            txt_tel.Text = "";
            txt_village.Text = "";
            txt_card_id.Text = "";
            txt_cusFullName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cusFullName.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ ແລະ ນາມສະກຸນກ່ອນ.");
                txt_cusFullName.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    if (customer_id == 0)
                    {
                        string query = @"
                        INSERT INTO [dbo].[tbl_customer]
                        (cus_full_name, cus_village, cus_district, cus_province, 
                         cus_tel, cus_age, cus_card_id, cus_passport_id, 
                         modify_date, modify_user, status_id)
                        VALUES (@full_name, @village, @district, @province, 
                        @tel, @age, @card_id, @passport_id, 
                        @modify_date, @modify_user, @status_id)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@full_name", txt_cusFullName.Text);
                            cmd.Parameters.AddWithValue("@village", txt_village.Text);
                            cmd.Parameters.AddWithValue("@district", txt_district.Text);
                            cmd.Parameters.AddWithValue("@province", txt_province.Text);
                            cmd.Parameters.AddWithValue("@tel", txt_tel.Text);
                            cmd.Parameters.AddWithValue("@age", txt_age.Text);
                            cmd.Parameters.AddWithValue("@card_id", txt_card_id.Text);
                            cmd.Parameters.AddWithValue("@passport_id", txt_passport_id.Text);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            cmd.Parameters.AddWithValue("@status_id", 1);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"
                        UPDATE [dbo].[tbl_customer]
                        SET cus_full_name = @full_name,
                            cus_village = @village,
                            cus_district = @district,
                            cus_province = @province,
                            cus_tel = @tel,
                            cus_age = @age,
                            cus_card_id = @card_id,
                            cus_passport_id = @passport_id,
                            modify_date = @modify_date,
                            modify_user = @modify_user
                        WHERE cus_id = @cus_id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cus_id", customer_id);
                            cmd.Parameters.AddWithValue("@full_name", txt_cusFullName.Text);
                            cmd.Parameters.AddWithValue("@village", txt_village.Text);
                            cmd.Parameters.AddWithValue("@district", txt_district.Text);
                            cmd.Parameters.AddWithValue("@province", txt_province.Text);
                            cmd.Parameters.AddWithValue("@tel", txt_tel.Text);
                            cmd.Parameters.AddWithValue("@age", txt_age.Text);
                            cmd.Parameters.AddWithValue("@card_id", txt_card_id.Text);
                            cmd.Parameters.AddWithValue("@passport_id", txt_passport_id.Text);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    conn.Close();
                    clear_form();
                    getData();
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
            if (customer_id > 0)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string exc_qry = "update tbl_customer set status_id=2 where cus_id=" + customer_id;
                    int exc = db.sqlExecute(exc_qry);
                    clear_form();
                    getData();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (frmMain.Instance.tcl.SelectedTab != null)
            {
                frmMain.Instance.tcl.Tabs.Remove(frmMain.Instance.tcl.SelectedTab);
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

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                DataGridViewRow row = dgv_data.Rows[e.RowIndex];
                customer_id = Convert.ToInt32(row.Cells["col_cus_id"].Value);
                string sql = "SELECT * FROM tbl_customer Where cus_id=" + customer_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txt_cusFullName.Text = reader["cus_full_name"].ToString();
                        txt_age.Text = reader["cus_age"].ToString();
                        txt_district.Text = reader["cus_district"].ToString();
                        txt_passport_id.Text = reader["cus_passport_id"].ToString();
                        txt_province.Text = reader["cus_province"].ToString();
                        txt_tel.Text = reader["cus_tel"].ToString();
                        txt_village.Text = reader["cus_village"].ToString();
                        txt_card_id.Text = reader["cus_card_id"].ToString();
                        txt_cusFullName.Focus();
                    }
                }
            }

        }

    }
}
