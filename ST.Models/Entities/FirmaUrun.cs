using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.Entities
{
    [Table("FirmaUrunler")]
 public  class FirmaUrun
    {
        [Key]
        [Column(Order =1)]
        public int FirmaId { get; set; }

        [Key]
        [Column(Order =2)]
        public int UrunId { get; set; }

        //[DataType("decimal(7,2)")] // decimal için böyle bir ayrıcalık var. Datatype olarak kullanılır. Normalde column idi
        [Display(Name ="Fiyat")]
        public decimal UrunFiyati { get; set; }

        [Display(Name ="Satışta mı")]
        public bool SatistaMi { get; set; } = false;
        [ForeignKey("FirmaId")]
        public virtual Firma Firmalar { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urunler { get; set; } 
    }
} 
