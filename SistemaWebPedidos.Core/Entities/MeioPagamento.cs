using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class MeioPagamento : Entity
    {
        public string Nome { get; set; }

        public int NumMaxParcelamento { get; set; }

        public double ValorMinParcela { get; set; }

        public bool Ativo { get; set; }

        public string Img { get; set; }
        public List<Pedido> Pedido { get; set; }
    }
}
