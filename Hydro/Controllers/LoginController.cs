using Hydro.Models;
using HydroBLL;
using HydroMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
//using HydroBLL;


namespace Hydro.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("MainDashboard", "Dashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UserLogin(string email, string password)
        {

            bool logado = new LoginBLL().LoginVerify(email, password);
            if (logado)
            {
                int codCliente = new LoginBLL().LoginVerifyCodUser(email);
                Session["User"] = codCliente;
                return Json(new
                {
                    sucesso = true,
                    codCliente
                });

            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult FormCadastro()
        {
            return View();
        }


        public ActionResult CadastarCliente(string nome, string email, string telefone, string cpf, string cep, string cidade, string rua, string bairro, string uf, int numero, string id, string senha, int codPlano)
        {
            PlanoMOD plano = new LoginBLL().BuscarPlano(codPlano);
            ClienteMOD ClienteMOD = new ClienteMOD
            {
                Nome = nome,
                Email = email,
                Telefone = telefone,
                CPF = cpf,
                Endereco = cidade + " " + bairro + " " + rua + " " + uf + " " + numero,
                Id = id,
                Senha = senha,
                Plano = plano
            };

            bool cadastrado = new LoginBLL().CadastrarCliente(ClienteMOD);
            return Json(new { sucesso = cadastrado });
        }

        [HttpPost]
        public ActionResult UserLogout()
        {
            Session["User"] = null;

            return Json(Url.Action("Login"));
        }
    }
}