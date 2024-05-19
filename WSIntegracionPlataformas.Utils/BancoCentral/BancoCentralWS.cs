using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WSIntegracionPlataformas.Utils.BancoCentral
{
    public class BancoCentral
    {
        public int GetValorDolar()
        {

            BancoCentralWS.SieteWSSoapClient ValorDolar = new BancoCentralWS.SieteWSSoapClient("SieteWSSoap");
            string[] series = new string[1];
            series[0] = ConfigurationManager.AppSettings["Serie"].ToString();
            var usuario = ConfigurationManager.AppSettings["IdBanco"].ToString();
            var pass = ConfigurationManager.AppSettings["PassBanco"].ToString();
            var fechaDesde = DateTime.Now.ToString("yyyy-MM-dd");
            var fechaHasta = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            var valor = ValorDolar.GetSeries(usuario, pass, fechaDesde, fechaHasta, series).Series[0].obs[0].value;
            return Convert.ToInt32(valor);

        }
    }
}