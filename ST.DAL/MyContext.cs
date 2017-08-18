using Microsoft.AspNet.Identity.EntityFramework;
using ST.Models.Entities;
using ST.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser> //bu sefer kalıtımımızı dbcontext ten değil buradan aldık
    {
        public MyContext()
       :base("name=MyCon")
        {
            //this.RequireUniqueEmail = true;

        }
        public virtual DbSet<Firma> Firmalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<UrunKategori> UrunKategoriler { get; set; }

    }
}
