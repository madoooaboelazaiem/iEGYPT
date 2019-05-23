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
    public partial class SendMSG : System.Web.UI.Page
    {
        int viewer_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand ad = new SqlCommand("SELECT * FROM dbo.[User] u, dbo.Viewer v WHERE u.ID = v.ID", cnn);
            SqlDataAdapter da = new SqlDataAdapter(ad);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MSG.DataSource = ds;
            MSG.DataBind();
            receive();
            cnn.Close();
        }
        public void Select(object sender, EventArgs e)
        {

            viewer_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["x"] = viewer_id;

        }
        protected void receive()
        {
            string connetionString;
            SqlConnection cnn;
            int contributor_id = Convert.ToInt32(Session["ID"]);
            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            SqlCommand ad = new SqlCommand("Show_Message", cnn);
            ad.CommandType = System.Data.CommandType.StoredProcedure;
            ad.Parameters.Add(new SqlParameter("@contributor_id", contributor_id));
            SqlDataAdapter da = new SqlDataAdapter(ad);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void upload(object sender, EventArgs e)
        {

            try
            {
                int x = Convert.ToInt32(Session["x"]);
                string msg;
                int contributor_id = Convert.ToInt32(Session["ID"]);
                int sender_type = 1;
                DateTime sent_at = DateTime.Now;

                msg = msgcontent.Text;


                string connetionString;
                SqlConnection cnn;

                connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Send_Message", cnn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@msg_text", msg));
                cmd.Parameters.Add(new SqlParameter("@viewer_id", x));
                cmd.Parameters.Add(new SqlParameter("@contributor_id", contributor_id));
                cmd.Parameters.Add(new SqlParameter("@sender_type", sender_type));
                cmd.Parameters.Add(new SqlParameter("@sent_at", sent_at));
                // execute the command
                SqlDataReader rdr = cmd.ExecuteReader();
                //command.dispose();
                cnn.Close();
                Response.Write("<script language=javascript>alert(' Message Sent')</script>");



            }
            catch
            {
                Response.Write("<script language=javascript>alert('invalid data ')</script>");
            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }
    }
}