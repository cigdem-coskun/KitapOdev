using AppCore.Business.Services.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Model.Services.Bases
{
    public interface IKategoriService:IService<KategoriModel,Kategori,KitapContext>
    {

    }
}

