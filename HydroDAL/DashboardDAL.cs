using Dapper;
using HydroMOD;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydroDAL
{
    public class DashboardDAL
    {
        public ClienteMOD BuscarUsuarioDashBoard(int codCliente)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var cmd = @"SELECT * FROM Cliente WHERE CodCliente = @codCliente";
                var x = connection.QueryFirstOrDefault<ClienteMOD>(cmd, new { codCliente });
                return x;
            }
        }
    }
}
