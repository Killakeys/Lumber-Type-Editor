using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;



namespace CCDLumberTypeEditor
{
    public partial class frmLogin : Form
    {
        private string userNameFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\UserName.txt";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogUserIn();
        }

        private void LogUserIn()
        {
            var aLogIn = new LogIn(txtUserName.Text, txtPassWord.Text);
            if (aLogIn.LogInValid)
            {
                if (aLogIn.PermittedToUseApp("LumberTypeEditor"))
                {
                    StoreUserName(aLogIn.UserName, userNameFilePath);
                    var aFrmEditLumber = new frmEditLumber();
                    aFrmEditLumber.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "User not permitted for this application.";
                }
            }
            else
            {
                lblMessage.Text = "User Name or Password not valid.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string userName = RetrieveUserName(userNameFilePath);
            if (userName != "")
            {
                txtUserName.Text = userName;
                this.ActiveControl = txtPassWord;
            }
            else
            {
                this.ActiveControl = txtUserName;
            }
            lblMessage.Text = "";
            txtPassWord.Text = "";
            if (System.Diagnostics.Debugger.IsAttached)
            {
                txtPassWord.Text = "zx9r";
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogUserIn();
            }
        }

        public static void StoreUserName(string userName, string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(userName);
            }
        }

        public string RetrieveUserName(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    return reader.ReadLine();
                }
            }
            return string.Empty;
        }
    }
}
