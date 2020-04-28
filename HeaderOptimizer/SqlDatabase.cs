using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
namespace CCDLumberTypeEditor
{
    static public class SqlDatabase
    {

        public static DataSet SelectFromDB(string Sql)
        {
            DataSet functionReturnValue = default(DataSet);
            SqlConnection myConnection = new SqlConnection("Data Source=hercules\\clearspan; Initial Catalog=Central;User Id=sa;Password=dog");
            //Dim myConnection As SqlConnection = New SqlConnection("Data Source=SJW4300\sqlexpress; Initial Catalog=Alply;User Id=tcawthorn;Password=panel")
            SqlDataAdapter myDataAdaptor = new SqlDataAdapter(Sql, myConnection);
            //Dim myCommand As SqlCommand = New SqlCommand(Sql, myConnection)
            DataSet myDataset = new DataSet();

            try
            {

                //myDataAdaptor.SelectCommand.Connection = myConnection;
                //myDataAdaptor.SelectCommand.CommandText = Sql;
                //myDataAdaptor.SelectCommand.CommandType = CommandType.Text;
                myDataAdaptor.Fill(myDataset, "CurData");
                functionReturnValue = myDataset;
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                functionReturnValue = null;
            }
            return functionReturnValue;
        }

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
            catch
            {
                //Interaction.MsgBox(ex.Message);
                return false;
            }

        }
        public static void template()
        {
            //Use the following code template to retrieve data

            DataSet myDataset = new DataSet();
            string sql;
            List<string> ProjectNumbers = new List<string>();


            sql = "Select number from project ";

            myDataset = SelectFromDB(sql);


            if ((myDataset != null))
            {

                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        ProjectNumbers.Add(dr["number"].ToString());

                    }
                }
            }

            //**if (myDataset.Tables("CurData").Rows.Count > 0)
            //if (myDataset.
            //{

            //    for (DataIndex = 0; DataIndex <= myDataset.Tables("CurData").Rows.Count - 1; DataIndex++)
            //    {
            //        Length = Convert.ToSingle(myDataset.Tables("CurData").Rows(DataIndex).Item("Scale"));

            //    }
            //}


            //Use the refollowing code template to retrieve data
        }



        public static object AddToInsertClause(string InsertString, string Field, string value, bool NeedsQuote)
        {
            object functionReturnValue = null;
            // This function concatenates the field and value arguments into a valid SQL Field and Value clause of
            // an insert statement.

            dynamic PositionBeforeValue = null;
            //String Position before the word 'Value'
            int PositionAfterValue = 0;
            //string position after the word 'Value'
            int InsertLength = 0;
            //Length of Insert string
            int FieldSideLength = 0;
            //Length of Fieldside string
            int ValueSideLength = 0;
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
                PositionBeforeValue = ValuesPosition - 1;
                PositionAfterValue = ValuesPosition + 6;

                FieldSide = InsertString.Substring(0, PositionBeforeValue);

                ValueSide = InsertString.Substring(PositionAfterValue, InsertLength - (PositionAfterValue - 1));

                //Split the FieldSide string into two strings, so we can insert the field name
                FieldSideLength = FieldSide.Length;
                FieldSideLeft = FieldSide.Substring(1, FieldSideLength - 2);
                FieldSideRight = FieldSide.Substring(FieldSideLeft.Length + 1, 2);

                //Split the Valueside string into two strings, so we can insert the values
                //-------
                ValueSideLength = ValueSide.Length;
                ValueSideLeft = ValueSide.Substring(1, ValueSideLength - 1);
                ValueSideRight = ValueSide.Substring(ValueSideLeft.Length + 1, 1);

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
            while (lPos != 0)
            {
                sBl = sBl + sBr.Substring(0, lPos) + Char.ConvertFromUtf32(39);
                sBr = Right(sBr, sBr.Length - lPos);
                lPos = sBr.IndexOf(Char.ConvertFromUtf32(39), 0);
            }

            lPos = sBr.IndexOf(Char.ConvertFromUtf32(39), 0);
            while (lPos != 0)
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
            if (String.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }


    }

}
