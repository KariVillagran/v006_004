using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WSIntegracionPlataformas.DAL.Entidades;
using Microsoft.Ajax.Utilities;
using WSIntegracionPlataformas.BL.Implementacion;
using System.Configuration;
using System.Text.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Transbank.Webpay.TransaccionCompleta;

namespace WSIntegracionPlataformas.Controllers
{
    public class APIController : Controller
    {
        private readonly HttpClient _httpClient;
        public APIController()
        {
            _httpClient = new HttpClient();
           
        }

        public Negocio NegocioService = new Negocio();

        #region VISTAS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Endpoints()
        {
            return View();
        }

        #endregion VISTAS

        [HttpPost]
        public JsonResult Login(string RUT, string CLAVE)
        {
            if (RUT != null && CLAVE != null)
            {
                var rol = NegocioService.ValidarUsuario(RUT, CLAVE);
                if (rol != "")
                {
                    var token = GenerateToken(CLAVE);
                    var mensaje = new
                    {
                        Codigo = 1,
                        Mensaje = "Usuario Logeado con éxito",
                        Token = token,
                    };
                    Session["Token"] = token;
                    Session["ROL"] = rol;
                    
                    return Json(mensaje, JsonRequestBehavior.AllowGet);
                }

            }
            return Json("Usuario o contraseña incorrectos", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult CerrarSesion()
        {
            if(Session["Token"].ToString() != "")
            {
                Session["Token"] = "";
                Session["ROL"] = "";
                return Json("Sesión cerrada", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No hay ninguna sesión vigente", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult CrearUsuario(Usuario user)
        {
            var resp = new Respuesta();
            if (Session["Token"] != null && Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                if (Session["ROL"].ToString() == "Admin")
                {
                    resp = NegocioService.CrearUsuario(user);
                }
                else
                {
                    return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
                }
            }
            else{
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
           
            return Json(resp, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult ObtenerProductoPorID(int ID_PRODUCTO)
        {
            var producto = new Producto();
           
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                producto = NegocioService.ObtenerProductosPorID(ID_PRODUCTO);
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
            
           
            if (producto.ID == 0)
            {
                return Json("No existen productos", JsonRequestBehavior.AllowGet);

            }
            return Json(producto, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult ObtenerProductos()
        {
            var productos = new List<Producto>();
            
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                productos = NegocioService.ObtenerProductos();
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
            
            if (productos == null)
            {
                return Json("No existen productos", JsonRequestBehavior.AllowGet);

            }
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AgregarProducto(Producto Producto)
        {
            var resp = new Respuesta();
            
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                if(Session["ROL"].ToString() == "Admin")
                {
                    resp = NegocioService.AgregarProducto(Producto);
                }
                else
                {
                    return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
                }
                    
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
           


            return Json(resp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ObtenerStockProductos(int CANTIDADSTOCK)
        {
            var resp = new List<Producto>();
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                if (Session["ROL"].ToString() == "Admin")
                {
                    resp = NegocioService.ObtenerStockProductos(CANTIDADSTOCK);
                }
                else
                {
                    return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
           
            if (resp.Count == 0)
            {
                return Json("No existen productos con menos de esta cantidad de stock", JsonRequestBehavior.AllowGet);
            }


            return Json(resp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RealizarPedido(Pedido pedido)
        {
            var resp = new Respuesta();
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                resp = NegocioService.RealizarPedido(pedido);
                var mensaje = new
                {
                    Codigo = 1,
                    Mensaje = "Se ha registrado Pedido",
                };
            return Json(mensaje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
           

        }

        [HttpGet]
        public JsonResult ObtenerPedidos(Pedido pedidos)
        {
            var pedidosList = new List<Pedido>();
           
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                pedidosList = NegocioService.ObtenerPedidos(pedidos);
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
            


            return Json(pedidosList, JsonRequestBehavior.AllowGet);
        }
        #region WEBPAY
        [HttpPost]
        public JsonResult RealizarPago(int ID_PEDIDO, string NUMERO_TARJETA, int CVV, string FECHA_EXPIRACION)
        {
           
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                
                var pedido = new Pedido();
                pedido.ID_PEDIDO = ID_PEDIDO;
                var ResPedidop = NegocioService.ObtenerPedidos(pedido);
                if (ResPedidop[0].ESTADO == "Aprobado")
                {
                    return Json("El pedido no tiene pagos pendientes", JsonRequestBehavior.AllowGet);
                }
                if (ResPedidop[0].ESTADO == "Pendiente Pago")
                {
                    return Json("Tu pedido está pendiente de confirmación", JsonRequestBehavior.AllowGet);
                }
                var random = new Random();
                var buyOrder = ID_PEDIDO.ToString();
                var sessionId = random.Next(999999999).ToString();
                var amount = ResPedidop[0].VALOR_TOTAL;
                var cvv = CVV;
                var card_number = NUMERO_TARJETA;
                var card_expiration_date = FECHA_EXPIRACION;


                var result = (new FullTransaction()).Create(
                    buyOrder: buyOrder,
                    sessionId: sessionId,
                    amount: amount,
                    cvv: cvv,
                    cardNumber: card_number,
                    cardExpirationDate: card_expiration_date);

                var mensaje = new
                {
                    Codigo = 1,
                    Mensaje = "Operación exitosa, Espera que se confirme el pago",
                    NumeroDePedido = buyOrder,
                    Monto_Pagado = amount,
                    Fecha = DateTime.Now.ToString(),
                    TokenPago =result.Token
                };
                NegocioService.ConfirmarPago(Convert.ToInt32(buyOrder), 2);
                return Json(mensaje, JsonRequestBehavior.AllowGet);
               
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }
            
            
        }
        [HttpPost]
        public JsonResult ConfirmarPago(string token)
        {
            if (Session["Token"] != null && ValidateToken(Session["Token"].ToString()))
            {
                if (Session["ROL"].ToString() == "Admin")
                {
                    var installments_number = 10;
                    var resultT = (new FullTransaction()).Installments(
                        token,
                        installments_number);

                    var idQueryInstallments = resultT.IdQueryInstallments;
                    var deferredPeriodsIndex = 0;
                    var gracePeriods = false;

                    var result = (new FullTransaction()).Commit(token, idQueryInstallments, deferredPeriodsIndex, gracePeriods);
                    if (result.Status == "AUTHORIZED")
                    {
                       NegocioService.ConfirmarPago(Convert.ToInt32(result.BuyOrder),3);
                        var mensaje = new
                        {
                            Codigo = 1,
                            Mensaje = "Se ha validado el pago relacionado al número Pedido: " + result.BuyOrder,
                        };
                        return Json(mensaje, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Confirmación fallida", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("No posee permisos para este recurso", JsonRequestBehavior.AllowGet);
            }

           

        }
        #endregion WEBPAY

        #region TOKEN_SESION
        public string GenerateToken(string Pass)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Semilla"].ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", Pass.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        
        }
        public bool ValidateToken(string token = null)
        {
            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Semilla"].ToString());
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return true;
            }
            catch
            {
                // return null if validation fails
                return false;
            }
        }
        #endregion TOKEN_SESION
    }
}