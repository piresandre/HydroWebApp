using Hydro.Models;
using HydroBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hydro.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult MainDashboard()
        {
            int codCliente = 0;
            if (Session["User"]!= null)
            {
                codCliente = Convert.ToInt32(Session["User"]);
                ClienteModel model = new ClienteModel(new DashboardBLL().BuscarUsuarioDashBoard(codCliente));
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        
    }
}