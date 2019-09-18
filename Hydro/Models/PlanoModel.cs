using HydroMOD;

namespace Hydro.Models
{
    public class PlanoModel
    {
        public PlanoModel()
        {

        }
        public PlanoModel(PlanoMOD plano)
        {
            Codigo = plano.CodPlano;
            Descricao = plano.DescricaoPlano;
            Valor = plano.ValorPlano;

        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}