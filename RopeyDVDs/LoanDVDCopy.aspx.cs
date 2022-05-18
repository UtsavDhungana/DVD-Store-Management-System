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
    public partial class LoanDVDCopy : System.Web.UI.Page
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
                getLoanedCopies();
                getMemberNumber();
                getAvailableCopyNumber();
                getLoanTypeNumber();
                dateOutTB.Text = DateTime.Now.ToString();
            }
        }

        void getLoanedCopies()
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

        void getMemberNumber()
        {
            if (!IsPostBack)
            {
                string sql = "getMemberNumber";
                SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                memberNumberDD.DataSource = dt;
                memberNumberDD.DataBind();
                memberNumberDD.DataTextField = "MemberNumber";
                memberNumberDD.DataBind();
                memberNumberDD.Items.Insert(0, " ");
            }
        }

        void getAvailableCopyNumber()
        {
            if (!IsPostBack)
            {
                string sql = "getAvailableCopy";
                SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CopyNumberDD.DataSource = dt;
                CopyNumberDD.DataBind();
                CopyNumberDD.DataTextField = "CopyNumber";
                CopyNumberDD.DataBind();
                CopyNumberDD.Items.Insert(0, " ");
            }
        }

        void getLoanTypeNumber()
        {
            if (!IsPostBack)
            {
                string sql = "getLoanTypeNumber";
                SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                LoanTypeNumberDD.DataSource = dt;
                LoanTypeNumberDD.DataBind();
                LoanTypeNumberDD.DataTextField = "LoanTypeNumber";
                LoanTypeNumberDD.DataBind();
                LoanTypeNumberDD.Items.Insert(0, " ");
            }
        }

        protected void clearTB()
        {
            memberNumberDD.SelectedIndex = -1;
            CopyNumberDD.SelectedIndex = -1;
            LoanTypeNumberDD.SelectedIndex = -1;

        }

        protected void btnLoan_Click(object sender, EventArgs e)
        {
            if (memberNumberDD.SelectedIndex != 0 && CopyNumberDD.SelectedIndex != 0 && LoanTypeNumberDD.SelectedIndex != 0)
            {
                string memberNumber = memberNumberDD.SelectedValue;
                string copyNumber = CopyNumberDD.SelectedValue;
                string loanTypeNumber = LoanTypeNumberDD.SelectedValue;

                string sql = "getMemberAge";
                SqlCommand sc = new SqlCommand(sql, gc.cn);
                sc.Parameters.AddWithValue("@memberID", Convert.ToInt32(memberNumber));
                sc.CommandType = CommandType.StoredProcedure;
                sc.ExecuteNonQuery();
                SqlDataReader dr = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                string sql1 = "getDVDRestriction";
                SqlCommand sc1 = new SqlCommand(sql1, gc.cn);
                sc1.Parameters.AddWithValue("@copyNumber", Convert.ToInt32(copyNumber));
                sc1.CommandType = CommandType.StoredProcedure;
                sc1.ExecuteNonQuery();
                SqlDataReader dr1 = sc1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                int standardCharge = Convert.ToInt32(dt1.Rows[0]["StandardCharge"].ToString());

                string sql2 = "getLoanDuration";
                SqlCommand sc2 = new SqlCommand(sql2, gc.cn);
                sc2.Parameters.AddWithValue("@loanTypeNumber", Convert.ToInt32(loanTypeNumber));
                sc2.CommandType = CommandType.StoredProcedure;
                sc2.ExecuteNonQuery();
                SqlDataReader dr2 = sc2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                int days = Convert.ToInt32(dt2.Rows[0]["LoanDuration"].ToString());
                DateTime currentDate = DateTime.Now;
                DateTime dueDate = DateTime.Now.AddDays(days);



                string sql3 = "getMemberCurrentLoanCountByMemberNumber";
                SqlCommand sc3 = new SqlCommand(sql3, gc.cn);
                sc3.Parameters.AddWithValue("@memberNumber", Convert.ToInt32(memberNumber));
                sc3.CommandType = CommandType.StoredProcedure;
                sc3.ExecuteNonQuery();
                SqlDataReader dr3 = sc3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                int memberCurrentLoan;
                int membershipCategoryTotalLoans;
                if (dt3.Rows.Count > 0)
                {
                     memberCurrentLoan = Convert.ToInt32(dt3.Rows[0]["TotalCurrentLoan"].ToString());
                     membershipCategoryTotalLoans = Convert.ToInt32(dt3.Rows[0]["MembershipCategoryTotalLoans"].ToString());
                }
                else
                {
                    memberCurrentLoan = 0;
                    membershipCategoryTotalLoans = 1;
                }
                 


                if (Convert.ToBoolean(dt1.Rows[0]["AgeRestricted"].ToString()) == true)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Age"].ToString()) > 18)
                    {

                        if (memberCurrentLoan < membershipCategoryTotalLoans)
                        {
                            int charge = standardCharge * days;

                            string sql4 = "giveLoan";
                            SqlCommand sc4 = new SqlCommand(sql4, gc.cn);
                            sc4.Parameters.AddWithValue("@memberNumber", Convert.ToInt32(memberNumber));
                            sc4.Parameters.AddWithValue("@loanTypeNumber", Convert.ToInt32(loanTypeNumber));
                            sc4.Parameters.AddWithValue("@copyNumber", Convert.ToInt32(copyNumber));
                            sc4.Parameters.AddWithValue("@dateOut", currentDate);
                            sc4.Parameters.AddWithValue("@dateDue", dueDate);
                            sc4.CommandType = CommandType.StoredProcedure;
                            sc4.ExecuteNonQuery();


                            Response.Write("<script>alert('Loan Successfully Granted. Total Loan Charge =  "+charge+"' );</script>");
                            clearTB();
                        }
                        else
                        {
                            Response.Write("<script>alert('The member has already loaned more DVDs than allowed.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('The member can not loan this DVD copy due to the age restriction.');</script>");
                    }
                }
                else
                {
                    if (memberCurrentLoan < membershipCategoryTotalLoans)
                    {
                        int charge = standardCharge * days;

                        string sql5 = "giveLoan";
                        SqlCommand sc5 = new SqlCommand(sql5, gc.cn);
                        sc5.Parameters.AddWithValue("@memberNumber", Convert.ToInt32(memberNumber));
                        sc5.Parameters.AddWithValue("@loanTypeNumber", Convert.ToInt32(loanTypeNumber));
                        sc5.Parameters.AddWithValue("@copyNumber", Convert.ToInt32(copyNumber));
                        sc5.Parameters.AddWithValue("@dateOut", currentDate);
                        sc5.Parameters.AddWithValue("@dateDue", dueDate);
                        sc5.CommandType = CommandType.StoredProcedure;
                        sc5.ExecuteNonQuery();

                        Response.Write("<script>alert('Loan Successfully Granted. Total Loan Charge =  " + charge + "' );</script>");

                        clearTB();
                    }
                    else
                    {
                        Response.Write("<script>alert('The member has already loaned more DVDs than allowed.');</script>");
                    }
                }

            }
            else
            {
                Response.Write("<script>alert('Please select all the values.');</script>");
            }


            

        }
    }
}