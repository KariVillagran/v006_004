using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSIntegracionPlataformas.DAL.Entidades
{
    public class Producto
    {
        public int ID {  get; set; }
        public string ID_PRODUCTO {  get; set; }
        public string MARCA {  get; set; }
        public string NOMBRE_PRODUCTO {  get; set; }
        public string TIPO_PRODUCTO {  get; set; }
        public int STOCK {  get; set; }
        public List<Precios> PRECIOS { get; set; }
    }
}
