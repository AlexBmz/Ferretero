using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ClienteDAO
    {

        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion
        public List<ClienteBEAN> ListarClientes()
        {
            List<ClienteBEAN> lista = new List<ClienteBEAN>();
            ClienteBEAN oCli;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_ListClientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oCli = new ClienteBEAN();
                                oCli.IdCliente = Convert.ToInt32(dr[0]);
                                oCli.NombreCliente = Convert.ToString(dr[1]);
                                oCli.ApePat = Convert.ToString(dr[2]);
                                oCli.ApeMat = Convert.ToString(dr[3]);
                                oCli.Direccion = Convert.ToString(dr[4]);
                                oCli.Telefono = Convert.ToInt32(dr[5]);
                                oCli.Email = Convert.ToString(dr[6]);
                                oCli.Documento = Convert.ToInt32(dr[7]);
                                oCli.Descripcion = Convert.ToString(dr[8]);
                                lista.Add(oCli);

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

        public List<ClienteBEAN> RegistroClientes(ClienteBEAN oCliBean)
        {
            List<ClienteBEAN> lista = new List<ClienteBEAN>();
            
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_InsertClientes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", oCliBean.NombreCliente);
                        cmd.Parameters.AddWithValue("@apePat", oCliBean.ApePat);
                        cmd.Parameters.AddWithValue("@apeMat", oCliBean.ApeMat);
                        cmd.Parameters.AddWithValue("@Direccion", oCliBean.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", oCliBean.Telefono);
                        cmd.Parameters.AddWithValue("@Email", oCliBean.Email);
                        cmd.Parameters.AddWithValue("@idTipoDoc", oCliBean.IdTipoDoc);
                        cmd.Parameters.AddWithValue("@documento", oCliBean.Documento);
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

        public ClienteBEAN BuscarClienteId(int id)
        {

            ClienteBEAN oCliente = new ClienteBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_BuscarClienteId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCliente", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oCliente = new ClienteBEAN();
                                oCliente.IdCliente = Convert.ToInt32(dr[0]);
                                oCliente.NombreCliente = Convert.ToString(dr[1]);
                                oCliente.ApePat = Convert.ToString(dr[2]);
                                oCliente.ApeMat = Convert.ToString(dr[3]);
                                oCliente.Direccion = Convert.ToString(dr[4]);
                                oCliente.Telefono = Convert.ToInt32(dr[5]);
                                oCliente.Email = Convert.ToString(dr[6]);
                                oCliente.IdTipoDoc = Convert.ToInt32(dr[7]);
                                oCliente.Documento = Convert.ToInt32(dr[8]);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oCliente;
        }


        public List<ClienteBEAN> BuscarClientePorNomb(string nomb)
        {
            List<ClienteBEAN> lista = new List<ClienteBEAN>();
            ClienteBEAN oCli;
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_BuscarClientePorNomb", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nomb", nomb);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oCli = new ClienteBEAN();
                                oCli.IdCliente = Convert.ToInt32(dr[0]);
                                oCli.NombreCliente = Convert.ToString(dr[1]);
                                oCli.ApePat = Convert.ToString(dr[2]);
                                oCli.ApeMat = Convert.ToString(dr[3]);
                                oCli.Direccion = Convert.ToString(dr[4]);
                                oCli.Telefono = Convert.ToInt32(dr[5]);
                                oCli.Email = Convert.ToString(dr[6]);
                                oCli.Documento = Convert.ToInt32(dr[7]);
                                oCli.Descripcion = Convert.ToString(dr[8]);
                                lista.Add(oCli);

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

        public ClienteBEAN ActualizarCliente(ClienteBEAN oCli)
        {
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("Sp_UpdateCliente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCli", oCli.IdCliente);
                        cmd.Parameters.AddWithValue("@nombCli", oCli.NombreCliente);
                        cmd.Parameters.AddWithValue("@apePat", oCli.ApePat);
                        cmd.Parameters.AddWithValue("@apeMat", oCli.ApeMat);
                        cmd.Parameters.AddWithValue("@direcc", oCli.Direccion);
                        cmd.Parameters.AddWithValue("@telf", oCli.Telefono);
                        cmd.Parameters.AddWithValue("@email", oCli.Email);
                        cmd.Parameters.AddWithValue("@IdTipoDoc", oCli.IdTipoDoc);
                        cmd.Parameters.AddWithValue("@doc", oCli.Documento);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oCli;
        }


    }
}