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
    public class ProductoDAL
    {
        #region Singleton
        private static volatile ProductoDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();
        private ProductoDAL() { }
        public static ProductoDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ProductoDAL();
            return instance;
        }
        #endregion
        #region add Producto
        public int Add(Producto producto){
            try{
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@descripcion", producto.descripcion);
                parameters[1] = new SqlParameter("@IdCategoriaFK", producto.IdCategoriaFK);
                parameters[2] = new SqlParameter("@precioUnitario", producto.precioUnitario);
                parameters[3] = new SqlParameter("@stock", producto.stock);
                parameters[4] = new SqlParameter("@codigo", producto.codigo);
                parameters[5] = new SqlParameter("@IdMarcaFK", producto.IdMarcaFK);
                parameters[6] = new SqlParameter("@activo", producto.activo);
                string query = "stp_productos_add";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region Delete
        public int Delete(Producto producto) {
            try {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProductos", producto.IdProductos);
                string query = "stp_productos_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region getall productos
        public Productos getAll(){
            try{
                string query = "stp_productos_getall";
                DataTable resultado = dataAccess.Query(query);
                Productos productos = new Productos();
                foreach (DataRow item in resultado.Rows){
                    productos.Add(new Producto(){

                        IdProductos = (int)item["IdProductos"],
                        descripcion = (string)item["descripcion"],
                        IdCategoriaFK = (int)item["IdCategoriaFK"],
                        precioUnitario = (decimal)item["precioUnitario"],
                        stock = (int)item["stock"],
                        codigo = (string)item["codigo"],
                        IdMarcaFK = (int)item["IdMarcaFK"],
                        activo = (bool)item["activo"]

                    });
                }
                return productos;{
                }
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region getbyid
        public Producto GetById(Producto producto){
            try{
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProducto", producto.IdProductos);
                string query = "stp_productos_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);
                if (resultado.Rows.Count > 0){
                    producto = new Producto(){
                        IdProductos = (int)resultado.Rows[0]["IdProductos"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        IdCategoriaFK = (int)resultado.Rows[0]["IdCategoriaFK"],
                        precioUnitario= (decimal)resultado.Rows[0]["precioUnitario"],
                        stock= (int)resultado.Rows[0]["stock"],
                        codigo= (String)resultado.Rows[0]["codigo"],
                        IdMarcaFK = (int)resultado.Rows[0]["IdMarcaFK"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                }
                return producto;
            }
            catch (Exception){

                throw;
            }
        }
        #endregion
        #region update
        public int Update(Producto producto){
            try{
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@IdProductos", producto.IdProductos);
                parameters[1] = new SqlParameter("@descripcion", producto.descripcion);
                parameters[2] = new SqlParameter("@IdCategoriaFK", producto.IdCategoriaFK);
                parameters[3] = new SqlParameter("@precioUnitario", producto.precioUnitario);
                parameters[4] = new SqlParameter("@stock", producto.stock);
                parameters[5] = new SqlParameter("@codigo", producto.codigo);
                parameters[6] = new SqlParameter("@IdMarcaFK", producto.IdMarcaFK);
                string query = "stp_productos_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception){
                throw;
            }
        }
        #endregion
    }
}
