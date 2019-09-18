using System;
using System.Collections.Generic;
using System.Text;

namespace HydroMOD
{
    public class PagamentoMOD
    {
        public int CodPagamento { get; set; }
        public ClienteMOD Cliente { get; set; }
        public TipoPagamentoMOD TipoPagamento { get; set; }
        public int NumeroCartao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodSeguranca { get; set; }
    }
}
