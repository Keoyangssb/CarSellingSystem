using CarSellingSystem.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;

namespace CarSellingSystem.SparePart
{
    public partial class frmSparePart : Form
    {
        public frmSparePart()
        {
            InitializeComponent();
        }

        private myClass db = new myClass();
        int item_id = 0;

        private void frmSparePart_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboSellType, "tbl_spare_part_sell_type", "spp_sell_type_name", "spp_sell_type_id", "", "spp_sell_type_id", false);
            db.FillCombo(cboType, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "spp_type_name", false);
            db.FillCombo(cboUnit, "tbl_spare_part_unit", "unit_name", "unit_id", "", "unit_name", false);
            db.FillCombo(cboCurBuy, "tbl_currency", "cur_name", "cur_id", "status_id=1", "cur_id", false);
            db.FillCombo(cboCurSell, "tbl_currency", "cur_name", "cur_id", "status_id=1", "cur_id", false);

            db.FillCombo(cboSellType_filter, "tbl_spare_part_sell_type", "spp_sell_type_name", "spp_sell_type_id", "", "spp_sell_type_id", true);
            db.FillCombo(cboType_filter, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "spp_type_name", true);

            clear_form();

            loadData();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void clear_form()
        {
            item_id = 0;
            cboSellType.SelectedIndex = -1;
            cboType.SelectedIndex = -1;
            cboUnit.SelectedIndex = -1;
            cboCurBuy.SelectedIndex = -1;
            cboCurSell.SelectedIndex = -1;
            txtBuyPrice.Text = "";
            txtName.Text = "";
            txtSalePrice.Text = "";
            pic_item.Image = null;
            pic_item.Tag = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboSellType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປະເພດຂາຍກ່ອນ.");
                cboSellType.Focus();
                return;
            }
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກປະເພດອາໄຫຼ່ກ່ອນ.");
                cboType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("ກະລຸນາປ້ອນຊື່ອາໄຫຼ່ກ່ອນ.");
                txtName.Focus();
                return;
            }
            if (cboUnit.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກຫົວໜ່ວຍກ່ອນ.");
                cboUnit.Focus();
                return;
            }
            if (cboCurBuy.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກສະກຸນເງິນຊື້ກ່ອນ.");
                cboCurBuy.Focus();
                return;
            }
            if (cboCurSell.SelectedIndex == -1)
            {
                MessageBox.Show("ກະລຸນາເລືອກສະກຸນເງິນຂາຍກ່ອນ.");
                cboCurSell.Focus();
                return;
            }

            double buy_price = db.ToNumber(txtBuyPrice.Text);
            double sell_price = db.ToNumber(txtSalePrice.Text);


            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                    {
                        string targetPath = globalVariable.target_sparePart_path;
                        string fullPath = "";
                        if (pic_item.Image != null){
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            string originalPath = pic_item.Tag.ToString();
                            string extension = ".jpg"; // default
                            if (!string.IsNullOrEmpty(originalPath))
                            {
                                extension = Path.GetExtension(originalPath);
                            }
                            string fileName = "SppImage_" + globalVariable.g_user_id.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                            fullPath = Path.Combine(targetPath, fileName);
                            pic_item.Image.Save(fullPath);
                        }
                        

                        if (item_id == 0)
                        {
                            string query = @"
                            INSERT INTO [dbo].[tbl_spare_part] (
                                [spp_sell_type_id], [spp_type_id], [spp_name], [unit_id],
                                [buy_price], [buy_currency_id], [sell_price], [sell_currency_id],
                                [image_path], [status_id], [modify_date], [modify_user]
                            )
                            VALUES (
                                @spp_sell_type_id, @spp_type_id, @spp_name, @unit_id,
                                @buy_price, @buy_currency_id, @sell_price, @sell_currency_id,
                                @image_path, @status_id, @modify_date, @modify_user);";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@spp_sell_type_id", cboSellType.SelectedValue);
                                cmd.Parameters.AddWithValue("@spp_type_id", cboType.SelectedValue);
                                cmd.Parameters.AddWithValue("@spp_name", txtName.Text);
                                cmd.Parameters.AddWithValue("@unit_id", cboUnit.SelectedValue);
                                cmd.Parameters.AddWithValue("@buy_price", buy_price);
                                cmd.Parameters.AddWithValue("@buy_currency_id", cboCurBuy.SelectedValue);
                                cmd.Parameters.AddWithValue("@sell_price", sell_price);
                                cmd.Parameters.AddWithValue("@sell_currency_id", cboCurSell.SelectedValue);
                                cmd.Parameters.AddWithValue("@image_path", fullPath);
                                cmd.Parameters.AddWithValue("@status_id", 1);
                                cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string query = @"
                                UPDATE [dbo].[tbl_spare_part]
                                SET
                                [spp_sell_type_id] = @spp_sell_type_id,
                                [spp_type_id] = @spp_type_id,
                                [spp_name] = @spp_name,
                                [unit_id] = @unit_id,
                                [buy_price] = @buy_price,
                                [buy_currency_id] = @buy_currency_id,
                                [sell_price] = @sell_price,
                                [sell_currency_id] = @sell_currency_id,
                                [image_path] = @image_path,
                                [modify_date] = @modify_date,
                                [modify_user] = @modify_user
                                WHERE [spp_id] = @spp_id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@spp_id", item_id);
                                cmd.Parameters.AddWithValue("@spp_sell_type_id", cboSellType.SelectedValue);
                                cmd.Parameters.AddWithValue("@spp_type_id", cboType.SelectedValue);
                                cmd.Parameters.AddWithValue("@spp_name", txtName.Text);
                                cmd.Parameters.AddWithValue("@unit_id", cboUnit.SelectedValue);
                                cmd.Parameters.AddWithValue("@buy_price", buy_price);
                                cmd.Parameters.AddWithValue("@buy_currency_id", cboCurBuy.SelectedValue);
                                cmd.Parameters.AddWithValue("@sell_price", sell_price);
                                cmd.Parameters.AddWithValue("@sell_currency_id", cboCurSell.SelectedValue);
                                cmd.Parameters.AddWithValue("@image_path", fullPath);
                                cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                        conn.Close();
                        clear_form();
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
            if (item_id > 0)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string exc_qry = "update tbl_spare_part set status_id=2 where spp_id=" + item_id;
                    int exc = db.sqlExecute(exc_qry);
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

        private void btn_upload_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic_item.Image = null;
                pic_item.Tag = "";
                pic_item.Refresh();
                try
                {
                    pic_item.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    pic_item.Tag = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }

        }

        private void btn_delete_pic_Click(object sender, EventArgs e)
        {
            pic_item.Image = null;
            pic_item.Tag = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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

                        dgvData.Rows[rowIndex].Cells["col_user"].Value = reader["modify_user"];
                        dgvData.Rows[rowIndex].Cells["col_item_del"].Value = "ລົບອອກ";
                    }
                }
                conn.Close();
                //set_item_rowNo();
            }
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

            item_id = 0;

            DataGridViewRow row = dgvData.Rows[e.RowIndex];

            string columnName = dgvData.Columns[e.ColumnIndex].Name;

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
                        string exc_qry = "update tbl_spare_part set status_id=2 where spp_id=" + get_item_id;
                        int exc = db.sqlExecute(exc_qry);
                    }
                    dgvData.Rows.RemoveAt(e.RowIndex);
                    clear_form();
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                {
                    item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                    string sql = "SELECT * FROM tbl_spare_part Where spp_id=" + item_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cboSellType.SelectedValue = reader["spp_sell_type_id"];
                            cboType.SelectedValue = reader["spp_type_id"];
                            txtName.Text = reader["spp_name"].ToString();
                            cboUnit.SelectedValue = reader["unit_id"];
                            txtBuyPrice.Text = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                            txtSalePrice.Text = Convert.ToDecimal(reader["sell_price"]).ToString(globalVariable.format_currency_usd);
                            cboCurBuy.SelectedValue = reader["buy_currency_id"];
                            cboCurSell.SelectedValue = reader["sell_currency_id"];
                            if (!string.IsNullOrEmpty(reader["image_path"].ToString()))
                            {
                                pic_item.Image = Image.FromFile(reader["image_path"].ToString());
                                pic_item.Tag = reader["image_path"].ToString();
                            }
                            else
                            {
                                pic_item.Image = null;
                                pic_item.Tag = "";
                            }
                        }
                    }
                }
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            frmSparePartType frm = new frmSparePartType();
            frm.ShowDialog();
            db.FillCombo(cboType, "tbl_spare_part_type", "spp_type_name", "spp_type_id", "status_id=1", "spp_type_name", false);
        }

        private void pic_item_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(pic_item.Tag.ToString()))
            {
                frmPreviewImage frm = new frmPreviewImage();
                frm.image_path = pic_item.Tag.ToString();
                frm.ShowDialog();
            }
        }

    }
}
