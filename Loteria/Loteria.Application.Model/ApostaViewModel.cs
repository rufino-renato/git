using System;

namespace Loteria.Application.Model
{
    public class ApostaViewModel
    {
        public int Id { get; set; }
        public int[] Dezenas { get; set; }
        public DateTime DataAposta { get; set; }
    }
}
