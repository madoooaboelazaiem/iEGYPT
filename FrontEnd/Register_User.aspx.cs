using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Company
{
    public partial class Register_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public void registerUser(object sender, EventArgs args)
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
            string specilization;
            string portofolio_link;
            string years_experience;
            string hire_date;
            string working_hours;
            string payment_rate;
            string usertype;


            usertype = usertypeTB.Value;
            email = emailTB.Text;
            password = passwordTB.Text;
            fname = fnameTB.Text;
            mname = mnameTB.Text;
            lname = lnameTB.Text;
            birthdate = birthdateTB.Text;
            workname = worknameTB.Text;
            worktype = worktypeTB.Text;
            workdisc = workdiscTB.Text;
            specilization = specilizationTB.Text;
            portofolio_link = portofolio_linkTB.Text;
            years_experience = years_experienceTB.Text;
            hire_date = hire_dateTB.Text;
            working_hours = working_hoursTB.Text;
            payment_rate = payment_rateTB.Text;
            
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-O0M32DE\SQLEXPRESS;Initial Catalog=PRO ;Integrated Security=True";
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
                cmd.Parameters.Add(new SqlParameter("@middlename", mname));
                cmd.Parameters.Add(new SqlParameter("@lastname", lname));
                cmd.Parameters.Add(new SqlParameter("@birth_date", birthdate));
                cmd.Parameters.Add(new SqlParameter("@working_place_name", workname));
                cmd.Parameters.Add(new SqlParameter("@working_place_type", worktype));
                cmd.Parameters.Add(new SqlParameter("@wokring_place_description", workdisc));
                cmd.Parameters.Add(new SqlParameter("@specilization", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@portofolio_link", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@years_experience", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@hire_date", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));    


                cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                int user_id = 0;
                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
                        }

                        //command.dispose();
                        cnn.Close();

                        Response.Redirect("Default.aspx?e_id=" + user_id);
                    }



                }
            }
  
        }

   
