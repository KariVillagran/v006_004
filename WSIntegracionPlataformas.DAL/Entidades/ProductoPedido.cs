using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSIntegracionPlataformas.DAL.Entidades
{
    public class ProductoPedido
    {
        public int ID { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string CODIGO_PRODUCTO { get; set; }
        public string MARCA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public int VALOR { get; set; }
    }
}
