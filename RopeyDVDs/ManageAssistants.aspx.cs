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
    public partial class ManageAssistant : System.Web.UI.Page
    {
        GlobalConnection gc = new GlobalConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("./Login.aspx");
            }
            else
            {
                getAssistants();
            }
        }
        void getAssistants()
        {
            string sql = "getAssistants";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvDVD.DataSource = dt;
                gvDVD.DataBind();
            }
        }

        protected bool checkUserNameExistance(string userName)
        {
            string sql = "checkUserExist";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@userName", assistantNameTB.Text.Trim());
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
                return true;
            }
            else
            {
                return false;
            }
        }
           

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (assistantNameTB.Text.Trim() != "")
            {
                if (checkUserTB.Text.Trim() == assistantNameTB.Text.Trim())
                {
                    string sql = "updateUserDetails";
                    SqlCommand sc = new SqlCommand(sql, gc.cn);
                    sc.Parameters.AddWithValue("@userName", assistantNameTB.Text.Trim());
                    sc.Parameters.AddWithValue("@userType", userTypeDD.SelectedValue);
                    sc.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
                    sc.Parameters.AddWithValue("@oldUserName", checkUserTB.Text.Trim());
                    sc.CommandType = CommandType.StoredProcedure;
                    int count = sc.ExecuteNonQuery();
                    if (count == 1)
                    {
                        Response.Write("<script>alert('The user details has been successfully updated.');</script>");
                        gvDVD.SelectedIndex = -1;
                        clearTB();
                        Page_Load(sender, e);
                    }
                }
                else
                {
                    if (checkUserNameExistance(assistantNameTB.Text.Trim()) == false)
                    {
                        string sql = "updateUserDetails";
                        SqlCommand sc = new SqlCommand(sql, gc.cn);
                        sc.Parameters.AddWithValue("@userName", assistantNameTB.Text.Trim());
                        sc.Parameters.AddWithValue("@userType", userTypeDD.SelectedValue);
                        sc.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
                        sc.Parameters.AddWithValue("@oldUserName", checkUserTB.Text.Trim());
                        sc.CommandType = CommandType.StoredProcedure;
                        sc.ExecuteNonQuery();
                        Response.Write("<script>alert('The user details has been successfully updated.');</script>");
                        gvDVD.SelectedIndex = -1;
                        clearTB();
                        Page_Load(sender, e);
                    }
                    else
                    {
                        Response.Write("<script>alert('This username is already in use. Please enter unique username.');</script>");
                    }
                }
            }
        }

        protected void clearTB()
        {
            assistantNameTB.Text = "";
            passwordTB.Text = "";
            userTypeDD.Items.Remove("Manager");
            checkUserTB.Text = "";
            
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string userNumber = Convert.ToString(e.CommandArgument);
            int loanNumber = int.Parse(userNumber);
            string sql = "getAssistantByUserNumber";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@userNumber", userNumber);
            sc.CommandType = CommandType.StoredProcedure;
            sc.ExecuteNonQuery();
            SqlDataReader dr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            checkUserTB.Text = dt.Rows[0]["UserName"].ToString();
            assistantNameTB.Text = dt.Rows[0]["UserName"].ToString();
            userTypeDD.Items.Add("Manager");
            passwordTB.Text = dt.Rows[0]["UserPassword"].ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (userTypeDD.SelectedValue == "Assistant")
            {
                if (assistantNameTB.Text.Trim() != "")
                {
                    if (checkUserNameExistance(assistantNameTB.Text.Trim()) == false)
                    {
                        string sql = "insertAssistant";
                        SqlCommand sc = new SqlCommand(sql, gc.cn);
                        sc.Parameters.AddWithValue("@userName", assistantNameTB.Text.Trim());
                        sc.Parameters.AddWithValue("@userType", userTypeDD.SelectedValue);
                        sc.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
                        sc.CommandType = CommandType.StoredProcedure;
                        sc.ExecuteNonQuery();
                        
                        Response.Write("<script>alert('The user details has been successfully added.');</script>");
                        gvDVD.SelectedIndex = -1;
                        clearTB();
                        Page_Load(sender, e);
                    }
                    else
                    {
                        Response.Write("<script>alert('This username is already in use. Please enter unique username.');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Only the user type assistant can be added.');</script>");
                gvDVD.SelectedIndex = -1;
                clearTB();
                Page_Load(sender, e);
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            string sql = "deleteAssistant";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@userName", assistantNameTB.Text.Trim());
            sc.Parameters.AddWithValue("@userType", userTypeDD.SelectedValue);
            sc.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
            sc.CommandType = CommandType.StoredProcedure;
            int count = sc.ExecuteNonQuery(); 

            if (count == 1)
            {
                Response.Write("<script>alert('User Successfully Deleted.');</script>");
                gvDVD.SelectedIndex = -1;
                clearTB();
                Page_Load(sender, e);
            }
            else
            {
                Response.Write("<script>alert('User Credential Incorrect.');</script>");
            }
        }
    }
}