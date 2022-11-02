using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CFuncionario
    {
        public static int CrearUsuarioFuncionario(Funcionario userFuncionario)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Funcionario.Agregar_Funcionario"
                };
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userFuncionario.Telefono;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Rut;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Apellidos;
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
        public static DataTable ListarFuncionario()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Funcionario.Listar_Funcionario"
                };
                cmd.Parameters.Add("Funcionarios", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int ActualizarFuncionario(Funcionario userFuncionario)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Funcionario.Actualizar_Funcionario"
                };
                cmd.Parameters.Add("id_usr", OracleDbType.Int32, ParameterDirection.Input).Value = userFuncionario.IdUsuario;
                cmd.Parameters.Add("email_c", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Email;
                cmd.Parameters.Add("pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Contraseña;
                cmd.Parameters.Add("fono", OracleDbType.Int32, ParameterDirection.Input).Value = userFuncionario.Telefono;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Nombres;
                cmd.Parameters.Add("apellido", OracleDbType.Varchar2, ParameterDirection.Input).Value = userFuncionario.Apellidos;
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
        public static int EliminarFuncionario(int idUsuario)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Usuario_Funcionario.Eliminar_Funcionario"
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
