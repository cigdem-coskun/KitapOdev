using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Kategori:RecordBase
    {
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }

        [StringLength(200)]
        public string Aciklamasi { get; set; }
        public List<Kitap> Kitaplar { get; set; }
    }
}
