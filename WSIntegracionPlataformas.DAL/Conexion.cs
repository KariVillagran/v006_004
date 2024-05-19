using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace WSIntegracionPlataformas.DAL
{
    public class Conexiones : IDisposable
    {
        // Internal members
        protected string ConnString;
        protected SqlConnection Conn;
        protected SqlTransaction Trans;
        protected bool Disposed;

        /// <summary>
        /// Setea o retorna la cadena de conexion utilizada por cualquier instancia de esta clase.
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Retorna el objeto de transaccion en efecto o nulo en caso de no existir.
        /// </summary>
        public SqlTransaction Transaction => Trans;

        /// <summary>
        /// Constructor utilizando la cadena de conexion por defecto en el archivo de configuración "DefaultConnection".
        /// </summary>
        public Conexiones()
        {
            ConnString = ConfigurationManager.ConnectionStrings["FERREMAS"].ConnectionString;
            Connect();
        }
        /// <summary>
        /// "strConnectionRUDO"
        /// </summary>
        /// <param name="name"></param>
        public Conexiones(string name)
        {
            ConnString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            Connect();
        }
        /// <summary>
        /// Constructor utilizando cadena de conexion pasada por parametro
        /// </summary>
        /// <param name="connString">Cadena de conexion para la instancia</param>
        /*public ConexionDa(string connString)
        {
            ConnString = connString;
            Connect();
        }*/
        public string SqlCon_Garantia()
        {
            string sqlCon = null;
            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["FERREMAS"];

            if (config != null)
                sqlCon = config.ConnectionString;

            return sqlCon;
        }

        // Creates a SqlConnection using the current connection string
        protected void Connect()
        {
            Conn = new SqlConnection(ConnString);
            Conn.Open();
        }

        /// <summary>
		/// Construye un SqlCommand con los parámetros dados. Este método se llama normalmente
		/// de los otros métodos y no se llama directamente. Pero aquí está si necesitas acceso
		/// lo.
        /// </summary>
        /// <param name="qry">SQL query or stored procedure name</param>
        /// <param name="type">Type of SQL command</param>
        /// <param name="args">Query arguments. Arguments should be in pairs where one is the
        /// name of the parameter and the second is the value. The very last argument can
        /// optionally be a SqlParameter object for specifying a custom argument type</param>
        /// <returns></returns>
        public SqlCommand CreateCommand(string qry, CommandType type, params object[] args)
        {
            SqlCommand cmd = new SqlCommand(qry, Conn);
            cmd.CommandTimeout = 0;
            // Associate with current transaction, if any
            if (Trans != null)
                cmd.Transaction = Trans;

            // Set command type
            cmd.CommandType = type;

            // Construct SQL parameters
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is string s && i < (args.Length - 1))
                {
                    SqlParameter parm = new SqlParameter
                    {
                        ParameterName = s,
                        Value = args[++i]
                    };
                    cmd.Parameters.Add(parm);
                }
                else if (args[i] is SqlParameter)
                {
                    cmd.Parameters.Add((SqlParameter)args[i]);
                }
                else throw new ArgumentException("Invalid number or type of arguments supplied");
            }
            return cmd;
        }

        #region Exec Members
        /// <summary>
        /// Executes a query that returns no results
        /// </summary>
        /// <param name="qry">Query text</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>The number of rows affected</returns>
        public int ExecNonQuery(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a stored procedure that returns no results
        /// </summary>
        /// <param name="proc">Name of stored proceduret</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>The number of rows affected</returns>
        public int ExecNonQueryProc(string proc, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(proc, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a query that returns a single value
        /// </summary>
        /// <param name="qry">Query text</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Value of first column and first row of the results</returns>
        public object ExecScalar(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Executes a query that returns a single value
        /// </summary>
        /// <param name="qry">Query</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Value of first column and first row of the results</returns>
        public object ExecScalarProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Executes a query and returns the results as a SqlDataReader
        /// </summary>
        /// <param name="qry">Query text</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Results as a SqlDataReader</returns>
        public SqlDataReader ExecDataReader(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                return cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Executes a stored procedure and returns the results as a SqlDataReader
        /// </summary>
        /// <param name="qry">Query</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Results as a SqlDataReader</returns>
        public SqlDataReader ExecDataReaderProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                return cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Executes a query and returns the results as a DataSet
        /// </summary>
        /// <param name="qry">Query text</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Results as a DataSet</returns>
        public DataSet ExecDataSet(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.Text, args))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Executes a stored procedure and returns the results as a Data Set
        /// </summary>
        /// <param name="qry">Query</param>
        /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
        /// <returns>Results as a DataSet</returns>
        public DataSet ExecDataSetProc(string qry, params object[] args)
        {
            using (SqlCommand cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                return ds;
            }
        }
        #endregion

        #region Transaction Members
        /// <summary>
        /// Begins a transaction
        /// </summary>
        /// <returns>The new SqlTransaction object</returns>
        public SqlTransaction BeginTransaction()
        {
            Rollback();
            Trans = Conn.BeginTransaction();
            return Transaction;
        }

        /// <summary>
        /// Commits any transaction in effect.
        /// </summary>
        public void Commit()
        {
            if (Trans != null)
            {
                Trans.Commit();
                Trans = null;
            }
        }

        /// <summary>
        /// Rolls back any transaction in effect.
        /// </summary>
        public void Rollback()
        {
            if (Trans != null)
            {
                Trans.Rollback();
                Trans = null;
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    if (Conn != null)
                    {
                        Rollback();
                        Conn.Dispose();
                        Conn = null;
                    }
                }
                Disposed = true;
            }
        }
        #endregion
    }
}
