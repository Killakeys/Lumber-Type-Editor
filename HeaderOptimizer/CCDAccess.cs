using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;
// using PrefabricatedComponentTypeLibrary;

namespace CCDLumberTypeEditor
{
    /// <summary>
    /// Static class which contains methods to simplify accessing Clearspan's Central Database (CCD)
    /// </summary>
    public static class CCDAccess
    {
        /// <summary>
        /// This method queries a database and returns a dataset based on the SQL string passed
        /// </summary>
        public static DataSet SelectFromDB(string SQL)
        {
            DataSet functionReturnValue = default(DataSet);
            SqlConnection myConnection = new SqlConnection("Data Source=10.0.0.14\\clearspan; Initial Catalog=Central;User Id=sa;Password=dog");
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(SQL, myConnection);
            DataSet myDataset = new DataSet();

            try
            {
                myDataAdapter.Fill(myDataset, "CurData");
                functionReturnValue = myDataset;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                functionReturnValue = null;
            }
            return functionReturnValue;
        }

        /// <summary>
        /// Updates, inserts or deletes records in a database
        /// </summary>
        public static bool UpdateDB(string Sql)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=hercules\\clearspan; Initial Catalog=Central;User Id=sa;Password=dog");
            SqlCommand myCommand = default(SqlCommand);
            int ra = 0;

            try
            {
                //you need to provide password for sql server
                myConnection.Open();
                myCommand = new SqlCommand(Sql, myConnection);
                ra = myCommand.ExecuteNonQuery();
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConnection.Close();
                return false;
            }
        }

        /*
        public static List<object> DataSetToList(DataSet setToList, Type typeOfList)
        {
            List<typeOfList> listToReturn;
            foreach (DataTable table in setToList.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    listToReturn.Add(dr.ToString());
                }
            }
            return listToReturn;
        }
         */ 
        /*
        public static List<String> GetProjectNumbers()
        {
            DataSet myDataset = new DataSet();
            string sql;
            List<string> projectNumbers = new List<string>();


            sql = "Select number from project ";

            myDataset = SelectFromDB(sql);


            if ((myDataset != null))
            {

                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        projectNumbers.Add(dr["number"].ToString());
                    }
                }
            }

            return projectNumbers;
        }

        public static List<object> GetSheathingOptions()
        {
            DataSet myDataset = new DataSet();
            string sql;
            List<Sheathing> sheathingOptions = new List<Sheathing>();

            sql = "SELECT * FROM SheathingType";
            myDataset = SelectFromDB(sql);

            foreach (DataTable table in myDataset.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    sheathingOptions.Add(new Sheathing(dr["Description"].ToString()));
                }
            }

            return sheathingOptions;
        }

         
        public static string GetEstimateOfProject()
        {
            string estimate = "";
            DataSet myDataset = new DataSet();
            string sql;


            sql = "SELECT Estimate FROM [CENTRAL].[dbo].[Estimate] WHERE ProjectNumber = " + SettingsController.ProjectNumber.ToString() + " AND Sold IS NOT NULL";

            myDataset = SelectFromDB(sql);


            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        estimate = dr["Estimate"].ToString();
                    }
                }
            }

            return estimate;
        }
        

        public static void ToggleDefaultSheatingForWallProgram(Sheathing sheathingToUpdate)
        {
            string description = sheathingToUpdate.Description;

            string sql;
            if (dr["DefaultTypeForWallProgram"].ToString().Equals("Yes"))
            if(sheathingToUpdate.IsCommon)
            {
                sql = "UPDATE SheathingType SET DefaultTypeForWallProgram = NULL WHERE Description LIKE '" + description + "'";
            }
            else
            {
                sql = "UPDATE SheathingType SET DefaultTypeForWallProgram = 'Yes' WHERE Description LIKE '" + description + "'";
            }
            UpdateDB(sql);
        }
        */

        /// <summary>
        /// Method to build an insert string with no SQL syntax errors 
        /// </summary>
        public static string AddToInsertClause(string InsertString, string Field, string value, bool NeedsQuote)
        {
            string functionReturnValue = null;
            // This function concatenates the field and value arguments into a valid SQL Field and Value clause of
            // an insert statement.

            dynamic PositionBeforeValue = null;
            //String Position before the word 'Value'
            int PositionAfterValue = 0;
            //string position after the word 'Value'
            int InsertLength = 0;
            //Length of Insert string
            //int FieldSideLength = 0;
            ////Length of Fieldside string
            //int ValueSideLength = 0;
            //Length of Valueside string
            string FieldSide = null;
            //Fieldside of Insert string
            string FieldSideLeft = null;
            //Left portion of FieldSide string when split before the right
            // parenthese... as (po_num in (po_num)
            string FieldSideRight = null;
            //Oppisite above
            string ValueSide = null;
            //Value side of Insert string
            string ValueSideLeft = null;
            //Left portion of ValueSide string when split before the right
            // parenthese... as ('0001' in ('0001')
            string ValueSideRight = null;
            //Oppisite above
            int ValuesPosition = 0;
            //Where the word Values position starts in the Insert string,
            //   used to divide the string


            // See if the value has any single quotes embedded in it.
            // Calls the Validate class
            value = DoubleApostrophe(value);

            if (string.IsNullOrEmpty(InsertString))
            {
                if (NeedsQuote)
                {
                    functionReturnValue = "(" + Field.Trim() + ") Values ('" + value.Trim() + "')";

                }
                else
                {
                    functionReturnValue = "(" + Field.Trim() + ") Values (" + value.Trim() + ")";
                }
            }
            else
            {
                //Split the string into two string, before and after the word 'Value'
                ValuesPosition = InsertString.IndexOf("Values", 0);

                InsertLength = InsertString.Length;
                PositionBeforeValue = ValuesPosition;
                PositionAfterValue = ValuesPosition + 6;

                FieldSide = InsertString.Substring(0, PositionBeforeValue);

                ValueSide = InsertString.Substring(PositionAfterValue, InsertLength - (PositionAfterValue));

                //Split the FieldSide string into two strings, so we can insert the field name
                //FieldSideLength = FieldSide.Length;
                //FieldSideLeft = FieldSide.Substring(0, FieldSideLength - 2);
                //FieldSideRight = FieldSide.Substring(FieldSideLeft.Length, 1);

                char[] ParenRight = { ')' };
                string[] Fields = FieldSide.Split(ParenRight);
                FieldSideLeft = Fields[0];
                FieldSideRight = ")";


                //Split the Valueside string into two strings, so we can insert the values
                //-------
                //ValueSideLength = ValueSide.Length;
                //ValueSideLeft = ValueSide.Substring(0, ValueSideLength -1);
                //ValueSideRight = ValueSide.Substring(ValueSideLeft.Length, 1);
                
                string[] Values = ValueSide.Split(ParenRight);
                ValueSideLeft = Values[0];
                ValueSideRight = ")";

                //Put it all together
                //added
                if (value == "Null")
                {
                    functionReturnValue = FieldSideLeft + ", " + Field.Trim() + FieldSideRight + "Values" + ValueSideLeft + ", " + value.Trim() + ValueSideRight;
                    //added
                    //added
                }
                else
                {
                    if (NeedsQuote)
                    {
                        functionReturnValue = FieldSideLeft + ", " + Field.Trim() + FieldSideRight + "Values" + ValueSideLeft + ", '" + value.Trim() + "'" + ValueSideRight;
                    }
                    else
                    {
                        functionReturnValue = FieldSideLeft + ", " + Field.Trim() + FieldSideRight + "Values" + ValueSideLeft + ", " + value.Trim() + ValueSideRight;
                    }
                }
                //added
            }
            return functionReturnValue;


        }


        public static string DoubleApostrophe(string sBr)
        {
            string functionReturnValue = null;

            int lPos = 0;
            string sBl = null;

            if (sBr.Length == 0)
                return functionReturnValue;

            lPos = sBr.IndexOf(Char.ConvertFromUtf32(39));
            while (lPos > 0)
            {
                sBl = sBl + sBr.Substring(0, lPos) + Char.ConvertFromUtf32(39);
                sBr = Right(sBr, sBr.Length - lPos);
                lPos = sBr.IndexOf(Char.ConvertFromUtf32(39), 0);
            }

            lPos = sBr.IndexOf(Char.ConvertFromUtf32(39), 0);
            while (lPos > 0)
            {
                sBl = sBl + sBr.Substring(0, lPos) + Char.ConvertFromUtf32(34);
                sBr = Right(sBr, sBr.Length - lPos);
                lPos = sBr.IndexOf(Char.ConvertFromUtf32(34), 0);
            }

            functionReturnValue = sBl + sBr;
            return functionReturnValue;
        }

        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (String.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }


    }
}