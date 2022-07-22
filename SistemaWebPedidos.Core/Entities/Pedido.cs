using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Pedido : Entity
    {
        public List<ItemPedido> ItensPedido { get; set; }

        public Guid UsuarioId { get; set; }

        public Decimal ValorTotal { get; set; }

        public DateTime DataCriacao { get; set; }

        public Guid EnderecoEntregaId { get; set; }

        public Endereco EnderecoEntrega { get; set; }

        public String? Status { get; set; }

        public MeioPagamento MeioPagamento { get; set;}

        public Guid MeioPagamentoId { get; set; }

        public double? Troco { get; set; }

        public int QuantidadeParcela { get; set; }

        public int NumeroPedido { get; set; }
    }
}
