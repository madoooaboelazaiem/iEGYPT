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
    public partial class Show_the_contributors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getdate();
        }
        public void getdate()
        {


        }
        protected void button2Clicked(object sender, EventArgs args) {



            string connetionString;
            SqlConnection cnn;

            //        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;



            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Order_Contributor", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure

            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            String output = " ";
            while (dataReader.Read())
            {
               
                if (dataReader.GetValue(15) == DBNull.Value)
                {
                    output = output + "<br>" + "<br>" + "<button " + "class" + "=lbb" + ">" + "Name:" + dataReader.GetValue(7) + " " + dataReader.GetValue(8) + " " + dataReader.GetValue(9) + "<br>" + "Email: " + dataReader.GetValue(6) + "<br>" + " birth_date:" + dataReader.GetValue(10) + "<br>" + "age: " + dataReader.GetValue(11) + "<br>" + "Years Of Experience: " + dataReader.GetValue(1) + "<br>" + "portfolio_link: " + dataReader.GetValue(2) + "<br>" + "specialization: " + dataReader.GetValue(3) + "</button>";
                }
                else {
                    if (!Convert.ToBoolean(dataReader.GetValue(15)))
                    {
                        output = output + "<br>" + "<br>" + "<button " + "class" + "=lbb" + ">" + "Name:" + dataReader.GetValue(7) + " " + dataReader.GetValue(8) + " " + dataReader.GetValue(9) + "<br>" + "Email: " + dataReader.GetValue(6) + "<br>" + " birth_date:" + dataReader.GetValue(10) + "<br>" + "age: " + dataReader.GetValue(11) + "<br>" + "Years Of Experience: " + dataReader.GetValue(1) + "<br>" + "portfolio_link: " + dataReader.GetValue(2) + "<br>" + "specialization: " + dataReader.GetValue(3) + "</button>";

                    }
                }
            }
            Label1.Text = output;
            dataReader.Close();
            //command.dispose();
            cnn.Close();




        }
    }
}