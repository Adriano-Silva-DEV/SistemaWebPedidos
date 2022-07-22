using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class MeioPagamentoViewModel
    {

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int NumMaxParcelamento { get; set; }

        public double ValorMinParcela { get; set; }

        public bool Ativo { get; set; }

        public string Img { get; set; }

        public List<PedidoViewModel> Pedido { get; set; }
    }
}
