using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ST.BLL.Account;
using ST.Models.IdentityModels;
using ST.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ST.BLL.Account.MembershipTools;

namespace ST.UI.MWC.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        /*public ActionResult Register(RegisterViewModel model)*/ //async çalıştırmak istersen burası async yazmalı ve void ya da genericlist task olmalı . yani. public async Task<ActionResult> Register(RegisterViewModel model). async olunca ne oluyor, bu async methodların aynı anda çalışmasını istiyorsak methodu komple async yaparız. Eğer async method kullanmak istiyorsak 
        [ValidateAntiForgeryToken] //Bu Annotation bazı tehlikeli kodları kendisi otomatik olarak engelliyor. 
        public async Task<ActionResult> Kayit(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = NewUserManager(); //yukarıya yazdık adresini.
            var checkUser = userManager.FindByEmail(model.Email);
            if (checkUser != null)
            {
                ModelState.AddModelError("", "Bu email adresi kullanılamamaktadır");
                return View(model);
            }
            /*checkUser = userManager.FindByName(model.Username);*/ //bu findbyId, name nin falan bir de async hali var. Async çalışırsa ne olur. Async olması için checkUse = await userManager.FindByNameAsnc yazmak gerek. Üstteki method adında da yuakrıda yazan değişiklikler yapılmalı. 
            checkUser = await userManager.FindByNameAsync(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı kullanılmamaktadır. ");
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Surname = model.Surname,
                UserName=model.Username

            };
            bool adminMi = userManager.Users.Count() == 0;
            var sonuc = await userManager.CreateAsync(user, model.ConfirmPassword); //şdi bu methoddan sonra iki ihtimal var, ya tabloda kullanıcı oluştu ya da oluşmadı. Bir ifleyelim onu.
            if (sonuc.Succeeded)
            {
                if (adminMi)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                /*userManager.AddToRole(user.Id, adminMi ? "Admin" : "User"); *///returnary if yazdık. Kısa if. user.ıd adMin misi true isi admin, değil ise User


                else
                {
                    if (model.FirmaMi)
                    {
                        userManager.AddToRole(user.Id, "Firma");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "Musteri"); //bunları enumaration ile yazıp foreach dönüp de bulabilirdik ama böyle daha kısa oldu gibi. 
                    }
                }
                return RedirectToAction("Index", "Ana"); //Kayıt olduktan sonra ana--giris sayfaya yönlendirdik. 

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");

                return View();
            }

        }
    
        public ActionResult Giris() //bunu düzelteceksin
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Giris(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = NewUserManager();
            var user = await userManager.FindAsync(model.NameEmail, model.Password);
            if (user == null)
            {
                var emailuser = await userManager.FindByEmailAsync(model.NameEmail);
                if (emailuser == null)
                {
                    ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunmamaktadır!");
                    return View(model);
                }
                user = await userManager.FindAsync(emailuser.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                    return View(model);
                }
                else
                {
                    //emaile göre giriş yaptı.
                    login(user);
                }
            }
            else
            {
                //kullanıcı adına göre giriş yaptu
                login(user);
            }
            
             void login(ApplicationUser loginuser) //local function
            {
                var authManager = HttpContext.GetOwinContext().Authentication; //login yapmak için bir manager
                var userIdentity = userManager.CreateIdentity(loginuser, DefaultAuthenticationTypes.ApplicationCookie); //applicationcookie e göre bir identity oluşturacak.
                //şimd bu ikisini birleştirerek bir atuhentication yapacağız.

                authManager.SignIn(new AuthenticationProperties() //bunun async sini kaldırdık çünkü hata verdi. 
                {
                    IsPersistent=model.RememberMe
                }, userIdentity);

            }

            return RedirectToAction("Index","Ana");
        }
        [Authorize] // bu ne işe yaradı? Bu bu action result ı sadece giriş yapanlar görebilsin demektir. 
        public ActionResult Cikis()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Ana");
        }
    }
}
    