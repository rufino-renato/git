using System;
using System.Collections.Generic;
using System.Text;
using Loteria.Shared.Entities;

namespace Loteria.Core.Domain.Entities
{
    public class Sorteio : BaseEntity
    {
        public int[] Dezenas { get; set; }

        public DateTime DataSorteio { get; set; }

        // Apostas vencedoras do concurso.
        public IList<Aposta> Apostas { get; set; }

        public Sorteio(int id, int[] dezenas) : base(id)
        {
            Dezenas = dezenas;
        }
    }
}
