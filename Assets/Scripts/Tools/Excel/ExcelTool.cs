using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OfficeOpenXml;
using Unity.VisualScripting;

namespace Excel
{
    public class ExcelTool
    {
        public class ExcelConfig
        {
            public static readonly string excelsFolderPath = Application.dataPath + "/Excels/DataExcel.xlsx";
        }

        public static string ReadExcel(int page, int row, int col)
        {
            //Start at index 1, not 0.
            //Get excel file information
            FileInfo fileInfo = new FileInfo(ExcelConfig.excelsFolderPath);

            //Automatic release of resources after exit
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo)) //打开excel表格
            {
                //Obtain the first table
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[page];

                //Get the data in a row and column of a table
                return worksheet.Cells[row, col].Value.ToString();
            }
        }
    }
}

