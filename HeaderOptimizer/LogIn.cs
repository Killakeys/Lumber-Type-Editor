using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CCDLumberTypeEditor
{
    class LogIn
    {
        private string _userName;
        private string _passWord;
        private bool _validLogin;
        private string _dotNetAppsAllowed;

        public string UserName { get; set; }

        public bool LogInValid => _validLogin;
        public LogIn(string userName, string passWord)
        {
            _userName = userName;
            _passWord = passWord;
            UserName = _userName;
            if (CheckforValidLogIn())
            {
                _validLogin = true;
                _dotNetAppsAllowed = GetAllowedApps();
            }
            else
            {
                _validLogin = false;
                _dotNetAppsAllowed = "";
            }

        }

        private bool CheckforValidLogIn()
        {
            DataSet myDataset = new DataSet();
            string sql;
            string passwordInDataBase = "";

            sql = "Select password from employee where username = '" + _userName + "'";

            myDataset = CCDAccess.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        DataRow d = table.Rows[0];
                        passwordInDataBase = d["password"].ToString();
                    }
                }
            }
            if (_passWord.Trim() == passwordInDataBase.Trim())
            {
                return true;
            }
            return false;
        }

        public bool PermittedToUseApp(string appName)
        {
            if (_dotNetAppsAllowed.IndexOf(appName) != -1)
            {
                return true;
            }
            return false;
        }
        private string GetAllowedApps()
        {
            DataSet myDataset = new DataSet();
            string sql;

            sql = "Select DotNetAppsAllowed from employee where username = '" + _userName + "'";

            myDataset = CCDAccess.SelectFromDB(sql);

            if ((myDataset != null))
            {
                foreach (DataTable table in myDataset.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        DataRow d = table.Rows[0];
                        return d["DotNetAppsAllowed"].ToString();
                    }
                }
            }
            return "";
        }

    }
}
