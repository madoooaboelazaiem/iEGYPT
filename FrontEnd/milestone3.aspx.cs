using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Company
{
    public partial class milestone3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Staff_Create_Type", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@type_name", TextBox1.Text));
            //cmd.Parameters.Add("@e_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;


            cmd.ExecuteNonQuery();

            //command.dispose();
            cnn.Close();



        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }





        


        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string queryString = "select CAST( uploaded_at as nvarchar(50)) + ' ' + ' /' + ' ' + type as uploaded_attype,c.id from Content c inner join Original_Content o on c.id=o.ID";
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "uploaded_attype";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
            }
            connection.Close();
        }

        
       






    


        protected void Button3_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("reviewer_filter_content", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@reviewer_id", Convert.ToInt32(Session["ID"])));

            cmd.Parameters.Add(new SqlParameter("@original_content", DropDownList1.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@status",DropDownList9.SelectedValue));
            //cmd.Parameters.Add("@e_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;


            cmd.ExecuteNonQuery();

            //command.dispose();
            cnn.Close();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Staff_Create_Category", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@category_name", TextBox3.Text));
            cmd.ExecuteNonQuery();
            //command.dispose();
            cnn.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Staff_Create_Subcategory", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@category_name", DropDownList2.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@subcategory_name", TextBox4.Text));

            cmd.ExecuteNonQuery();
            //command.dispose();
            cnn.Close();

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
           
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            string queryString = "SELECT * from Category";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField ="type";
                DropDownList2.DataValueField ="type";
                DropDownList2.DataBind();
            }
            connection.Close();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Most_Requested_Content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable mytable = new DataTable();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(mytable);
            GridView1.DataSource = mytable;
            GridView1.DataBind();



        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Workingplace_Category_Relation", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable mytable1 = new DataTable();
            SqlDataAdapter myadapter1 = new SqlDataAdapter(cmd);
            myadapter1.Fill(mytable1);
            GridView2.DataSource = mytable1;
            GridView2.DataBind();
        }

        

        

       

        protected void Button12_Click(object sender, EventArgs e)
        {
            string queryString = "select CAST( uploaded_at as nvarchar(50)) + ' ' + ' ' + type as uploaded_attype,c.id from Content c inner join Original_Content o on c.id=o.ID";
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList5.DataSource = dt;
                DropDownList5.DataTextField = "uploaded_attype";
                DropDownList5.DataValueField = "id";
                DropDownList5.DataBind();
            }
            connection.Close();
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete_Original_Content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@content_id", DropDownList5.SelectedValue));

            cmd.ExecuteNonQuery();
            //command.dispose();
            cnn.Close();
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            string queryString = "select CAST( uploaded_at as nvarchar(50)) + ' ' + ' ' + type as uploaded_attype,c.id from Content c inner join New_Content n on c.id=n.ID";
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList6.DataSource = dt;
                DropDownList6.DataTextField = "uploaded_attype";
                DropDownList6.DataValueField = "id";
                DropDownList6.DataBind();
            }
            connection.Close();

        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            string queryString = "select portfolio_link + ' ' + ' ' + '/ ' + specialization as new,ID from Contributor";
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList7.DataSource = dt;
                DropDownList7.DataTextField = "new";
                DropDownList7.DataValueField = "ID";
                DropDownList7.DataBind();
            }
            connection.Close();
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            string queryString = "select * from New_Request";
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList8.DataSource = dt;
                DropDownList8.DataTextField = "information";
                DropDownList8.DataValueField = "id";
                DropDownList8.DataBind();
            }
            connection.Close();
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Assign_Contributor_Request", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@contributor_id", DropDownList7.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@new_request_id", DropDownList8.SelectedValue));

            cmd.ExecuteNonQuery();
            //command.dispose();
            cnn.Close();
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete_New_Content", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@content_id", DropDownList6.SelectedValue));
       

            cmd.ExecuteNonQuery();
            //command.dispose();
            cnn.Close();
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            string queryString = "select CAST( uploaded_at as nvarchar(50)) + ' ' + ' /' + ' ' +type as uploaded_attype,c.id from Content c inner join Original_Content o on c.id=o.ID where o.review_status=1";
            SqlConnection connection = new SqlConnection( WebConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(command);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList10.DataSource = dt;
                DropDownList10.DataTextField = "uploaded_attype";
                DropDownList10.DataValueField = "id";
                DropDownList10.DataBind();
            }
            connection.Close();
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Content_manager_filter_content", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@content_manager_id", Convert.ToInt32(Session["ID"])));

            cmd.Parameters.Add(new SqlParameter("@original_content", DropDownList10.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@status", DropDownList11.SelectedValue));
            //cmd.Parameters.Add("@e_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;


            cmd.ExecuteNonQuery();

            //command.dispose();
            cnn.Close();
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Show_Possible_Contributors", cnn);
            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable mytable1 = new DataTable();
            SqlDataAdapter myadapter1 = new SqlDataAdapter(cmd);
            myadapter1.Fill(mytable1);
            GridView3.DataSource = mytable1;
            GridView3.DataBind();
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}