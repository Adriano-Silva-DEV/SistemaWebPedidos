using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Produto : Entity
    {

        public string Nome { get; set; }

        public Categoria Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public string Descricao { get; set; }

        public decimal PrecoCusto { get; set; }

        public decimal PrecoVenda { get; set; }

        public decimal PrecoPromocional { get; set; }

        public string Imagem1 { get; set; }

        public string Imagem2 { get; set; }

        public string Imagem3 { get; set; }

        public string Imagem4 { get; set; }

        public string Imagem5 { get; set; }

        public string Sku { get; set; }

        public string Url { get; set; }

        public bool Ativo { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public Guid FornecedorId { get; set; }

        public DateTime dataCadastro { get; set; }

        public List<ItemPedido> ItemPedido { get; set; }
        public bool Excluido { get; set; }

        public int QuantidadeDisponivel { get; set; }
    }
}
