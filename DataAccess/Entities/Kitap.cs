using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Kitap:RecordBase
    {   
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }
        [Required]
        [StringLength(200)]
        public string YazarAdiSoyadi { get; set; }
        [StringLength(200)]
        public string Aciklamasi { get; set; }
        public int StokMiktari { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

    }
}
