using System.Web.Mvc;

namespace Web.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }
    }
}