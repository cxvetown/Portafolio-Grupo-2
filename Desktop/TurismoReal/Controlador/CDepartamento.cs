using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public static class CDepartamento
    {
        public static int CrearDepto(Departamento dpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.insertar_dpto"
                };
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = dpto.NombreDpto;
                cmd.Parameters.Add("tarifa", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.TarifaDiara;
                cmd.Parameters.Add("DIREC", OracleDbType.Varchar2, ParameterDirection.Input).Value = dpto.Direccion;
                cmd.Parameters.Add("NRO", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.NroDpto;
                cmd.Parameters.Add("CAP", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.Capacidad;
                cmd.Parameters.Add("COMUNA", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.Comuna.IdComuna;
                cmd.Parameters.Add("disponibilidad", OracleDbType.Char, ParameterDirection.Input).Value = Convert.ToInt32(dpto.Disponibilidad);
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
        public static int ActualizarDepto(Departamento dpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.actualizar_dpto"
                };                
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.IdDepto;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = dpto.NombreDpto;
                cmd.Parameters.Add("tarifa", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.TarifaDiara;
                cmd.Parameters.Add("DIREC", OracleDbType.Varchar2, ParameterDirection.Input).Value = dpto.Direccion;
                cmd.Parameters.Add("NRO", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.NroDpto;
                cmd.Parameters.Add("CAP", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.Capacidad;
                cmd.Parameters.Add("COMUNA", OracleDbType.Int32, ParameterDirection.Input).Value = dpto.Comuna.IdComuna;
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
        public static DataTable ListarDpto()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.listar_dpto"
                };
                cmd.Parameters.Add("Deptos", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int ContarDpto()
        {
            int resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.contar_dpto"
                };
                cmd.Parameters.Add("R", OracleDbType.Int32, ParameterDirection.Output);
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
        public static int EliminarDpto(int idDpto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.eliminar_dpto"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = idDpto;
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
        public static int ActualizarDisponibilidad(int id, bool estado)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Dpto.actualizar_dpto_dispo"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = id;
                cmd.Parameters.Add("disp", OracleDbType.Char, ParameterDirection.Input).Value = Convert.ToInt32(estado);
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
    }
}
