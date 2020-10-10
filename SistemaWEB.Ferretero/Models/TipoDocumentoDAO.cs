using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class TipoDocumentoDAO
    {
        #region CADENA DE CONEXION
        string _StringConnection = ConfigurationManager.ConnectionStrings["connBD"].ConnectionString;
        #endregion
        public List<TipoDocumentoBEAN> ListarTipoDocumento()
        {
            List<TipoDocumentoBEAN> lista = new List<TipoDocumentoBEAN>();
            TipoDocumentoBEAN oTipDoc;
            try
            {

                using (var conn = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_List_TipoDoc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oTipDoc = new TipoDocumentoBEAN();
                                oTipDoc.IdTipoDoc = Convert.ToInt32(dr[0]);
                                oTipDoc.Descripcion = Convert.ToString(dr[1]);
                                lista.Add(oTipDoc);

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

        public List<TipoDocumentoBEAN> RegistroTipoDoc(TipoDocumentoBEAN oTipoDoc)
        {
            List<TipoDocumentoBEAN> lista = new List<TipoDocumentoBEAN>();
            
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("sp_Registrar_TipoDoc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", oTipoDoc.Descripcion);
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

        public TipoDocumentoBEAN BuscarTipoDocId(int id)
        {
                       
            TipoDocumentoBEAN oTipDoc = new TipoDocumentoBEAN();
            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_TipoDoc_BuscarById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idTipoDoc", id);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oTipDoc = new TipoDocumentoBEAN();
                                oTipDoc.IdTipoDoc = Convert.ToInt32(dr[0]);
                                oTipDoc.Descripcion = Convert.ToString(dr[1]);
                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oTipDoc;
        }

        public TipoDocumentoBEAN ActualizarTipoDoc(TipoDocumentoBEAN oTipoDocs)
        {
            List<TipoDocumentoBEAN> lista = new List<TipoDocumentoBEAN>();

            try
            {
                using (var con = new SqlConnection(_StringConnection))
                {
                    using (var cmd = new SqlCommand("SP_UpdateTipoDoc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idTipoDoc", oTipoDocs.IdTipoDoc);
                        cmd.Parameters.AddWithValue("@desc", oTipoDocs.Descripcion);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oTipoDocs;
        }
    }


}

