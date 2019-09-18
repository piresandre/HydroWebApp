using HydroDAL;
using HydroMOD;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydroBLL
{
    public class DashboardBLL
    {
        public ClienteMOD BuscarUsuarioDashBoard(int codCliente)
        {
            return new DashboardDAL().BuscarUsuarioDashBoard(codCliente);
        }
    }
}
