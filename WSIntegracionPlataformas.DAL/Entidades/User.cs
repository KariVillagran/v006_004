using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSIntegracionPlataformas.DAL.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string ROL { get; set; }
        public string PASS { get; set; }
    }
}
