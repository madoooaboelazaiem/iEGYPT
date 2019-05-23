using System;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;

namespace Company
{

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");

        }


    }
}
