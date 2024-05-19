using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSIntegracionPlataformas.DAL.Entidades;
using WSIntegracionPlataformas.DAL.Implementacion;
using WSIntegracionPlataformas;
using WSIntegracionPlataformas.Utils.BancoCentral;

namespace WSIntegracionPlataformas.BL.Implementacion
{
    public class Negocio
    {
        
        
        private ProductosImpl ProductosService = new ProductosImpl();
        private UserImpl UserService = new UserImpl();
        public string ValidarUsuario(string RUT, string CLAVE)
        {
            var resp = UserService.ValidarUsuario(RUT, CLAVE);
            return resp;
        }
        public Respuesta AgregarProducto(Producto producto)
        {
            var resp = ProductosService.AgregarProducto(producto);
            if (resp.ID >= 1)
            {
                producto.ID = resp.ID;
                ProductosService.AgregarPrecios(producto);
            }
            return resp;
        }

        public Respuesta CrearUsuario(Usuario user)
        {
            var resp = ProductosService.CrearUsuario(user);
            return resp;
        }

        public List<Producto> ObtenerProductos()
        {
            var productos = ProductosService.ObtenerProductos();
            foreach (var producto in productos)
            {
                producto.PRECIOS = ProductosService.ObtenerPrecios(producto.ID);

            }
            return productos;
        }

        public Producto ObtenerProductosPorID(int ID_PRODUCTO)
        {
            var producto = ProductosService.ObtenerProductosPorID(ID_PRODUCTO);
            producto.PRECIOS = ProductosService.ObtenerPrecios(producto.ID);
            
            return producto;
        }

        public List<Producto> ObtenerStockProductos(int CANTIDADSTOCK)
        {
            var resp = ProductosService.ObtenerStockProductos(CANTIDADSTOCK);
            return resp;
        }

        public Respuesta RealizarPedido(Pedido pedido)
        {
            var resp = ProductosService.RealizarPedido(pedido);
            return resp;
        }
        public List<Pedido> ObtenerPedidos(Pedido pedidos)
        {
            var pedidosList = ProductosService.ObtenerPedidos(pedidos);
            foreach (var pedido in pedidosList)
            {
                pedido.VALOR_TOTAL = 0;
                pedido.PRODUCTOS = ProductosService.ObtenerProductosAsociados(pedido.ID_PEDIDO);

                foreach (var PRODUCTO in pedido.PRODUCTOS)
                {
                    pedido.VALOR_TOTAL = pedido.VALOR_TOTAL + PRODUCTO.VALOR;
                }
            }
            return pedidosList;
        }

        public int ObtenerValorDolar()
        {
            BancoCentral bancoCentral = new BancoCentral();
            var valor = bancoCentral.GetValorDolar();
            return valor;
        }

        public Respuesta ConfirmarPago(int ID_PEDIDO, int ESTADO)
        {
            var resp = ProductosService.ConfirmarPago(ID_PEDIDO, ESTADO);
            return resp;
        }
    }
}
