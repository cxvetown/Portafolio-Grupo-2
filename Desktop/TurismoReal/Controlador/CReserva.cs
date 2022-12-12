using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CReserva
    {
        public static DataTable ListarReservas(int estado)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Reserva.listar_reserva"
                };
                cmd.Parameters.Add("Reservas", OracleDbType.Int32, ParameterDirection.Input).Value = estado;
                cmd.Parameters.Add("Reservas", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static DataTable Buscar(string valor)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Reserva.buscar_reserva"
                };
                cmd.Parameters.Add("valor", OracleDbType.Varchar2, ParameterDirection.Input).Value = valor;
                cmd.Parameters.Add("reservas_encontradas", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int ConfirmarFirma(int IdReserva, char FirmaFunc, char estadoRes, char estadoPago)
        {
            int resultado;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Reserva.actualizar_firma"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = IdReserva;
                cmd.Parameters.Add("firma", OracleDbType.Char, ParameterDirection.Input).Value = FirmaFunc;
                cmd.Parameters.Add("estadoR", OracleDbType.Char, ParameterDirection.Input).Value = estadoRes;
                cmd.Parameters.Add("estadoP", OracleDbType.Char, ParameterDirection.Input).Value = estadoPago;
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
