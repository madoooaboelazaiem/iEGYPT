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
    public partial class Contributer_AC : System.Web.UI.Page
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
            Boolean y = true;
            string specilization;
            string portofolio_link;
            string years_experience;

            string usertype;


            usertype = "Contributor";
            email = Emailt.Value;
            password = passwordt.Value;
            fname = fnamet.Value;
            mname = mnamet.Value;
            lname = lnmaet.Value;
            birthdate = dobt.Value;
            
            specilization = spet.Value;
            portofolio_link = plt.Value;
            years_experience = yoet.Value;



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

                cmd.Parameters.Add(new SqlParameter("@working_place_name", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@working_place_type", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@wokring_place_description", DBNull.Value));




                if (specilization.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@specilization", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@specilization", specilization));
                }
                if (portofolio_link.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@portofolio_link", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@portofolio_link", portofolio_link));
                }
                if (years_experience.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));
                }
                else
                {
                    int value;
                    if (int.TryParse(years_experience, out value))
                        cmd.Parameters.Add(new SqlParameter("@years_experience", years_experience));
                    else
                        y = false;
                }

                cmd.Parameters.Add(new SqlParameter("@hire_date", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));


                cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                int user_id = 0;
                // execute the command
                DateTime Test1;
                if ((birthdate.Length == 0 | DateTime.TryParseExact(birthdate, "yyyy-mm-dd", null, DateTimeStyles.None, out Test1) == true)&y)
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
                    }

                    //command.dispose();
                    cnn.Close();
                    Session["ID"] = user_id;
                    Response.Redirect("Contributor_profile.aspx?user_id=" + user_id);
                }
                else {
                    if(!y)
                        L1.Text = "Enter Number in Years of Experiance";
                }
            }
        }
    }
}