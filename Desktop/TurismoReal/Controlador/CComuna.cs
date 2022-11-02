using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Controlador
{
    public static class CComuna
    {
        public static List<Comuna> ListarComuna()
        {
            List<Comuna> comunas;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Ubicacion.listar_comunas"
                };
                cmd.Parameters.Add("Comunas", OracleDbType.RefCursor, ParameterDirection.Output);
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

                    comunas = (from rw in resultado.AsEnumerable()
                                 select new Comuna()
                                 {
                                     IdComuna = Convert.ToInt32(rw[0]),
                                     NombreComuna = Convert.ToString(rw[1])
                                 }).OrderBy(comuna => comuna.NombreComuna).ToList();
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
            return comunas;
        }
    }
}
