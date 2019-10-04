using Hydro.Models;
using HydroBLL;
using HydroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hydro.Controllers
{
    public class ConsumoController : ApiController
    {
        public List<ConsumoAgua> Get()
        {
            var c =  new ConsumoControlDAL().ListarTodosDados<ConsumoAgua>();
            return c;
        }


        public ConsumoAgua Post(int codCliente, double qtdGasta)
        {
            ConsumoAgua c = new ConsumoAgua
            {
                QtdGasta = qtdGasta,
                Cliente = new ClienteModel(new DashboardBLL().BuscarUsuarioDashBoard(codCliente)),
            };
            new ConsumoControlDAL().insertRecord(c);
            return c;
        }
        [Route("api/porUsuario/{codCliente}")]
        public List<ConsumoAgua> Get(int codCliente)
        {
            var c = new ConsumoControlDAL().BuscarPorCodCliente<ConsumoAgua>(codCliente);
            return c;
        }
    }
}
