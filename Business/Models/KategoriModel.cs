using AppCore.DataAccess.EntityFramework.Bases;
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
    public class KategoriModel:RecordBase
    {
        [Required]
        [StringLength(200)]
        [DisplayName("Adı")]
        public string Adi { get; set; }

        [StringLength(200)]
       [DisplayName("Adı")]
        public string Aciklamasi { get; set; }

        
    }
}
