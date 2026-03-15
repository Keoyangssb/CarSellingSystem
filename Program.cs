using CarSellingSystem.BuyCar;
using CarSellingSystem.Cars;
using CarSellingSystem.Customer;
using CarSellingSystem.ExchangeRate;
using CarSellingSystem.Expense;
using CarSellingSystem.MasterData;
using CarSellingSystem.SaleCar;
using CarSellingSystem.SparePart;
using CarSellingSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CarSellingSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUserLogin());
        }
    }
}
