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
    public class MeioPagamentoRepository : Repository<MeioPagamento>, IMeioPagamentoService
    {
         public MeioPagamentoRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

    }
}
