using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class KitapModel:RecordBase
    {
        [Required(ErrorMessage ="Adı gereklidir.")]
        [StringLength(200)]
        [DisplayName("Adı")]
        public string Adi { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("Yazar Adı soyadı")]
        public string YazarAdiSoyadi { get; set; }
        [StringLength(200)]
        [DisplayName("Açıklaması")]
        public string Aciklamasi { get; set; }
        public int StokMiktari { get; set; }
        [Required]
        public int? KategoriId { get; set; }
        
    }
}
