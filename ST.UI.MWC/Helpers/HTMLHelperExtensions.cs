using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //htmlHelper için bunu ekledik. Öbür paketi değil. 

//bu helpers ı adminTema içindeki helper dan direk aldık sonra onu sildik. Çünkü orası web app. Ama hazır template mvc. Oyüzden hata veriryordu sildik attık. 
namespace ST.UI.MWC.Helpers
{
    public static class HTMLHelperExtensions //original helper içi normal public classtı. Static yaptık hata vermesi düzeldi.Statiği görmesi içinde web.config içine adresi ekledik. 
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
    }
}