using System.Web.Mvc;

namespace Cenema.Helpers
{
    public static class FooterHelper
    {
        public static MvcHtmlString Footer(this HtmlHelper htmlHelper,
            params string[] items)
        {
            /*<footer><p>context</p></footer>*/
            var footer = new TagBuilder("footer");
            foreach (var item in items)
            {
                var p = new TagBuilder("p");
                p.SetInnerText(item);
                footer.InnerHtml += p.ToString();
            }
            return new MvcHtmlString(footer.ToString());
        }
    }
}