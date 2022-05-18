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
    public partial class ViewDVDs : System.Web.UI.Page
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
                if (ddMemberNumber.SelectedValue == "" && ddMemberSurname.SelectedValue == "")
                {
                    getMemberDVDDetails();
                    getMemberSurname();
                    getMemberNumber();

                }
                else
                {
                    if (ddMemberNumber.SelectedValue.Trim() == "All" && ddMemberSurname.SelectedValue.Trim() == "All")
                    {
                        getMemberDVDDetails();
                        getMemberSurname();
                        getMemberNumber();
                    }
                    else if (ddMemberNumber.SelectedValue.Trim() != "All" && ddMemberSurname.SelectedValue.Trim() != "All")
                    {
                        getMemberDVDDetails();
                        getMemberSurname();
                        getMemberNumber();
                    }
                    else
                    {
                        getMemberDVDBySurnameOrNumber();
                    }
                }
            }
        }

        void getMemberDVDDetails()
        {
            string sql = "viewMemberDVDsinMonth";
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

        void getMemberSurname()
        {
            string sql = "getMemberSurname";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddMemberSurname.DataSource = dt;
            ddMemberSurname.DataBind();
            ddMemberSurname.DataTextField = "MemberLastName";
            ddMemberSurname.DataBind();
            ListItem li = new ListItem("All", "-1");
            ddMemberSurname.Items.Insert(0, "All");
        }

        void getMemberNumber()
        {
            string sql = "getMemberNumber";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddMemberNumber.DataSource = dt;
            ddMemberNumber.DataBind();
            ddMemberNumber.DataTextField = "MemberNumber";
            ddMemberNumber.DataBind();
            ListItem li = new ListItem("All", "-1");
            ddMemberNumber.Items.Insert(0, "All");
        }

        void getMemberDVDBySurnameOrNumber()
        {
            int memberNumber;
            if (ddMemberNumber.SelectedValue.Trim() == "All")
            {
                memberNumber = 0;
            }
            else
            {
                memberNumber = int.Parse(ddMemberNumber.SelectedValue.Trim());
            }
            string sql = "getLoanHistoryByMemberSurname";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@memberNumber", memberNumber);
            sc.Parameters.AddWithValue("@memberSurname", ddMemberSurname.SelectedValue);
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
                Response.Write("<script>alert('The selected member has not loaned any DVD within 31 days.');</script>");
                getMemberDVDDetails();
                getMemberSurname();
                getMemberNumber();
            }
        }
    }
}