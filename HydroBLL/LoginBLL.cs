using HydroDAL;
using HydroMOD;
using System;

namespace HydroBLL
{
    public class LoginBLL
    {
        public bool LoginVerify(string email, string password)
        {
            return new LoginDAL().LoginVerify(email, password);
        }

        public int LoginVerifyCodUser(string email)
        {
            return new LoginDAL().LoginVerifyCodUser(email);
        }

        public bool CadastrarCliente(ClienteMOD clienteMOD)
        {
            return new LoginDAL().CadastrarCliente(clienteMOD);
        }

        public PlanoMOD BuscarPlano(int codPlano)
        {
            return new LoginDAL().BuscarPlano(codPlano);
        }
    }
}
