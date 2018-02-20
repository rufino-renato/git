using Loteria.Core.Data.Interfaces;
using Loteria.Core.Data.Repository;
using Loteria.Core.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Loteria.Core.Data
{
    public class SorteioRepository : Repository<Sorteio>, ISorteioRepository
    {
        public SorteioRepository(IMemoryCache memoryCache) 
            : base(memoryCache, new MemoryCacheEntryOptions(), "Sorteio")
        {
        }
    }
}
