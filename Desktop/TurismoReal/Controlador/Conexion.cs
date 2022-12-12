using Oracle.ManagedDataAccess.Client;

namespace Controlador
{
    class Conexion
    {
        private string connectionString = "User Id=c##turismo_real; Password=TurismoReal22; Data Source=localhost:1521/ORCL";
        private static Conexion Con = null;

        public OracleConnection ConexionDB()
        {
            OracleConnection con = new();
            try
            {
                con.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                throw;
            }
            return con;
        }
        public static Conexion getInstance()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
