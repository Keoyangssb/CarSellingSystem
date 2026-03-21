using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;

namespace CarSellingSystem
{
    public class myClass
    {
        public static string gStrCon = globalVariable.connectionString; //"Data source =ATECH-0072;Initial Catalog=db_cars;Persist Security Info=True;User ID=sa; Password=kySQL@2005";

        private static readonly string Key = "ThisIsMy32ByteSecureKey343567839"; // 32 bytes
        private static readonly string IV = "ThisIsAnIV198756"; // 16 bytes
        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = encryptor.TransformFinalBlock(
                    Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public long XMax(string sTable, string sField, string myCriteria, int getRange = 0)
        {
            string strSql = "SELECT MAX(" + sField + ") FROM " + sTable + "";

            if (!string.IsNullOrEmpty(myCriteria))
            {
                strSql += " WHERE " + myCriteria + "";
            }

            DataTable dt = GetDataTable(strSql); // Make sure GetDataTable method is available

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                long maxValue = Convert.ToInt64(dt.Rows[0][0]);
                return getRange > 0 ? maxValue + getRange : maxValue;
            }
            else
            {
                return getRange > 0 ? getRange : 0;
            }
        }

        public DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(gStrCon))
            {
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(com))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        return table;
                    }
                }
            }
        }

        public void FillCombo(ComboBox combo, string tableName, string fieldDisplay, string value, string criteria, string order_by, bool isAll)
        {
            string sql = "SELECT " + fieldDisplay + ", " + value + " FROM " + tableName + "";

            if (!string.IsNullOrEmpty(criteria))
            {
                sql += " WHERE " + criteria + "";
            }
            if (!string.IsNullOrEmpty(order_by))
            {
                sql += " ORDER BY " + order_by + "";
            }

            DataTable dt = GetDataTable(sql); // Ensure GetDataTable method is implemented

            if (isAll)
            {
                DataRow dtRow = dt.NewRow();
                dtRow[0] = "ທັງໝົດ";
                dt.Rows.InsertAt(dtRow, 0);
            }

            combo.BeginUpdate();
            combo.DisplayMember = fieldDisplay;
            combo.ValueMember = value;
            combo.DataSource = dt;
            combo.EndUpdate();
        }


        public double ToNumber(string srcCurrency, bool retZeroIfNegative = false)
        {
            double retValue = 0;
            if (string.IsNullOrEmpty(srcCurrency))
            {
                return 0;
            }
            else
            {
                if (srcCurrency.Contains(","))
                {
                    srcCurrency = srcCurrency.Replace(",", "");
                }

                if (double.TryParse(srcCurrency, out retValue))
                {
                    if (retZeroIfNegative && retValue < 1)
                    {
                        retValue = 0;
                    }
                }
                else
                {
                    retValue = 0; 
                }
                return retValue;
            }
        }

        public decimal ToNumberDecimal(string srcCurrency, bool retZeroIfNegative = false)
        {
            decimal retValue = 0;
            if (string.IsNullOrEmpty(srcCurrency))
            {
                return 0;
            }
            else
            {
                if (srcCurrency.Contains(","))
                {
                    srcCurrency = srcCurrency.Replace(",", "");
                }

                if (decimal.TryParse(srcCurrency, out retValue))
                {
                    if (retZeroIfNegative && retValue < 1)
                    {
                        retValue = 0;
                    }
                }
                else
                {
                    retValue = 0;
                }
                return retValue;
            }
        }

        public int GetSparePartBalanceQty(int ssp_id = 0)
        {
            decimal balance_qty = 0;
            decimal total_buy_qty = 0;
            decimal total_sale_qty = 0;

            total_buy_qty = XSum("buy_qty", "v_buySparePart", "spp_id=" + ssp_id);
            total_sale_qty = XSum("sell_qty", "v_sellSparePart_item", "spp_id=" + ssp_id);
            balance_qty = total_buy_qty - total_sale_qty;
            return Convert.ToInt32(balance_qty);
        }

        public double NLookupDouble(string sField, string sTable, string criteria)
        {
            string strSql = "";
            strSql += "SELECT " + sField + " FROM " + sTable + " ";
            if (!string.IsNullOrEmpty(criteria))
            {
                strSql += " WHERE " + criteria;
            }
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                if (!Convert.IsDBNull(dt.Rows[0][0]))
                {
                    return Convert.ToDouble(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public decimal NLookupDecimal(string sField, string sTable, string criteria)
        {
            string strSql = "";
            strSql += "SELECT " + sField + " FROM " + sTable + " ";
            if (!string.IsNullOrEmpty(criteria))
            {
                strSql += " WHERE " + criteria;
            }
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                if (!Convert.IsDBNull(dt.Rows[0][0]))
                {
                    return Convert.ToDecimal(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public int sqlExecute(string strsql)
        {
            SqlCommand cmd = new SqlCommand(strsql);
            int X = cmdExecute(ref cmd);
            return X;
        }

        public int cmdExecute(ref SqlCommand cmd)
        {
            int X;
            using (SqlConnection cn = new SqlConnection(gStrCon))
            {
                cmd.Connection = cn;
                try
                {
                    cn.Open();
                    X = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception)
                {
                    cn.Close();
                    X = -1;
                }
            }
            return X;
        }

        public string XLookup(string sField, string sTable, string Criteria)
        {
            string StrSql = "";
            StrSql += "SELECT " + sField + " FROM " + sTable + " ";
            if (!string.IsNullOrEmpty(Criteria))
            {
                StrSql += "WHERE " + Criteria;
            }
            DataTable dt = GetDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (!Convert.IsDBNull(dt.Rows[0][0]))
                {
                    return Convert.ToString(dt.Rows[0][0]);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public long nLookup(string sField, string sTable, string Criteria)
        {
            string StrSql = "";
            StrSql += "SELECT " + sField + " FROM " + sTable + " ";
            if (!string.IsNullOrEmpty(Criteria))
            {
                StrSql += "WHERE " + Criteria;
            }
            DataTable dt = GetDataTable(StrSql);
            if (dt.Rows.Count > 0)
            {
                if (!Convert.IsDBNull(dt.Rows[0][0]))
                {
                    return Convert.ToInt64(dt.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public Decimal XSum(string sField, string sTable, string Criteria)
        {
            string StrSql = "";
            StrSql += "SELECT Sum(" + sField + ") FROM " + sTable + " ";
            if (!string.IsNullOrEmpty(Criteria))
            {
                StrSql += "WHERE " + Criteria;
            }
            DataTable dt = GetDataTable(StrSql);
            if (dt.Rows.Count > 0 && !Convert.IsDBNull(dt.Rows[0][0]))
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        private static readonly string[] units = 
        { 
            "ສູນ", "ໜຶ່ງ", "ສອງ", "ສາມ", "ສີ່", "ຫ້າ", 
            "ຫົກ", "ເຈັດ", "ແປດ", "ເກົ້າ" 
        };

        private static string NumberToWords(long number)
        {
            if (number == 0) return units[0];
            if (number < 0) return "ລົບ " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + "ລ້ານ ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + "ພັນ ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "ຮ້ອຍ ";
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 10)
                {
                    words += units[number];
                }
                else if (number < 20)
                {
                    if (number == 10) words += "ສິບ";
                    else words += "ສິບ" + units[number % 10];
                }
                else if (number < 30)
                {
                    if (number == 10) words += "ຊາວ";
                    else words += "ຊາວ" + units[number % 10];
                }
                else
                {
                    words += units[number / 10] + "ສິບ";
                    if ((number % 10) > 0) words += units[number % 10];
                }
            }
            return words.Trim();
        }

        public string NumberToCurrencyKip(decimal amount, string currency = "ກີບ", string centsText = "ສະຕາງ")
        {
            long intPart = (long)Math.Floor(amount);
            int decimalPart = (int)((amount - intPart) * 100);
            string result = NumberToWords(intPart) + " " + currency;

            if (decimalPart > 0)
            {
                result += " ແລະ " + NumberToWords(decimalPart) + " " + centsText;
            }
            return result;
        }

        public string NumberToCurrencyDollar(decimal amount, string currency = "ໂດລາ", string centsText = "ສະຕາງ")
        {
            long intPart = (long)Math.Floor(amount);
            int decimalPart = (int)((amount - intPart) * 100);
            string result = NumberToWords(intPart) + currency;

            if (decimalPart > 0)
            {
                result += " ແລະ " + NumberToWords(decimalPart) + centsText;
            }
            return result;
        }


        public double C2USD(int myCurrency, double myValue)
        {
            double return_value = 0;
            double exc_bath_usd = NLookupDouble("bath_usd", "tbl_exchange_rate", "status_id=1");
            double exc_kip_usd = NLookupDouble("kip_usd", "tbl_exchange_rate", "status_id=1");
            if (exc_bath_usd > 0 && exc_kip_usd > 0)
            {
                if (myCurrency == 1) // LAK
                {
                    return_value = myValue / exc_kip_usd;
                }
                else if (myCurrency == 2) // THB
                {
                    return_value = myValue / exc_bath_usd;
                }
                else if (myCurrency == 3) // USD
                {
                    return_value = myValue;
                }
            }
            return return_value; // default if no rows found
        }


        public void CheckRoleAccess(string formName)
        {
            DataTable dt;

            if (globalVariable.g_user_role_id == 1)
            {
                globalVariable.can_add = true;
                globalVariable.can_edit = true;
                globalVariable.can_view = true;
                globalVariable.can_delete = true;
            }
            else
            {
                dt = GetDataTable("Select * From View_Check_Role_Access where roleId = "
                                  + globalVariable.g_user_role_id + " and menu_name=N'" + formName + "'");

                if (dt.Rows.Count > 0)
                {
                    globalVariable.can_add = Convert.ToBoolean(dt.Rows[0]["canAdd"]);
                    globalVariable.can_edit = Convert.ToBoolean(dt.Rows[0]["canEdit"]);
                    globalVariable.can_view = Convert.ToBoolean(dt.Rows[0]["canView"]);
                    globalVariable.can_delete = Convert.ToBoolean(dt.Rows[0]["canDelete"]);
                }
                else
                {
                    globalVariable.can_add = false;
                    globalVariable.can_edit = false;
                    globalVariable.can_view = false;
                    globalVariable.can_delete = false;
                }
            }
        }

        public void SetControlsEnabled(Control parent, bool enabled)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Enabled = enabled;

                if (ctrl.HasChildren)
                {
                    SetControlsEnabled(ctrl, enabled);
                }
            }
        }


    }

}
