using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class SobreRepository : Repository<Sobre>, ISobreRepository
    {
         public SobreRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

        public async Task<Sobre> Obter()
        {       
            return await _apiDbContext.Sobre.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
