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

        public String Cnpj { get; set; }

        public String RazaoSocial { get; set; }

        public String Cpf { get; set; }

        public String NomeEstabelecimento { get; set; }

        public String HorarioAbertura  { get; set; }

        public String HorarioFechamento { get; set; }

        public String Descricao { get; set; }

        public String ContatoPrincipal { get; set; }

        public String ContatoSecundario { get; set; }

        public String Email { get; set; }

        public string Numero { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
