using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Controlador
{
    public class CReporte
    {
        public static DataTable GenReporteReserva(int id, int nivel, DateTime fecha_inicio, DateTime fecha_termino)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "reporte_reserva"
                };
                cmd.Parameters.Add("fecha_inicio", OracleDbType.Date, ParameterDirection.Input).Value = fecha_inicio;
                cmd.Parameters.Add("fecha_termino", OracleDbType.Date, ParameterDirection.Input).Value = fecha_termino;
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = id;
                cmd.Parameters.Add("nivel", OracleDbType.Int32, ParameterDirection.Input).Value = nivel;
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
        public static DataTable GenReporteStats(int id, int nivel, DateTime fecha_inicio, DateTime fecha_termino)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "reporte_stats"
                };
                cmd.Parameters.Add("fecha_inicio", OracleDbType.Date, ParameterDirection.Input).Value = fecha_inicio;
                cmd.Parameters.Add("fecha_termino", OracleDbType.Date, ParameterDirection.Input).Value = fecha_termino;
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = id;
                cmd.Parameters.Add("nivel", OracleDbType.Int32, ParameterDirection.Input).Value = nivel;
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
    }
}
