using ST.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.Entities
{
    public class Firma 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Firma Adı")] //Ekrana basarken bu isimde görünecek. Veri tabanıyla alakası yok. UI tarafıyla ilgilidir. 
        public string FirmaAdi { get; set; }
        [StringLength(200)]
        public string Adres { get; set; }
        [StringLength(11)]
        public string Telefon { get; set; }

        [DataType(DataType.Url)]
        [StringLength(75)]
        public string WebUrl { get; set; }
        [Display(Name ="Ortalama Teslim Süresi")]
        public byte OrtalamaTeslimSuresi { get; set; } = 15;

        public bool AktifMi { get; set; } = false;

        [Column(TypeName = "smalldatetime")]
        [Display(Name ="Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public string KullaniciId { get; set; }
        public decimal MinimumSiparisTutari { get; set; } = 0;
        public string FirmaProfilFotoPath { get; set; }

        public string FirmaKapakFotoPath { get; set; }
        //Navigation Property
        [ForeignKey("KullaniciId")]
        public virtual ApplicationUser Kullanicisi { get; set; }  //kullanıcıyı bağladık. 
 

    }

}