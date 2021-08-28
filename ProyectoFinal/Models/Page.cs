using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Page
    {
        public Pagination Pagination { get; set; }

        public List<Data> Data { get; set; }
    }
}
