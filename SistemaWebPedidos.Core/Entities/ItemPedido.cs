using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class ItemPedido : Entity
    {
        public Produto Produto { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorSemDesconto { get; set; }
        public decimal ValorTotal { get; set; }  
        public Pedido Pedido { get; set; }  

        public Guid PedidoId   { get; set; }
    }
}
