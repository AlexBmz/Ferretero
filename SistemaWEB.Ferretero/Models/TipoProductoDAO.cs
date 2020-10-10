using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class TipoProductoDAO
    {
        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion
        public List<TipoPoductoBEAN> ListarTipoProducto()
        {
            List<TipoPoductoBEAN> lista = new List<TipoPoductoBEAN>();
            TipoPoductoBEAN oTipoProd;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_ListTipoProd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oTipoProd = new TipoPoductoBEAN();
                                oTipoProd.IdTipoProd = Convert.ToInt32(dr[0]);
                                oTipoProd.NombreTipoProd = Convert.ToString(dr[1]);
                                oTipoProd.NombreClase = Convert.ToString(dr[2]);
                               
                                lista.Add(oTipoProd);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lista;

        }
        public List<TipoPoductoBEAN> RegistrarTipoProducto(TipoPoductoBEAN oTipoProdBEAN)
        {
            List<TipoPoductoBEAN> lista = new List<TipoPoductoBEAN>();

            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_InsertTipoProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreTipo", oTipoProdBEAN.NombreTipoProd);
                        cmd.Parameters.AddWithValue("@Idclase", oTipoProdBEAN.IdClase);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public TipoPoductoBEAN BuscarTipoProdId(int id)
        {

            TipoPoductoBEAN oTipoProd = new TipoPoductoBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_BuscarTipoProdId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idTipoProd", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oTipoProd = new TipoPoductoBEAN();
                                oTipoProd.IdTipoProd = Convert.ToInt32(dr[0]);
                                oTipoProd.NombreTipoProd = Convert.ToString(dr[1]);
                                oTipoProd.IdClase = Convert.ToInt32(dr[2]);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oTipoProd;
        }

        public TipoPoductoBEAN ActualizarTipoProd(TipoPoductoBEAN oTipoProd)
        {
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_Update_TipoProd", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idTipoProd", oTipoProd.IdTipoProd);
                        cmd.Parameters.AddWithValue("@nombTipoProd", oTipoProd.NombreTipoProd);
                        cmd.Parameters.AddWithValue("@idClase", oTipoProd.IdClase);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oTipoProd;
        }
    }
}