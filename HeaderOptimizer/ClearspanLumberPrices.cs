using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;
using System.Data;

namespace CCDLumberTypeEditor
{
    public class ClearspanLumberPrices
    {
        Distance height;
        Distance width;
        Distance length;
        Distance heigthNominal;
        Distance widthNominal;
        string grade;
        string species;
        string additionalSpecification;
        string lumbercode;
        float bfPerPiece;
        int stocked;
        int transfer;
        int auditWeek;
        string includeInFifo;
        string useAsStud;
        int priority;
        float freight;
        string treated;
        string oldLumberCode;
        DateTime currentPriceDate;
        float cost;
        string useForRoofDesign;



        public ClearspanLumberPrices(DateTime inquiryDate)
        {
            // Get FOBMill prices for the date/time input for all lumbertypes set as stocked.


        }

        private List<string> GetDatabaseValues()
        {

            DataSet myDataset = new DataSet();
            string sql;
            List<string> projectNumbers = new List<string>();


            sql = "Select number from project ";

            myDataset = CCDAccess.SelectFromDB(sql);


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

            //string additionalSpecification;
            //string lumbercode;
            //float bfPerPiece;
            //int stocked;
            //int transfer;
            //int auditWeek;
            //string includeInFifo;
            //string useAsStud;
            //int priority;
            //float freight;
            //string treated;
            //string oldLumberCode;
            //DateTime currentPriceDate;
            //float cost;
            //string useForRoofDesign;

        }

        public string HeightArchitectural()
        {
            return height.Architectural.ToString();
        }

        public string HeightDecimalInches()
        { 
            return height.ValueInInches.ToString();
        }

        public string WidthArchitectural()
        {
            return width.Architectural.ToString();
        }

        public string WidthDecimalInches()
        {
            return width.ValueInInches.ToString();
        }

        public string LengthArchitectural()
        {
            return length.Architectural.ToString();
        }

        public string LengthDecimalFeet()
        {
            return length.ValueInFeet.ToString();
        }

        public string Grade()
        {
            return grade;
        }

        public string Species()
        {
            return species;
        }

        public string AdditionalSpecifications()
        {
            return additionalSpecification;
        }

        public bool ChangeLength(Distance NewLength)
        {
            length = NewLength;
            return true;
        }

        public string LumberCode ()
        {

            double feet;
            double decimalInches;
            double rawInches;
            double decimalSixteenths;
            double inches;
            double rawSixteenths;
            double sixteenths;
            string sixteensthsString;

            //Strip feet
            StripFractionalNumber(length.ValueInFeet, out feet, out decimalInches);

            //Convert Inches
            rawInches = decimalInches * 12;
            StripFractionalNumber(rawInches, out inches, out decimalSixteenths);

            //Convert Sixteenths
            rawSixteenths = decimalSixteenths * 16;

            sixteenths = Math.Round(rawSixteenths);

            if (sixteenths == 16)
            {
                inches = inches + 1;
                sixteenths = 0;
            }

            sixteensthsString = sixteenths.ToString();

            if (inches == 12)
            {
                feet = feet + 1;
                inches = 0;
            }

            return height.ValueInInches + "~" + width.ValueInInches + "~" + grade + "~" + feet.ToString() + "-" + inches.ToString() + "-" + sixteensthsString + "~" + species + "~" + additionalSpecification + "~";


            //double decimalLength = length.ValueInInches;
            //double feetInches =  decimalLength / 12;
            //double justInches = feetInches - Math.Truncate(feetInches);
            //double justFeet = Math.Truncate(decimalLength);


        }

        private void StripFractionalNumber(double Whole, out double Integer, out double Fractional)
        {
            double RoundedWhole = Math.Round(Whole);
            if (RoundedWhole > Whole)
            {
                 Fractional = 1 - (RoundedWhole - Whole);
                 Integer = Convert.ToInt16(RoundedWhole - 1);
            }
            else
            {
                 Fractional = Whole - RoundedWhole;
                 Integer = Convert.ToInt16(RoundedWhole);
            }
        }
    }
}
