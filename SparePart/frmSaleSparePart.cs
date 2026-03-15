using CarSellingSystem.Customer;
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

namespace CarSellingSystem.SparePart
{
    public partial class frmSaleSparePart : Form
    {
        public frmSaleSparePart()
        {
            InitializeComponent();
        }

        public long transaction_id = 0;
        private myClass db = new myClass();
        int customer_id = 0;
        double exc_bath_usd = 0;
        double exc_kip_usd = 0;

        private void frmSaleSparePart_Load(object sender, EventArgs e)
        {

            if (transaction_id > 0)
            {
                loadSaleSPP();
            }
            else
            {
                clear_form();
            }
        }

        private void loadSaleSPP()
        {
            txtPaid.Text = "";
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tbl_sell_sparePart Where sale_id=" + transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtTranNo.Text = reader["sale_no"].ToString();
                        dtSale.Value = Convert.ToDateTime(reader["sale_date"]);
                        txtRemark.Text = reader["remarks"].ToString();
                        //load total paid
                        decimal totalBuyPaid = db.XSum("pay_amount_in_currency", "tbl_sell_sparePart_payment", "sale_id=" + transaction_id + " And status_id=1");
                        txtPaid.Text = totalBuyPaid.ToString(globalVariable.format_currency_usd);
                        customer_id = Convert.ToInt32(reader["customer_id"]);
                        getCustomerInfo();
                    }
                }
            }
            loadDataItem();
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

                if (row.Cells["col_sale_price"].Value != null)
                {
                    price = Convert.ToDecimal(row.Cells["col_sale_price"].Value);
                }
                if (row.Cells["col_qty"].Value != null)
                {
                    qty = Convert.ToInt32(row.Cells["col_qty"].Value);
                }

                total_amount = price * qty;
                grand_total = grand_total + total_amount;
                row.Cells["col_sale_price"].Value = price.ToString(globalVariable.format_currency_usd);
                row.Cells["col_total"].Value = total_amount.ToString(globalVariable.format_currency_usd);
            }
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
                                row2.Cells["col_sale_price"].Value = Convert.ToDecimal(reader["sell_price"]).ToString(globalVariable.format_currency_usd);
                                row2.Cells["col_total"].Value = 0;
                                string cur_name = db.XLookup("cur_name", "tbl_currency", "cur_id=" + reader["sell_currency_id"]);
                                row2.Cells["col_currency"].Value = cur_name;
                                row2.Cells["col_currency"].Tag = reader["sell_currency_id"].ToString();
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
                                string exc_qry = "update tbl_sell_sparePart_item set status_id=2 where detail_id=" + free_item_id;
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
                long run_no = db.XMax("tbl_sell_sparePart", "run_num", "", 0) + 1;
                string sale_no = "SN-" + run_no.ToString("D4");
                txtTranNo.Text = sale_no;
            }
            else
            {
                txtTranNo.Text = "";
            }
        }

        private void btnBrowseCustomer_Click(object sender, EventArgs e)
        {
            frmBrowseCustomer frm = new frmBrowseCustomer();
            frm.ShowDialog();
            if (globalVariable.selling_customer_id > 0)
            {
                customer_id = globalVariable.selling_customer_id;
                getCustomerInfo();
            }
        }

        private void getCustomerInfo()
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM tbl_customer Where cus_id=" + customer_id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            txt_cusFullName.Tag = reader["cus_id"].ToString();
                            txt_cusFullName.Text = reader["cus_full_name"].ToString();
                            txt_village.Text = reader["cus_village"].ToString();
                            txt_district.Text = reader["cus_district"].ToString();
                            txt_province.Text = reader["cus_province"].ToString();
                            txt_tel.Text = reader["cus_tel"].ToString();
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clear_form();
            create_tran_no();
        }

        private void clear_form()
        {
            transaction_id = 0;
            txtTranNo.Text = "";
            dgvData.Rows.Clear();
            txtRemark.Text = "";
            txtGrandTotal.Text = "";
            txtPaid.Text = "";
            txtBalance.Text = "";
            chkCreateNo.Enabled = true;
            txtTranNo.ReadOnly = false;
            customer_id = 0;
            txt_cusFullName.Text = "";
            txt_district.Text = "";
            txt_province.Text = "";
            txt_tel.Text = "";
            txt_village.Text = "";
            set_item_rowNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    if (txtTranNo.Text == "")
                    {
                        MessageBox.Show("ກະລຸນາປ້ອນເລກທີຂາຍກ່ອນ.");
                        txtTranNo.Focus();
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

                        if (row.Cells["col_sale_price"].Value != null)
                        {
                            price_amount = Convert.ToDecimal(row.Cells["col_sale_price"].Value);
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

                    if (customer_id == 0 || txt_cusFullName.Text == "")
                    {
                        MessageBox.Show("ກະລຸນາເລືອກລູກຄ້າກ່ອນ.");
                        btnBrowseCustomer.Focus();
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

                    if (transaction_id == 0)
                    {
                        exc_bath_usd = db.NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
                        exc_kip_usd = db.NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");

                        long run_no = db.XMax("tbl_sell_sparePart", "run_num", "", 0) + 1;

                        string insertQuery = @"
                        INSERT INTO [dbo].[tbl_sell_sparePart] (
                            sale_id,
                            run_num,
                            sale_no,
                            sale_date,
                            customer_id,
                            remarks,
                            rate_kip2usd,
                            rate_bath2usd,
                            status_id,
                            created_date,
                            created_user
                        ) VALUES (
                            @sale_id,
                            @run_num,
                            @sale_no,
                            @sale_date,
                            @customer_id,
                            @remarks,
                            @rate_kip2usd,
                            @rate_bath2usd,
                            @status_id,
                            @created_date,
                            @created_user
                        )";

                        transaction_id = db.XMax("tbl_sell_sparePart", "sale_id", "", 0) + 1;

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@sale_id", transaction_id); // Should be unique if it's not an IDENTITY
                            cmd.Parameters.AddWithValue("@run_num", run_no);
                            cmd.Parameters.AddWithValue("@sale_no", txtTranNo.Text);
                            cmd.Parameters.AddWithValue("@sale_date", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@customer_id", customer_id);
                            cmd.Parameters.AddWithValue("@remarks", txtRemark.Text);
                            cmd.Parameters.AddWithValue("@rate_kip2usd", exc_kip_usd);
                            cmd.Parameters.AddWithValue("@rate_bath2usd", exc_bath_usd);
                            cmd.Parameters.AddWithValue("@status_id", 1);
                            cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateQuery = @"
                        UPDATE [dbo].[tbl_sell_sparePart]
                        SET
                            sale_date = @sale_date,
                            customer_id = @customer_id,
                            remarks = @remarks,
                            modify_date = @modify_date,
                            modify_user = @modify_user
                        WHERE
                            sale_id = @sale_id";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            // Set parameters
                            cmd.Parameters.AddWithValue("@sale_id", transaction_id); // Should be unique if it's not an IDENTITY
                            cmd.Parameters.AddWithValue("@sale_date", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@customer_id", customer_id);
                            cmd.Parameters.AddWithValue("@remarks", txtRemark.Text);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }

                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvData.Rows[i];

                        int spp_item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                        string item_name = row.Cells["col_name"].Value.ToString();
                        int item_qty = Convert.ToInt32(row.Cells["col_qty"].Value);
                        decimal sell_price = Convert.ToDecimal(row.Cells["col_sale_price"].Value);
                        int sell_cur_id = Convert.ToInt32(row.Cells["col_currency"].Tag);

                        long check_id = db.nLookup("detail_id", "tbl_sell_sparePart_item", "sale_id=" + transaction_id + " And spp_id=" + spp_item_id + " And status_id=1");
                        if (check_id == 0)
                        {
                            string insertQuery = @"
                            INSERT INTO [dbo].[tbl_sell_sparePart_item] (
                                sale_id,
                                spp_id,
                                spp_name,
                                sell_price,
                                sell_currency_id,
                                sell_qty,
                                status_id
                            ) VALUES (
                                @sale_id,
                                @spp_id,
                                @spp_name,
                                @sell_price,
                                @sell_currency_id,
                                @sell_qty,
                                @status_id
                            )";

                            SqlCommand sqlCom_item = new SqlCommand(insertQuery, conn);
                            sqlCom_item.Parameters.AddWithValue("@sale_id", transaction_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_id", spp_item_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_name", item_name);
                            sqlCom_item.Parameters.AddWithValue("@sell_price", sell_price);
                            sqlCom_item.Parameters.AddWithValue("@sell_currency_id", sell_cur_id);
                            sqlCom_item.Parameters.AddWithValue("@sell_qty", item_qty);
                            sqlCom_item.Parameters.AddWithValue("@status_id", 1);
                            int rowsInserted = sqlCom_item.ExecuteNonQuery();
                        }
                        else
                        {
                            string updateQuery = @"
                            UPDATE [dbo].[tbl_sell_sparePart_item]
                            SET
                                spp_name = @spp_name,
                                sell_price = @sell_price,
                                sell_qty = @sell_qty
                            WHERE detail_id = @detail_id";

                            SqlCommand sqlCom_item = new SqlCommand(updateQuery, conn);
                            sqlCom_item.Parameters.AddWithValue("@detail_id", check_id);
                            sqlCom_item.Parameters.AddWithValue("@spp_name", item_name);
                            sqlCom_item.Parameters.AddWithValue("@sell_price", sell_price);
                            sqlCom_item.Parameters.AddWithValue("@sell_qty", item_qty);
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

        private void loadDataItem()
        {
            if (transaction_id > 0)
            {
                chkCreateNo.Enabled = false;
                txtTranNo.ReadOnly = true;
            }
            else
            {
                chkCreateNo.Enabled = true;
                txtTranNo.ReadOnly = false;
            }
            dgvData.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM v_sellSparePart_item Where sale_id=" + transaction_id;
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
                        row2.Cells["col_qty"].Value = reader["sell_qty"].ToString();
                        row2.Cells["col_unit"].Value = reader["unit_name"].ToString();
                        row2.Cells["col_sale_price"].Value = Convert.ToDecimal(reader["sell_price"]).ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_total"].Value = 0;
                        row2.Cells["col_currency"].Value = reader["cur_name"].ToString();
                        row2.Cells["col_currency"].Tag = reader["sell_currency_id"].ToString();
                    }
                }
                conn.Close();
                set_item_rowNo();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (transaction_id > 0)
            {
                frmSaleSparePartPayment frm = new frmSaleSparePartPayment();
                frm.transaction_id = transaction_id;
                frm.ShowDialog();
                loadSaleSPP();
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
                    int del_buy = db.sqlExecute("Update tbl_sell_sparePart Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where sale_id=" + transaction_id);
                    int del_freeItem = db.sqlExecute("Update tbl_sell_sparePart_item Set status_id=2 Where sale_id=" + transaction_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    clear_form();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
