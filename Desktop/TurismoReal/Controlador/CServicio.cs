using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CServicio
    {
        public static int IngresarServicioDpto(Servicio servicioDpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios.insertar_svdpto"
                };
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioDpto.NombreServDpto;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioDpto.DescServDpto;
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
        public static int ActualizarServicioDpto(Servicio servicioDpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios.actualizar_svdpto"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = servicioDpto.IdServDpto;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioDpto.NombreServDpto;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioDpto.DescServDpto;
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
        public static DataTable ListarServiciosDpto()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios.listar_svdpto"
                };
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
        public static int EliminarServicio(int idServDpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios.eliminar_svdpto"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = idServDpto;
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
