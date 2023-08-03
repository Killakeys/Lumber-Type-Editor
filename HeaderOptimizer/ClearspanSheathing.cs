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
    public class ClearspanSheathing
    {

        private string _sheathingcode;
        private string _description;
        private string _grade;
        private Distance _width;
        private Distance _length;
        private string _manufacturer;
        private Distance _widthNominal;
        private Distance _heightActual;
        private Distance _widthActual;
        
        private string _additionalSpecification;
        private double _bfPerPiece;
        private string _stocked;
        private string _useAsStud;
        private double _freight;
        private string _treated;
        private sheathingPrice _price;

        [Thickness]
      ,[Width]
      ,[Length]
      ,[Manufacturer]
      ,[Type]
      
      ,[CurrentPrice]
      ,[CurrentPriceDate]
      
      ,[SquareFt]
      ,[Structural]
      ,[IncludeInFifo]
      ,[ShortName]
      ,[WallProgramFavorite]

        public string Sheathingcode => _sheathingcode;
        public string Description => _description;
        public string Grade => _grade;
        public Distance Width => _width;
        public Distance Length => _length;
        public string Manufacturer => _manufacturer;
        public Distance WidthNominal => _widthNominal;
        public Distance HeigthActual => _heightActual;
        public Distance WidthActual => _widthActual;
        
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
        public SheathingPrice Price
        {
            get
            { return _price; }

            set
            {
                _price = value;
            }
        }

        public void SetSheathingAsStocked()
        {
            _stocked = "Yes";
            UpdateSheathingTypeDatabaseValue(_sheathingcode, SheathingFields.Stocked, _stocked);
        }

        public void SetSheathingAsUnStocked()
        {
            _stocked = "No";
            UpdateSheathingTypeDatabaseValue(_sheathingcode, SheathingFields.Stocked, _stocked);
        }

        public void SetToUseAsStud()
        {
            _useAsStud = "Yes";
            UpdateSheathingTypeDatabaseValue(_sheathingcode, SheathingFields.UseAsStud, _useAsStud);
        }

        public void SetToDontUseAsStud()
        {
            _useAsStud = "No";
            UpdateSheathingTypeDatabaseValue(_sheathingcode, SheathingFields.UseAsStud, _useAsStud);
        }

        public Single CurrentPrice()
        {
            return Price.Price;
        }

        public void SetCurrentPrice(double _newPrice, String _employeeId)
        {
            string sql = "Insert sheathingprices (Sheathingcode, Price, PriceDate, UserName, Factor, Op, FobMillPrice, Freight)" +
                "Values ('" + _sheathingcode + "'," + _newPrice + ", '" + DateTime.Now + "', '" + _employeeId + "', " + GetCurrentSheathingFactor() +
                ", 'Multiply', 0, " + _freight + ")";
            
            SqlDatabase.UpdateDB(sql);
        }

        private enum SheathingFields
        {
            SheathingCode,
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


        public struct SheathingPrice
        {
            public readonly string Sheathingcode;
            public readonly string PriceDate;
            public readonly int Price;
            public readonly Double Factor;
            public readonly int FobMillPrice;
            public readonly int Freight;


            public SheathingPrice(string sheathingcode, string priceDate, int price, Single factor, int fobMillPrice, int freight)
            {
                this.Sheathingcode = sheathingcode;
                this.PriceDate = priceDate;
                this.Price = price;
                this.Factor = factor;
                this.FobMillPrice = fobMillPrice;
                this.Freight = freight;
            }
        }

        public ClearspanSheathing(string ClearspanSheathingCode)
        {
            GetDatabaseValues(ClearspanSheathingCode);
            Price = GetSheathingPrice(ClearspanSheathingCode, DateTime.Now);
        }

        public ClearspanSheathing(string ClearspanSheathingCode, DateTime inquiryDate)
        {
            GetDatabaseValues(ClearspanSheathingCode);
            Price = GetSheathingPrice(this.Sheathingcode, inquiryDate);
        }

        private Single GetCurrentSheathingFactor()
        {
            DataSet myDataset = new DataSet();
            string sql;

            sql = "Select * from variable where system = 'CCD' and variable = 'SheathingPadFactor'";

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

       
        private SheathingPrice GetSheathingPrice(string _sheathingCode, DateTime _inquiryDate)
        {
            DataSet myDataset = new DataSet();
            string sql;

            sql = "Select * from sheathingprices where sheathingcode = '" + _sheathingCode + "' and pricedate <= '" + _inquiryDate + "' order by pricedate desc";

            myDataset = CCDAccess.SelectFromDB(sql);

            string _priceDate = "";
            int _price = 0;
            Single _factor = 0;
            int _fobMillPrice = 0;
            int _freight = 0;
            SheathingPrice tempSheathingPrices;

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
                            tempSheathingPrices = new SheathingPrice(_sheathingCode, _priceDate, _price, _factor, _fobMillPrice, _freight);
                        }
                        else
                        {
                            tempSheathingPrices = new SheathingPrice();
                        }

                        return tempSheathingPrices;
                    }
                }
            }
            return new SheathingPrice();
        }

        private void UpdateSheathingTypeDatabaseValue(string _sheathingcode, SheathingFields _field, string _newValue)
        {
            string sql = "";
            switch (_field)
            {
                case SheathingFields.SheathingCode:
                case SheathingFields.Grade:
                case SheathingFields.Species:
                case SheathingFields.HeightNominal:
                case SheathingFields.WidthNominal:
                case SheathingFields.HeightActual:
                case SheathingFields.WidthActual:
                case SheathingFields.Length:
                case SheathingFields.AdditionalSpecifications:
                case SheathingFields.UseAsStud:
                case SheathingFields.Treated:
                case SheathingFields.Stocked:
                    sql = "update sheathingtype set " + _field + " = '" + _newValue + "'";
                    break;
                case SheathingFields.Freight:                
                case SheathingFields.BfPerPiece:
                    sql = "update sheathingtype set " + _field + " = " + _newValue;
                    break;
                default:
                    break;
            }
            sql = sql + " where sheathingcode  = '" + _sheathingcode + "'";
            SqlDatabase.UpdateDB(sql);

        }
        
        private void GetDatabaseValues(string _passedSheathingCode)
        {

            DataSet myDataset = new DataSet();
            string sql;
            List<string> projectNumbers = new List<string>();


            sql = "Select * from sheathingtype where sheathingcode = '" + _passedSheathingCode + "'";

            myDataset = CCDAccess.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        _sheathingcode = dr["sheathingcode"].ToString();
                        _description = dr["description"].ToString();
                        _grade = dr["grade"].ToString();
                        _width = dr["species"].ToString();
                        _manufacturer = new Distance(new Inch(), Convert.ToDouble(dr["ThicknessN"].ToString()));
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
