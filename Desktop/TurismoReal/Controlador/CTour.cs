using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CTour
    {
        public static int IngresarTour(Tour tour)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Tours.insertar_tour"
                };
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = tour.NombreTour;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = tour.DescripcionTour;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = tour.ValorTour;
                cmd.Parameters.Add("region", OracleDbType.Int32, ParameterDirection.Input).Value = tour.Region.IdRegion;
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
        public static int ActualizarTour(Tour tour)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Tours.actualizar_tour"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = tour.IdTour;
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Input).Value = tour.NombreTour;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = tour.DescripcionTour;
                cmd.Parameters.Add("valor", OracleDbType.Int32, ParameterDirection.Input).Value = tour.ValorTour;
                cmd.Parameters.Add("region", OracleDbType.Int32, ParameterDirection.Input).Value = tour.Region.IdRegion;
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
        public static DataTable ListarTours()
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Tours.listar_tour"
                };
                cmd.Parameters.Add("Tours", OracleDbType.RefCursor, ParameterDirection.Output);
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
        public static int EliminarTour(int idTour)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Tours.eliminar_tour"
                };
                cmd.Parameters.Add("identificador", OracleDbType.Int32, ParameterDirection.Input).Value = idTour;
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
