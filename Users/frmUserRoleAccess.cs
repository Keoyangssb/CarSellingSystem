using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.Users
{
    public partial class frmUserRoleAccess : Form
    {
        public frmUserRoleAccess()
        {
            InitializeComponent();
        }
        private myClass db = new myClass();

        bool canView;
        bool canAdd;
        bool canEdit;
        bool canDelete;

        private void frmUserRoleAccess_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboRole, "tbl_user_role", "roleName", "roleId", "", "roleName", false);
            cboRole.SelectedIndex = -1;
            LoadMenu();
            CheckRole();
        }

        private void LoadMenu()
        {
            DataTable dt = db.GetDataTable("select menu_id, menu_text from tblmenu order by shortby");

            dgv.Rows.Clear();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = dt.Rows[i]["menu_id"];
                    dgv.Rows[i].Cells[1].Value = dt.Rows[i]["menu_text"];
                }
            }
        }

        private void CheckRole()
        {
            db.CheckRoleAccess(this.Name);

            if (globalVariable.can_add == true || globalVariable.can_edit == true)
            {
                chkAdd.Enabled = true;
                chkEdit.Enabled = true;
                chkDelete.Enabled = true;
                chkView.Enabled = true;
                dgv.ReadOnly = false;
            }
            else
            {
                chkAdd.Enabled = false;
                chkEdit.Enabled = false;
                chkDelete.Enabled = false;
                chkView.Enabled = false;
                dgv.ReadOnly = true;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (frmMain.Instance.tcl.SelectedTab != null)
            {
                frmMain.Instance.tcl.Tabs.Remove(frmMain.Instance.tcl.SelectedTab);
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != -1)
            {
                if (dgv.Rows.Count > 0)
                {
                    SetRoleAccess();
                }
            }
        }

        private void SetRoleAccess()
        {
            int roleId = Convert.ToInt32(cboRole.SelectedValue);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                LoadRoleAccess(roleId, Convert.ToInt32(dgv.Rows[i].Cells[0].Value));

                dgv.Rows[i].Cells[2].Value = canView;
                dgv.Rows[i].Cells[3].Value = canAdd;
                dgv.Rows[i].Cells[4].Value = canEdit;
                dgv.Rows[i].Cells[5].Value = canDelete;
            }
        }

        private void LoadRoleAccess(int roleId, int menuId)
        {
            canAdd = canView = canEdit = canDelete = false;

            string query = "select canAdd, canEdit, canView, canDelete from tb_role_access where roleId=" + roleId + " And " + " menuId= " + menuId;

            DataTable dt = db.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                canAdd = row["canAdd"] != DBNull.Value && Convert.ToBoolean(row["canAdd"]);
                canView = row["canView"] != DBNull.Value && Convert.ToBoolean(row["canView"]);
                canEdit = row["canEdit"] != DBNull.Value && Convert.ToBoolean(row["canEdit"]);
                canDelete = row["canDelete"] != DBNull.Value && Convert.ToBoolean(row["canDelete"]);
            }
         }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            try
            {
                if (cboRole.SelectedIndex != -1)
                {
                    int roleId = Convert.ToInt32(cboRole.SelectedValue);
                    int menuId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);

                    bool nValue;
                    long chkId = 0;

                    chkId = db.nLookup("roleAutoId", "tb_role_access", "roleId=" + roleId + " And menuId=" + menuId);

                    if (e.ColumnIndex == 2) // view
                    {
                        nValue = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[2].Value);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','False','" + nValue + "','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canView='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                    else if (e.ColumnIndex == 3) // add
                    {
                        nValue = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[3].Value);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'" + nValue + "','False','False','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canAdd='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                    else if (e.ColumnIndex == 4) // edit
                    {
                        nValue = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[4].Value);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','" + nValue + "','False','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canEdit='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                    else if (e.ColumnIndex == 5) // delete
                    {
                        nValue = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[5].Value);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','False','False','" + nValue + "')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canDelete='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != -1)
            {
                if (dgv.Rows.Count > 0)
                {
                    if (chkView.Checked)
                    {
                        SetAllView(true);
                    }
                    else
                    {
                        SetAllView(false);
                    }

                    SetRoleAccess();
                }
            }
        }

        private void SetAllView(bool nValue)
        {
            int roleId = Convert.ToInt32(cboRole.SelectedValue);
            int menuId = 0;
            long chkId = 0;

            try
            {
                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        menuId = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);

                        chkId = db.nLookup("roleAutoId", "tb_role_access",
                            "roleId=" + roleId + " And menuId=" + menuId);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','False','" + nValue + "','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canView='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAllAdd(bool nValue)
        {
            int roleId = Convert.ToInt32(cboRole.SelectedValue);
            int menuId = 0;
            long chkId = 0;

            try
            {
                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        menuId = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);

                        chkId = db.nLookup("roleAutoId", "tb_role_access",
                            "roleId=" + roleId + " And menuId=" + menuId);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'" + nValue + "','False','False','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canAdd='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAllEdit(bool nValue)
        {
            int roleId = Convert.ToInt32(cboRole.SelectedValue);
            int menuId = 0;
            long chkId = 0;

            try
            {
                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        menuId = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);

                        chkId = db.nLookup("roleAutoId", "tb_role_access",
                            "roleId=" + roleId + " And menuId=" + menuId);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','" + nValue + "','False','False')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canEdit='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAllDelete(bool nValue)
        {
            int roleId = Convert.ToInt32(cboRole.SelectedValue);
            int menuId = 0;
            long chkId = 0;

            try
            {
                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        menuId = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);

                        chkId = db.nLookup("roleAutoId", "tb_role_access",
                            "roleId=" + roleId + " And menuId=" + menuId);

                        if (chkId == 0)
                        {
                            db.sqlExecute("Insert Into tb_role_access(roleId, menuId, canAdd, canEdit, canView, canDelete) Values("
                                   + roleId + "," + menuId + ",'False','False','False','" + nValue + "')");
                        }
                        else
                        {
                            db.sqlExecute("Update tb_role_access Set canDelete='" + nValue + "' Where roleAutoId=" + chkId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != -1)
            {
                if (dgv.Rows.Count > 0)
                {
                    if (chkAdd.Checked)
                    {
                        SetAllAdd(true);
                    }
                    else
                    {
                        SetAllAdd(false);
                    }

                    SetRoleAccess();
                }
            }
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != -1)
            {
                if (dgv.Rows.Count > 0)
                {
                    if (chkEdit.Checked)
                    {
                        SetAllEdit(true);
                    }
                    else
                    {
                        SetAllEdit(false);
                    }

                    SetRoleAccess();
                }
            }
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != -1)
            {
                if (dgv.Rows.Count > 0)
                {
                    if (chkDelete.Checked)
                    {
                        SetAllDelete(true);
                    }
                    else
                    {
                        SetAllDelete(false);
                    }

                    SetRoleAccess();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmRoleAccess frm = new frmRoleAccess();
            frm.ShowDialog();
            db.FillCombo(cboRole, "tbl_user_role", "roleName", "roleId", "", "roleName", false);
        }

    }
}
