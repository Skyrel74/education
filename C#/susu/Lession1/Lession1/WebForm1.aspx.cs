using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lession1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public bool checkValues(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                a + b <= c || a + c <= b || c + b <= a)
                return false;
            return true;
        }

        protected void calcButton_Click(object sender, EventArgs e)
        {
            double a, b, c, p, s;

            if (double.TryParse(legA.Text, out a) && double.TryParse(legB.Text, out b)&& double.TryParse(legC.Text, out c) && checkValues(a, b, c))
            {
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Decision.Text = s.ToString();
            }
            else
                Decision.Text = "Некорректные данные!";
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}