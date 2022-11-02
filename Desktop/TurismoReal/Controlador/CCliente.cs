using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CCliente
    {
        public static int CrearUsuarioCliente(Cliente userCliente)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Cliente.Agregar_Cliente"
                };
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userCliente.Telefono;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Rut;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Apellidos;
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
        public static DataTable ListarCliente()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Cliente.Listar_Cliente"
                };
                cmd.Parameters.Add("Clientes", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int ActualizarCliente(Cliente userCliente)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Cliente.Actualizar_Cliente"
                };
                cmd.Parameters.Add("id_usr", OracleDbType.Int32, ParameterDirection.Input).Value = userCliente.IdUsuario;
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userCliente.Telefono;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userCliente.Apellidos;
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
        public static int EliminarCliente(int idUsuario)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Cliente.Eliminar_Cliente"
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
