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
    public partial class LoginForm : System.Web.UI.Page
    {

        public void button2Clicked(object sender, EventArgs args)
        {
            string email;
            string password;

            email = email_login.Value;
            password = Password1.Value;


            string connetionString;
            SqlConnection cnn;

            //connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;



            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("User_login", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            int @user_id = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                @user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
            }

            //command.dispose();

           // L1.Text =""+@user_id;
            if (@user_id == -1)
            {
                L1.Text = "Wrong email Or Password";
            }
            else
            {
                if (@user_id == 0)
                {
                    L1.Text = "Your Account is deactivated to activte it Sign In ";
                }
                else
                {
                    cmd = new SqlCommand("usert", cnn);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@userid", @user_id));
                    

                    cmd.Parameters.Add("@type", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                    int utype = -1;
                    // execute the command
                    
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {    if(cmd.Parameters["@type"].Value!=DBNull.Value)
                        utype = Convert.ToInt32(cmd.Parameters["@type"].Value);
                    }
                    Session["ID"] = @user_id;
                    if(utype==0)
                    Response.Redirect("Viewer_profile.aspx");
                    if (utype == 1)
                        Response.Redirect("Contributor_profile.aspx");
                    if (utype == 2)
                        Response.Redirect("CM_profile.aspx");
                }
            }
            cnn.Close();

        }
    }
}