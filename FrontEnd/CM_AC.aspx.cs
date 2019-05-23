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
    public partial class CM_AC : System.Web.UI.Page
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
            Boolean x = true;
            Boolean y = true;
            string hire_date;
            string working_hours;
            string payment_rate;
            string usertype;


            usertype = "Content Manager";
            email = Emailt.Value;


            password = passwordt.Value;
            fname = fnamet.Value;
            mname = mnamet.Value;
            lname = lnmaet.Value;
            birthdate = dobt.Value;

            hire_date = hdt.Value;
            working_hours = wht.Value;
            payment_rate = prt.Value;


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

                cmd.Parameters.Add(new SqlParameter("@specilization", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@portofolio_link", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));


                if (hire_date.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@hire_date", DBNull.Value));
                }
                else
                {
                    DateTime Test;
                    if (DateTime.TryParseExact(hire_date, "yyyy-mm-dd", null, DateTimeStyles.None, out Test) == true)
                        cmd.Parameters.Add(new SqlParameter("@hire_date", hire_date));
                    else
                        L1.Text = "Wrong HireDate Formate";
                }
                if (working_hours.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));
                }
                else
                {
                    int value;
                    if (int.TryParse(working_hours, out value))
                        cmd.Parameters.Add(new SqlParameter("@working_hours", working_hours));
                    else
                        x = false;
                }
                if (payment_rate.Length == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));
                }
                else
                {
                    double value;
                    if (Double.TryParse(payment_rate, out value))
                        cmd.Parameters.Add(new SqlParameter("@payment_rate", payment_rate));
                    else
                        y = false;
                }

                cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                int user_id = 0;
                // execute the command
                DateTime Test2;
                if ((birthdate.Length == 0 | DateTime.TryParseExact(birthdate, "yyyy-mm-dd", null, DateTimeStyles.None, out Test2) == true) & (hire_date.Length == 0 | DateTime.TryParseExact(hire_date, "yyyy-mm-dd", null, DateTimeStyles.None, out Test2) == true) & y & x)
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
                    }

                    //command.dispose();
                    cnn.Close();
                    Session["ID"] = user_id;
                    Response.Redirect("CM_profile.aspx?user_id=" + user_id);
                }
                else
                {
                    if (!y & x)
                        L1.Text = "Enter Number in Payment Rate";
                    if (!y & !x)
                        L1.Text = "Enter Number in Payment Rate and Working Hours";
                    if (y & !x)
                        L1.Text = "Enter Number in Working Hours";
                }
            }
        }
    }
}