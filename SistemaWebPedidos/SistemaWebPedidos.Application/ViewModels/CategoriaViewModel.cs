﻿using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class CategoriaViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigadotorio ")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres"),  MinLength(2)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public List<ProdutoViewModel> Produtos { get; set; }

    }
}
