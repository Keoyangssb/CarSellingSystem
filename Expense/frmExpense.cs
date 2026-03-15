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

namespace CarSellingSystem.Expense
{
    public partial class frmExpense : Form
    {
        public frmExpense()
        {
            InitializeComponent();
        }
        public long transaction_id = 0;
        double exc_bath_usd = 0;
        double exc_kip_usd = 0;

        private myClass db = new myClass();

        private void frmExpense_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_carsDataSet.tbl_currency' table. You can move, or remove it, as needed.
            //this.tbl_currencyTableAdapter.Fill(this.db_carsDataSet.tbl_currency);
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
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                string sql = "SELECT * FROM tblExpense Where expId=" + transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtTranNo.Text = reader["exp_no"].ToString();
                        dtDate.Value = Convert.ToDateTime(reader["exp_date"]);
                        txtRemark.Text = reader["exp_description"].ToString();
                    }
                }
            }
            loadDataItem();
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
                long run_no = db.XMax("tblExpense", "run_num", "", 0) + 1;
                string sale_no = "PAY-" + run_no.ToString("D5");
                txtTranNo.Text = sale_no;
            }
            else
            {
                txtTranNo.Text = "";
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvData.Rows.Add();
            DataGridViewRow row = dgvData.Rows[rowIndex];
            DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
            comboCell.Items.AddRange("ກີບ", "ບາດ", "ໂດລາ");
            row.Cells["col_currency"] = comboCell;

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

                decimal total_amount = 0;

                if (row.Cells["col_amount"].Value != null)
                {
                    total_amount = Convert.ToDecimal(row.Cells["col_amount"].Value);
                    row.Cells["col_amount"].Value = total_amount.ToString(globalVariable.format_currency_usd);
                }
                grand_total = grand_total + total_amount;
            }
            txtGrandTotal.Text = grand_total.ToString(globalVariable.format_currency_usd);
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
            chkCreateNo.Enabled = true;
            txtTranNo.ReadOnly = false;
            set_item_rowNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
            {
                try
                {
                    //if (txtTranNo.Text == "")
                    //{
                    //    MessageBox.Show("ກະລຸນາປ້ອນເລກທີຂາຍກ່ອນ.");
                    //    txtTranNo.Focus();
                    //    return;
                    //}
                    if (dgvData.Rows.Count == 0)
                    {
                        MessageBox.Show("ກະລຸນາໃສ່ຂໍ້ມູນລາຍຈ່າຍກ່ອນ.");
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
                            MessageBox.Show("ກະລຸນາປ້ອນຊື່ລາຍຈ່າຍໃຫ້ຄົບກ່ອນ.");
                            return;
                        }

                        decimal expense_amount = 0;

                        if (row.Cells["col_amount"].Value != null)
                        {
                            expense_amount = Convert.ToDecimal(row.Cells["col_amount"].Value);
                        }

                        if (expense_amount == 0)
                        {
                            MessageBox.Show("ກະລຸນາປ້ອນລາຄາຊື້ໃຫ້ຄົບກ່ອນ.");
                            return;
                        }

                        string currencyName = "";
                        if (row.Cells["col_currency"].Value != null)
                        {
                            currencyName = row.Cells["col_currency"].Value.ToString();
                        }
                        if (currencyName == "")
                        {
                            MessageBox.Show("ກະລຸນາເລືອກສະກຸນເງິນໃຫ້ຄົບກ່ອນ.");
                            return;
                        }
                        if (currencyName == "ກີບ")
                        {
                            row.Cells["col_currency"].Tag = "1";
                        }
                        else if (currencyName == "ບາດ")
                        {
                            row.Cells["col_currency"].Tag = "2";
                        }
                        else if (currencyName == "ໂດລາ")
                        {
                            row.Cells["col_currency"].Tag = "3";
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
                        long excId = db.nLookup("exc_id", "tbl_exchange_rate", "status_id=1");

                        long run_no = db.XMax("tblExpense", "run_num", "", 0) + 1;

                        string query = @"
                        INSERT INTO [dbo].[tblExpense]
                        (expId,run_num, exp_no, exp_date, exp_description, exc_id,status_id, created_date, created_user)
                        VALUES (@expId,@run_num, @exp_no, @exp_date, @exp_description, @exc_id,@status_id, @created_date, @created_user)";

                        transaction_id = db.XMax("tblExpense", "expId", "", 0) + 1;

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@expId", transaction_id);
                            cmd.Parameters.AddWithValue("@run_num", run_no);
                            cmd.Parameters.AddWithValue("@exp_no", txtTranNo.Text);
                            cmd.Parameters.AddWithValue("@exp_date", dtDate.Value);
                            cmd.Parameters.AddWithValue("@exp_description", txtRemark.Text);
                            cmd.Parameters.AddWithValue("@exc_id", excId);
                            cmd.Parameters.AddWithValue("@status_id", 1);
                            cmd.Parameters.AddWithValue("@created_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@created_user", globalVariable.g_user_name);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"
                        UPDATE [dbo].[tblExpense]
                        SET exp_no = @exp_no,
                            exp_date = @exp_date,
                            exp_description = @exp_description,
                            modify_date = @modify_date,
                            modify_user = @modify_user
                        WHERE expId = @expId";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@expId", transaction_id);
                            cmd.Parameters.AddWithValue("@exp_no", txtTranNo.Text);
                            cmd.Parameters.AddWithValue("@exp_date", dtDate.Value);
                            cmd.Parameters.AddWithValue("@exp_description", txtRemark.Text);
                            cmd.Parameters.AddWithValue("@modify_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@modify_user", globalVariable.g_user_name);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvData.Rows[i];
                        double payAmountInUsd = 0;

                        int item_id = Convert.ToInt32(row.Cells["col_item_id"].Value);
                        string item_name = row.Cells["col_name"].Value.ToString();
                        double expense_amount = Convert.ToDouble(row.Cells["col_amount"].Value);
                        int currency_id = Convert.ToInt32(row.Cells["col_currency"].Tag);
                        string currency_name = row.Cells["col_currency"].Value.ToString();

                        long check_id = db.nLookup("detail_id", "tblExpenseDetail", "exp_id=" + transaction_id + " And item_id=" + item_id + " And status_id=1");

                        if (currency_id != 3)
                        {
                            payAmountInUsd = db.C2USD(currency_id, expense_amount);
                        }
                        else
                        {
                            payAmountInUsd = expense_amount;
                        }

                        if (check_id == 0)
                        {
                            string query = @"
                            INSERT INTO [dbo].[tblExpenseDetail]
                            (exp_id, item_id, item_name, expense_amount, currency_id, currencyName, payAmountInUsd,status_id)
                            VALUES (@exp_id, @item_id, @item_name, @expense_amount, @currency_id, @currencyName,@payAmountInUsd, @status_id)";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@exp_id", transaction_id);
                                cmd.Parameters.AddWithValue("@item_id", item_id);
                                cmd.Parameters.AddWithValue("@item_name", item_name);
                                cmd.Parameters.AddWithValue("@expense_amount", expense_amount);
                                cmd.Parameters.AddWithValue("@currency_id", currency_id);
                                cmd.Parameters.AddWithValue("@currencyName", currency_name);
                                cmd.Parameters.AddWithValue("@payAmountInUsd", payAmountInUsd);
                                cmd.Parameters.AddWithValue("@status_id", 1);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string query = @"
                            UPDATE [dbo].[tblExpenseDetail]
                            SET item_id = @item_id,
                                item_name = @item_name,
                                expense_amount = @expense_amount,
                                currency_id = @currency_id,
                                currencyName = @currencyName,
                                payAmountInUsd = @payAmountInUsd
                            WHERE detail_id = @detail_id";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@detail_id", check_id);
                                cmd.Parameters.AddWithValue("@item_id", item_id);
                                cmd.Parameters.AddWithValue("@item_name", item_name);
                                cmd.Parameters.AddWithValue("@expense_amount", expense_amount);
                                cmd.Parameters.AddWithValue("@currency_id", currency_id);
                                cmd.Parameters.AddWithValue("@currencyName", currency_name);
                                cmd.Parameters.AddWithValue("@payAmountInUsd", payAmountInUsd);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.");
                    conn.Close();
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
                string sql = "SELECT * FROM v_expenseDetail Where exp_id=" + transaction_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvData.Rows.Add();
                        DataGridViewRow row2 = dgvData.Rows[rowIndex];

                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                        comboCell.Items.AddRange("ກີບ", "ບາດ", "ໂດລາ");
                        row2.Cells["col_currency"] = comboCell;

                        row2.Cells["col_tran_item_id"].Value = reader["detail_id"].ToString();
                        row2.Cells["col_item_id"].Value = reader["item_id"].ToString();
                        row2.Cells["col_type"].Value = reader["type_name"].ToString();
                        row2.Cells["col_name"].Value = reader["item_name"].ToString();
                        row2.Cells["col_amount"].Value = Convert.ToDecimal(reader["expense_amount"]).ToString(globalVariable.format_currency_usd);
                        row2.Cells["col_currency"].Value = reader["currencyName"].ToString();
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
                    int del_buy = db.sqlExecute("Update tblExpense Set modify_date=GETDATE(),modify_user='" + globalVariable.g_user_name + "', status_id=2 Where expId=" + transaction_id);
                    int del_freeItem = db.sqlExecute("Update tblExpenseDetail Set status_id=2 Where exp_id=" + transaction_id);
                    MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດແລ້ວ.");
                    clear_form();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                frmBrowseExpenseCode frm = new frmBrowseExpenseCode();
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
                                //if (row.Cells["col_qty"].Value != null)
                                //{
                                //    row.Cells["col_qty"].Value = Convert.ToInt32(row.Cells["col_qty"].Value) + 1;
                                //}
                                //set_item_rowNo();
                                return;
                            }
                        }
                    }

                    using (SqlConnection conn = new SqlConnection(globalVariable.connectionString))
                    {
                        string sql = "SELECT * FROM v_expenseCode Where item_id=" + globalVariable.get_free_item_id;
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                DataGridViewRow row2 = dgvData.Rows[e.RowIndex];
                                row2.Cells["col_item_id"].Value = reader["item_id"].ToString();
                                row2.Cells["col_type"].Value = reader["type_name"].ToString();
                                row2.Cells["col_name"].Value = reader["item_name"].ToString();
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
                        if (row.Cells["col_tran_item_id"].Value != null)
                        {
                            int free_item_id = Convert.ToInt32(row.Cells["col_tran_item_id"].Value);
                            if (free_item_id > 0)
                            {
                                string exc_qry = "update tblExpenseDetail set status_id=2 where detail_id=" + free_item_id;
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

            string columnName = dgvData.Columns[e.ColumnIndex].Name;

            if (columnName == "col_amount")
            {
                set_item_rowNo();
            }
        }
    }
}
