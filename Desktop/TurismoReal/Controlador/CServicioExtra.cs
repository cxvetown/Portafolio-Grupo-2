using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public static class CServicioExtra
    {
        public static int IngresarServicio(ServicioExtra servicioExtra)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Extras.insertar_svextra"
                };
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioExtra.NombreServicioExtra;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioExtra.DescripcionServicioExtra;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = servicioExtra.ValorServicioExtra;
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
        public static int ActualizarServicio(ServicioExtra servicioExtra)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Extras.actualizar_svextra"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = servicioExtra.IdServicioExtra;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioExtra.NombreServicioExtra;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = servicioExtra.DescripcionServicioExtra;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = servicioExtra.ValorServicioExtra;
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
        public static DataTable ListarServicios()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Extras.listar_svextra"
                };
                cmd.Parameters.Add("Servicios_Ex", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int EliminarServicio(int idServ)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Servicios_Extras.eliminar_svextra"
                };                
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = idServ;
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
