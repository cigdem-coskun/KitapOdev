using AppCore.Business.Models.Results;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Model.Services.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class KategoriService : IKategoriService
    {
        public RepoBase<Kategori, KitapContext> Repo { get; set; } = new Repo<Kategori, KitapContext>();

        //public KategoriService(KategoriRepoBase kategoriRepo)
        //{
        //    Repo = kategoriRepo;
        //}


         public Result Add(KategoriModel model)
        {
           Kategori existingEntity= Repo.Query().SingleOrDefault(kategori=>kategori.Adi.ToUpper() == model.Adi.ToUpper().Trim());
            if (existingEntity != null)
                return new ErrorResult("Girdiğiniz Kategori adına sahip kayıt bulunmaktadır.");

            Kategori entity = new Kategori()
            {
                Adi = model.Adi .Trim(),
               Aciklamasi=model.Aciklamasi?.Trim()
            };
            Repo.Add(entity);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {

            Kategori entity = Repo.Query(k => k.Id == id, "Kitaplar").SingleOrDefault();
            if (entity.Kitaplar != null && entity.Kitaplar.Count > 0)
            {
                return new ErrorResult("Kategori silinemez çünkü ilişkili Kitaplar bulunmaktadır!");
            }
            Repo.Delete(entity);
            return new SuccessResult("Kategori başarıyla silindi.");
        }

            public void Dispose()
        {
            Repo.Dispose();
            
        }

        public IQueryable<KategoriModel> Query()
        {
           IQueryable<KategoriModel>query= Repo.Query().OrderBy(k=>k.Adi).Select(k => new KategoriModel()
            {
                  Id=k.Id,
                   Adi=k.Adi,
                    Aciklamasi=k.Aciklamasi,
                   

            });
            return query;
        }

        public Result Update(KategoriModel model)
        {
            if (Repo.Query().Any(kategori => kategori.Adi.ToUpper() == model.Adi.ToUpper().Trim() && kategori.Id != model.Id))
                return new ErrorResult("Girdiğiniz kategori adına sahip kayıt bulunamktadır!");
            Kategori entity = Repo.Query().SingleOrDefault(kategori => kategori.Id == model.Id);
            entity.Adi = model.Adi.Trim();
            entity.Aciklamasi = model.Aciklamasi?.Trim();
            Repo.Update(entity);
            return new SuccessResult("Kategori başarıyla güncellendi.");
        }
    }
}
