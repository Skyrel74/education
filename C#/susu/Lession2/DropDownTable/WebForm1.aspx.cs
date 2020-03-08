using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DropDownTable
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Укажите размеры таблицы";
            if (Page.IsPostBack) return;
            for (int i = 1; i <= 5; ++i)
            {
                DropDownList1.Items.Add(i.ToString());
                DropDownList2.Items.Add(i.ToString());
            }
            Table1.Caption = "Пример";
            Table1.CaptionAlign = TableCaptionAlign.Top;
            Table1.ToolTip = "Укажите количество строк и столбцов";
            Table1.BorderStyle = BorderStyle.Solid;
            Table1.GridLines = GridLines.Both;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int Row = int.Parse(DropDownList1.SelectedItem.Value);
            int Col = int.Parse(DropDownList2.SelectedItem.Value);
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