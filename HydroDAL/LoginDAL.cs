using Dapper;
using HydroMOD;
using System;

namespace HydroDAL
{
    public class LoginDAL
    {
        public bool LoginVerify(string email, string password)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var cmd = @"SELECT * FROM Cliente WHERE Email = @email AND Senha = @password";
                var x = connection.ExecuteScalar<int>(cmd, new { email, password });
                return x >= 1;
            }
        }

        public int LoginVerifyCodUser(string email)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var cmd = @"SELECT codCliente FROM Cliente WHERE Email = @email";
                var x = connection.ExecuteScalar<int>(cmd, new { email});
                return x;
            }
        }

        public PlanoMOD BuscarPlano(int codPlano)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var cmd = @"SELECT * FROM plano WHERE CodPlano = @codPlano";
                var x = connection.QueryFirstOrDefault<PlanoMOD>(cmd, new { codPlano });
                return x;
            }
        }

        public bool CadastrarCliente(ClienteMOD clienteMOD)
        {
            using (var connection = ConnectionFactory.HydroDB())
            {
                var cmd = @"INSERT INTO Cliente
	                            (
		                            Nome,
                                    codPlano,
                                    Id,  
		                            Email, 
                                    Telefone, 
                                    Endereco,
                                    CPF,
                                    Senha 
	                            )
                            VALUES
	                            (
		                            @Nome,
                                    @CodPlano,
                                    @Id,  
                                    @Email,
                                    @Telefone,
                                    @Endereco,
                                    @CPF,
                                    @Senha
		                            
	                            )
                                ";
                var Cadastrado = connection.QueryFirstOrDefault<bool>(cmd, new { clienteMOD.Nome,clienteMOD.Plano.CodPlano, clienteMOD.Id,clienteMOD.Email, clienteMOD.Telefone, clienteMOD.CPF, clienteMOD.Endereco, clienteMOD.Senha });
                return Cadastrado;
            }
        }
    }
}
