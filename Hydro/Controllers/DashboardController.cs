using Hydro.Hubs;
using Hydro.Models;
using HydroBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        [HttpGet]
        public JsonResult Get()
        {
            MainDashboard();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EasywayHelpDeskDB"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT jan,fev,mar,abr,mai,jun,jul,aug,sete,outu,nov,dez FROM [dbo].[Meses]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var listCus = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                jan = (decimal)x["Jan"],
                                fev = (decimal)x["Fev"],
                                mar = (decimal)x["Mar"],
                                abr = (decimal)x["Abr"],
                                mai = (decimal)x["Mai"],
                                jun = (decimal)x["Jun"],
                                jul = (decimal)x["Jul"],
                                aug = (decimal)x["Aug"],
                                sete = (decimal)x["Sete"],
                                outu = (decimal)x["Outu"],
                                nov = (decimal)x["Nov"],
                                dez = (decimal)x["Dez"],
                            }).ToList();

                    return Json(new { listCus = listCus }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            CusHub.Show();
        }

    }
}