using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Usuario : Entity
    {

        public string Nome { get; set; }

        public int Telefone { get; set; }

        public String Email  { get; set; }
   
        public Endereco Endereco { get; set; }  

        public Guid EnderecoId { get; set; }
    }
}
