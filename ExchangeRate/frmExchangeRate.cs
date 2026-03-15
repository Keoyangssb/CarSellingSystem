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

namespace CarSellingSystem.ExchangeRate
{
    public partial class frmExchangeRate : Form
    {
        public frmExchangeRate()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();
        private void frmExchangeRate_Load(object sender, EventArgs e)
        {
            getData();
            clear_form();
        }

        private void clear_form()
        {
            txtBathUSD.Text = "";
            txtKipBath.Text = "";
            txtKipUSD.Text = "";
            txtKipBath.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKipBath.Text))
            {
                txtKipBath.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtKipUSD.Text))
            {
                txtKipUSD.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtBathUSD.Text))
            {
                txtBathUSD.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການບັນທຶກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string sql = "UPDATE dbo.tbl_exchange_rate SET status_id = @status_id ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@status_id", 0);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    sql = "";

                    sql = "INSERT INTO dbo.tbl_exchange_rate (kip_bath, kip_usd,bath_usd,status_id,created_date,created_user) VALUES (@kip_bath, @kip_usd,@bath_usd,@status_id,@created_date,@created_user)";
                    SqlCommand cmd_insert = new SqlCommand(sql, conn);
                    cmd_insert.Parameters.AddWithValue("@kip_bath", Convert.ToDecimal(txtKipBath.Text));
                    cmd_insert.Parameters.AddWithValue("@kip_usd", Convert.ToDecimal(txtKipUSD.Text));
                    cmd_insert.Parameters.AddWithValue("@bath_usd", Convert.ToDecimal(txtBathUSD.Text));
                    cmd_insert.Parameters.AddWithValue("@status_id", 1);
                    cmd_insert.Parameters.AddWithValue("@created_date", DateTime.Now);
                    cmd_insert.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                    cmd_insert.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("ບັນທຶກສຳເລັດ.");
                    getData();
                    clear_form();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                }
            }
        }

        private void getData()
        {
            dgv_data.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT TOP(10) * FROM dbo.tbl_exchange_rate Order By created_date DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string date_add = Convert.ToDateTime(reader["created_date"]).ToString("dd/MM/yyyy hh:mm tt");
                    string kip_bath = Convert.ToDecimal(reader["kip_bath"]).ToString(globalVariable.format_currency_usd);
                    string kip_usd = Convert.ToDecimal(reader["kip_usd"]).ToString(globalVariable.format_currency_usd);
                    string bath_usd = Convert.ToDecimal(reader["bath_usd"]).ToString(globalVariable.format_currency_usd);

                    dgv_data.Rows.Add(date_add, kip_bath, kip_usd, bath_usd, reader["created_user"]);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtKipBath_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtKipBath.Text);
            txtKipBath.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

        private void txtKipUSD_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtKipUSD.Text);
            txtKipUSD.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

        private void txtBathUSD_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtBathUSD.Text);
            txtBathUSD.Text = c_amount.ToString(globalVariable.format_currency_usd);
        }

    }
}
