using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Company
{
    public partial class Viewer_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            String s = Request.QueryString["user_id"];

            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            cnn = new SqlConnection(connetionString);

            cnn.Open();


            if (Session["ID"] != null)
            {
                SqlCommand cmd = new SqlCommand("Show_Profile", cnn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@user_id", Convert.ToInt32(Session["ID"])));



                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 30).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@ﬁrstname", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@middlename", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@birth_date", System.Data.SqlDbType.Date).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_place_name", System.Data.SqlDbType.VarChar, 30).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_place_type", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@wokring_place_description", System.Data.SqlDbType.VarChar, 50).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@specilization", System.Data.SqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@portofolio_link", System.Data.SqlDbType.VarChar, 30).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@years_experience", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@hire_date", System.Data.SqlDbType.Date).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_hours", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@payment_rate", System.Data.SqlDbType.Decimal).Direction = System.Data.ParameterDirection.Output;

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (Convert.ToString(cmd.Parameters["@ﬁrstname"].Value).Length != 0)
                        L1.Text= "<p " + "class" + "=info" + ">" +  Convert.ToString(cmd.Parameters["@ﬁrstname"].Value) + " " + Convert.ToString(cmd.Parameters["@middlename"].Value) + " " + Convert.ToString(cmd.Parameters["@lastname"].Value)+"</p>";
                    if (Convert.ToString(cmd.Parameters["@birth_date"].Value).Length != 0)
                        L2.Text = "<p " + "class" + "=info" + ">" +"<b>BirthDate</b>" + "<br>" + Convert.ToString(cmd.Parameters["@birth_date"].Value)+"</p>";
                    if (Convert.ToString(cmd.Parameters["@working_place_name"].Value).Length != 0)
                        L3.Text = "<p " + "class" + "=info" + ">" + "<h> Working Place Name</h> " + " <br> " + Convert.ToString(cmd.Parameters["@working_place_name"].Value) + "</p>";
                    if (Convert.ToString(cmd.Parameters["@working_place_type"].Value).Length != 0)
                        L4.Text = "<p " + "class" + "=info" + ">" + "<b>Type</b>" + " <br> " + Convert.ToString(cmd.Parameters["@working_place_type"].Value) + "</p>";
                    if (Convert.ToString(cmd.Parameters["@wokring_place_description"].Value).Length != 0)
                        L5.Text = "<p " + "class" + "=info" + ">" + "<b>Description</b>" +"<br>" + Convert.ToString(cmd.Parameters["@wokring_place_description"].Value) + "</p>";
                }

            }
            else
            {
            }




            //Response.Write(Session["ID"]);

            //command.dispose();
            cnn.Close();


        }
    }
}