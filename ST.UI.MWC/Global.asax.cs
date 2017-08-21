using Microsoft.AspNet.Identity;
using ST.BLL.Account;
using ST.Models.IdentityModels;
using ST.UI.MWC.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ST.UI.MWC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //bundleconfig ekledik ve içinde adres değişikliği yaptık. Şimdi onu bir yazalım burada. Aynı üsttekilerin yazıldığı gibi yazalım. 
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var roleManager = MembershipTools.NewRoleManager(); //ilk uygulamanın çalışmasında applicationstart başlıyor. Mail method gibi. 
            if (!roleManager.RoleExists("Admin")) //bu yazacaklarımızı rolleri oluşturması için kullanacağız. 
            {
                roleManager.Create(new ApplicationRole()
                    { //object initializer i açtık
                    Name = "Admin",
                    Description = "Site Yöneticisi"

                    });
            }
            if (!roleManager.RoleExists("Musteri"))
            {
                roleManager.Create(new ApplicationRole()
                { //object initializer i açtık
                    Name = "Musteri",
                    Description = "Uygulama Musterisi"

                });
            }
            if (!roleManager.RoleExists("Firma"))
            {
                roleManager.Create(new ApplicationRole()
                { //object initializer i açtık
                    Name = "Firma",
                    Description = "Firma Sahibi Üye"

                });
            }
        }
    }
}
