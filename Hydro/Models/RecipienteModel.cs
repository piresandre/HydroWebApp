using HydroMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydro.Models
{

    public class RecipienteModel
    {
        public RecipienteModel(RecipienteMOD r)
        {
            Id = r.Id;
            Nome = r.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}