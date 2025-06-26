using HepsiburadaApi.Application.Interfaces.Repositories;
using HepsiburadaApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;
        public ReadRepository(DbContext dbContext)       //DbContext imi ReadRepostory e entegre ediyorum
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }  //normalde aşağıda her bir metod repository için " dbContext.Set<T>() " yapacağıma burada metod yaptık


        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table; //dbSet ettiğim benim T nesnem bir Querybable olarak işlev görecektir
            if (!enableTracking) queryable = queryable.AsNoTracking();  // tracking mekenizması sayesinde, sorgusunu yaptığımz işlmin üzerinde bir değişiklik yapıp yapmadığımızı işliyor, ama burada sadece read işlemi yapacağımız için için bunu daha performanslı olması adına devre dışı bırakmam gerekiyor
            if (include is not null) queryable = include(queryable);
            if(predicate is not null) queryable = queryable.Where(predicate);
            if(orderBy is not null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table; 
            if (!enableTracking) queryable = queryable.AsNoTracking();  
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
            return await queryable.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();   //Entity Framework'te AsNoTracking() demek: "Bu verileri getir ama takip etme, değişiklikleri izleme" anlamına gelir.
            if(predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }
    }
       
}
