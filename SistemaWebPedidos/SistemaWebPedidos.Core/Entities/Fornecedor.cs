using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Entities
{
    public class Fornecedor : Entity
    {


        public string Nome { get; set; }

        public string Documento { get; set; }

        public int TipoFornecedor { get; set; }

        public bool Ativo { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
