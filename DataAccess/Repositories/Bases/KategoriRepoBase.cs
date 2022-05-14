using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Repositories.Bases
{
    public abstract  class KategoriRepoBase:RepoBase<Kategori,KitapContext>
    {

       protected KategoriRepoBase():base()
        {

        }

        public KategoriRepoBase(KitapContext kitapContext):base(kitapContext)
        {

        }
    }
}
