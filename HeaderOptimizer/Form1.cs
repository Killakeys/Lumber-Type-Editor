using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using UnitClassLibrary;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;
using System.Timers;

namespace CCDLumberTypeEditor
{
    public partial class frmEditLumber : Form
    {
        public frmEditLumber()
        {
            InitializeComponent();
        }

        private enum LumberFields
        {
            LumberCode,
            Grade,
            Species,
            ThicknessN,
            WidthN,
            ThicknessA,
            WidthA,
            Length,
            AdditionalSpecifications,
            BfPerPiece,
            Stocked,
            UseAsStud,
            Freight,
            Treated
        }

        private string sqlForGrid = "select lt.lumbercode, ltrim(rtrim(lt.description)), lt.thicknessn, lt.Widthn, lt.grade, lt.length, lt.species, lt.treated, lt.stocked, lt.useasstud," +
                                    " CONVERT(MONEY, lumberprices2.Price, 0) 'Price', lumberprices2.pricedate 'Price Date', CONVERT(MONEY, lumberprices2.FOBMillPrice, 0) 'FobMill', CONVERT(MONEY,  lumberprices2.Freight, 0) 'Freight' from lumbertype lt cross apply " +
                                    "( select top 1 (LumberPrices.Price* lumberprices.Factor) 'Price', Lumberprices.PriceDate, Lumberprices.FOBMillPrice, Lumberprices.Freight from LumberPrices where LumberPrices.LumberCode = lt.LumberCode order by LumberPrices.PriceDate desc) LumberPrices2";
        private bool loadingCombos = true;

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            string clearSpanLumber = "";

            if (dgvLumberType.SelectedRows.Count > 0)
            {
                clearSpanLumber = dgvLumberType.Rows[dgvLumberType.SelectedRows[0].Index].Cells[0].Value.ToString().Trim();
                frmEditFields frmEF = new frmEditFields();
                frmEF.lumberCode = clearSpanLumber;
                frmEF.ShowDialog();
                FilterGrid();

                //dgvLumberType.SelectedRows.Clear();
                foreach (DataGridViewRow row in dgvLumberType.Rows)
                {
                    var cells = row.Cells;
                    if (cells[0].Value.ToString().Trim() == clearSpanLumber)
                    {
                        row.Selected = true;
                    }
                }

                dgvLumberType.FirstDisplayedScrollingRowIndex = dgvLumberType.SelectedRows[0].Index;
            }
        }
        private void btnPriceHistory_Click(object sender, EventArgs e)
        {
            string clearSpanLumber = "";

            if (dgvLumberType.SelectedRows.Count > 0)
            {
                clearSpanLumber = dgvLumberType.Rows[dgvLumberType.SelectedRows[0].Index].Cells[0].Value.ToString().Trim();
            }

            frmPriceHistory frmPH = new frmPriceHistory();
            frmPH.lumberCode = clearSpanLumber;
            frmPH.ShowDialog();
            FilterGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillFilterCombos();
            PopulateGrid(sqlForGrid);
        }

        private void FillFilterCombos()
        {
            loadingCombos = true;

            var depthList = FilterList(LumberFields.ThicknessN);
            cboDepth.Items.Add("No Filter");
            foreach (var fieldItem in depthList)
            {
                cboDepth.Items.Add(fieldItem);
            }
            cboDepth.SelectedIndex = 0;

            var widthList = FilterList(LumberFields.WidthN);
            cboWidth.Items.Add("No Filter");
            foreach (var fieldItem in widthList)
            {
                cboWidth.Items.Add(fieldItem);
            }
            cboWidth.SelectedIndex = 0;

            var gradeList = FilterList(LumberFields.Grade);
            cboGrade.Items.Add("No Filter");
            foreach (var fieldItem in gradeList)
            {
                cboGrade.Items.Add(fieldItem);
            }
            cboGrade.SelectedIndex = 0;

            var lengthList = FilterList(LumberFields.Length);
            cboLength.Items.Add("No Filter");
            foreach (var fieldItem in lengthList)
            {
                cboLength.Items.Add(fieldItem);
            }
            cboLength.SelectedIndex = 0;

            var speciesList = FilterList(LumberFields.Species);
            cboSpecies.Items.Add("No Filter");
            foreach (var fieldItem in speciesList)
            {
                cboSpecies.Items.Add(fieldItem);
            }
            cboSpecies.SelectedIndex = 0;

            var treatmentList = FilterList(LumberFields.Treated);
            cboTreatment.Items.Add("No Filter");
            foreach (var fieldItem in treatmentList)
            {
                cboTreatment.Items.Add(fieldItem);
            }
            cboTreatment.SelectedIndex = 0;

            var stockedList = FilterList(LumberFields.Stocked);
            cboStocked.Items.Add("No Filter");
            foreach (var fieldItem in stockedList)
            {
                cboStocked.Items.Add(fieldItem);
            }
            cboStocked.SelectedIndex = 0;

            var useAsStudList = FilterList(LumberFields.UseAsStud);
            cboUseAsStud.Items.Add("No Filter");
            foreach (var fieldItem in useAsStudList)
            {
                cboUseAsStud.Items.Add(fieldItem);
            }
            cboUseAsStud.SelectedIndex = 0;

            loadingCombos = false;
        }

        private void PopulateGrid(string sqlPopulate)
        {
            DataSet dsLumberType = SqlDatabase.SelectFromDB(sqlPopulate);

            if ((dsLumberType != null))
            {
                foreach (DataTable table in dsLumberType.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        Debug.Print(dr["price"].ToString());
                    }
                }
            }


            dgvLumberType.DataSource = dsLumberType.Tables[0];
            dgvLumberType.Columns[0].Visible = false;

            dgvLumberType.Columns[1].HeaderText = "Description";
            dgvLumberType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLumberType.Columns[2].HeaderText = "Depth";
            dgvLumberType.Columns[3].HeaderText = "Width";
            dgvLumberType.Columns[4].HeaderText = "Grade";
            dgvLumberType.Columns[5].HeaderText = "Length";
            dgvLumberType.Columns[6].HeaderText = "Species";
            dgvLumberType.Columns[7].HeaderText = "Treatment";
            dgvLumberType.Columns[8].HeaderText = "Stocked";
            dgvLumberType.Columns[9].HeaderText = "Use As Stud";
            dgvLumberType.Columns[10].HeaderText = "Price";
            dgvLumberType.Columns[10].DefaultCellStyle.Format = "C2";
            dgvLumberType.Columns[11].HeaderText = "Price Date";
            dgvLumberType.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLumberType.Columns[12].HeaderText = "FOB Mill";
            dgvLumberType.Columns[12].DefaultCellStyle.Format = "C2";
            dgvLumberType.Columns[13].HeaderText = "Freight";
            dgvLumberType.Columns[13].DefaultCellStyle.Format = "C2";

            dgvLumberType.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private List<String> FilterList(LumberFields field)
        {
            DataSet myDataset = new DataSet();
            string sql;
            List<string> fieldList = new List<string>();

            sql = "Select distinct " + field + " from lumbertype";

            myDataset = SqlDatabase.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        fieldList.Add(dr[field.ToString()].ToString());
                    }
                }
            }
            return fieldList;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterGrid();
        }

        private string BuildWhereClause(string previousClaus, string field, string value, bool isString)
        {
            if (previousClaus != "")
            {
                if (isString)
                {
                    return previousClaus + " and " + field + " = '" + value + "'";
                }
                else
                {
                    return previousClaus + " and " + field + " = " + value;
                }
            }
            else
            {
                if (isString)
                {
                    return field + " = '" + value + "'";
                }
                else
                {
                    return field + " = " + value;
                }
            }
        }

        private void FilterGrid()
        {
            string whereClause = "";
            if (cboDepth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "thicknessN", cboDepth.Text, false);
            }

            if (cboWidth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "widthN", cboWidth.Text, false);
            }

            if (cboGrade.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "grade", cboGrade.Text, true);
            }

            if (cboLength.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "length", cboLength.Text, false);
            }

            if (cboTreatment.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "treated", cboTreatment.Text, true);
            }

            if (cboSpecies.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "species", cboSpecies.Text, true);
            }

            if (cboStocked.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "stocked", cboStocked.Text, true);
            }

            if (cboUseAsStud.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "useAsStud", cboUseAsStud.Text, true);
            }

            string sql = sqlForGrid;
            if (whereClause != "")
            {
                sql = sql + " where " + whereClause;
            }

            PopulateGrid(sql);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cboDepth.SelectedIndex = 0;
            cboWidth.SelectedIndex = 0;
            cboGrade.SelectedIndex = 0;
            cboLength.SelectedIndex = 0;
            cboSpecies.SelectedIndex = 0;
            cboTreatment.SelectedIndex = 0;
            cboStocked.SelectedIndex = 0;
            cboUseAsStud.SelectedIndex = 0;
            
            PopulateGrid(sqlForGrid);
        }

        private void cboDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboStocked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void cboUseAsStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterGrid();
            }
        }

        private void frmEditLumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                int columnCount = dgvLumberType.ColumnCount;
                string columnNames = "";
                string[] output = new string[dgvLumberType.RowCount + 1];

                columnNames += "Lumber Code" + ",";
                columnNames += "Description" + ",";
                columnNames += "Depth" + ",";
                columnNames += "Width" + ",";
                columnNames += "Grade" + ",";
                columnNames += "Length" + ",";
                columnNames += "Species" + ",";
                columnNames += "Treatment" + ",";
                columnNames += "Stocked" + ",";
                columnNames += "Use As Stud" + ",";
                columnNames += "Price" + ",";
                columnNames += "Price Date  " + ",";
                columnNames += "FOB Mill" + ",";
                columnNames += "Freight" + ",";

                output[0] += columnNames;
                for (int i = 1; (i - 1) < dgvLumberType.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += dgvLumberType.Rows[i - 1].Cells[j].Value + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
            }
        }
    }
}