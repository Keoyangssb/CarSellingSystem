using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserPass.Focus();
            }
        }

        private void txtUserPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NetCar", true);
            //RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            //                    .OpenSubKey(@"SOFTWARE\NetCar", true);

            string gStrCon = regKey.GetValue("SqlConnection").ToString();
            //string gMachine = regKey.GetValue("Machine").ToString();
            globalVariable.connectionString = gStrCon;
            globalVariable.target_cars_path = @"" + regKey.GetValue("target_cars_path").ToString();
            globalVariable.target_sell_cars_path = @"" + regKey.GetValue("target_sell_cars_path").ToString();
            globalVariable.target_sparePart_path = @"" + regKey.GetValue("target_sparePart_path").ToString();

            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Focus();
                return;
            }
            if (txtUserPass.Text == "")
            {
                txtUserPass.Focus();
                return;
            }

            string genPass = myClass.Encrypt("dfdlUVjslddslkfjdsldadhhcxjjsdlifhdkfhdsjkfhiserereL0njknasd" + txtUserPass.Text + "uhksdhdhirdcdcjxcds5332kmxcxncnlzxlznkcxz");

            int userId = 0;

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM tbl_user Where login_name='" + txtUserName.Text.Trim() + "' And login_pwd='" + genPass + "' And statusid=1";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["userid"]);
                            globalVariable.g_user_id = userId;
                            globalVariable.g_user_name = reader["full_name"].ToString();
                            globalVariable.g_user_role_id = Convert.ToInt32(reader["roleid"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ຊື່ ຫຼື ລະຫັດບໍ່ຖຶກຕ້ອງ....ກະລຸນາລອງໃໝ່ອີກຄັ້ງ.");
                    }
                    conn.Close();
                    if (userId > 0)
                    {
                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login ມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
                
            }

            
        }
    }
}
