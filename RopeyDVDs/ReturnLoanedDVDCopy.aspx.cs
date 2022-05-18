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
    public partial class ReturnLoanedDVDCopy : System.Web.UI.Page
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
                getNotReturnedLoanedCopies();
            }
        }

        void getNotReturnedLoanedCopies()
        {
            string sql = "getNotReturnedLoanedCopies ";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (loanNumberTB.Text != "")
            {
                
                string sql = "updateLoanReturn";
                SqlCommand sc = new SqlCommand(sql, gc.cn);
                sc.Parameters.AddWithValue("@loanNumber", Convert.ToInt32(loanNumberTB.Text));
                sc.Parameters.AddWithValue("@dateReturned", DateTime.Now);
                sc.CommandType = CommandType.StoredProcedure;
                sc.ExecuteNonQuery();
                Response.Write("<script>alert('The DVD has been returned successfully.');</script>");
                gvDVD.SelectedIndex = -1;
                clearTB();
                Page_Load(sender, e);
            }
        }

        protected void clearTB()
        {
            MemberNameTB.Text = "";
            DVDTitleTB.Text = "";
            loanNumberTB.Text = "";
            dvdCopyNumberTB.Text = "";
            dueDateTB.Text = "";
            returnDateTB.Text = "";
            penaltyChargeTB.Text = "";
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string index = Convert.ToString(e.CommandArgument);
            int loanNumber = int.Parse(index);
            string sql = "getNotReturnedLoanedCopyByLoanNumber ";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@loanNumber", loanNumber);
            sc.CommandType = CommandType.StoredProcedure;
            sc.ExecuteNonQuery();
            SqlDataReader dr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MemberNameTB.Text = dt.Rows[0]["membername"].ToString();
            DVDTitleTB.Text = dt.Rows[0]["dvdtitle"].ToString();
            loanNumberTB.Text = dt.Rows[0]["loannumber"].ToString();
            dvdCopyNumberTB.Text = dt.Rows[0]["copynumber"].ToString();
            dueDateTB.Text = dt.Rows[0]["datedue"].ToString();
            returnDateTB.Text = dt.Rows[0]["datereturned"].ToString();
            string penaltyCharge = dt.Rows[0]["penaltyCharge"].ToString();
            DateTime dueDate = Convert.ToDateTime(dt.Rows[0]["datedue"].ToString());
            DateTime currentDate = DateTime.Now;
            returnDateTB.Text = currentDate.ToString();
            if (dueDate < currentDate)
            {
                int dayDifference = Convert.ToInt32((currentDate - dueDate).TotalDays);
                int totalPenalty = dayDifference * Convert.ToInt32(penaltyCharge);
                penaltyChargeTB.Text = "Rs " + totalPenalty.ToString();
            }
            else
            {
                penaltyChargeTB.Text = "No Penalty Charge.";
            }
        }
    }
}