using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Company
{
    public partial class DeleteContent : System.Web.UI.Page
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
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand ad = new SqlCommand("select * from content", cnn);
            SqlDataAdapter da = new SqlDataAdapter(ad);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cnn.Close();
            contents.DataSource = ds;
            contents.DataBind();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }


        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            int content_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand ad = new SqlCommand("Delete_Content", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@content_id", content_id));
            SqlDataReader rdr = ad.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(ad);
            bindgrid();



            cnn.Close();
        }

    }
}