using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CServDpto
    {
        public static int IngresarServicioDpto(int servicio, int dpto, int estado)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Dpto.insertar_svdpto"
                };
                cmd.Parameters.Add("id_serv", OracleDbType.Int32, ParameterDirection.Input).Value = servicio;
                cmd.Parameters.Add("id_dpto", OracleDbType.Int32, ParameterDirection.Input).Value = dpto;
                cmd.Parameters.Add("estado", OracleDbType.Char, ParameterDirection.Input).Value = estado;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return resultado;
        }

        public static int ActualizarServicioDpto(int servicio, int dpto, int estado)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Dpto.actualizar_svdpto"
                };
                cmd.Parameters.Add("id_serv", OracleDbType.Int32, ParameterDirection.Input).Value = servicio;
                cmd.Parameters.Add("id_dpto", OracleDbType.Int32, ParameterDirection.Input).Value = dpto;
                cmd.Parameters.Add("estado", OracleDbType.Char, ParameterDirection.Input).Value = estado;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);


                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return resultado;
        }

        public static DataTable ListarServiciosDpto(int id_Dpto)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Dpto.listar_svdpto"
                };
                cmd.Parameters.Add("id_depto", OracleDbType.Int32, ParameterDirection.Input).Value = id_Dpto;
                cmd.Parameters.Add("Servicios_dpto", OracleDbType.RefCursor, ParameterDirection.Output);
                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    OracleDataAdapter da = new()
                    {
                        SelectCommand = cmd
                    };
                    da.Fill(resultado);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                }
            }
            return resultado;
        }

        public static DataTable ListarServiciosAsignadosDpto(int id_Dpto)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Dpto.listar_svdptoContratado"
                };
                cmd.Parameters.Add("id_depto", OracleDbType.Int32, ParameterDirection.Input).Value = id_Dpto;
                cmd.Parameters.Add("Servicios_dpto", OracleDbType.RefCursor, ParameterDirection.Output);
                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    OracleDataAdapter da = new()
                    {
                        SelectCommand = cmd
                    };
                    da.Fill(resultado);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                }
            }
            return resultado;
        }
        public static int EliminarServicioDpto(int servicio, int dpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Dpto.eliminar_svdpto"
                };
                cmd.Parameters.Add("id_serv", OracleDbType.Int32, ParameterDirection.Input).Value = servicio;
                cmd.Parameters.Add("id_dpto", OracleDbType.Int32, ParameterDirection.Input).Value = dpto;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);


                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return resultado;
        }
    }
}
