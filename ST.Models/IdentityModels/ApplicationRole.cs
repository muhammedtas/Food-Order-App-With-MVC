using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.IdentityModels
{
public class ApplicationRole : IdentityRole // identity nin bir diğer özelliği asıl veri tabanınııza dokunmadan giriş bilgileri için ayrı bir veri tabanı oluşturabilmeniz. 
    {
        [StringLength(200)]
        public string Decription { get; set; }
    }
}
