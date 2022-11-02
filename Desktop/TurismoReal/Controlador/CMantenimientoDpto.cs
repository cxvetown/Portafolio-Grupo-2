using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CMantenimientoDpto
    {
        public static int CrearMantDepto(Mantencion mant, int IdDepto)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Mantenimiento.Agregar_Mantenimiento"
                };
                cmd.Parameters.Add("id_depto", OracleDbType.Int32, ParameterDirection.Input).Value = IdDepto;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = mant.NombreMantenimiento;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = mant.DescripcionMantenimiento;
                cmd.Parameters.Add("fecha_ini", OracleDbType.Date, ParameterDirection.Input).Value = mant.FechaInicio;
                cmd.Parameters.Add("fecha_fin", OracleDbType.Date, ParameterDirection.Input).Value = mant.FechaTermino;
                cmd.Parameters.Add("estado_man", OracleDbType.Char, ParameterDirection.Input).Value = mant.Estado;
                cmd.Parameters.Add("costo", OracleDbType.Int32, ParameterDirection.Input).Value = mant.CostoMantencion;
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
        public static int ActualizarMantDepto(Mantencion mant)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Mantenimiento.Actualizar_Mantenimiento"
                };
                cmd.Parameters.Add("id_mantenimiento", OracleDbType.Int32, ParameterDirection.Input).Value = mant.IdMantencion;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = mant.NombreMantenimiento;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = mant.DescripcionMantenimiento;
                cmd.Parameters.Add("fecha_ini", OracleDbType.Date, ParameterDirection.Input).Value = mant.FechaInicio;
                cmd.Parameters.Add("fecha_fin", OracleDbType.Date, ParameterDirection.Input).Value = mant.FechaTermino;
                cmd.Parameters.Add("estado_man", OracleDbType.Char, ParameterDirection.Input).Value = mant.Estado;
                cmd.Parameters.Add("costo", OracleDbType.Int32, ParameterDirection.Input).Value = mant.CostoMantencion;
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
        public static DataTable ListarMantenimiento(int idDepto)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Mantenimiento.Listar_Mantenimientos"
                };
                cmd.Parameters.Add("Deptos", OracleDbType.Int32, ParameterDirection.Input).Value = idDepto;
                cmd.Parameters.Add("Mantenimientos", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int EliminarMantDpto(int idMantenimiento)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Mantenimiento.Eliminar_Mantenimiento"
                };
                cmd.Parameters.Add("id_mantenimiento", OracleDbType.Int32, ParameterDirection.Input).Value = idMantenimiento;
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
