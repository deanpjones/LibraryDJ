using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    //DEAN JONES
    //JUL.16, 2017
    //OLE DB (EXCEL 2016) EXTENSIONS

    public static class OleDbExtension
    {
        //METHOD EXCEL CONNECTION (specify sheet name)
        //string fileName = @"C:\Users\Pythagoras\Desktop\After School\primes.xlsx";
        //eg. (ExcelConnectToSheet(fileName, "myXlsSheetName");
        public static bool ExcelConnectToSheet(string xlsFullPath, string xlsSheetName)
        {
            //connection string
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                   @"Data Source=" + xlsFullPath + ";" +
                   @"Extended Properties=" + Convert.ToChar(34).ToString() +
                   @"Excel 8.0" + Convert.ToChar(34).ToString() + ";";

            //try connection
            try
            {
                using (var conn = new OleDbConnection(connectionString))        //using System.Data.OleDb;
                {
                    OleDbCommand query = new OleDbCommand("SELECT * FROM [" + xlsSheetName + "$]", conn);  //default query to all data (entire sheet)
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //METHOD EXCEL CONNECTION (specify query)
        //string fileName = @"C:\Users\Pythagoras\Desktop\After School\primes.xlsx";
        //eg. (ExcelConnectWithQuery(fileName, "SELECT * FROM [calc$]");
        public static bool ExcelConnectWithQuery(string xlsFullPath, string query)
        {
            //connection string
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                   @"Data Source=" + xlsFullPath + ";" +
                   @"Extended Properties=" + Convert.ToChar(34).ToString() +
                   @"Excel 8.0" + Convert.ToChar(34).ToString() + ";";

            //try connection
            try
            {
                using (var conn = new OleDbConnection(connectionString))        //using System.Data.OleDb;
                {
                    //get sheet name (eg. "calc")
                    //query (eg. "SELECT * FROM [" + sheetName + "$]"
                    OleDbCommand myQuery = new OleDbCommand(query, conn);       //default query to all data (entire sheet)
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
