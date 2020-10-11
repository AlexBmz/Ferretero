using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ProductoDAO
    {

        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion

        public List<ProductoBEAN> ListarProductos()
        {
            List<ProductoBEAN> lista = new List<ProductoBEAN>();
            ProductoBEAN oProd;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_ListProductos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProd = new ProductoBEAN();
                                oProd.IdProducto = Convert.ToInt32(dr[0]);
                                oProd.NombreProd = Convert.ToString(dr[1]);
                                oProd.PrecioProd = Convert.ToDecimal(dr[2]);
                                oProd.Stock = Convert.ToInt32(dr[3]);
                                oProd.NombTipoProd = Convert.ToString(dr[4]);
                              
                                lista.Add(oProd);

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
        public List<ProductoBEAN> RegistrarProducto(ProductoBEAN oProdBEAN)
        {
            List<ProductoBEAN> lista = new List<ProductoBEAN>();

            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_InsertProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreProd", oProdBEAN.NombreProd);
                        cmd.Parameters.AddWithValue("@PrecioUnit", oProdBEAN.PrecioProd);
                        cmd.Parameters.AddWithValue("@stock", oProdBEAN.Stock);
                        cmd.Parameters.AddWithValue("@IdTipoProd", oProdBEAN.IdTipoProd);                      
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

        public ProductoBEAN BuscarProducto(int id)
        {

            ProductoBEAN oProd = new ProductoBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_BuscarProdId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idProd", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oProd = new ProductoBEAN();
                                oProd.IdProducto = Convert.ToInt32(dr[0]);
                                oProd.NombreProd = Convert.ToString(dr[1]);
                                oProd.PrecioProd =Convert.ToDecimal(dr[2]);
                                oProd.Stock = Convert.ToInt32(dr[3]);
                                oProd.IdTipoProd = Convert.ToInt32(dr[4]);
                              


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oProd;
        }

        public List<ProductoBEAN> BuscarProductoPorNomb(string nomb)
        {
            List<ProductoBEAN> lista = new List<ProductoBEAN>();
            ProductoBEAN oProd;
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_BuscarProductoPorNomb", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nomb", nomb);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProd = new ProductoBEAN();
                                oProd = new ProductoBEAN();
                                oProd.IdProducto = Convert.ToInt32(dr[0]);
                                oProd.NombreProd = Convert.ToString(dr[1]);
                                oProd.PrecioProd = Convert.ToDecimal(dr[2]);
                                oProd.Stock = Convert.ToInt32(dr[3]);
                                oProd.NombTipoProd = Convert.ToString(dr[4]);
                                lista.Add(oProd);

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

        public List<ProductoBEAN> EliminarProducto(int idProd)
        {
            List<ProductoBEAN> listaProd = new List<ProductoBEAN>();
            ProductoBEAN oProd;
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_EliminarProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idProd", idProd);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProd = new ProductoBEAN();
                                oProd.IdProducto = Convert.ToInt32(dr[0]);
                                oProd.NombreProd = Convert.ToString(dr[1]);
                                oProd.PrecioProd = Convert.ToDecimal(dr[2]);
                                oProd.Stock = Convert.ToInt32(dr[3]);
                                oProd.NombTipoProd = Convert.ToString(dr[4]);
                                listaProd.Add(oProd);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listaProd;
        }

        public ProductoBEAN ActualizarProducto(ProductoBEAN oProd)
        {
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_UpdateProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Idprod", oProd.IdProducto);
                        cmd.Parameters.AddWithValue("@nombProd", oProd.NombreProd);
                        cmd.Parameters.AddWithValue("@precioUnit", oProd.PrecioProd);
                        cmd.Parameters.AddWithValue("@stock", oProd.Stock);
                        cmd.Parameters.AddWithValue("@idTipoProd", oProd.IdProducto);                    
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oProd;
        }


    }
}