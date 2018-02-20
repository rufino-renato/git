using System.Collections;
using Loteria.Core.Service.Interfaces;
using Loteria.Application.Model;
using Loteria.Application.Model.AutoMapper;
using Loteria.Core.Data.Interfaces;
using Loteria.Core.Domain.Entities;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Core.Service.Test
{
    public class ApostaServiceTest
    {
        private readonly IApostaService _apostaService;

        public ApostaServiceTest()
        {
            IList<Aposta> apostas = new List<Aposta>
            {
                new Aposta(1, new int[] {1, 2, 3, 4, 5, 6})
            };

            var mockRepository = new Mock<IApostaRepository>();
            
            

            mockRepository.Setup(mr => mr.GetAll()).Returns(apostas);

            mockRepository.Setup(mr => mr.GetNextId()).Returns(apostas.Max(o => o.Id) + 1);

            mockRepository.Setup(mr => mr.Add(It.IsAny<Aposta>())).Returns((Aposta target) => new Aposta(mockRepository.Object.GetNextId(), new int[] { 4, 6, 16, 22, 26, 28 }));

            var mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            _apostaService = new ApostaService(mockRepository.Object, mapper);
        }

        [Fact]
        public void IncluirApostaSucesso()
        {
            var model = new ApostaViewModel();

            var result = _apostaService.IncluirAposta(model);

            Assert.NotNull(result);
        }
    }
}
