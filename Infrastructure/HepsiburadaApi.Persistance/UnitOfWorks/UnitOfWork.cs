using HepsiburadaApi.Application.Interfaces.Repositories;
using HepsiburadaApi.Application.Interfaces.UnitOfWorks;
using HepsiburadaApi.Persistance.Context;
using HepsiburadaApi.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();    
        //{
        //    return await dbContext.DisposeAsync();   //eğer tek bir return işlemi varsa yukarıdaki gibi bir yapı kullanabilirsin
        //}

        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
