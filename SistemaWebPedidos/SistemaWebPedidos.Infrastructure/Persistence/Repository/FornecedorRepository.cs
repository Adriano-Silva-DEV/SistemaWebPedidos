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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
         public FornecedorRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

        public async Task<Fornecedor> obterPorDocumento(string documento)
        {
            return await _apiDbContext.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Documento == documento);
        }
    }
}
