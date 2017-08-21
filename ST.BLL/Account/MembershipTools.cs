using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL;
using ST.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.BLL.Account
{
    //bu da üyelik işlemleri konusunda evladiyelik class ımız olabilir. 
 public static   class MembershipTools
    {
        public static UserStore<ApplicationUser> NewUserStore() // kullanıcılar tipini tanımladığımızclasslardı bu.
            => new UserStore<ApplicationUser>(new MyContext()); // kullanıcı ile alakalı veri tabanı işlemleri yaptığımız zaman userstore u kullanacağız. Eğer mycontext e yazmazsanız bunu, app datanın içine mdfuzantılı dosya açıp onun üzerinden çalıştırır. O yüzden koymalıyız. 
        public static UserManager<ApplicationUser> NewUserManager() //diğerleri de görevlerini yapıyor. 
            => new UserManager<ApplicationUser>(NewUserStore());
        public static RoleStore<ApplicationRole> NewRoleStore()
            => new RoleStore<ApplicationRole>(new MyContext());

        public static RoleManager<ApplicationRole> NewRoleManager()
            => new RoleManager<ApplicationRole>(NewRoleStore());
    }
}
