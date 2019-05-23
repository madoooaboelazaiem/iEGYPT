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
    public partial class Show_the_approved_original_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void button2Clicked(object sender, EventArgs args)
        {
            string fullname;

            fullname = tfullname1.Value;


            string connetionString;
            SqlConnection cnn;

            //        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;



            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Show_Original_Content_by_name", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            if (fullname.Length == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@fullname", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@fullname", fullname));
            }

            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            String output = " ";
            while (dataReader.Read())
            {
                output = output + "<br>" + "<br>" + "<button " + "class" + "=lbb" + ">" +"Name:"+ dataReader.GetValue(2)+" "+ dataReader.GetValue(3)+" "+ dataReader.GetValue(4)+"<br>" + "Email: " + dataReader.GetValue(1) + "<br>" + " Birth Date:" + dataReader.GetValue(5) + "<br>" + "age: " + dataReader.GetValue(6) + "<br>" + "last_login: " + dataReader.GetValue(8) + "<br>" + " Years of Experience: " + dataReader.GetValue(12) + "<br>" + "Portfolio Link: " + dataReader.GetValue(13) + "<br>" + "Specialization: " + dataReader.GetValue(14)+ "<br>" + "ContentLink:" + dataReader.GetValue(23) + "<br>" + "Uploaded At:"+ dataReader.GetValue(24) +"<br>"+"Category Type:"+ dataReader.GetValue(26) + "<br>" + "Subcategory Name:" + dataReader.GetValue(27)
              + "<br>" + "Rating: " + dataReader.GetValue(21) + "<br>" + "Type: " + dataReader.GetValue(28) + "<br>" + "Content Manger Name:" + dataReader.GetValue(29) + " " + dataReader.GetValue(30) + "<br>" + "Content MangerEmail: " + dataReader.GetValue(31) + "<br>" + " Reviewer Name:" + dataReader.GetValue(32) +  " " + dataReader.GetValue(33) + "<br>" + "Email: " + dataReader.GetValue(34) + "</button>";
                //output = output + "<br>" + "-----------------------" + "<br>" + "ID:  " + dataReader.GetValue(0) + "<br>" + "  email: " + dataReader.GetValue(1) + "<br>" + " birth_date:" + dataReader.GetValue(2) + "<br>" + "age: " + dataReader.GetValue(3) + "<br>" + "last_login: " + dataReader.GetValue(4) + "<br>" + "status: " + dataReader.GetValue(5) + "<br>" + "  deleted: " + dataReader.GetValue(6) + "<br>" + " years_of_experience: " + dataReader.GetValue(7) + "<br>" + "portfolio_link: " + dataReader.GetValue(8) + "<br>" + "specialization: " + dataReader.GetValue(9) + "<br>" + "notified_id: " + dataReader.GetValue(10);
            }
            Label1.Text = output;
            dataReader.Close();
            //command.dispose();
            cnn.Close();





        }
    }
}