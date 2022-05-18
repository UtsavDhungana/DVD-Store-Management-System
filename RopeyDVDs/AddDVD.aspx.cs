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
    public partial class AddDVD : System.Web.UI.Page
    {
        GlobalConnection gc = new GlobalConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void clear()
        {
            dvdTitleTB.Text = "";
            releaseDateTB.Text = "";
            standardChargeTB.Text = "";
            penaltyChargeTB.Text = "";
            actorFirstNameTB.Text = "";
            actorLastNameTB.Text = "";
            producerNameTB.Text= "";
            studioNameTB.Text = "";
            categoryDD.SelectedIndex = -1;
            ageRestrictedDD.SelectedIndex = -1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(dvdTitleTB.Text.Trim() != "" && releaseDateTB.Text.Trim() != "" && standardChargeTB.Text.Trim() != "" && penaltyChargeTB.Text.Trim() != ""
               && actorFirstNameTB.Text.Trim() != "" && actorLastNameTB.Text.Trim() != "" && producerNameTB.Text.Trim() != "" && studioNameTB.Text.Trim() != ""
               && dvdImageFU.FileName != "")
            {
                if (dvdImageFU.HasFile)
                {
                    string str = dvdImageFU.FileName;
                    dvdImageFU.PostedFile.SaveAs(Server.MapPath("./images/" + str));
                    string imagePath = "./images/" + str.ToString();

                    string dvdTitle = dvdTitleTB.Text.Trim();
                    DateTime releaseDate = Convert.ToDateTime(releaseDateTB.Text.Trim());
                    int standardCharge = Convert.ToInt32(standardChargeTB.Text.Trim());
                    int penaltyCharge = Convert.ToInt32(penaltyChargeTB.Text.Trim());
                    string actorFirstName = actorFirstNameTB.Text.Trim();
                    string actorLastName = actorLastNameTB.Text.Trim();
                    string producerName = producerNameTB.Text.Trim();
                    string studioName = studioNameTB.Text.Trim();
                    string dvdImage = imagePath;

                    int categoryNumber;
                    string sql = "checkCategory";
                    SqlCommand sc = new SqlCommand(sql, gc.cn);
                    sc.Parameters.AddWithValue("@categoryDescription", categoryDD.SelectedValue);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.ExecuteNonQuery();
                    SqlDataReader dr = sc.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        categoryNumber = Convert.ToInt32(dt.Rows[0]["CategoryNumber"].ToString());
                    }
                    else
                    {
                        string sqlInsert = "insertCategory";
                        SqlCommand sc1 = new SqlCommand(sqlInsert, gc.cn);
                        sc1.Parameters.AddWithValue("@categoryDescription", categoryDD.SelectedValue);
                        sc1.Parameters.AddWithValue("@ageRestricted", ageRestrictedDD.SelectedValue);
                        sc1.CommandType = CommandType.StoredProcedure;
                        sc1.ExecuteNonQuery();

                        string sql2 = "checkCategory";
                        SqlCommand sc2 = new SqlCommand(sql2, gc.cn);
                        sc2.Parameters.AddWithValue("@categoryDescription", categoryDD.SelectedValue);
                        sc2.CommandType = CommandType.StoredProcedure;
                        sc2.ExecuteNonQuery();
                        SqlDataReader dr1 = sc2.ExecuteReader();
                        DataTable dt1 = new DataTable();
                        dt1.Load(dr1);
                        categoryNumber = Convert.ToInt32(dt1.Rows[0]["CategoryNumber"].ToString());
                    }



                    int studioNumber;
                    string sql3 = "checkStudio";
                    SqlCommand sc3 = new SqlCommand(sql3, gc.cn);
                    sc3.Parameters.AddWithValue("@studioName", studioName);
                    sc3.CommandType = CommandType.StoredProcedure;
                    sc3.ExecuteNonQuery();
                    SqlDataReader dr3 = sc3.ExecuteReader();
                    DataTable dt3 = new DataTable();
                    dt3.Load(dr3);
                    if (dt3.Rows.Count > 0)
                    {
                        studioNumber = Convert.ToInt32(dt3.Rows[0]["StudioNumber"].ToString());
                    }
                    else
                    {
                        string sql4 = "insertStudio";
                        SqlCommand sc4 = new SqlCommand(sql4, gc.cn);
                        sc4.Parameters.AddWithValue("@studioName", studioName);
                        sc4.CommandType = CommandType.StoredProcedure;
                        sc4.ExecuteNonQuery();

                        string sql5 = "checkStudio";
                        SqlCommand sc5 = new SqlCommand(sql5, gc.cn);
                        sc5.Parameters.AddWithValue("@studioName", studioName);
                        sc5.CommandType = CommandType.StoredProcedure;
                        sc5.ExecuteNonQuery();
                        SqlDataReader dr5 = sc5.ExecuteReader();
                        DataTable dt5 = new DataTable();
                        dt5.Load(dr5);
                        studioNumber = Convert.ToInt32(dt5.Rows[0]["StudioNumber"].ToString()); 
                    }



                    int producerNumber;
                    string sql6 = "checkProducer";
                    SqlCommand sc6 = new SqlCommand(sql6, gc.cn);
                    sc6.Parameters.AddWithValue("@producerName", producerName);
                    sc6.CommandType = CommandType.StoredProcedure;
                    sc6.ExecuteNonQuery();
                    SqlDataReader dr6 = sc6.ExecuteReader();
                    DataTable dt6 = new DataTable();
                    dt6.Load(dr6);
                    if (dt6.Rows.Count > 0)
                    {
                        producerNumber = Convert.ToInt32(dt6.Rows[0]["producerNumber"].ToString());
                    }
                    else
                    {
                        string sql7 = "insertProducer";
                        SqlCommand sc7 = new SqlCommand(sql7, gc.cn);
                        sc7.Parameters.AddWithValue("@producerName", producerName);
                        sc7.CommandType = CommandType.StoredProcedure;
                        sc7.ExecuteNonQuery();

                        string sql8 = "checkProducer";
                        SqlCommand sc8 = new SqlCommand(sql8, gc.cn);
                        sc8.Parameters.AddWithValue("@producerName", producerName);
                        sc8.CommandType = CommandType.StoredProcedure;
                        sc8.ExecuteNonQuery();
                        SqlDataReader dr8 = sc8.ExecuteReader();
                        DataTable dt8 = new DataTable();
                        dt8.Load(dr8);
                        producerNumber = Convert.ToInt32(dt8.Rows[0]["producerNumber"].ToString());
                    }




                    int actorNumber;
                    string sql9 = "checkActor";
                    SqlCommand sc9 = new SqlCommand(sql9, gc.cn);
                    sc9.Parameters.AddWithValue("@actorFirstName", actorFirstName);
                    sc9.Parameters.AddWithValue("@actorLastName", actorLastName);
                    sc9.CommandType = CommandType.StoredProcedure;
                    sc9.ExecuteNonQuery();
                    SqlDataReader dr9 = sc9.ExecuteReader();
                    DataTable dt9 = new DataTable();
                    dt9.Load(dr9);
                    if (dt9.Rows.Count > 0)
                    {
                        actorNumber = Convert.ToInt32(dt9.Rows[0]["actorNumber"].ToString());
                    }
                    else
                    {
                        string sql10 = "insertActor";
                        SqlCommand sc10 = new SqlCommand(sql10, gc.cn);
                        sc10.Parameters.AddWithValue("@actorFirstName", actorFirstName);
                        sc10.Parameters.AddWithValue("@actorLastName", actorLastName);
                        sc10.CommandType = CommandType.StoredProcedure;
                        sc10.ExecuteNonQuery();

                        string sql11 = "checkActor";
                        SqlCommand sc11 = new SqlCommand(sql11, gc.cn);
                        sc11.Parameters.AddWithValue("@actorFirstName", actorFirstName);
                        sc11.Parameters.AddWithValue("@actorLastName", actorLastName);
                        sc11.CommandType = CommandType.StoredProcedure;
                        sc11.ExecuteNonQuery();
                        SqlDataReader dr11 = sc11.ExecuteReader();
                        DataTable dt11 = new DataTable();
                        dt11.Load(dr11);
                        actorNumber = Convert.ToInt32(dt11.Rows[0]["actorNumber"].ToString());
                    }

                    string sql12 = "insertDVDTitle";
                    SqlCommand sc12 = new SqlCommand(sql12, gc.cn);
                    sc12.Parameters.AddWithValue("@categoryNumber", categoryNumber);
                    sc12.Parameters.AddWithValue("@studioNumber", studioNumber);
                    sc12.Parameters.AddWithValue("@producerNumber", producerNumber);
                    sc12.Parameters.AddWithValue("@dvdTitle", dvdTitle);
                    sc12.Parameters.AddWithValue("@dateReleased", releaseDate);
                    sc12.Parameters.AddWithValue("@standardCharge", standardCharge);
                    sc12.Parameters.AddWithValue("@penaltyCharge", penaltyCharge);
                    sc12.Parameters.AddWithValue("@dvdImage", imagePath);
                    sc12.CommandType = CommandType.StoredProcedure;
                    sc12.ExecuteNonQuery();

                    int dvdNumber;
                    string sql13 = "checkDVDTitle";
                    SqlCommand sc13 = new SqlCommand(sql13, gc.cn);
                    sc13.Parameters.AddWithValue("@dvdTitle", dvdTitle);
                    sc13.CommandType = CommandType.StoredProcedure;
                    sc13.ExecuteNonQuery();
                    SqlDataReader dr13 = sc13.ExecuteReader();
                    DataTable dt13 = new DataTable();
                    dt13.Load(dr13);
                    dvdNumber = Convert.ToInt32(dt13.Rows[0]["dvdNumber"].ToString());


                    string sql14 = "insertCastMember";
                    SqlCommand sc14 = new SqlCommand(sql14, gc.cn);
                    sc14.Parameters.AddWithValue("@dvdNumber", dvdNumber);
                    sc14.Parameters.AddWithValue("@actorNumber", actorNumber);
                    sc14.CommandType = CommandType.StoredProcedure;
                    sc14.ExecuteNonQuery();


                    Response.Write("<script>alert('The record has been successfully added.');</script>");
                    clear();
                }
            }
            else
            {
                Response.Write("<script>alert('Enter values in all the fields.');</script>");
            }
        }
    }
}