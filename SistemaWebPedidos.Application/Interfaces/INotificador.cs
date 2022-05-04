

using SistemaWebPedidos.Application.Notificacoes;
using System.Collections.Generic;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}