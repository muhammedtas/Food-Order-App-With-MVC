using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.Entities
{
    [Table("Urunler")]
  public  class Urun
    {
        [Key]
        public int Id { get; set;}

        [Required]
        [StringLength(100)] //stringlength yapmazsan Unique yapamazsın. Çünkü sınır vermezsen bunu varcharmax yapıyor. Max olan bir şeye de unique diyemiyoruz. 
        [Index(IsUnique = true)]
        [Display(Name ="Ürün Adı")] //Buraya resourcetype deyip, properties lerin içinde resourcelere girerek bir string text i yüklersen oraya dil seçeneklerini o dosyadan da seçebilirsin. Atıyorum hangi dilde istiyorsan. 
        public string UrunAdi { get; set; }

        public string UrunFotografYolu { get; set; }

        public int UrunKategoriId { get; set; }

        [ForeignKey("UrunKategoriId")]
        public virtual UrunKategori UrunKategori { get; set; }
    }
}
