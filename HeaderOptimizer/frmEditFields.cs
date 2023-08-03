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
    public partial class frmEditFields : Form
    {
        public string materialCode { get; set; }
        public bool isLumberEdit { get; set; }
        private ClearspanLumber clearSpanLumber;
        public frmEditFields()
        {
            InitializeComponent();
        }

        private void frmEditFields_Load(object sender, EventArgs e)
        {
            clearSpanLumber = new ClearspanLumber(materialCode);

            lblLumberDescription.Text = clearSpanLumber.Description;

            if (clearSpanLumber.Stocked == "Stocked")
            {
                chkStocked.Checked = true;
            }
            else
            {
                chkStocked.Checked = false;
            }

            if (clearSpanLumber.UseAsStud == "Yes")
            {
                chkUseAsStud.Checked = true;
            }
            else
            {
                chkUseAsStud.Checked = false;
            }

            lblCurrentPrice.Text = clearSpanLumber.CurrentPrice().ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkStocked.Checked == true & clearSpanLumber.Stocked == "Not Stocked")
            {
                clearSpanLumber.SetLumberAsStocked();
            }
            if (chkStocked.Checked == false & clearSpanLumber.Stocked == "Stocked")
            {
                clearSpanLumber.SetLumberAsUnStocked();
            }

            if (chkUseAsStud.Checked == true & clearSpanLumber.UseAsStud.ToString().Trim().ToUpper() == "NO")
            {
                clearSpanLumber.SetToUseAsStud();
            }
            if (chkUseAsStud.Checked == false & clearSpanLumber.UseAsStud == "YES")
            {
                clearSpanLumber.SetToDontUseAsStud();
            }

            if (IsNumber(txtPrice.Text))
            {
                double newPrice = Convert.ToDouble(txtPrice.Text);
                if (clearSpanLumber.CurrentPrice() != newPrice)
                {
                    if (newPrice > 0 & newPrice < 10000)
                    {
                        clearSpanLumber.SetCurrentPrice(newPrice, "Edit");
                    }
                }
            }

            this.Close();
        }

        public Boolean IsNumber(String s)
        {
            Boolean value = true;
            if (s == String.Empty || s == null)
            {
                value = false;
            }
            else
            {
                foreach (Char c in s.ToCharArray())
                {
                    value = value && Char.IsDigit(c);
                }
            }
            return value;
        }
    }
}
