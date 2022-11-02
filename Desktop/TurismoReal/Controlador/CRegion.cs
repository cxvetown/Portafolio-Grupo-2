using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public class CRegion
    {
        public static List<Region> ListarRegion()
        {
            List<Region> regiones;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Ubicacion.listar_regiones"
                };
                cmd.Parameters.Add("Regiones", OracleDbType.RefCursor, ParameterDirection.Output);
                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    OracleDataAdapter da = new()
                    {
                        SelectCommand = cmd
                    };
                    DataTable resultado = new();

                    da.Fill(resultado);

                    regiones = (from rw in resultado.AsEnumerable()
                               select new Region()
                               {
                                   IdRegion = Convert.ToInt32(rw[0]),
                                   NombreRegion = Convert.ToString(rw[1])
                               }).OrderBy(region => region.IdRegion).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return regiones;
        }
    }
}
