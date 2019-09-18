using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace HydroDAL
{
    public class ConnectionFactory
    {
        public static DbConnection HydroDB()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DESKTOP-B3Q14IV"].ConnectionString);
            //connection.Open();
            return connection;
        }
    }
}
