using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Categoria Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public String Descricao { get; set; }

        public decimal PrecoCusto { get; set; }

        public decimal PrecoVenda { get; set; }

        public decimal PrecoPromocional { get; set; }

        public List<String> imagens { get; set; }

        public String Sku { get; set; }

        public String Url { get; set; }

        public bool Ativo { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public Guid FornecedorId { get; set; }
    }
}
