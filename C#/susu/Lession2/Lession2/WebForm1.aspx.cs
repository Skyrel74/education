using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lession2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator1.ControlToValidate = "TextBox1";
            RequiredFieldValidator1.EnableClientScript = false;
            RequiredFieldValidator1.ErrorMessage = "Необходимо заполнить количество строк";
            RequiredFieldValidator2.ControlToValidate = "TextBox2";
            RequiredFieldValidator2.EnableClientScript = false;
            RequiredFieldValidator2.ErrorMessage = "Необходимо заполнить количество столбцов";
            CompareValidator1.ControlToValidate = "TextBox1";
            CompareValidator1.EnableClientScript = false;
            CompareValidator1.Type = ValidationDataType.Integer;
            CompareValidator1.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator1.ErrorMessage = "Следует вводить числа";

            CompareValidator1.ControlToValidate = "TextBox2";
            CompareValidator1.EnableClientScript = false;
            CompareValidator1.Type = ValidationDataType.Integer;
            CompareValidator1.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator1.ErrorMessage = "Следует вводить числа";
            Table1.Caption = "Таблица";
            Table1.CaptionAlign = TableCaptionAlign.Right;
            Table1.BorderStyle = BorderStyle.Solid;
            Table1.GridLines = GridLines.Both;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UInt16 Row = Convert.ToUInt16(TextBox1.Text);
                UInt16 Col = Convert.ToUInt16(TextBox2.Text);
                for (int i = 1; i <= Row; ++i)
                {
                    var row = new TableRow();
                    for (uint j = 1; j <= Col; ++j)
                    {
                        var cell = new TableCell();
                        cell.Text = String.Format("tt{0}, {1}", i, j);
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        row.Cells.Add(cell);
                    }
                    Table1.Rows.Add(row);
                }
            }
        }
    }
}