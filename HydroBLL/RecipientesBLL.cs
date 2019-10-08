using HydroDAL;
using HydroMOD;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydroBLL
{
    public class RecipientesBLL
    {
        public List<RecipienteMOD> ListarRecipientes()
        {
            return new RecipientesDAL().ListarRecipientes();
        }

        public RecipienteMOD BuscarRecipiente(int id)
        {
            return new RecipientesDAL().BuscarRecipiente(id);   
        }
    }
}
