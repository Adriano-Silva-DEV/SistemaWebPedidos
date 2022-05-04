using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class UsuarioViewModel
    {

        public Guid Id { get; set; }

        public Guid IdIdentity { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(12, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Telefone { get; set; }

        public EnderecoViewModel endereco { get; set; }

        public Guid EnderecoId { get; set; }

    }
}
