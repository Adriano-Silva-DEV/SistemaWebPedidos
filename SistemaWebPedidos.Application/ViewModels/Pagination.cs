using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.ViewModels
{
    public class Pagination
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public int Total { get; set; }

        public int PaginaAtual { get; set; }

        public Pagination(int skip, int take, int total)
        {
            Skip = skip;
            Take = take;
            Total = total;
            if (Skip == 0) Skip++;      
            PaginaAtual = (skip / take) +1;
        }
    }
}
