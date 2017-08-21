using System.Web.Mvc;

namespace ST.UI.MWC.Areas.Yonetim
{
    public class YonetimAreaRegistration : AreaRegistration  //bu area yı MVC nin içine add ettik. Bir arearegistration class ı oluştu pollymorphism ile. Bunda yönetimsel logic işlemlerin olduğu alanlar olacak. Kendi view ve controller ları var. Burada yapmamız gereken işlemler için ekstrada controller view models alanı oluşturmayacağız. 
    {
        public override string AreaName 
        {
            get 
            {
                return "Yonetim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Yonetim_default",
                "Yonetim/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}