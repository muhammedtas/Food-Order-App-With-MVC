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
        public virtual DbSet<Adres> Adresler { get; set; }
        public virtual DbSet<FirmaUrun> FirmaUrunler { get; set; }
        public virtual DbSet<OdemeTipi> OdemeTipleri { get; set; }
        public virtual DbSet<Siparis> Siparisler { get; set; }
        public virtual DbSet<SiparisDetay> SiparisDetaylar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // bu satır ve üstü otomatik geliyor zaten. 

            //fluent api ile bu işi çözdük. 
            modelBuilder.Entity<FirmaUrun>()
                 .Property(x => x.UrunFiyati)
                 .HasPrecision(7, 2); //bu neydi şimdi firmaUrun içindeki UrunFiyatı ezdik. 

            modelBuilder.Entity<SiparisDetay>()
                .Property(x => x.UrunFiyat)
                .HasPrecision(7, 2); //siparis detaydaki decimal ürün fiyatını da ezdik. 
        }

    }
}
