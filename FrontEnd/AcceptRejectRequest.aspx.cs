﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace Company
{
    public partial class AcceptRejectRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }



        }
        protected void bindgrid()
        {
            int contributer_id = Convert.ToInt32(Session["ID"]);
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand ad = new SqlCommand("show_NewRequest", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@contributer_id", contributer_id));
            ad.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(ad);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();

            Requests.DataSource = ds;
            Requests.DataBind();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            int Request_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int contributer_id = Convert.ToInt32(Session["ID"]); ;
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand ad = new SqlCommand("Respond_New_Request", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@contributor_id", contributer_id));
            ad.Parameters.Add(new SqlParameter("@accept_status", 1));
            ad.Parameters.Add(new SqlParameter("@request_id", Request_id));
            SqlDataReader rdr = ad.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(ad);
            bindgrid();
          


            cnn.Close();
        }
        protected void Reject_Click(object sender, EventArgs e)
        {
            int Request_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int contributer_id = Convert.ToInt32(Session["ID"]); ;
            int accept_status = 0;
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand ad = new SqlCommand("Respond_New_Request", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@contributor_id", contributer_id));
            ad.Parameters.Add(new SqlParameter("@accept_status", accept_status));
            ad.Parameters.Add(new SqlParameter("@request_id", Request_id));
            SqlDataReader rdr = ad.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(ad);
            bindgrid();



            cnn.Close();
        }
    }
}