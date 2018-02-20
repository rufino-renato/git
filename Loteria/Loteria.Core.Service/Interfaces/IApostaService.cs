using Loteria.Application.Model;
using System.Collections.Generic;

namespace Loteria.Core.Service.Interfaces
{
    public interface IApostaService
    {
        ApostaViewModel IncluirAposta(ApostaViewModel aposta);
        IEnumerable<ApostaViewModel> GetAll();
        ApostaViewModel GetAposta(int id);
    }
}
