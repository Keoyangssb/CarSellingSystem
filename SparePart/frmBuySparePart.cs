using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarSellingSystem.SparePart
{
    public partial class frmBuySparePart : Form
    {
        public frmBuySparePart()
        {
            InitializeComponent();
        }

        public long transaction_id = 0;
        private myClass db = new myClass();

        private void frmBuySparePart_Load(object sender, EventArgs e)
        {
            db.FillCombo(cboCurFee, "tbl_currency", "cur_name", "cur_id", "status_id=1", "", false);
            if (transaction_id > 0)
            {
                loadData();
            }
            else
            {
                clear_form();
            }
            CheckRole();
        }

        private void CheckRole()
        {
            db.CheckRoleAccess("btnBuySparePartList");
            if (globalVariable.can_add || globalVariable.can_edit)
            {
                btnAddNew.Visible = true;
                btnSave.Visible = true;
                btnPayment.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnPayment.Visible = false;
                db.SetControlsEnabled(this, false);
            }
            if (globalVariable.can_delete)
            {
                btnDelete.Visible = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnDelete.Enabled = true;
            }
            btnClose.Enabled = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
            create_tran_no();
        }

        private void clear_form()
        {
            transaction_id = 0;
            txtBuyNo.Text = "";
            dgvData.Rows.Clear();
            txtRemark.Text = "";
            txtGrandTotal.Text = "";
            txtTransportFee.Text = "";
            txtTotal.Text = "";
            txtPaid.Text = "";
            txtBalance.Text = "";
            chkCreateNo.Enabled = true;
            txtBuyNo.ReadOnly = false;
            set_item_rowNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    if (txtBuyNo.Text == "")
                    {
                        MessageBox.Show("ກະລຸນາປ້ອນເລກທີຊື້ກ່ອນ.");
                        txtBuyNo.Focus();
                        return;
                    }
                    if (dgvData.Rows.Count == 0)
                    {
                        MessageBox.Show("ກະລຸນາໃສ່ຂໍ້ມູນອາໄຫຼ່ກ່ອນ.");
                        return;
                    }

                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvData.Rows[i];

                        if (row.Cells["col_type"].Value == null)
                        {
                            MessageBox.Show("ກະລຸນາເລືອກປະເພດອາໄຫຼ່ໃຫ້ຄົບກ່ອນ.");
                            return;
                        }

                        if (row.Cells["col_name"].Value == null)
                        {
                            MessageBox.Show("ກະລຸນາປ້ອນຊື່ອາໄຫຼ່ໃຫ້ຄົບກ່ອນ.");
                            return;
                        }

                        decimal price_amount = 0;
                        int qty = 0;

                        if (row.Cells["col_buy_price"].Value != null)
                        {
                            price_amount = Convert.ToDecimal(row.Cells["col_buy_price"].Value);
                        }
                        if (row.Cells["col_qty"].Value != null)
                        {
                            qty = Convert.ToInt32(row.Cells["col_qty"].Value);
                        }

                        if (qty == 0)
                        {
                            MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນໃຫ້ຄົບກ່ອນ.");
                            return;
                        }

                        if (price_amount == 0)
                        {
                            MessageBox.Show("ກະລຸນາປ້ອນລາຄາຊື້ໃຫ້ຄົບກ່ອນ.");
                            return;
                        }
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

                    if (transaction_id == 0)
                    {
                        long run_no = db.XMax("tbl_buy_spare_part", "run_num", "", 0) + 1;
                        string tran_no = "";
                        if (txtBuyNo.Text == "")
                        {
                            tran_no = "ID-" + run_no.ToString("D4");
                        }else{
                            tran_no = txtBuyNo.Text;
                        }
                        
                        string insertQuery = @"
                            INSERT INTO [dbo].[tbl_buy_spare_part] (
                                [buy_id],
                                [run_num],
                                [buy_no],
                                [buy_date],
                                [transport_fee],
                                [transport_fee_cur_id],
                                [remarks],
                                [status_id],
                                [created_date],
                                [created_user]
                            )
                            VALUES (
                                @buy_id,
                                @run_num,
                                @buy_no,
                                @buy_date,
                                @transport_fee,
                                @transport_fee_cur_id,
                                @remarks,
                                @status_id,
                                @created_date,
                                @created_user
                            )";

                        transaction_id = db.XMax("tbl_buy_spare_part", "buy_id", "", 0) + 1;

                        using (SqlCommand command = new SqlCommand(insertQuery, conn))
                        {
                            command.Parameters.AddWithValue("@buy_id", transaction_id); // Replace with actual value
                            command.Parameters.AddWithValue("@run_num", run_no);
                            command.Parameters.AddWithValue("@buy_no", tran_no);
                            command.Parameters.AddWithValue("@buy_date", dtBuy.Value);
                            command.Parameters.AddWithValue("@transport_fee", db.ToNumberDecimal(txtTransportFee.Text));
                            command.Parameters.AddWithValue("@transport_fee_cur_id", cboCurFee.SelectedValue);
                            command.Parameters.AddWithValue("@remarks", txtRemark.Text);
                            command.Parameters.AddWithValue("@status_id", 1);
                            command.Parameters.AddWithValue("@created_date", DateTime.Now);
                            command.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                            conn.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateQuery = @"
                                UPDATE [dbo].[tbl_buy_spare_part]
                                SET
                                buy_date = @buy_date,
                                transport_fee = @transport_fee,
                                transport_fee_cur_id = @transport_fee_cur_id,
                                remarks = @remarks,
                                modify_date = @modify_date,
                                modify_user = @modify_user
                                WHERE buy_id = @buy_id";

                        using (SqlCommand command = new SqlCommand(updateQuery, conn))
                        {
                            // Set parameters
                            command.Parameters.AddWithValue("@buy_id", transaction_id); // The ID of the record to update
                            command.Parameters.AddWithValue("@buy_date", dtBuy.Value);
                            command.Parameters.AddWithValue("@transport_fee", db.ToNumberDecimal(txtTransportFee.Text));
                            command.Parameters.AddWithValue("@transport_fee_cur_id", cboCurFee.SelectedValue);
                            command.Parameters.AddWithValue("@remarks", txtRemark.Text);
                            command.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            command.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                        }
                    }

                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvData.Rows[i];

                        int spp_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                        string item_name = row.Cells["col_name"].Value.ToString();
                        int item_qty = Convert.ToInt32(row.Cells["col_qty"].Value);
                        decimal buy_price = Convert.ToDecimal(row.Cells["col_buy_price"].Value);
                        int buy_cur_id = Convert.ToInt32(row.Cells["col_currency"].Tag);

                        long check_id = db.nLookup("detail_id", "tbl_buy_spare_part_item", "buy_id=" + transaction_id + " And spp_id=" + spp_item_id + " And status_id=1");
                        if (check_id == 0)
                        {
                            string insertQuery = @"
                            INSERT INTO [dbo].[tbl_buy_spare_part_item] (
                                buy_id,
                                spp_id,
                                spp_name,
                                buy_price,
                                buy_currency_id,
                                buy_qty,
                                status_id
                            ) VALUES (
                                @buy_id,
                                @spp_id,
                                @spp_name,
                                @buy_price,
                                @buy_currency_id,
                                @buy_qty,
                                @status_id
                            )";

                            SqlCommand sqlCom_item = new SqlCommand(insertQuery, conn);
                            sqlCom_item.Parameters.AddWithValue("@buy_id", transaction_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_id", spp_item_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_name", item_name);
                            sqlCom_item.Parameters.AddWithValue("@buy_price", buy_price);
                            sqlCom_item.Parameters.AddWithValue("@buy_currency_id", buy_cur_id);
                            sqlCom_item.Parameters.AddWithValue("@buy_qty", item_qty);
                            sqlCom_item.Parameters.AddWithValue("@status_id", 1);
                            int rowsInserted = sqlCom_item.ExecuteNonQuery();
                        }
                        else
                        {
                            string updateQuery = @"
                            UPDATE [dbo].[tbl_buy_spare_part_item]
                            SET
                                spp_name = @spp_name,
                                buy_price = @buy_price,
                                buy_qty = @buy_qty
                            WHERE detail_id = @detail_id";

                            SqlCommand sqlCom_item = new SqlCommand(updateQuery, conn);
                            sqlCom_item.Parameters.AddWithValue("@detail_id", check_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_name", item_name);
                            sqlCom_item.Parameters.AddWithValue("@buy_price", buy_price);
                            sqlCom_item.Parameters.AddWithValue("@buy_qty", item_qty);
                            int rowsInserted = sqlCom_item.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    conn.Close();
                    //load item
                    loadDataItem();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ບັນທຶກມີຂໍ້ຜິດຜາດ. >> " + ex.Message.ToString());
                    conn.Close();
                }
            }
        }

        private void loadData()
        {
            txtPaid.Text = "";
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_buy_spare_part Where buy_id=" + transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtBuyNo.Text = reader["buy_no"].ToString();
                        dtBuy.Value = Convert.ToDateTime(reader["buy_date"]);
                        txtRemark.Text = reader["remarks"].ToString();
                        txtTransportFee.Text = Convert.ToDecimal(reader["transport_fee"]).ToString(globalVariable.format_currency_usd);
                        cboCurFee.SelectedValue = Convert.ToInt32(reader["transport_fee_cur_id"]);
                        //load total paid
                        decimal totalBuyPaid = db.XSum("pay_amount_in_currency", "tbl_buy_spare_part_payment", "buy_id=" + transaction_id + " And status_id=1");
                        txtPaid.Text = totalBuyPaid.ToString(globalVariable.format_currency_usd);
                    }
                }
            }
            loadDataItem();
        }

        private void loadDataItem()
        {
            if (transaction_id > 0)
            {
                chkCreateNo.Enabled = false;
                txtBuyNo.ReadOnly = true;
            }
            else
            {
                chkCreateNo.Enabled = true;
                txtBuyNo.ReadOnly = false;
            }
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_buySparePart Where buy_id=" + transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        DataGridViewRow row2 = dgvData.Rows[rowIndex];
                        row2.Cells["col_buy_item_id"].Value = reader["detail_id"].ToString();
                        row2.Cells["col_item_id"].Value = reader["spp_id"].ToString();
                        row2.Cells["col_sell_type"].Value = reader["spp_sell_type_name"].ToString();
                        row2.Cells["col_type"].Value = reader["spp_type_name"].ToString();
                        row2.Cells["col_name"].Value = reader["spp_name"].ToString();
                        row2.Cells["col_qty"].Value = reader["buy_qty"].ToString();
                        row2.Cells["col_unit"].Value = reader["unit_name"].ToString();
                        row2.Cells["col_buy_price"].Value = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_total"].Value = 0;
                        row2.Cells["col_currency"].Value = reader["cur_name"].ToString();
                        row2.Cells["col_currency"].Tag = reader["buy_currency_id"].ToString();
                    }
                }
                conn.Close();
                set_item_rowNo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (transaction_id > 0)
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບຂໍ້ມູນຊື້ອາໄຫຼ່ອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int del_buy = db.sqlExecute("Update tbl_buy_spare_part Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where buy_id=" + transaction_id);
                    int del_freeItem = db.sqlExecute("Update tbl_buy_spare_part_item Set status_id=2 Where buy_id=" + transaction_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    clear_form();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Add();
            set_item_rowNo();
        }

        private void set_item_rowNo()
        {
            decimal grand_total = 0;
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                DataGridViewRow row = dgvData.Rows[i];
                
                row.Cells["col_item_no"].Value = i + 1;
                row.Cells["col_browse_item"].Value = "ເລືອກລາຍການ";
                row.Cells["col_item_del"].Value = "ລົບອອກ";

                decimal price = 0;
                int qty = 0;
                decimal total_amount = 0;

                if (row.Cells["col_buy_price"].Value != null)
                {
                    price = Convert.ToDecimal(row.Cells["col_buy_price"].Value);
                }
                if (row.Cells["col_qty"].Value != null)
                {
                    qty = Convert.ToInt32(row.Cells["col_qty"].Value);
                }

                total_amount = price * qty;
                grand_total = grand_total + total_amount;
                row.Cells["col_buy_price"].Value = price.ToString(globalVariable.format_currency_usd);
                row.Cells["col_total"].Value = total_amount.ToString(globalVariable.format_currency_usd);
            }
            txtTotal.Text = grand_total.ToString(globalVariable.format_currency_usd);
            decimal transport_amount = db.ToNumberDecimal(txtTransportFee.Text);
            grand_total = grand_total + transport_amount;
            txtGrandTotal.Text = grand_total.ToString(globalVariable.format_currency_usd);
            decimal total_paid = db.ToNumberDecimal(txtPaid.Text);
            decimal balance = grand_total - total_paid;
            txtBalance.Text = balance.ToString(globalVariable.format_currency_usd);
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

            string columnName = dgvData.Columns[e.ColumnIndex].Name;

            if (columnName == "col_browse_item")
            {
                globalVariable.get_free_item_id = 0;
                frmBrowseSparePart frm = new frmBrowseSparePart();
                frm.ShowDialog();
                if (globalVariable.get_free_item_id > 0)
                {
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvData.Rows[i];
                        if (row.Cells["col_item_id"].Value != null)
                        {
                            int existing_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                            if (globalVariable.get_free_item_id == existing_item_id)
                            {
                                if (row.Cells["col_qty"].Value != null)
                                {
                                    row.Cells["col_qty"].Value = Convert.ToInt32(row.Cells["col_qty"].Value) + 1;
                                }
                                set_item_rowNo();
                                return;
                            }
                        }
                    }

                    using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                    {
                        string sql = "SELECT * FROM v_sparePart Where spp_id=" + globalVariable.get_free_item_id;
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                DataGridViewRow row2 = dgvData.Rows[e.RowIndex];
                                row2.Cells["col_item_id"].Value = reader["spp_id"].ToString();
                                row2.Cells["col_sell_type"].Value = reader["spp_sell_type_name"].ToString();
                                row2.Cells["col_type"].Value = reader["spp_type_name"].ToString();
                                row2.Cells["col_name"].Value = reader["spp_name"].ToString();
                                row2.Cells["col_qty"].Value = 1;
                                row2.Cells["col_unit"].Value = reader["unit_name"].ToString();
                                row2.Cells["col_buy_price"].Value = Convert.ToDecimal(reader["buy_price"]).ToString(globalVariable.format_currency_usd);
                                row2.Cells["col_total"].Value = 0;
                                row2.Cells["col_currency"].Value = reader["cur_name"].ToString();
                                row2.Cells["col_currency"].Tag = reader["buy_currency_id"].ToString();
                                set_item_rowNo();
                            }
                        }
                        conn.Close();
                    }
                }
            }
            else if (columnName == "col_item_del")
            {
                DialogResult result = MessageBox.Show(
                    "ທ່ານຕ້ອງການລົບອອກບໍ?",
                    "ຂໍ້ຄວາມເຕືອນ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow row = dgvData.Rows[e.RowIndex];
                        if (row.Cells["col_buy_item_id"].Value != null)
                        {
                            int free_item_id = Convert.ToInt32(row.Cells["col_buy_item_id"].Value);
                            if (free_item_id > 0)
                            {
                                string exc_qry = "update tbl_buy_spare_part_item set status_id=2 where detail_id=" + free_item_id;
                                int exc = db.sqlExecute(exc_qry);
                            }
                        }
                        dgvData.Rows.RemoveAt(e.RowIndex);
                        set_item_rowNo();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == -1)
            {
                return;
            }
            set_item_rowNo();
        }

        private void txtTransportFee_Leave(object sender, EventArgs e)
        {
            double c_amount = db.ToNumber(txtTransportFee.Text);
            txtTransportFee.Text = c_amount.ToString(globalVariable.format_currency_usd);
            set_item_rowNo();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (transaction_id > 0)
            {
                frmBuySparePartPayment frm = new frmBuySparePartPayment();
                frm.buy_transaction_id = transaction_id;
                frm.ShowDialog();
                loadData();
            }
        }

        private void chkCreateNo_CheckedChanged(object sender, EventArgs e)
        {
            if (transaction_id == 0)
            {
                create_tran_no();
            }
        }

        private void create_tran_no()
        {
            if (chkCreateNo.Checked)
            {
                long run_no = db.XMax("tbl_buy_spare_part", "run_num", "", 0) + 1;
                string sale_no = "BN-" + run_no.ToString("D4");
                txtBuyNo.Text = sale_no;
            }
            else
            {
                txtBuyNo.Text = "";
            }
        }

    }
}
