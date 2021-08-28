using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class InfoVM
    {
        public List<Data> InfUsers { get; set; }
        public Pagination InfPagination { get; set; }
    }
}
