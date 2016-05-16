﻿using System;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

public class NPOIHelper : IDisposable
{
    private string fileName = null;
    private IWorkbook workbook = null;
    private FileStream fs = null;
    private bool disposed;

    public NPOIHelper(string fileName)
    {
        this.fileName = fileName;
        disposed = false;
    }

    /// <summary>
    /// 将DataTable数据导入到excel中
    /// </summary>
    /// <param name="data">要导入的数据</param>
    /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
    /// <param name="sheetName">要导入的excel的sheet的名称</param>
    /// <returns>导入数据行数(包含列名那一行)</returns>
    public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
    {
        int i = 0;
        int j = 0;
        int count = 0;
        ISheet sheet = null;

        fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        if (fileName.IndexOf(".xlsx") > 0)     // 2007版本
            workbook = new XSSFWorkbook();
        else if (fileName.IndexOf(".xls") > 0) // 2003版本
            workbook = new HSSFWorkbook();

        try
        {
            if (workbook != null)
            {
                sheet = workbook.CreateSheet(sheetName);
            }
            else
            {
                return -1;
            }

            if (isColumnWritten == true) //写入DataTable的列名
            {
                IRow row = sheet.CreateRow(0);
                for (j = 0; j < data.Columns.Count; ++j)
                {
                    row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                }
                count = 1;
            }
            else
            {
                count = 0;
            }

            for (i = 0; i < data.Rows.Count; ++i)
            {
                IRow row = sheet.CreateRow(count);
                for (j = 0; j < data.Columns.Count; ++j)
                {
                    row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                }
                ++count;
            }
            workbook.Write(fs); //写入到excel
            return count;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            return -1;
        }
    }

    /// <summary>
    /// 将excel中的数据导入到DataTable中
    /// </summary>
    /// <param name="sheetName">excel工作薄sheet的名称</param>
    /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
    /// <returns>返回的DataTable</returns>
    public DataTable ExcelToDataTable(string sheetName, int headRowIndex, int startRowIndex)
    {
        ISheet sheet = null;
        DataTable data = new DataTable();
        int startRow = 0;
        try
        {
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0)     // 2007版本
                workbook = new XSSFWorkbook(fs);
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook(fs);
            if (sheetName != null)
            {
                sheet = workbook.GetSheet(sheetName);
            }
            else
            {
                sheet = workbook.GetSheetAt(0);
            }
            if (sheet != null)
            {
                int cellCount = 0;
                if (headRowIndex == -1)
                {
                    IRow firstRow = sheet.GetRow(startRowIndex);
                    cellCount = firstRow.LastCellNum;//一行最后一个cell的编号 即总的列数
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        DataColumn column = new DataColumn("f" + i.ToString());
                        data.Columns.Add(column);
                    }
                }
                else
                {
                    IRow firstRow = sheet.GetRow(headRowIndex);
                    cellCount = firstRow.LastCellNum;//一行最后一个cell的编号 即总的列数
                    if (startRowIndex > 0)
                    {
                        if (firstRow != null)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                DataColumn column = new DataColumn(firstRow.GetCell(i).StringCellValue);
                                data.Columns.Add(column);
                            }
                        }
                        startRow = sheet.FirstRowNum + startRowIndex;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                }
                //最后一列的标号
                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;//没有数据的行默认是null
                    DataRow dataRow = data.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    data.Rows.Add(dataRow);
                }
            }
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            return null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                if (fs != null)
                    fs.Close();
            }

            fs = null;
            disposed = true;
        }
    }
}