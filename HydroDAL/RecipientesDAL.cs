using Dapper;
using HydroMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HydroDAL
{
    public class RecipientesDAL
    {
        public List<RecipienteMOD> ListarRecipientes()
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var x = connection.Query<RecipienteMOD>("SELECT * FROM Recipientes").ToList();
                return x;
            }
        }

        public RecipienteMOD BuscarRecipiente(int id)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var x = connection.QueryFirstOrDefault<RecipienteMOD>("SELECT * FROM Recipientes where Id = @Id", new { id });
                return x;
            }
        }
    }
}
