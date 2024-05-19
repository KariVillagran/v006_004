using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSIntegracionPlataformas.DAL.Entidades;
using WSIntegracionPlataformas.Utils.BancoCentralWS;

namespace WSIntegracionPlataformas.DAL.Implementacion
{
    public class UserImpl
    {
        

        public string ValidarUsuario(string Rut, string Clave)
        {
            string ROL =  "";


            try
            {
                using (var db = new Conexiones())
                using (var proc = db.ExecDataReaderProc("SP_VALIDAR_LOGIN", "@USUARIO", Rut, "@CLAVE", Clave))
                {
                    if (proc.HasRows)
                    {
                        while (proc.Read())
                        {
                            ROL = proc["ROL"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ROL = "";
            }

            return ROL;
        }
    }
}
