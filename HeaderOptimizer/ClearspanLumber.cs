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
    public class ClearspanLumber
    {

        private string _lumbercode;
        private string _description;
        private string _grade;
        private string _species;
        private Distance _heightNominal;
        private Distance _widthNominal;
        private Distance _heightActual;
        private Distance _widthActual;
        private Distance _length;
        private string _additionalSpecification;
        private double _bfPerPiece;
        private string _stocked;
        private string _useAsStud;
        private double _freight;
        private string _treated;
        private LumberPrice _price;

        public string Lumbercode => _lumbercode;
        public string Description => _description;
        public string Grade => _grade;
        public string Species => _species;
        public Distance HeigthNominal => _heightNominal;
        public Distance WidthNominal => _widthNominal;
        public Distance HeigthActual => _heightActual;
        public Distance WidthActual => _widthActual;
        public Distance Length => _length;
        public string AdditionalSpecification => _additionalSpecification;

        public double BfPerPiece => _bfPerPiece;
        public string Stocked
        {
            get
            {
                if (_stocked == "Yes")
                {
                    return "Stocked";
                }
                else
                {
                    return "Not Stocked";
                }
            }
        }

        public string UseAsStud
        {
            get
            {
                return _useAsStud;
            }
        }

        public double Freight
        {
            get
            { return _freight; }

            set
            {
                _freight = value;
            }
        }
        public string Treated => _treated;
        public LumberPrice Price
        {
            get
            { return _price; }

            set
            {
                _price = value;
            }
        }

        public void SetLumberAsStocked()
        {
            _stocked = "Yes";
            UpdateLumberTypeDatabaseValue(_lumbercode, LumberFields.Stocked, _stocked);
        }

        public void SetLumberAsUnStocked()
        {
            _stocked = "No";
            UpdateLumberTypeDatabaseValue(_lumbercode, LumberFields.Stocked, _stocked);
        }

        public void SetToUseAsStud()
        {
            _useAsStud = "Yes";
            UpdateLumberTypeDatabaseValue(_lumbercode, LumberFields.UseAsStud, _useAsStud);
        }

        public void SetToDontUseAsStud()
        {
            _useAsStud = "No";
            UpdateLumberTypeDatabaseValue(_lumbercode, LumberFields.UseAsStud, _useAsStud);
        }

        public Single CurrentPrice()
        {
            return Price.Price;
        }

        public void SetCurrentPrice(double _newPrice, String _employeeId)
        {
            string sql = "Insert lumberprices (Lumbercode, Price, PriceDate, UserName, Factor, Op, FobMillPrice, Freight)" +
                "Values ('" + _lumbercode + "'," + _newPrice + ", '" + DateTime.Now + "', '" + _employeeId + "', " + GetCurrentLumberFactor() +
                ", 'Multiply', 0, " + _freight + ")";
            
            SqlDatabase.UpdateDB(sql);
        }

        private enum LumberFields
        {
            LumberCode,
            Grade,
            Species,
            HeightNominal,
            WidthNominal,
            HeightActual,
            WidthActual,
            Length,
            AdditionalSpecifications,
            BfPerPiece,
            Stocked,
            UseAsStud,
            Freight,
            Treated
        }


        public struct LumberPrice
        {
            public readonly string Lumbercode;
            public readonly string PriceDate;
            public readonly int Price;
            public readonly Double Factor;
            public readonly int FobMillPrice;
            public readonly int Freight;


            public LumberPrice(string lumbercode, string priceDate, int price, Single factor, int fobMillPrice, int freight)
            {
                this.Lumbercode = lumbercode;
                this.PriceDate = priceDate;
                this.Price = price;
                this.Factor = factor;
                this.FobMillPrice = fobMillPrice;
                this.Freight = freight;
            }
        }

        public ClearspanLumber(string clearspanLumberCode)
        {
            GetDatabaseValues(clearspanLumberCode);
            Price = GetLumberPrice(clearspanLumberCode, DateTime.Now);
        }

        public ClearspanLumber(string clearspanLumberCode, DateTime inquiryDate)
        {
            GetDatabaseValues(clearspanLumberCode);
            Price = GetLumberPrice(this.Lumbercode, inquiryDate);
        }

        private Single GetCurrentLumberFactor()
        {
            DataSet myDataset = new DataSet();
            string sql;

            sql = "Select * from variable where system = 'CCD' and variable = 'LumberPadFactor'";

            myDataset = CCDAccess.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        DataRow d = table.Rows[0];
                        return Convert.ToSingle(d["data"]);
                    }
                }
            }
            return 0;
        }

       
        private LumberPrice GetLumberPrice(string _lumberCode, DateTime _inquiryDate)
        {
            DataSet myDataset = new DataSet();
            string sql;

            sql = "Select * from lumberprices where lumbercode = '" + _lumberCode + "' and pricedate <= '" + _inquiryDate + "'";

            myDataset = CCDAccess.SelectFromDB(sql);

            string _priceDate = "";
            int _price = 0;
            Single _factor = 0;
            int _fobMillPrice = 0;
            int _freight = 0;
            LumberPrice tempLumberPrices;

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        DataRow d = table.Rows[0];

                        bool validData = true;

                        if (d["PriceDate"] == DBNull.Value)
                        {

                            validData = false;
                        }
                        else
                        {
                            _priceDate = d["PriceDate"].ToString();
                        }

                        if (d["Price"] == DBNull.Value)
                        {
                            validData = false;
                        }
                        else
                        {
                            _price = Convert.ToInt16(d["Price"]);
                        }

                        if (d["Factor"] == DBNull.Value)
                        {
                            validData = false;
                        }
                        else
                        {
                            _factor = Convert.ToSingle(d["Factor"]);
                        }

                        if (d["FobMillPrice"] == DBNull.Value)
                        {
                            _fobMillPrice = 0;
                        }
                        else
                        {
                            _fobMillPrice = Convert.ToInt16(d["FobMillPrice"]);
                        }

                        if (d["Freight"] == DBNull.Value)
                        {
                            _freight = 0;
                        }
                        else
                        {
                            _freight = Convert.ToInt16(d["Freight"]);
                        }

                        if (validData)
                        {
                            tempLumberPrices = new LumberPrice(_lumberCode, _priceDate, _price, _factor, _fobMillPrice, _freight);
                        }
                        else
                        {
                            tempLumberPrices = new LumberPrice();
                        }

                        return tempLumberPrices;
                    }
                }
            }
            return new LumberPrice();
        }

        private void UpdateLumberTypeDatabaseValue(string _lumbercode, LumberFields _field, string _newValue)
        {
            string sql = "";
            switch (_field)
            {
                case LumberFields.LumberCode:
                case LumberFields.Grade:
                case LumberFields.Species:
                case LumberFields.HeightNominal:
                case LumberFields.WidthNominal:
                case LumberFields.HeightActual:
                case LumberFields.WidthActual:
                case LumberFields.Length:
                case LumberFields.AdditionalSpecifications:
                case LumberFields.UseAsStud:
                case LumberFields.Treated:
                case LumberFields.Stocked:
                    sql = "update lumbertype set " + _field + " = '" + _newValue + "'";
                    break;
                case LumberFields.Freight:                
                case LumberFields.BfPerPiece:
                    sql = "update lumbertype set " + _field + " = " + _newValue;
                    break;
                default:
                    break;
            }
            sql = sql + " where lumbercode  = '" + _lumbercode + "'";
            SqlDatabase.UpdateDB(sql);

        }
        
        private void GetDatabaseValues(string _passedLumberCode)
        {

            DataSet myDataset = new DataSet();
            string sql;
            List<string> projectNumbers = new List<string>();


            sql = "Select * from lumbertype where lumbercode = '" + _passedLumberCode + "'";

            myDataset = CCDAccess.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        _lumbercode = dr["lumbercode"].ToString();
                        _description = dr["description"].ToString();
                        _grade = dr["grade"].ToString();
                        _species = dr["species"].ToString();
                        _heightNominal = new Distance(new Inch(), Convert.ToDouble(dr["ThicknessN"].ToString()));
                        _widthNominal = new Distance(new Inch(), Convert.ToDouble(dr["WidthN"].ToString()));
                        _heightActual = new Distance(new Inch(), Convert.ToDouble(dr["ThicknessA"].ToString()));
                        _widthActual = new Distance(new Inch(), Convert.ToDouble(dr["WidthA"].ToString()));
                        _length = new Distance(new Inch(), Convert.ToDouble(dr["Length"].ToString()));
                        _additionalSpecification = dr["AdditionalSpecifications"].ToString();
                        _bfPerPiece = Convert.ToSingle(dr["bfPerPiece"].ToString());
                        _stocked = dr["stocked"].ToString();
                        _useAsStud = dr["UseAsStud"].ToString();
                        _freight = Convert.ToSingle(dr["freight"].ToString());
                        _treated = dr["treated"].ToString();
                    }
                }
            }
        }
        public string HeightArchitectural()
        {
            return HeigthNominal.Architectural.ToString();
        }

        public string HeightDecimalInches()
        {
            return HeigthNominal.ValueInInches.ToString();
        }

        public string WidthArchitectural()
        {
            return WidthNominal.Architectural.ToString();
        }

        public string WidthDecimalInches()
        {
            return WidthNominal.ValueInInches.ToString();
        }

        public string LengthArchitectural()
        {
            return Length.Architectural.ToString();
        }

        public string LengthDecimalFeet()
        {
            return Length.ValueInFeet.ToString();
        }
        public string AdditionalSpecifications()
        {
            return AdditionalSpecification;
        }
    }
}
