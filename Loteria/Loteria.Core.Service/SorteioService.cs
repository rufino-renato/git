using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Loteria.Application.Model;
using Loteria.Core.Data.Interfaces;
using Loteria.Core.Domain.Entities;
using Loteria.Core.Domain.Enums;
using Loteria.Core.Service.Interfaces;
using Loteria.Shared;

namespace Loteria.Core.Service
{
    public class SorteioService : ISorteioService
    {
        private readonly ISorteioRepository _sorteioRepository;
        private readonly IApostaRepository _apostaRepository;
        private readonly IMapper _mapper;

        public SorteioService(ISorteioRepository sorteioRepository, IApostaRepository apostaRepository, IMapper mapper)
        {
            _sorteioRepository = sorteioRepository;
            _apostaRepository = apostaRepository;
            _mapper = mapper;
        }

        public SorteioViewModel IncluirSorteio()
        {
            var sorteio = new Sorteio(_sorteioRepository.GetNextId(), SortearDezenas());

            sorteio.Apostas = RecuperarApostasVencedoras(sorteio.Dezenas).ToList();

            return _mapper.Map<SorteioViewModel>(_sorteioRepository.Add(sorteio));
        }

        private int[] SortearDezenas()
        {
            return GeradorDezenas.GerarDezenas(1, 60, 6);
        }

        private IEnumerable<Aposta> RecuperarApostasVencedoras(int[] dezenas)
        {
            var apostas = _apostaRepository.GetAll().ToList();
            IList<Aposta> apostasVencedoras = new List<Aposta>();

            foreach (var aposta in apostas)
            {
                var acertos = aposta.Dezenas.Intersect(dezenas).Count();

                switch (acertos)
                {
                    case 4:
                        aposta.TipoContemplacao = TipoContemplacao.Quadra;
                        apostasVencedoras.Add(aposta);
                        break;
                    case 5:
                        aposta.TipoContemplacao = TipoContemplacao.Quina;
                        apostasVencedoras.Add(aposta);
                        break;
                    case 6:
                        aposta.TipoContemplacao = TipoContemplacao.Sena;
                        apostasVencedoras.Add(aposta);
                        break;
                }
            }

            return apostasVencedoras;
        }
    }
}
