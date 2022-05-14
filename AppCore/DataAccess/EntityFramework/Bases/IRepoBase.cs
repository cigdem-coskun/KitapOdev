using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public interface IRepoBase<TEntity,TDbContext> :IDisposable where TEntity:class,new() where TDbContext:DbContext,new()//TEntity ile generic tip yaptık tip olarak ne gönderdiğimize bakıyoruz
    {
        TDbContext DbContext { get; set; }
        IQueryable<TEntity> Query(params string[]entitiesToInclude);//read okuma
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate ,params string[] entitiesToInclude);//predicate koşul göndererek çalışan metod  
        void Add(TEntity entity, bool save=true);
        void Update(TEntity entity, bool save=true);
        void Delete(TEntity entity, bool save = true);
        void Delete(Expression<Func<TEntity, bool>> predicate, bool save=true);//belirtilen koşulda silme işlemi
        int Save();

    }
}
