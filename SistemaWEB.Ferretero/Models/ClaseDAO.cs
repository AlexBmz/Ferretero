using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ClaseDAO
    {

        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion

        public List<ClaseBEAN> ListarClase()
        {
            List<ClaseBEAN> lista = new List<ClaseBEAN>();
            ClaseBEAN oClase;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_ListClase", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oClase = new ClaseBEAN();
                                oClase.IdClase = Convert.ToInt32(dr[0]);
                                oClase.NombClase = Convert.ToString(dr[1]);
                                oClase.NombreCat = Convert.ToString(dr[2]);
                                lista.Add(oClase);

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
        public List<ClaseBEAN> RegistrarClase(ClaseBEAN oClaseBean)
        {
            List<ClaseBEAN> lista = new List<ClaseBEAN>();

            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("InstertClase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreClase", oClaseBean.NombClase);
                        cmd.Parameters.AddWithValue("@IdCat", oClaseBean.IdCat);
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

        public ClaseBEAN BuscarClaseId(int id)
        {

            ClaseBEAN oClase = new ClaseBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_BuscarClaseId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idClase", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oClase = new ClaseBEAN();
                                oClase.IdClase = Convert.ToInt32(dr[0]);
                                oClase.NombClase = Convert.ToString(dr[1]);
                                oClase.IdCat = Convert.ToInt32(dr[2]);
                               

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oClase;
        }

        public ClaseBEAN ActualizarCategoria(ClaseBEAN oClase)
        {
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_Update_Clase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idClase", oClase.IdClase);
                        cmd.Parameters.AddWithValue("@nombreClase", oClase.NombClase);
                        cmd.Parameters.AddWithValue("@idCat", oClase.IdCat);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oClase;
        }
    }
}