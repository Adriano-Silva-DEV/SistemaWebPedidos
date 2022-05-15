using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class ProdutoViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigadotorio ")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres"), MinLength(3)]
        public string Nome { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public string Descricao { get; set; }

        public decimal PrecoCusto { get; set; }

        public decimal PrecoVenda { get; set; }

        public decimal PrecoPromocional { get; set; }

        public string Imagem2 { get; set; }

        public string Imagem3 { get; set; }

        public string Imagem4 { get; set; }

        public string Imagem5 { get; set; }

        public string Sku { get; set; }

        public string Url { get; set; }

        public bool Ativo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        public Guid FornecedorId { get; set; }

        public DateTime dataCadastro { get; set; }

        public string ImagemUpload { get; set; }

        public string Imagem1 { get; set; }

    }
}
