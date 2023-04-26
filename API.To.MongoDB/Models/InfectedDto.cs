using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.To.MongoDB.Models
{
    public class InfectedDto
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
