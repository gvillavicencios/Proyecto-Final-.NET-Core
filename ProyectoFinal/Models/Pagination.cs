using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }

        public int Page { get; set; }
        public int Limit { get; set; }
        public Link Links { get; set; }
    }
}
