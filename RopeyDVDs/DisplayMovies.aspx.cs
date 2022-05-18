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
    
    public partial class DisplayMovies : System.Web.UI.Page
    {
        GlobalConnection gc = new GlobalConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Login"] != null)
            {
                Response.Write("<script>alert('IN');</script>");
                if (Request.Cookies["Login"]["userName"].ToString() != null)
                {
                    Response.Write("<script>alert('CookiesDone');</script>");
                    Session["User"] = Request.Cookies["Login"]["userName"].ToString();
                    Response.Redirect("./ViewDVDsMain.aspx");
                }
            }
            else
            {
                if (ddActorSurname.SelectedValue == "")
                {
                    getDVDDetails();
                    getActorSurname();

                }
                else
                {
                    if (ddActorSurname.SelectedValue.Trim() == "All")
                    {
                        getDVDDetails();
                        getActorSurname();
                    }
                    else
                    {
                        getDVDDetailsBySurname();
                    }
                }
            }
        }


        void getDVDDetails()
        {
            string sql = "getDVDDetails";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            



            if (dt.Rows.Count > 0)
            {
                gvDVD.DataSource = Concat.concatActors(dt);
                gvDVD.DataBind();
            }
        }

        void getActorSurname()
        {
            string sql = "getSurname";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddActorSurname.DataSource = dt;
            ddActorSurname.DataBind();
            ddActorSurname.DataTextField = "ActorSurname";
            ddActorSurname.DataBind();
            ListItem li = new ListItem("All", "-1");
            ddActorSurname.Items.Insert(0, "All");
        }

        void getDVDDetailsBySurname()
        {
            string sql = "getDVDDetailsBySurname";
            SqlCommand sc = new SqlCommand(sql, gc.cn);
            sc.Parameters.AddWithValue("@surname", ddActorSurname.SelectedValue);
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
                Response.Write("<script>alert('There is no DVD available of the selected actor.');</script>");
                getDVDDetails();
                getActorSurname();
            }
        }

        
    }
}