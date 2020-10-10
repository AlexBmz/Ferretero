using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class CategoriaDAO
    {
        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion

        public List<CategoriaBEAN> ListarCategorias()
            {
            List<CategoriaBEAN> lista = new List<CategoriaBEAN>();
            CategoriaBEAN oCat;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_ListCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oCat = new CategoriaBEAN();
                                oCat.IdCategoria = Convert.ToInt32(dr[0]);
                                oCat.NombCat = Convert.ToString(dr[1]);
                                lista.Add(oCat);

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

        public List<CategoriaBEAN> RegistrarCat(CategoriaBEAN oCatBEAN)
        {
            List<CategoriaBEAN> lista = new List<CategoriaBEAN>();    
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_InsertCategoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreCat", oCatBEAN.NombCat);
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

        public CategoriaBEAN BuscarCatId(int id)
        {

            CategoriaBEAN oCat = new CategoriaBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_BuscarCatId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCat", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oCat = new CategoriaBEAN();
                                oCat.IdCategoria = Convert.ToInt32(dr[0]);
                                oCat.NombCat = Convert.ToString(dr[1]);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oCat;
        }
        public List<CategoriaBEAN>BuscarCateId(int id)
        {
            List<CategoriaBEAN> lista = new List<CategoriaBEAN>();
            CategoriaBEAN oCat = new CategoriaBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_BuscarCatId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCat", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oCat = new CategoriaBEAN();
                                oCat.IdCategoria = Convert.ToInt32(dr[0]);
                                oCat.NombCat = Convert.ToString(dr[1]);
                                lista.Add(oCat);

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

        public CategoriaBEAN ActualizarCategoria(CategoriaBEAN oCat)
        {      
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_Update_Categoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCat", oCat.IdCategoria);
                        cmd.Parameters.AddWithValue("@nomCat", oCat.NombCat);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oCat;
        }
    }
}