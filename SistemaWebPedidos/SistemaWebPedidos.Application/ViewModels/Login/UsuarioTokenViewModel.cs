using System.Collections.Generic;

namespace SistemaWebPedidos.Application.ViewModels.Login
{
    public class UsuarioTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}
