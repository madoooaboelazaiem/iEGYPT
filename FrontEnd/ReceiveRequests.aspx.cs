using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company
{
    public partial class ReceiveRequests : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int contributor_id = Convert.ToInt32(Session["ID"]);
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand ad = new SqlCommand("contributor_newContent", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@contributor_id", contributor_id));
            SqlDataAdapter da = new SqlDataAdapter(ad);
            DataSet ds = new DataSet();
            da.Fill(ds);
            contents.DataSource = ds;
            contents.DataBind();
            cnn.Close();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

        protected void lnkSelect_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            int new_request_id;
            if ((int.TryParse((sender as LinkButton).CommandArgument, out new_request_id)) == false)
            {
                new_request_id = 0;
            }
            else
            {
                if (int.TryParse((sender as LinkButton).CommandArgument, out new_request_id)) { }
            }

            int contributer_id = Convert.ToInt32(Session["ID"]); //session;       

            if (new_request_id == 0)

            {
                cnn.Open();
                SqlCommand ad2 = new SqlCommand("Receive_New_Request", cnn);
                ad2.CommandType = System.Data.CommandType.StoredProcedure;
                ad2.Parameters.Add(new SqlParameter("@contributor_id", contributer_id));
                ad2.Parameters.Add("@can_receive", SqlDbType.Int).Direction = ParameterDirection.Output;
                ad2.ExecuteNonQuery();
                int canReceive = Convert.ToInt32(ad2.Parameters["@can_receive"].Value);
                if (canReceive == 1)
                {
                    SqlCommand ad = new SqlCommand("show_NewRequest", cnn);
                    ad.CommandType = System.Data.CommandType.StoredProcedure;
                    ad.Parameters.Add(new SqlParameter("@contributer_id", contributer_id));
                    ad.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(ad);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    cnn.Close();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Cannot Receive New Requests as 3 or more requests are still in process')</script>");

                }
            }
            else
            {
                cnn.Open();
                SqlCommand ad2 = new SqlCommand("Receive_New_Request", cnn);
                ad2.CommandType = System.Data.CommandType.StoredProcedure;
                ad2.Parameters.Add(new SqlParameter("@contributor_id", contributer_id));
                ad2.Parameters.Add("@can_receive", SqlDbType.Int).Direction = ParameterDirection.Output;
                ad2.ExecuteNonQuery();
                int canReceive = Convert.ToInt32(ad2.Parameters["@can_receive"].Value);
                if (canReceive == 1)
                {//law el can receive btaa3 el contributor id da b 1 5osh hatly el requests kolaha using el request id???
                    SqlCommand ad = new SqlCommand("Receive_New_Requests", cnn);
                    ad.CommandType = System.Data.CommandType.StoredProcedure;
                    ad.Parameters.Add(new SqlParameter("@request_id", new_request_id));
                    ad.Parameters.Add(new SqlParameter("@contributor_id", contributer_id));
                    ad.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(ad);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    cnn.Close();

                }
                else
                {
                    Response.Write("<script language=javascript>alert('Cannot Receive New Requests as 3 or more requests are still in process')</script>");

                }
            }



            cnn.Close();
        }
    }
}