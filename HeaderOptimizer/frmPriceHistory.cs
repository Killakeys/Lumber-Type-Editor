using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCDLumberTypeEditor
{
    public partial class frmPriceHistory : Form
    {
        public string lumberCode { get; set; }
        private ClearspanLumber clearSpanLumber;
        public frmPriceHistory()
        {
            InitializeComponent();
        }

        private void frmPriceHistory_Load(object sender, EventArgs e)
        {
            if (lumberCode != "")
            {
                var aClearspanLumber = new ClearspanLumber(lumberCode);
                lblDescription.Text = aClearspanLumber.Description;

                string sqlPopulate = "select pricedate 'Date Entered', lp.Price*lp.Factor, lp.Price, lp.FOBMillPrice, lp.Freight, " + 
                    "ltrim(rtrim(e.FirstName)) + ' ' + ltrim(rtrim(e.LastName)) 'Entered By' from lumberprices lp, Employee e " + 
                    "where lp.LumberCode = '" + lumberCode + "' and lp.UserName = e.UserName order by lp.PriceDate desc";
                DataSet dsPrices = SqlDatabase.SelectFromDB(sqlPopulate);
                dgvPriceHistory.DataSource = dsPrices.Tables[0];

                for (int i = 0; i < dgvPriceHistory.ColumnCount; i++)
                {
                    dgvPriceHistory.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                dgvPriceHistory.Columns[0].HeaderText = "Date";
                dgvPriceHistory.Columns[1].HeaderText = "Estimate Price";
                dgvPriceHistory.Columns[1].DefaultCellStyle.Format = "c2";
                dgvPriceHistory.Columns[2].HeaderText = "Price with Freight";
                dgvPriceHistory.Columns[2].DefaultCellStyle.Format = "c2";
                dgvPriceHistory.Columns[3].HeaderText = "Price FOB Mill";
                dgvPriceHistory.Columns[3].DefaultCellStyle.Format = "c2";
                dgvPriceHistory.Columns[4].HeaderText = "Freight";
                dgvPriceHistory.Columns[4].DefaultCellStyle.Format = "c2";
                //dgvPriceHistory.Columns[5].HeaderText = "Entered By";


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
