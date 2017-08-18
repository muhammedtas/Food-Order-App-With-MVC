using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.Entities
{
public class OdemeTipi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ödeme Tipi")]
        public string OdemeTipiAdi { get; set; }
    }
}
