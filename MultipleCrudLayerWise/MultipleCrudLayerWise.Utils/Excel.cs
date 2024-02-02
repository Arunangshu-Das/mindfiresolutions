using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using static OfficeOpenXml.LicenseContext;

namespace MultipleCrudLayerWise.Utils
{
    public static class Excel
    {
        static Excel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }
        public static void ToDataTable<T>(List<T> list) where T : class, new()
        {
            DataTable dt = new DataTable();

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dt.Columns.Add(prop.Name);
            }

            foreach (T item in list)
            {
                DataRow values = dt.NewRow();
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            dt.ToExcel();
        }

        public static void ToExcel(this DataTable dtDataTable)
        {
            string fileName = "DataExport.xlsx";
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            string strFilePath = Path.Combine(file, fileName);

            using (var package = new ExcelPackage(new FileInfo(strFilePath)))
            {
                String SheetName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                var worksheet = package.Workbook.Worksheets.Add(SheetName);
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dtDataTable.Columns[i].ColumnName;
                }
                for (int i = 0; i < dtDataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dtDataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dtDataTable.Rows[i][j];
                    }
                }

                package.Save();
            }
        }
    }
}
