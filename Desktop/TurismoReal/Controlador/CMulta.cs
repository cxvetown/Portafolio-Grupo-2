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
    public class CMulta
    {
        public static int GenerarMulta(Multa multa, int idReserva, int idDpto, int idCli)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "P_CheckList.RealizarMulta"
                };
                cmd.Parameters.Add("reserva ", OracleDbType.Int32, ParameterDirection.Input).Value = idReserva;
                cmd.Parameters.Add("costo", OracleDbType.Int32, ParameterDirection.Input).Value = multa.ValorMulta;
                cmd.Parameters.Add("razon", OracleDbType.Varchar2, ParameterDirection.Input).Value = multa.RazonMulta;
                cmd.Parameters.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input).Value = multa.DescMulta;
                cmd.Parameters.Add("dpto", OracleDbType.Int32, ParameterDirection.Input).Value = idDpto;
                cmd.Parameters.Add("cliente", OracleDbType.Int32, ParameterDirection.Input).Value = idCli;
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
        public static int ObjetoAfectado(int multa, int idObjeto, int cantidad)
        {
            int resultado = 0;
            using (OracleConnection con = Conexion.getInstance().ConexionDB())
            {
                OracleCommand cmd = new()
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "P_CheckList.ObjetoAfectado"
                };
                cmd.Parameters.Add("multa", OracleDbType.Int32, ParameterDirection.Input).Value = multa;
                cmd.Parameters.Add("objeto", OracleDbType.Int32, ParameterDirection.Input).Value = idObjeto;
                cmd.Parameters.Add("cantidad", OracleDbType.Int32, ParameterDirection.Input).Value = cantidad;
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
