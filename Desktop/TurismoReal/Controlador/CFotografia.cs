using Modelo;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CFotografia
    {
        public static int InsertarImagen(Fotografia foto, System.IO.Stream pathFoto)
        { 
            int resultado;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,   
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Img.Agregar_Img"
                };
                cmd.Parameters.Add("id_dp", OracleDbType.Int32, ParameterDirection.Input).Value = foto.Id_dpto;
                cmd.Parameters.Add("alt_img", OracleDbType.Varchar2, ParameterDirection.Input).Value = foto.Alt;
                cmd.Parameters.Add("r", OracleDbType.Int32, ParameterDirection.Output);

                try
                {
                    con.Open();
                    cmd.ExecuteReader();
                    resultado = int.Parse(cmd.Parameters["r"].Value.ToString());
                    if (resultado >0)
                    {
                    }
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
        public static DataTable ListarImagenes(int idDepto)
        {
            DataTable resultado = new();
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Mantener_Img.Listar_Img"
                };
                cmd.Parameters.Add("id_Dpto", OracleDbType.Int32, ParameterDirection.Input).Value = idDepto;
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
