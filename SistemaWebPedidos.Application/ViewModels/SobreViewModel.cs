using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class SobreViewModel
    {

        public Guid Id { get; set; }

        public bool PessoaFisica { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string Cpf { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigadotorio ")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres"), MinLength(2)]
        public string NomeEstabelecimento { get; set; }

        
        public String HorarioAbertura { get; set; }

        public String HorarioFechamento { get; set; }

        public String Descricao { get; set; }

        public String ContatoPrincipal { get; set; }

        public String ContatoSecundario { get; set; }

        public String Email { get; set; }

        public string ImagemUpload { get; set; }

        public string Imagem1 { get; set; }

        public EnderecoViewModel Endereco { get; set; }

      
        [StringLength(5, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Rua { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Bairro { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Estado { get; set; }


    }
}
