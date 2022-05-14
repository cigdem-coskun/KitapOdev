using DataAccess.Contexts;
using DataAccess.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public class KategoriRepo:KategoriRepoBase
    {
        public KategoriRepo():base()
        {

        }

        public KategoriRepo(KitapContext kitapContext) : base(kitapContext)
        {

        }
    }
}
