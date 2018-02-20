using Loteria.Core.Data.Interfaces;
using Loteria.Core.Data.Repository;
using Loteria.Core.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Loteria.Core.Data
{
    public class ApostaRepository : Repository<Aposta>, IApostaRepository
    {
        public ApostaRepository(IMemoryCache memoryCache) 
            : base(memoryCache, new MemoryCacheEntryOptions(), "Aposta")
        {
        }
    }
}
