using AutoMapper;
using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.AutoMapper
{
    internal class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();    
        }
    }
}
