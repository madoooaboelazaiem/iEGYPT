using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Globalization;

namespace Company
{
    public partial class Viewer_CA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string email;
            string password;
            string fname;
            string mname;
            string lname;
            string birthdate;
            string workname;
            string worktype;
            string workdisc;

            string usertype;


            usertype = "Viewer";
            email = Emailt.Value;
            password = passwordt.Value;
            fname = fnamet.Value;
            mname = mnamet.Value;
            lname = lnmaet.Value;
            birthdate = dobt.Value;
            workname = Wt.Value;
            worktype = Wtypet.Value;
            workdisc = Wdest.Value;


            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
            if (usertype != "0")
            {
                SqlCommand cmd = new SqlCommand("Register_User", cnn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@usertype", usertype));

                cmd.Parameters.Add(new SqlParameter("@email", email));


                cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@firstname", fname));
                

                if (mname.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@middlename", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@middlename", mname));
                }


                cmd.Parameters.Add(new SqlParameter("@lastname", lname));


                if (birthdate.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@birth_date", DBNull.Value));
                }
                else
                {
                    DateTime Test;
                    if (DateTime.TryParseExact(birthdate, "yyyy-mm-dd", null, DateTimeStyles.None, out Test) == true)
                        cmd.Parameters.Add(new SqlParameter("@birth_date", birthdate));

                    else
                        L1.Text = "Wrong BirthDate Formate";
                }

                if (workname.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@working_place_name", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@working_place_name", workname));
                }
                if (worktype.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@working_place_type", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@working_place_type", worktype));
                }
                if (workdisc.Length == 0)
                {


                    cmd.Parameters.Add(new SqlParameter("@wokring_place_description", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@wokring_place_description", workdisc));
                }
                cmd.Parameters.Add(new SqlParameter("@specilization", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@portofolio_link", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@hire_date", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));


                cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                int user_id = 0;
                // execute the command
                DateTime Test1;
                if ((birthdate.Length == 0 | DateTime.TryParseExact(birthdate, "yyyy-mm-dd", null, DateTimeStyles.None, out Test1) == true))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
                    }

                    //command.dispose();
                    cnn.Close();
                    Session["ID"] = user_id;
                    Response.Redirect("Viewer_profile.aspx?user_id=" + user_id);
                }
                
            }
        }
    }
}