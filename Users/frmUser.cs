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

namespace CarSellingSystem.Users
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        int userId = 0;
        private myClass db = new myClass();

        private void frmUser_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboRole_filter, "tbl_user_role", "roleName", "roleId", "", "roleName", true);
            db.FillCombo(cboRole, "tbl_user_role", "roleName", "roleId", "", "roleName", false);

            loadData();
            clear_form();
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnCustomer");

            if (globalVariable.can_add)
            {
                btnAddNew.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
            }
            if (globalVariable.can_edit || globalVariable.can_add)
            {
                btnSave.Visible = true;
                btnNewRole.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnNewRole.Visible = false;
            }
            if (globalVariable.can_delete)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void clear_form()
        {
            userId = 0;
            txtFullName.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            txtTel.Text = "";
            cboRole.SelectedIndex = -1;
            txtFullName.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "")
            {
                txtFullName.Focus();
                return;
            }
            if (txtLogin.Text == "")
            {
                txtLogin.Focus();
                return;
            }

            if (userId == 0)
            {
                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                    return;
                }
            }
            
            if (cboRole.SelectedIndex == -1)
            {
                cboRole.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການບັນທຶກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    try
                    {
                        if (userId == 0)
                        {
                            string encrypt_pass = myClass.Encrypt("dfdlUVjslddslkfjdsldadhhcxjjsdlifhdkfhdsjkfhiserereL0njknasd" + txtPassword.Text + "uhksdhdhirdcdcjxcds5332kmxcxncnlzxlznkcxz");
                            string query = @"
                            INSERT INTO tbl_user (full_name, login_name, login_pwd, roleid, usertel, statusid, createby, createon)
                            VALUES (@FullName, @LoginName, @LoginPwd, @RoleId, @UserTel, @StatusId, @CreateBy, @CreateOn)";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                                cmd.Parameters.AddWithValue("@LoginName", txtLogin.Text.Trim());
                                cmd.Parameters.AddWithValue("@LoginPwd", encrypt_pass);
                                cmd.Parameters.AddWithValue("@RoleId", cboRole.SelectedValue);
                                cmd.Parameters.AddWithValue("@UserTel", txtTel.Text);
                                cmd.Parameters.AddWithValue("@StatusId", 1);
                                cmd.Parameters.AddWithValue("@CreateBy", globalVariable.g_user_name);
                                cmd.Parameters.AddWithValue("@CreateOn",  DateTime.Now);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string query = @"
                            UPDATE tbl_user
                            SET full_name = @FullName,
                                login_name = @LoginName,
                                roleid = @RoleId,
                                usertel = @UserTel,
                                modifyby = @ModifyBy,
                                modifyon = @ModifyOn
                            WHERE userid = @UserId";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                                cmd.Parameters.AddWithValue("@LoginName", txtLogin.Text.Trim());
                                cmd.Parameters.AddWithValue("@RoleId", cboRole.SelectedValue);
                                cmd.Parameters.AddWithValue("@UserTel", txtTel.Text);
                                cmd.Parameters.AddWithValue("@ModifyBy", globalVariable.g_user_name);
                                cmd.Parameters.AddWithValue("@ModifyOn", DateTime.Now);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            if (txtPassword.Text != "")
                            {
                                string encrypt_pass = myClass.Encrypt("dfdlUVjslddslkfjdsldadhhcxjjsdlifhdkfhdsjkfhiserereL0njknasd" + txtPassword.Text + "uhksdhdhirdcdcjxcds5332kmxcxncnlzxlznkcxz");
                                string exc_qry = "update tbl_user set login_pwd='" + encrypt_pass  + "' where userid=" + userId;
                                int exc = db.sqlExecute(exc_qry);
                            }
                        }
                        MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
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
        }

        private void loadData()
        {
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_users ";
                if (cboRole_filter.SelectedIndex > 0)
                {
                    sql = sql + " Where roleId =" + cboRole_filter.SelectedValue + " ";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        dgvData.Rows[rowIndex].Cells["col_user_id"].Value = reader["userid"];
                        dgvData.Rows[rowIndex].Cells["col_full_name"].Value = reader["full_name"];
                        dgvData.Rows[rowIndex].Cells["col_login"].Value = reader["login_name"];
                        dgvData.Rows[rowIndex].Cells["col_tel"].Value = reader["usertel"];
                        dgvData.Rows[rowIndex].Cells["col_role"].Value = reader["roleName"];
                        dgvData.Rows[rowIndex].Cells["col_user_add"].Value = reader["createby"];
                    }
                }
                conn.Close();
                //set_item_rowNo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userId > 0)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string exc_qry = "update tbl_user set statusid=2 where userid=" + userId;
                    int exc = db.sqlExecute(exc_qry);
                    userId = 0;
                    clear_form();
                    loadData();
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

        private void cboRole_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
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

            clear_form();

            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                userId = Convert.ToInt32(row.Cells["col_user_id"].Value);
                string sql = "SELECT * FROM tbl_user Where userid=" + userId;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        cboRole.SelectedValue = reader["roleid"];
                        txtFullName.Text = reader["full_name"].ToString();
                        txtLogin.Text = reader["login_name"].ToString();
                        txtPassword.Text = ""; // reader["login_pwd"].ToString();
                        txtTel.Text = reader["usertel"].ToString();
                        txtFullName.Focus();
                    }
                }
                conn.Close();
            }

        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            frmRoleAccess frm = new frmRoleAccess();
            frm.ShowDialog();
            db.FillCombo(cboRole_filter, "tbl_user_role", "roleName", "roleId", "", "roleName", true);
            db.FillCombo(cboRole, "tbl_user_role", "roleName", "roleId", "", "roleName", false);
        }
    }
}
