using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.ComponentModel;

namespace CarSellingSystem
{
    public static class globalVariable
    {

        public static string connectionString; // = "Server=ATECH-0072;Database=db_cars;User Id=sa;Password=kySQL@2005;";

        public static int g_user_id = 0;
        public static string g_user_name = "";
        public static int g_user_role_id = 0;

        public static string format_date = "dd/MM/yyyy";
        public static string format_date_time = "dd/MM/yyyy hh:mm:ss tt";
        public static string format_time = "hh:mm:ss tt";

        public static string format_currency_usd = "#,##0.00";
        public static string format_currency_lak = "#,##0";

        public static string target_cars_path = ""; //@"\\ATECH-0072\scs_attach_files\cars"; //@"D:\scs_attach_files\cars";
        public static string target_sell_cars_path = ""; //@"D:\scs_attach_files\sell_cars";
        public static string target_sparePart_path = ""; //@"C:\scs_attach_files\sparepath";

        public static int selling_car_id = 0;

        public static int get_free_item_id = 0;
        public static string get_free_item_name = "";

        public static int selling_customer_id = 0;

       // public static int get_sparePart_id = 0;
        

    }


}
