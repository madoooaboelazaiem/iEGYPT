using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Company
{
    public partial class UploadOriginal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void upload(object sender, EventArgs args)
        {
            try
            {
                string t;
                string c;
                string sn;
                string li;
                int a = Convert.ToInt32(Session["ID"]); //session

                t = type_id.Text;
                c = category_id.Text;
                sn = subcategory_name.Text;
                li = link.Text;


                string connetionString;
                SqlConnection cnn;

                connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Upload_Original_Content", cnn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@type_id", t));
                cmd.Parameters.Add(new SqlParameter("@subcategory_name", sn));
                cmd.Parameters.Add(new SqlParameter("@category_id", c));
                cmd.Parameters.Add(new SqlParameter("@contributor_id", a));
                cmd.Parameters.Add(new SqlParameter("@link", li));
                // execute the command
                SqlDataReader rdr = cmd.ExecuteReader();
                //command.dispose();
                cnn.Close();
                Response.Write("<script language=javascript>alert(' original content uploaded')</script>");



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