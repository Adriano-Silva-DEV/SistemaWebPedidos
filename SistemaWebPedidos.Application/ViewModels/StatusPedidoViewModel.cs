using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class StatusPedidoViewModel
    {
      public  int Id { get; set; }
      public String Nome { get; set; }
      public bool? Ativo { get; set; }
    }
}
