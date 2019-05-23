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
    public partial class original_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public void button2Clicked(object sender, EventArgs args)
        {
            string type;
            string category;

            type = Text0.Value;
            category = Text1.Value;


            string connetionString;
            SqlConnection cnn;

            //        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;



            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Original_Content_Search", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            if (type.Length == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@typename", DBNull.Value));
            }
            else {
                cmd.Parameters.Add(new SqlParameter("@typename", type));
            }
            if (category.Length == 0)
            {
                cmd.Parameters.Add(new SqlParameter("@categoryname", DBNull.Value));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@categoryname", category));

            }

            SqlDataReader dataReader;
            dataReader= cmd.ExecuteReader();
            String output = " ";
            while (dataReader.Read()) {
                output = output + "<br>" + "<br>" + "<button " + "class" + "=lbb" + ">" + "Link:" + dataReader.GetValue(4) + "<br>" + "Type: " + dataReader.GetValue(3) + "<br>" + " Category Type:" + dataReader.GetValue(1) + "<br>" + "Subcategory Name: " + dataReader.GetValue(2) + "<br>" + "Rataing: " + dataReader.GetValue(0) + "<br>" + "<b>Contributer</b>" + "<br>"+" Name: " + dataReader.GetValue(6) +" "+ dataReader.GetValue(7) + "<br>" + "email: " + dataReader.GetValue(8) +"<br>" +"<b>ContentManger :</b>" + "<br>" + " Name: " + dataReader.GetValue(9) + " " + dataReader.GetValue(10) + "<br>" + "email: " + dataReader.GetValue(11)+"<br>" + "<b>Reviwer</b>" + "<br>" + " Name: " + dataReader.GetValue(12) + " " + dataReader.GetValue(13) + "<br>" + "email: " + dataReader.GetValue(14) +"<br>"+ "Uploaded At: " + dataReader.GetValue(5) + "</button>";

                            }
            Label1.Text = output;
            dataReader.Close();
            //command.dispose();
            cnn.Close();





        }
    }
}