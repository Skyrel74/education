using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lession_3._1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = TextBox1.Text;
            string password = TextBox2.Text;
            if(login.Length != 0 && password.Length != 0)
            {
                
            }
        }
    }
}