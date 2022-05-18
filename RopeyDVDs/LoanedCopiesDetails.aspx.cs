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
    public partial class LoanedCopiesDetails : System.Web.UI.Page
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
                if (ddCopyNumber.SelectedValue == "")
                {
                    getLoanedDVDCopyDetails();
                    getCopyNumber();

                }
                else
                {
                    if (ddCopyNumber.SelectedValue.Trim() == "All")
                    {
                        getLoanedDVDCopyDetails();
                        getCopyNumber();
                    }
                    else
                    {
                        getLoanedDVDCopyByCopyNumber();
                    }
                }
            }
        }

        void getLoanedDVDCopyDetails()
        {
            string sql = "getLoanedCopyDetails";
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

        void getCopyNumber()
        {
            string sql = "getCopyNumber";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddCopyNumber.DataSource = dt;
            ddCopyNumber.DataBind();
            ddCopyNumber.DataTextField = "CopyNumber";
            ddCopyNumber.DataBind();
            ListItem li = new ListItem("All", "-1");
            ddCopyNumber.Items.Insert(0, "All");
        }

        void getLoanedDVDCopyByCopyNumber()
        {
            int copyNumber;
            if (ddCopyNumber.SelectedValue.Trim() == "All")
            {
                copyNumber = 0;
            }
            else
            {
                copyNumber = int.Parse(ddCopyNumber.SelectedValue.Trim());
            }
            string sql = "getLoanedCopyDetailsByCopyNumber";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@copyNumber", copyNumber);
            sc.CommandType = CommandType.StoredProcedure;
            sc.ExecuteNonQuery();
            SqlDataReader dr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                gvDVD.DataSource = dt;
                gvDVD.DataBind();
            }
            else
            {
                Response.Write("<script>alert('The selected copy has not been loaned yet.');</script>");
                getLoanedDVDCopyDetails();
                getCopyNumber();
            }
        }
    }
}