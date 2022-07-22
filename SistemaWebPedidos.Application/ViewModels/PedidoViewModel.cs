using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class PedidoViewModel
    {

        public Guid Id { get; set; }

        public List<ItemPedidoViewModel> ItensPedido { get; set; }

        public Guid UsuarioId { get; set; }

        public Decimal ValorTotal { get; set; }

        public DateTime DataCriacao { get; set; }

        public Guid EnderecoEntregaId { get; set; }

        public EnderecoViewModel EnderecoEntrega { get; set; }

        public String Status { get; set; }

        public MeioPagamentoViewModel MeioPagamento { get; set; }

        public Guid MeioPagamentoId { get; set; }

        public double? Troco { get; set; }

        public int QuantidadeParcela { get; set; }

        public int NumeroPedido { get; set; }

       public Pagination Pagination { get; set; }
    }
}
