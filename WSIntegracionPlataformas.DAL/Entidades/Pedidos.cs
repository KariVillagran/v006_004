using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSIntegracionPlataformas.DAL.Entidades
{
    public class Pedido
    {
       public int ID_PEDIDO { get; set; }
       public int RUT_CLIENTE { get; set; }
       public string DIRECCION { get; set; }
       public string FECHA_PEDIDO { get; set; }
       public string ESTADO { get; set; }
       public int VALOR_TOTAL { get; set; }
        public List<ProductoPedido> PRODUCTOS { get; set; }
    }
}
