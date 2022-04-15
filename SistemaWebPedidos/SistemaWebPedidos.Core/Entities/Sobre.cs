using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Sobre : Entity
    {

        public bool PessoaFisica { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string Cpf { get; set; }

        public string NomeEstabelecimento { get; set; }

        public TimeOnly HorarioAbertura  { get; set; }

        public TimeOnly HorarioFechamento { get; set; }

        public String Descricao { get; set; }

        public String ContatoPrincipal { get; set; }

        public String ContatoSecundario { get; set; }

        public String Email { get; set; }

        public Endereco Endereco { get; set; }


    }
}
