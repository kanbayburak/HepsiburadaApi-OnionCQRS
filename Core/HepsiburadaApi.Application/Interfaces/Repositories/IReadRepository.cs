using HepsiburadaApi.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, //predicate, filtreleme şartlarını tanımlayan ve veritabanından hangi verilerin çekileceğini belirleyen bir koşuldur
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,  //bunun sayesinde GetAllAsync(x=>x.include(x=>x.brand).theninclude) şeklinde kyllanabiliyorum
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, //sıralama yapılması için
            bool enableTracking = false);

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,  // burada predicate i zorunlu tutmamızın nedeni; bana sadece 1 tane veri dönecek ve o veriyi dönebilmemiz için buna kesinlikle predicate zorunlu tutmamız lazım
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);   //IQueryable, veritabanından veri çekerken "ne çekileceğini" tarif eder, ama hemen çalışmaz. Verileri gerçekten almak istediğinde (ToList(), FirstOrDefault() gibi) çalışır ve veritabanına sorgu gönderilir.


        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);  // CountAsync, veritabanındaki kayıtların sayısını verir.
    }
}
