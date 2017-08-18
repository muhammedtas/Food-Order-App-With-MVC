using Microsoft.AspNet.Identity.EntityFramework;
using ST.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.IdentityModels
{
 public   class ApplicationUser : IdentityUser //identity işlemlerini kullanmak için bu class ı eklemeliyiz. İdentity classlar sisteme kullanıcı, admin vs gibi girişlerde kolaylık sağlayan bir pakettir. 
    {
        [Index(IsUnique =true)] //bu indexler , IsClustered =true gibi database içinde kullanıldığında arama yapıldığında daha hızlı bulunmasını sağlar. 
        public override string Email { get; set; }
        [Index(IsUnique = true)]
        public override string UserName { get; set; }
        [StringLength(25)]
        [Required]
        public string Name { get; set; }

        [StringLength(35)]
        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public virtual List<Firma> Firmalar { get; set; } = new List<Firma>();
        public virtual List<Adres> Adresler { get; set; } = new List<Adres>(); //bir kullanıcının birden çok adresi olabilir .
        public virtual List<Siparis> Siparisler { get; set; } = new List<Siparis>(); //bir kişinin birden çok siparişi de olabilir. 
    }
}
