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
    public partial class ViewCopyDetailsWithNoBorrowSince31Days : System.Web.UI.Page
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
                getCopyDetailsWithNoBorrowSince31Days();
            }
        }

        void getCopyDetailsWithNoBorrowSince31Days()
        {
            string sql = "getCopyDetailsWithNoBorrowSince31Days";
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
    }
}