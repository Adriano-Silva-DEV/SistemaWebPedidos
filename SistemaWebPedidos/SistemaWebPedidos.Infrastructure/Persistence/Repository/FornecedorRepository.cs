using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
         public FornecedorRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }
    }
}
