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

        private string sqlForTypeGrid = "select lt.lumbercode, ltrim(rtrim(lt.description)), lt.thicknessn, lt.Widthn, lt.grade, lt.length, lt.species, lt.treated, lt.stocked, lt.useasstud," +
                                    " CONVERT(MONEY, lumberprices2.Price, 0) 'Price', lumberprices2.pricedate 'Price Date', CONVERT(MONEY, lumberprices2.FOBMillPrice, 0) 'FobMill', CONVERT(MONEY,  lumberprices2.Freight, 0) 'Freight' from lumbertype lt cross apply " +
                                    "( select top 1 (LumberPrices.Price* lumberprices.Factor) 'Price', Lumberprices.PriceDate, Lumberprices.FOBMillPrice, Lumberprices.Freight from LumberPrices where LumberPrices.LumberCode = lt.LumberCode order by LumberPrices.PriceDate desc) LumberPrices2";

        private string sqlForInventoryGrid = "select lt.lumbercode, ltrim(rtrim(lt.description)), l.DateRecv, l.lastAuditDate, l.Shed, l.Section, l.Quantity, CONVERT(MONEY, l.PurchasePrice, 0) 'Price', l.Supplier, l.Tag, ROUND((((lt.WidthN*lt.ThicknessN)/12)*(lt.Length)*l.Quantity),0) 'BF', DateUsed " +
                                                " from lumbertype lt, lumber l";
        private string sqlForInventoryGridWhereClause = " where lt.LumberCode = l.LumberCode and WrittenOff is null";
        private string sqlForInventoryGridOrderByClause = " order by l.lastauditdate desc, lt.description";
        private bool loadingCombos = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTypeFilterCombos();
            FillInventoryFilterCombos();
            PopulateLumberTypeGrid(sqlForTypeGrid);
            //PopulateInventoryGrid(sqlForInventoryGrid + sqlForInventoryGridWhereClause + sqlForInventoryGridOrderByClause);
            chkShowUsedLumber.Checked = false;
            dtpUsedStart.Value = DateTime.Now.AddDays(-7);
            dtpUsedEnd.Value = DateTime.Now;
            FilterInventoryGrid();
        }
        #region Buttons
        private void btnOptimize_Click(object sender, EventArgs e)
        {
            string clearSpanLumber = "";

            if (dgvLumberType.SelectedRows.Count > 0)
            {
                clearSpanLumber = dgvLumberType.Rows[dgvLumberType.SelectedRows[0].Index].Cells[0].Value.ToString().Trim();
                frmEditFields frmEF = new frmEditFields();
                frmEF.lumberCode = clearSpanLumber;
                frmEF.ShowDialog();
                FilterTypeGrid();

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
            FilterTypeGrid();
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

        private void btnInventoryExport_Click(object sender, EventArgs e)
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
                int columnCount = dgvInventory.ColumnCount;
                string columnNames = "";
                string[] output = new string[dgvInventory.RowCount + 1];

                columnNames += "Lumber Code" + ",";
                columnNames += "Description" + ",";
                columnNames += "Date Recv" + ",";
                columnNames += "Last Audit Date" + ",";
                columnNames += "Shed" + ",";
                columnNames += "Section" + ",";
                columnNames += "Qty" + ",";
                columnNames += "Price" + ",";
                columnNames += "Supplier" + ",";
                columnNames += "Tag" + ",";
                columnNames += "Date Used" + ",";

                output[0] += columnNames;
                for (int i = 1; (i - 1) < dgvInventory.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        string valueToInsert = "";
                        if (dgvInventory.Rows[i - 1].Cells[j].Value != null)
                        {
                            if (dgvInventory.Rows[i - 1].Cells[j].Value.ToString().Contains(","))
                            {
                                valueToInsert = "\"" + dgvInventory.Rows[i - 1].Cells[j].Value.ToString() + "\"";
                            }
                            else
                            {
                                valueToInsert = dgvInventory.Rows[i - 1].Cells[j].Value.ToString();
                            }
                        }

                        output[i] += valueToInsert + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
            }
        }
        #endregion Buttons

        #region PopulateGrids
        private void PopulateLumberTypeGrid(string sqlPopulate)
        {
            DataSet dsLumberType = SqlDatabase.SelectFromDB(sqlPopulate);

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

        private void PopulateInventoryGrid(string sqlPopulate)
        {
            DataSet dsLumberInventory = SqlDatabase.SelectFromDB(sqlPopulate);

            dgvInventory.DataSource = dsLumberInventory.Tables[0];
            dgvInventory.Columns[0].Visible = false;
            dgvInventory.AllowUserToAddRows = false;

            dgvInventory.Columns[1].HeaderText = "Description";
            dgvInventory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInventory.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[2].HeaderText = "Received";
            dgvInventory.Columns[2].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[3].HeaderText = "Last Audited";
            dgvInventory.Columns[3].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[4].HeaderText = "Shed";
            dgvInventory.Columns[4].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[5].HeaderText = "Section";
            dgvInventory.Columns[5].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[6].HeaderText = "Qty";
            dgvInventory.Columns[6].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[7].HeaderText = "Price";
            dgvInventory.Columns[7].DefaultCellStyle.Format = "C2";
            dgvInventory.Columns[7].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[8].HeaderText = "Supplier";
            dgvInventory.Columns[8].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[9].HeaderText = "Tag Number";
            dgvInventory.Columns[9].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvInventory.Columns[10].HeaderText = "Boardfeet";
            dgvInventory.Columns[10].SortMode = DataGridViewColumnSortMode.Programmatic;

            dgvInventory.EditMode = DataGridViewEditMode.EditProgrammatically;

            lblBoardFeet.Text = CalculateColumnSum(dgvInventory, 10).ToString("N0");
            lblBundlesTotalsQty.Text = dgvInventory.RowCount.ToString("N0"); ;
            lblTotalPieces.Text = CalculateColumnSum(dgvInventory, 6).ToString("N0");
        }

        decimal CalculateColumnSum(DataGridView dataGridView, int columnIndex)
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnIndex].Value != null && row.Cells[columnIndex].Value != DBNull.Value)
                {
                    decimal cellValue;
                    if (Decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }

            return sum;
        }
        #endregion PopulateGrids

        #region Filters
        private void FillTypeFilterCombos()
        {
            loadingCombos = true;

            var depthList = FilterList(LumberFields.ThicknessN);
            cboTypeDepth.Items.Add("No Filter");
            foreach (var fieldItem in depthList)
            {
                cboTypeDepth.Items.Add(fieldItem);
            }
            cboTypeDepth.SelectedIndex = 0;

            var widthList = FilterList(LumberFields.WidthN);
            cboTypeWidth.Items.Add("No Filter");
            foreach (var fieldItem in widthList)
            {
                cboTypeWidth.Items.Add(fieldItem);
            }
            cboTypeWidth.SelectedIndex = 0;

            var gradeList = FilterList(LumberFields.Grade);
            cboTypeGrade.Items.Add("No Filter");
            foreach (var fieldItem in gradeList)
            {
                cboTypeGrade.Items.Add(fieldItem);
            }
            cboTypeGrade.SelectedIndex = 0;

            var lengthList = FilterList(LumberFields.Length);
            cboTypeLength.Items.Add("No Filter");
            foreach (var fieldItem in lengthList)
            {
                cboTypeLength.Items.Add(fieldItem);
            }
            cboTypeLength.SelectedIndex = 0;

            var speciesList = FilterList(LumberFields.Species);
            cboTypeSpecies.Items.Add("No Filter");
            foreach (var fieldItem in speciesList)
            {
                cboTypeSpecies.Items.Add(fieldItem);
            }
            cboTypeSpecies.SelectedIndex = 0;

            var treatmentList = FilterList(LumberFields.Treated);
            cboTypeTreatment.Items.Add("No Filter");
            foreach (var fieldItem in treatmentList)
            {
                cboTypeTreatment.Items.Add(fieldItem);
            }
            cboTypeTreatment.SelectedIndex = 0;

            var stockedList = FilterList(LumberFields.Stocked);
            cboTypeStocked.Items.Add("No Filter");
            foreach (var fieldItem in stockedList)
            {
                cboTypeStocked.Items.Add(fieldItem);
            }
            cboTypeStocked.SelectedIndex = 0;

            var useAsStudList = FilterList(LumberFields.UseAsStud);
            cboTypeUseAsStud.Items.Add("No Filter");
            foreach (var fieldItem in useAsStudList)
            {
                cboTypeUseAsStud.Items.Add(fieldItem);
            }
            cboTypeUseAsStud.SelectedIndex = 0;

            loadingCombos = false;
        }

        private void FillInventoryFilterCombos()
        {
            loadingCombos = true;

            var depthList = FilterList(LumberFields.ThicknessN);
            cboInventoryDepth.Items.Add("No Filter");
            foreach (var fieldItem in depthList)
            {
                cboInventoryDepth.Items.Add(fieldItem);
            }
            cboInventoryDepth.SelectedIndex = 0;

            var widthList = FilterList(LumberFields.WidthN);
            cboInventoryWidth.Items.Add("No Filter");
            foreach (var fieldItem in widthList)
            {
                cboInventoryWidth.Items.Add(fieldItem);
            }
            cboInventoryWidth.SelectedIndex = 0;

            var gradeList = FilterList(LumberFields.Grade);
            cboInventoryGrade.Items.Add("No Filter");
            foreach (var fieldItem in gradeList)
            {
                cboInventoryGrade.Items.Add(fieldItem);
            }
            cboInventoryGrade.SelectedIndex = 0;

            var lengthList = FilterList(LumberFields.Length);
            cboInventoryLength.Items.Add("No Filter");
            foreach (var fieldItem in lengthList)
            {
                cboInventoryLength.Items.Add(fieldItem);
            }
            cboInventoryLength.SelectedIndex = 0;

            var speciesList = FilterList(LumberFields.Species);
            cboInventorySpecies.Items.Add("No Filter");
            foreach (var fieldItem in speciesList)
            {
                cboInventorySpecies.Items.Add(fieldItem);
            }
            cboInventorySpecies.SelectedIndex = 0;

            var treatmentList = FilterList(LumberFields.Treated);
            cboInventoryTreatment.Items.Add("No Filter");
            foreach (var fieldItem in treatmentList)
            {
                cboInventoryTreatment.Items.Add(fieldItem);
            }
            cboInventoryTreatment.SelectedIndex = 0;

            loadingCombos = false;
        }
        private List<String> FilterList(LumberFields field)
        {
            DataSet myDataset = new DataSet();
            string sql;
            List<string> fieldList = new List<string>();

            sql = "Select distinct " + field + " from lumbertype order by " + field;

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
            FilterTypeGrid();
        }

        private void btnInventoryFilter_Click(object sender, EventArgs e)
        {
            FilterInventoryGrid();
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

        private void FilterTypeGrid()
        {
            string whereClause = "";
            if (cboTypeDepth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.thicknessN", cboTypeDepth.Text, false);
            }

            if (cboTypeWidth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.widthN", cboTypeWidth.Text, false);
            }

            if (cboTypeGrade.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.grade", cboTypeGrade.Text, true);
            }

            if (cboTypeLength.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.length", cboTypeLength.Text, false);
            }

            if (cboTypeTreatment.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.treated", cboTypeTreatment.Text, true);
            }

            if (cboTypeSpecies.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.species", cboTypeSpecies.Text, true);
            }

            if (cboTypeStocked.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.stocked", cboTypeStocked.Text, true);
            }

            if (cboTypeUseAsStud.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.useAsStud", cboTypeUseAsStud.Text, true);
            }

            string sql = sqlForTypeGrid;
            if (whereClause != "")
            {
                sql = sql + " where " + whereClause;
            }

            PopulateLumberTypeGrid(sql);
        }

        private void FilterInventoryGrid()
        {
            string whereClause = "";
            if (cboInventoryDepth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.thicknessN", cboInventoryDepth.Text, false);
            }

            if (cboInventoryWidth.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.widthN", cboInventoryWidth.Text, false);
            }

            if (cboInventoryGrade.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.grade", cboInventoryGrade.Text, true);
            }

            if (cboInventoryLength.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.length", cboInventoryLength.Text, false);
            }

            if (cboInventoryTreatment.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.treated", cboInventoryTreatment.Text, true);
            }

            if (cboInventorySpecies.Text != "No Filter")
            {
                whereClause = BuildWhereClause(whereClause, "lt.species", cboInventorySpecies.Text, true);
            }

            if (whereClause.Length > 0)
            {
                whereClause += " and ";
            }
            
            if (chkShowUsedLumber.Checked)
            {
                whereClause += "l.DateUsed >= '" + dtpUsedStart.Value.ToString("MM/dd/yyyy") + "' and l.DateUsed <= '" + dtpUsedEnd.Value.ToString("MM/dd/yyyy") + "'";
            }
            else
            {
                whereClause += "l.DateUsed is null";
            }

            string sql = sqlForInventoryGrid + sqlForInventoryGridWhereClause;
            if (whereClause != "")
            {
                sql = sql + " and " + whereClause + sqlForInventoryGridOrderByClause;
            }
            else
            {

            }

            PopulateInventoryGrid(sql);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cboTypeDepth.SelectedIndex = 0;
            cboTypeWidth.SelectedIndex = 0;
            cboTypeGrade.SelectedIndex = 0;
            cboTypeLength.SelectedIndex = 0;
            cboTypeSpecies.SelectedIndex = 0;
            cboTypeTreatment.SelectedIndex = 0;
            cboTypeStocked.SelectedIndex = 0;
            cboTypeUseAsStud.SelectedIndex = 0;

            PopulateLumberTypeGrid(sqlForTypeGrid);
        }
        private void btnInventoryClearFilter_Click(object sender, EventArgs e)
        {
            cboInventoryDepth.SelectedIndex = 0;
            cboInventoryWidth.SelectedIndex = 0;
            cboInventoryGrade.SelectedIndex = 0;
            cboInventoryLength.SelectedIndex = 0;
            cboInventorySpecies.SelectedIndex = 0;
            cboInventoryTreatment.SelectedIndex = 0;

            PopulateInventoryGrid(sqlForInventoryGrid + sqlForInventoryGridWhereClause + sqlForInventoryGridOrderByClause);
        }

        private void cboDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboStocked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboUseAsStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterTypeGrid();
            }
        }

        private void cboInventoryDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void cboInventoryWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void cboInventoryGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void cboInventoryLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void cboInventorySpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void cboInventoryTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingCombos)
            {
                FilterInventoryGrid();
            }
        }

        private void frmEditLumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void dgvInventory_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dgvInventory.Columns[e.ColumnIndex];

            // Sort the data based on the clicked column
            if (clickedColumn.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                dgvInventory.Sort(clickedColumn, ListSortDirection.Descending);
            }
            else
            {
                dgvInventory.Sort(clickedColumn, ListSortDirection.Ascending);
            }
        }
        #endregion Filters

        private void chkShowUsedLumber_CheckedChanged(object sender, EventArgs e)
        {
            FilterInventoryGrid();
        }

        private void dtpUsedStart_ValueChanged(object sender, EventArgs e)
        {
            FilterInventoryGrid();
        }

        private void dtpUsedEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterInventoryGrid();
        }
    }
}