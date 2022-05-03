using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class ItemPedidoViewModel
    {
        public Guid Id { get; set; }   

        public ProdutoViewModel Produto { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorSemDesconto { get; set; }

        public decimal ValorTotal { get; set; }

    }
}
