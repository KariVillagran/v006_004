using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WSIntegracionPlataformas.DAL.Entidades;
using WSIntegracionPlataformas.Utils.BancoCentral;

namespace WSIntegracionPlataformas.DAL.Implementacion
{
    public class ProductosImpl
    {
        private BancoCentral bancoCentral = new BancoCentral();
        private readonly int valorDolar;
        public ProductosImpl()
        {
            BancoCentral bancoCentral = new BancoCentral();
            valorDolar = bancoCentral.GetValorDolar();
        }
        [HttpPost]
        public Respuesta AgregarProducto(Producto nuevoProducto)
        {
            Respuesta respuesta = new Respuesta();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_AGREGAR_PRODUCTO","@CODIGO_PRODUCTO", nuevoProducto.ID_PRODUCTO, "@MARCA",nuevoProducto.MARCA, "@NOMBRE_PRODUCTO", nuevoProducto.NOMBRE_PRODUCTO, "@TIPO_PRODUCTO", nuevoProducto.TIPO_PRODUCTO, "@STOCK", nuevoProducto.STOCK))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {


                            respuesta.ID = Convert.ToInt32(proc["ID"]);
                            respuesta.MENSAJE = proc["MENSAJE"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.ID = -1;
                respuesta.MENSAJE = ex.Message.ToString();
            }

            return respuesta;
        }

        public Respuesta CrearUsuario(Usuario user)
        {
            Respuesta respuesta = new Respuesta();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_AGREGAR_USUARIO", "@RUT", user.RUT, "@NOMBRE", user.NOMBRE, "@ROL", user.ROL, "@PASS", user.PASS))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            respuesta.ID = Convert.ToInt32(proc["ID"]);
                            respuesta.MENSAJE = proc["MENSAJE"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.ID =-1;
                respuesta.MENSAJE = ex.Message.ToString();
            }

            return respuesta;
        }

        public List<Precios> ObtenerPrecios(int ID_PRODUCTO)
        {
            List<Precios> respuesta = new List<Precios>();

            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_PRECIOS", "@ID_PRODUCTO", ID_PRODUCTO))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            var obj = new Precios
                            {

                                //ID = Convert.ToInt32(proc["ID"]),
                                VALOR = Convert.ToInt32(proc["VALOR"]),
                                VALORDOLAR = Math.Round(Convert.ToDecimal(proc["VALOR"])/ valorDolar,2),
                                FECHA = proc["FECHA"].ToString(),

                            };
                            respuesta.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> respuesta = new List<Producto>();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_PRODUCTOS"))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            var obj = new Producto
                            {

                                ID = Convert.ToInt32(proc["ID"]),
                                ID_PRODUCTO = proc["ID_PRODUCTO"].ToString(),
                                MARCA = proc["MARCA"].ToString(),
                                NOMBRE_PRODUCTO = proc["NOMBRE_PRODUCTO"].ToString(),
                                TIPO_PRODUCTO = proc["TIPO_PRODUCTO"].ToString(),
                                STOCK = Convert.ToInt32(proc["STOCK"]),

                            };
                            respuesta.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            return respuesta;
        }

        public Producto ObtenerProductosPorID(int ID_PRODUCTO)
        {
            Producto producto = new Producto();
            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_PRODUCTO_ID","@ID_PRODUCTO", ID_PRODUCTO))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            producto.ID = Convert.ToInt32(proc["ID"]);
                            producto.ID_PRODUCTO = proc["ID_PRODUCTO"].ToString();
                            producto.MARCA = proc["MARCA"].ToString();
                            producto.NOMBRE_PRODUCTO = proc["NOMBRE_PRODUCTO"].ToString();
                            producto.TIPO_PRODUCTO = proc["TIPO_PRODUCTO"].ToString();
                            producto.STOCK = Convert.ToInt32(proc["STOCK"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return producto;
        }

        public List<Producto> ObtenerStockProductos(int cantidadStock)
        {
            List<Producto> respuesta = new List<Producto>();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_RESUMEN_STOCK", "@CANTIDAD", cantidadStock))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            var obj = new Producto
                            {
                                ID = Convert.ToInt32(proc["ID"]),
                                ID_PRODUCTO = proc["ID_PRODUCTO"].ToString(),
                                MARCA = proc["MARCA"].ToString(),
                                NOMBRE_PRODUCTO = proc["NOMBRE_PRODUCTO"].ToString(),
                                TIPO_PRODUCTO = proc["TIPO_PRODUCTO"].ToString(),
                                STOCK = Convert.ToInt32(proc["STOCK"]),

                            };
                            respuesta.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              
            }

            return respuesta;
        }

        public Respuesta RealizarPedido(Pedido pedido)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                var resp = CrearPedido(pedido);
                if (resp.ID >= 1)
                {
                    foreach (var producto in pedido.PRODUCTOS)
                    {
                        using (var db = new Conexiones())

                        using (var proc = db.ExecDataReaderProc("SP_REALIZAR_PEDIDO", "@ID_PEDIDO", resp.ID, "@CODIGO_PRODUCTO", producto.ID_PRODUCTO, "@CANTIDAD", producto.CANTIDAD))
                        {


                            if (proc.HasRows)
                            {

                                while (proc.Read())
                                {

                                    respuesta.ID = Convert.ToInt32(proc["ID"]);
                                    respuesta.MENSAJE = proc["MENSAJE"].ToString();
                                }
                            }
                        }
                        if(respuesta.ID == -1)
                        {
                            return respuesta;
                        }
                    }
                }

                respuesta = resp;
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }

        public Respuesta CrearPedido(Pedido pedido)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_CREAR_PEDIDO","@RUT_CLIENTE", pedido.RUT_CLIENTE,"@DIRECCION", pedido.DIRECCION))
                {
                    if (proc.HasRows)
                    {
                        while (proc.Read())
                        {
                            respuesta.ID = Convert.ToInt32(proc["ID"]);
                            respuesta.MENSAJE = proc["MENSAJE"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.ID = -1;
                respuesta.MENSAJE = ex.Message.ToString();
            }

            return respuesta;
        }

        public Respuesta AgregarPrecios(Producto producto)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                foreach (var precio in producto.PRECIOS)
                {
                    using (var db = new Conexiones())
                    using (var proc = db.ExecDataReaderProc("SP_INSERTAR_PRECIO_PRODUCTO", "@ID_PRODUCTO", producto.ID, "@VALOR", precio.VALOR,"@FECHA",precio.FECHA))
                    {
                        if (proc.HasRows)
                        {
                            while (proc.Read())
                            {
                                respuesta.ID = Convert.ToInt32(proc["ID"]);
                                respuesta.MENSAJE = proc["MENSAJE"].ToString();
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                respuesta.ID = -1;
                respuesta.MENSAJE = ex.Message.ToString();
            }

            return respuesta;
        }

        public List<Pedido> ObtenerPedidos(Pedido pedidos)
        {
            List<Pedido> pedidosList = new List<Pedido>();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_DETALLE_PEDIDO","@ID_PEDIDO", pedidos.ID_PEDIDO))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            var obj = new Pedido
                            {

                                ID_PEDIDO = Convert.ToInt32(proc["ID_PEDIDO"]),
                                RUT_CLIENTE = Convert.ToInt32(proc["RUT_CLIENTE"]),
                                FECHA_PEDIDO = proc["FECHA_PEDIDO"].ToString(),
                                DIRECCION = proc["DIRECCION"].ToString(),
                                ESTADO = proc["ESTADO"].ToString(),

                            };
                            pedidosList.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return pedidosList;
        }

        public List<ProductoPedido> ObtenerProductosAsociados(int ID_PEDIDO)
        {
            List<ProductoPedido> productosList = new List<ProductoPedido>();


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_OBTENER_PRODUCTOS_PEDIDO","@ID_PEDIDO", ID_PEDIDO))
                {


                    if (proc.HasRows)
                    {

                        while (proc.Read())
                        {
                            var obj = new ProductoPedido
                            {

                                ID = Convert.ToInt32(proc["ID"]),
                                CODIGO_PRODUCTO = proc["ID_PRODUCTO"].ToString(),
                                MARCA = proc["MARCA"].ToString(),
                                NOMBRE_PRODUCTO = proc["NOMBRE_PRODUCTO"].ToString(),
                                TIPO_PRODUCTO = proc["TIPO_PRODUCTO"].ToString(),
                                CANTIDAD = Convert.ToInt32(proc["CANTIDAD"]),
                                VALOR = Convert.ToInt32(proc["VALOR"])
                            };
                            productosList.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return productosList;
        }

        public Respuesta ConfirmarPago(int ID_PEDIDO,int ESTADO)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                
                    using (var db = new Conexiones())
                    using (var proc = db.ExecDataReaderProc("SP_UPDATE_ESTADO_PEDIDO", "@ID_PEDIDO", ID_PEDIDO,"@ESTADO", ESTADO))
                    {
                        if (proc.HasRows)
                        {
                            while (proc.Read())
                            {
                                respuesta.ID = Convert.ToInt32(proc["ID"]);
                                respuesta.MENSAJE = proc["MENSAJE"].ToString();
                            }
                        }
                    }
                

            }
            catch (Exception ex)
            {
                respuesta.ID = -1;
                respuesta.MENSAJE = ex.Message.ToString();
            }

            return respuesta;
        }
    }
}
