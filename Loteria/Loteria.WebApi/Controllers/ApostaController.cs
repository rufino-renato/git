using System.Collections.Generic;
using System.Linq;
using Loteria.Application.Model;
using Loteria.Core.Service.Interfaces;
using Loteria.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Loteria.WebApi.Controllers
{
    public class ApostaController : BaseController
    {
        private readonly IApostaService _apostaService;

        public ApostaController(IApostaService apostaService)
        {
            _apostaService = apostaService;
        }

        [HttpGet]
        public IList<ApostaViewModel> GetApostas()
        {
            return _apostaService.GetAll().ToList();
        }

        public ApostaViewModel GerarDezenas()
        {
            var aposta = new ApostaViewModel
            {
                Dezenas = GeradorDezenas.GerarDezenas(1, 60, 6)
            };

            return aposta;
        }

        [HttpPost]
        public ApostaViewModel InserirAposta([FromBody] int[] dezenas)
        {
            var aposta = new ApostaViewModel
            {
                Dezenas = dezenas
            };

            return _apostaService.IncluirAposta(aposta);
        }
    }
}