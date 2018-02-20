using Loteria.Shared.Entities;
using System;
using Loteria.Core.Domain.Enums;

namespace Loteria.Core.Domain.Entities
{
    public class Aposta : BaseEntity
    {
        public int[] Dezenas { get; }

        public DateTime DataAposta => DateTime.Now;

        public TipoContemplacao? TipoContemplacao { get; set; }

        public Aposta(int id, int[] dezenas) : base(id)
        {
            Dezenas = dezenas;
        }
    }
}
