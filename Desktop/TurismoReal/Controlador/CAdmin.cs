using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CAdmin
    {
        public static int CrearUsuarioAdmin(Administrador userAdmin)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Admin.Agregar_Admin"
                };
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userAdmin.Telefono;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Rut;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Apellidos;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);
                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
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
        public static int ActualizarAdmin(Administrador userAdmin)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Admin.Actualizar_Admin"
                };
                cmd.Parameters.Add("id_usr", OracleDbType.Int32, ParameterDirection.Input).Value = userAdmin.IdUsuario;
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userAdmin.Telefono;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userAdmin.Apellidos;
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
        public static DataTable ListarAdmin()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Admin.Listar_Admin"
                };
                cmd.Parameters.Add("Administradores", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int EliminarAdmin(int idUsuario)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Admin.Eliminar_Admin"
                };
                cmd.Parameters.Add("id_usr", OracleDbType.Int32, ParameterDirection.Input).Value = idUsuario;
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
