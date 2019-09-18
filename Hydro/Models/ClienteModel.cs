using HydroMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydro.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {

        }
        public ClienteModel(ClienteMOD cliente)
        {
            CodCliente = cliente.CodCliente;
            Nome = cliente.Nome;
            CPF = cliente.CPF;
            RG = cliente.RG;
            Email = cliente.Email;
            Endereco = cliente.Endereco;
            Telefone = cliente.Telefone;
            Senha = cliente.Senha;
        }

        public int CodCliente { get; set; }
        public PlanoModel Plano { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}