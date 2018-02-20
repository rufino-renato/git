using System;
using Xunit;

namespace Loteria.Shared.Test
{
    public class GeradorDezenasTest
    {
        [Fact]
        public void GerarDezenasSucesso()
        {
            var dezenas = GeradorDezenas.GerarDezenas(1, 60, 6);

            Assert.NotNull(dezenas);
        }
    }
}
