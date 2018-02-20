using System;
using System.Collections.Generic;

namespace Loteria.Shared
{
    public static class GeradorDezenas
    {
        public static int[] GerarDezenas(int minimo, int maximo, int quantidade)
        {
            var random = new Random();
            var dic = new Dictionary<int, int>();
            int[] dezenas = new int[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                var dezena = random.Next(minimo, maximo);

                while (dic.ContainsValue(dezena))
                {
                    dezena = random.Next(minimo, maximo);
                }

                dic.Add(i, dezena);
                dezenas[i] = dezena;
            }

            return dezenas;
        }
    }
}
