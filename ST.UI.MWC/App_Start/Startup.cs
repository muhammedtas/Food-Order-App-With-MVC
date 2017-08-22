using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ST.UI.MWC.App_Start.Startup))]

namespace ST.UI.MWC.App_Start
{
    public class Startup
    {
        //projeye çalıştırdığınız zaman owin hata penceresi gelecek. Bu class ı Owin page ile kurduk. 
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            //bu alttarafı hocanın emlak projesinden aldık. Daha sonra open autanticationları buradan yapıyoruz. 
            //facebook twitter vs işlem butonlarını oradan alacağımız kodu buraya yapıştırarak yaparız.

            //yaptığımız sitede kısıtlanmış alanlar yapacağız. 


            //bu alttarafı hocanın emlak projesinden aldık. Daha sonra open autanticationları buradan yapıyoruz.  cookieler hata vermesin diye bu kodu yazıyoruz her owin sayfası açtığımızda. 
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Hesap/Giris") //daha sonra account login path'i verilecek. Verdik ve hesap giris yaptık. 
            });
        }
    }
}
