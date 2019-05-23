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
    public partial class editcm : System.Web.UI.Page
    {
        string oldpassword;
        Boolean falage = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (falage)
            {
                GetData();
                falage = false;
            }
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
                    oldpassword = Convert.ToString(cmd.Parameters["@password"].Value);
               }

            }
            else
            {
            }




            
            
            cnn.Close();


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
            string specilization;
            string portofolio_link;
            string years_experience;
            string hire_date;
            string working_hours;
            string payment_rate;
            string newpassword;
            Boolean y = true;
            Boolean x = true;
            email = Emailt.Value;
            password = passwordt.Value;
            newpassword = passwordt1.Value;
            fname = fnamet.Value;
            mname = mnamet.Value;
            lname = lnmaet.Value;
            birthdate = TextBox1.Text;
            workname = "";
            worktype = "";
            workdisc = "";
            specilization = "";
            portofolio_link = "";
            years_experience = "";
            hire_date = hdt.Value;
            working_hours = wht.Value;
            payment_rate = prt.Value;



            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
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
            if (!password.Equals(oldpassword))
            {
                L1.Text = "Wrong Password";
            }
            else
            {
                if (newpassword.Length != 0)
                    cmd.Parameters.Add(new SqlParameter("@password", newpassword));
                else
                    cmd.Parameters.Add(new SqlParameter("@password", oldpassword));
            
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



                if (password.Length == 0)
                {
                    L1.Text = "Enter The Password";
                }
                else
                {
                    DateTime Test;
                    if ((birthdate.Length == 0 | DateTime.TryParseExact(birthdate, "yyyy-mm-dd", null, DateTimeStyles.None, out Test) == true) & (hire_date.Length == 0 | DateTime.TryParseExact(hire_date, "yyyy-mm-dd", null, DateTimeStyles.None, out Test) == true) & y & x)
                    {
                        cmd.ExecuteReader();
                        Response.Redirect("CM_profile.aspx");
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
                //command.dispose();
                cnn.Close();
            





        }
        public void deactivate(object sender, EventArgs args)
        {


            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Deactivate_Proﬁle", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@user_id", Convert.ToInt32(Session["ID"])));


            cmd.ExecuteReader();
            Response.Redirect("LoginForm.aspx");
            Session["ID"] = 0;
            //command.dispose();
            cnn.Close();





        }
    }
}