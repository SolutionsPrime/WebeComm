using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace eCommSite.SolutionsPrime
{
    public class spCvsData
    {
        public static DataTable testData { get; set; }
        public static string cvsFilePath = "..\\..\\..\\..\\WebeComm\\eCommSite\\DataFiles\\";
        public string cvsFile { get; set; }
        public string cvsDelimiter { get; set; }        

        public spCvsData()
        {
            
        }

        public DataTable getCvsData()
        {
            if (cvsFile == null)
            {
                throw new Exception("cvsFile property is null");
            }
            return getCvsData(cvsFile);
        }

        public DataTable getCvsData(string fileName)
        {

            spReporter.WriteLine(cvsFile);
            spReporter.WriteLine(cvsDelimiter);
            
            if(cvsDelimiter ==null)
            {
                spReporter.WriteLine("setting delimiter avalue to comma");
                cvsDelimiter = ",";
            }
            
            DataTable dt = new DataTable();
            bool isFirstRow = true;

            using (TextFieldParser txtParser = new TextFieldParser(fileName))
            {
                txtParser.TextFieldType = FieldType.Delimited;
                txtParser.SetDelimiters(cvsDelimiter);

                while (!txtParser.EndOfData)
                {
                    string[] dataCells = txtParser.ReadFields();
                    if (isFirstRow)
                    {
                        foreach (string cell in dataCells)
                        {
                            dt.Columns.Add(new DataColumn(cell, typeof(string)));
                        }
                        isFirstRow = false;
                    }
                    else
                    {
                        int counter = 0;
                        DataRow dataRow = dt.NewRow();
                        foreach (string cell in dataCells)
                        {
                            dataRow[counter++] = cell;
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            return dt;
        }

        public DataRow getTestCaseData(string testCaseId)
        {
            DataTable dt = new DataTable(testCaseId);
            DataRow dr = dt.NewRow();
            int counter = testData.Columns["TestCase"].Ordinal;
            foreach (DataRow row in testData.Rows)
            {                
                if(row.ItemArray[counter].ToString() == testCaseId)
                {
                    dr = row;
                }             
            }
            return dr;
        }
    }
}
