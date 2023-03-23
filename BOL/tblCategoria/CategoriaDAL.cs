using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CategoriaDAL
    {
        #region Singleton
        private static volatile CategoriaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();
        private CategoriaDAL() { }
        public static CategoriaDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new CategoriaDAL();
            return instance;
        }
        #endregion
        #region add categoria
        public int Add(Categoria categoria) {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@description", categoria.descripcion);
                string query = "stp_categoria_add";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex) {
                throw new ApplicationException("Error "+ ex.Message);
            }
        }
        #endregion
        #region Delete
        public int Delete(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCategoria", categoria.IdCategoria);
                string query = "stp_categoria_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion

        #region getall categoria
        public categorias getAll() {
            try
            {
                string query = "stp_categorias_getall";
                DataTable resultado = dataAccess.Query(query);
                categorias categoria= new categorias();
                foreach (DataRow item in resultado.Rows) {
                    categoria.Add(new Categoria()
                    {
                        IdCategoria = (int)item["idCategoria"],
                        descripcion = (string)item["descripcion"],
                        activo = (bool)item["activo"]
                    });
                }
                return categoria;
                {
                }
            }
            catch (Exception ex)
            { 

                throw new ApplicationException("Error "+ex.Message);
            }
        }
        #endregion
        #region getbyid
        public Categoria GetById (Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdCat", categoria.IdCategoria);
                string query = "stp_categorias_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);
                if (resultado.Rows.Count > 0) {
                    categoria = new Categoria()
                    {
                        IdCategoria = (int)resultado.Rows[0]["IdCat"],
                        descripcion = (string)resultado.Rows[1]["descripcion"]
                    };
                }
                return categoria;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region update
        public int Update (Categoria categoria) {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@IdCat", categoria.IdCategoria);
                parameters[1] = new SqlParameter("@Desc", categoria.descripcion);
                string query = "stp_categorias_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region getByDescription
        public Categoria GetByCategoria(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@descripcion", categoria.descripcion);
                string query = "stp_categorias_getbydescripcion";
                DataTable resultado = dataAccess.Query(query, parameters);
                if (resultado.Rows.Count > 0)
                {
                    categoria = new Categoria()
                    {
                        IdCategoria = (int)resultado.Rows[0]["IdCategoria"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                }
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}