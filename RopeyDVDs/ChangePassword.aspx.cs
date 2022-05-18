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
    public partial class ChangePassword : System.Web.UI.Page
    {
        GlobalConnection gc = new GlobalConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("./Login.aspx");
            }
            else if(Request.Cookies["Login"]["userType"] == "Manager")
            {
                Response.Redirect("./ManageAssistants.aspx");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string userName = Request.Cookies["login"]["userName"];
            string userPassword = Request.Cookies["Login"]["password"];
            string userType = Request.Cookies["Login"]["userType"];

            if (currentPasswordTB.Text.Trim() != userPassword)
            {
                Response.Write("<script>alert('The current password you entered is incorrect.');</script>");
            }
            else if (newPasswordTB.Text.Trim() != confirmPasswordTB.Text.Trim())
            {
                Response.Write("<script>alert('The new password and confirm password does not match.');</script>");
            }
            else
            {
                if (confirmPasswordTB.Text.Trim() == currentPasswordTB.Text.Trim())
                {
                    Response.Write("<script>alert('The new password must not be same as current password. Please enter different password.');</script>");
                }
                else
                {
                    string sql = "updatePassword";
                    SqlCommand sc = new SqlCommand(sql, gc.cn);
                    sc.Parameters.AddWithValue("@userName", userName);
                    sc.Parameters.AddWithValue("@userType", userType);
                    sc.Parameters.AddWithValue("@password", confirmPasswordTB.Text.Trim());
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.ExecuteNonQuery();
                    int count = sc.ExecuteNonQuery();
                    if (count == 1)
                    {
                        Response.Cookies["Login"]["userName"] = userName;
                        Response.Cookies["Login"]["password"] = confirmPasswordTB.Text.Trim();
                        Response.Cookies["Login"]["userType"] = userType;
                        Response.Cookies["Login"].Expires = DateTime.Now.AddDays(5);
                        Response.Write("<script>alert('Password Successfully Changed.');</script>");
                    }
                }
            }
        }
    }
}