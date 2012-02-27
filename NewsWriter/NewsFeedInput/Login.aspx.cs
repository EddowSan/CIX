using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace NewsFeedInput
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                if (ValidateUser())
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                else
                    Response.Redirect("logon.aspx", true);
            }
        }

        public bool ValidateUser()
        {
            MySqlConnection conn;
            MySqlCommand comm;
            string passwordLookUp = null;

            if ((null == txtUserName.Text) || (0 == txtUserName.Text.Length) || (txtUserName.Text.Length > 15))
            {
                headerTag.InnerHtml = "Coleman University<br />UserName Failed";
                return false;
            }

            if ((null == txtPassword.Text) || (0 == txtPassword.Text.Length) || (txtPassword.Text.Length > 25))
            {
                headerTag.InnerHtml = "Coleman University<br />Password Failed";
                return false;
            }

            string strConnection = ConfigurationManager.ConnectionStrings["NewsWriter"].ConnectionString;
            
            conn = new MySqlConnection(strConnection);

            comm = new MySqlCommand("SELECT Password FROM Users WHERE UserName = @UserName", conn);
            comm.Parameters.Add("@UserName", MySqlDbType.VarChar);
            comm.Parameters["@UserName"].Value = txtUserName.Text;

            try
            {
                conn.Open();

                passwordLookUp = (string)comm.ExecuteScalar();
            }
            catch (Exception error)
            {
                headerTag.InnerHtml = "Coleman University<br />" + error.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }

            if (null == passwordLookUp)
            {
                headerTag.InnerHtml = "Coleman University<br />No Matching User";
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(passwordLookUp, txtPassword.Text, false));
        }
    }
}