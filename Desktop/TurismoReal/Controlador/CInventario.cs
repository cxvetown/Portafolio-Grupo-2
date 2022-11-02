using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public static class CInventario
    {
        public static int CrearInventario(Objeto objeto, int idDepto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Inventario_Dpto.insertar_objeto"
                };
                cmd.Parameters.Add("id_Dpto", OracleDbType.Int32, ParameterDirection.Input).Value = idDepto;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = objeto.NombreObjeto;
                cmd.Parameters.Add("cantidad", OracleDbType.Int32, ParameterDirection.Input).Value = objeto.CantidadObjeto;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = objeto.ValorUnitarioObjeto;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);

                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                }
                catch (Exception ex)
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
        public static int ActualizarInventario(Objeto objeto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Inventario_Dpto.actualizar_objeto"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = objeto.IdObjeto;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = objeto.NombreObjeto;
                cmd.Parameters.Add("cantidad", OracleDbType.Int32, ParameterDirection.Input).Value = objeto.CantidadObjeto;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = objeto.ValorUnitarioObjeto;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);

                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                }
                catch (Exception ex)
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

        public static DataTable ListarInventario(int idDepto)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Inventario_Dpto.listar_inventario"
                };
                cmd.Parameters.Add("id_Dpto", OracleDbType.Int32, ParameterDirection.Input).Value = idDepto;
                cmd.Parameters.Add("R", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int EliminarObjeto(int idObejto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Inventario_Dpto.eliminar_objeto"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = idObejto;
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
