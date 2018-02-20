using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Loteria.Application.Model;
using Loteria.Core.Data.Interfaces;
using Loteria.Core.Domain.Entities;
using Loteria.Core.Service.Interfaces;

namespace Loteria.Core.Service
{
    public class ApostaService : IApostaService
    {
        private readonly IApostaRepository _apostaRepository;

        private readonly IMapper _mapper;

        public ApostaService(IApostaRepository apostaRepository, IMapper mapper)
        {
            _apostaRepository = apostaRepository;
            _mapper = mapper;
        }

        public IEnumerable<ApostaViewModel> GetAll() => _mapper.Map<IEnumerable<ApostaViewModel>>(_apostaRepository.GetAll().ToList());

        public ApostaViewModel GetAposta(int id)
        {
            throw new NotImplementedException();
        }

        public ApostaViewModel IncluirAposta(ApostaViewModel model)
        {
            int id = _apostaRepository.GetNextId();

            var aposta = new Aposta(id, model.Dezenas);

            return _mapper.Map<ApostaViewModel>(_apostaRepository.Add(aposta));
        }
    }
}
