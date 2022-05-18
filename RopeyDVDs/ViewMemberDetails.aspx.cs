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
    public partial class ViewMemberDetails : System.Web.UI.Page
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
                getMemberDetails();
            }
        }

        void getMemberDetails()
        {
            string sql = "getMemberLoanCount ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dtTotalLoanCount = new DataTable();
            sda.Fill(dtTotalLoanCount);

            string sql1 = "getMemberCurrentLoanCount";
            SqlDataAdapter sda1 = new SqlDataAdapter(sql1, gc.cn);
            sda1.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dtCurrentLoanCount = new DataTable();
            sda1.Fill(dtCurrentLoanCount);

            foreach (DataRow row in dtCurrentLoanCount.Rows)
            {
                foreach (DataRow row1 in dtTotalLoanCount.Rows)
                {

                    if (row["MemberNumber"].ToString() == row1["MemberNumber"].ToString())
                    {
                        row1["Total Current Loan"] = row["Total Current Loan"].ToString();

                        if(Convert.ToInt16(row["Total Current Loan"]) > Convert.ToInt16(row1["MembershipCategoryTotalLoans"]))
                        {
                            row1["Error Message"] = "**Too Many DVDs Loaned";  
                        }
                        break;
                    }
                    
                }
            }

            if (dtTotalLoanCount.Rows.Count > 0)
            {
                gvDVD.DataSource = dtTotalLoanCount;
                gvDVD.DataBind();
            }
        }
    }
}