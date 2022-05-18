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
    public partial class DeleteOldDVDCopies : System.Web.UI.Page
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
                getOldDVDCopiesDetails();
            }
        }

        void getOldDVDCopiesDetails()
        {
            string sql = "getOldDVDCopies";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            sda.Fill(dt);   
            if (dt.Rows.Count > 0)
            {
                gvDVD.Visible = true;
                btnErrorMessage.Visible = false;
                gvDVD.DataSource = dt;
                gvDVD.DataBind();
            }
            else
            {
                gvDVD.Visible = false;
                btnErrorMessage.Visible = true;
                btnErrorMessage.Text = "No Old DVD Copies Available";
            }
        }

        protected void btnDeleteOldCopies_Click(object sender, EventArgs e)
        {
            string sql = "deleteAllOldCopies";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.CommandType = CommandType.StoredProcedure;
            int count = sc.ExecuteNonQuery();

            if (count == 1)
            {
                Response.Write("<script>alert('All Old Copies Successfully Deleted.');</script>");
            }
            else
            {
                Response.Write("<script>alert('No Old DVD Copies Available To Delete.');</script>");
            }
            getOldDVDCopiesDetails();
        }
    }
}