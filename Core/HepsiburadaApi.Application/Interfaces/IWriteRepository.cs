using HepsiburadaApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Application.Interfaces
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);  //burada şunu düşün 10 tane veri ekliyorum ve 9 tanesi başarılı 1 tanesi başarısız o zaman hiç birini eklemeden devam et demiş olduk. Bunun başka versiyorunu da 9 tanesini kaydet 1 ini kaydetme bu durumda istenirse farklı bir metodla gerçekleştirilir.
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
    }
}
