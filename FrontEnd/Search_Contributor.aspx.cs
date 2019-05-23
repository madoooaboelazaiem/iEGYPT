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
    public partial class Search_Contributor : System.Web.UI.Page
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

            SqlCommand cmd = new SqlCommand("Contributor_Search", cnn);

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
            //ListBox1.Items.Clear();
            while (dataReader.Read())
            {   // output =
                            output= output+"<br>"+"<button "+"class"+ "=lbb" + ">" + "email: " + dataReader.GetValue(1) +"<br>" +" birth_date:" + dataReader.GetValue(2) + "<br>" + "age: " + dataReader.GetValue(3) + "<br>" + "last_login: " + dataReader.GetValue(4) + "<br>" + "status: " + dataReader.GetValue(5)+"  deleted: " + dataReader.GetValue(6) + " years_of_experience: " + dataReader.GetValue(7) + "<br>" + "portfolio_link: " + dataReader.GetValue(8) + "<br>" + "specialization: " + dataReader.GetValue(9) + "</button>";

               // ListBox1.Items.Add(item);
            }
            Label1.Text = output;
            dataReader.Close();
            //command.dispose();
            cnn.Close();

           



        }
    }
}