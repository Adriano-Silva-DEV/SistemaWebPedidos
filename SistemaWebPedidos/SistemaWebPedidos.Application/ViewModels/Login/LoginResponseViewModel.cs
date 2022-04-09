namespace SistemaWebPedidos.Application.ViewModels.Login
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UserToken { get; set; }
    }
}
