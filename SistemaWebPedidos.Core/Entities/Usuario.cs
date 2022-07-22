using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Usuario : Entity
    {

        public Guid IdIdentity { get; set; }
        public String Nome { get; set; }

        public String Sobrenome { get; set; }

        public String Telefone { get; set; }

        public Endereco Endereco { get; set; }  

        public Guid EnderecoId { get; set; }

    }
}
