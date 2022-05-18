using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RopeyDVDs
{
    public partial class Login : System.Web.UI.Page
    {
        GlobalConnection gc = new GlobalConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        void checkUser(string userName, string password, string userType)
        {
            
            string sql = "checkUser";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@username", userName);
            sc.Parameters.AddWithValue("@password", password);
            sc.Parameters.AddWithValue("@userType", userType);
            sc.CommandType = CommandType.StoredProcedure;
            sc.ExecuteNonQuery();
            SqlDataReader dr = sc.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                // Use the row data, presumably
                count++;
            }
            if (count == 1)
            {
                Session["User"] = userName;
                Response.Cookies["Login"]["userName"] = userName;
                Response.Cookies["Login"]["password"] = password;
                Response.Cookies["Login"]["userType"] = userType;
                Response.Cookies["Login"].Expires = DateTime.Now.AddDays(5);
                Response.Write("<script>alert('Login Successful');</script>");
                Response.Redirect("./ViewDVDsMain.aspx");
            }
            else
            {
                Response.Write("<script>alert('Incorrect Login Credential');</script>");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (userNameTB.Text.Trim() == ""){

            }
            if (passwordTB.Text.Trim() == "")
            {

            }
            if (userNameTB.Text.Trim() != "" && passwordTB.Text.Trim() != ""){
                checkUser(userNameTB.Text, passwordTB.Text, userTypeDDL.SelectedValue);
            }           
        }
    }
}