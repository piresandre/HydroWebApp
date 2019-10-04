using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydro.Models
{
    public class ConsumoAgua
    {
        [BsonId]
        public Guid Id { get; set; }
        public double QtdGasta { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}