using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Company
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Editing(object sender, EventArgs args)
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

                SqlCommand cmd = new SqlCommand("Edit_Profile", cnn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@user_id", Convert.ToInt32(Session["ID"])));
            if (email.Length == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@email", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@email", email));
            }
            if (password.Length == 0)
            {
                    L1.Text = "Enter The Password";
             }
             else
                {
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                }
                        if (fname.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@ﬁrstname", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@ﬁrstname", fname));
                        }
                        if (mname.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@middlename", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@middlename", mname));
                        }
                        if (lname.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@lastname", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@lastname", lname));
                        }
                        if (birthdate.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@birth_date", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@birth_date", birthdate));
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
                            cmd.Parameters.Add(new SqlParameter("@years_experience", years_experience));
                        }
                        if (hire_date.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@hire_date", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@hire_date", hire_date));
                        }
                        if (working_hours.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@working_hours", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@working_hours", working_hours));
                        }
                        if (payment_rate.Length == 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@payment_rate", DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@payment_rate", payment_rate));
                        }



            if (password.Length == 0)
            {
                L1.Text = "Enter The Password";
            }
            else
            {

                cmd.ExecuteReader();
                Response.Redirect("Default.aspx");
                //command.dispose();
                cnn.Close();
            }
            // execute the command


                       // Response.Redirect("Default.aspx ");
                    



                }
        public void deactivate(object sender, EventArgs args)
        {


            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-O0M32DE\SQLEXPRESS;Initial Catalog=PRO ;Integrated Security=True";
            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Deactivate_Proﬁle", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@user_id", Convert.ToInt32(Session["ID"])));


            cmd.ExecuteReader();
            Response.Redirect("LoginForm.aspx");
            Session["ID"]= 0;
            //command.dispose();
            cnn.Close();





        }

    }
        
    
}