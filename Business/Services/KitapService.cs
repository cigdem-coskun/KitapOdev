using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IKitapServise:IService<KitapModel,Kitap,KitapContext>
    {

    }
    public class KitapService : IKitapServise

    {
        public RepoBase<Kitap, KitapContext> Repo { get; set; } = new Repo<Kitap, KitapContext>();

        public Result Add(KitapModel model)
        {
            if (Repo.Query().Any(u => u.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Belirtilen kitap adına sahip kayıt bulunmaktadır!");
            Kitap entity = new Kitap()
            {

                Adi = model.Adi?.Trim(),
                YazarAdiSoyadi = model.YazarAdiSoyadi?.Trim(),
                KategoriId = model.KategoriId.Value,
                StokMiktari = model.StokMiktari,


            };
            Repo.Add(entity);
            return new SuccessResult("Kitap başarıyla eklendi");
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<KitapModel> Query()
        {

            
            return Repo.Query().OrderBy(u => u.Adi).Select(u => new KitapModel()
            {
                Aciklamasi = u.Aciklamasi,
                Adi = u.Adi,
                 StokMiktari=u.StokMiktari,
                  YazarAdiSoyadi=u.YazarAdiSoyadi,
                   KategoriId=u.KategoriId,
                   
                
                
            });
        
    }

        public Result Update(KitapModel model)
        {
            throw new NotImplementedException();
        }
    }
}
