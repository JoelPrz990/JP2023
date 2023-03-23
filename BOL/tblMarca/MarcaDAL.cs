﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class MarcaDAL
    {
        #region Singleton
        private static volatile MarcaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();
        private MarcaDAL() { }
        public static MarcaDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new MarcaDAL();
            return instance;
        }
        #endregion
        #region add Marca
        public int Add(Marca marca){
            try{
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@description", marca.descripcion);
                string query = "stp_marcas_add";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region Delete
        public int Delete(Marca marca) {
            try{
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idMarca", marca.IdMarca);
                string query = "stp_marcas_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region getall marcas
        public Marcas getAll(){
            try{
                string query = "stp_marcas_getall";
                DataTable resultado = dataAccess.Query(query);
                Marcas marcas = new Marcas();
                foreach (DataRow item in resultado.Rows)
                {
                    marcas.Add(new Marca(){
                        IdMarca = (int)item["idMarca"],
                        descripcion = (string)item["descripcion"],
                        activo = (bool)item["activo"]
                    });
                }
                return marcas;{
                }
            }
            catch (Exception ex){
                throw new ApplicationException("Error " + ex.Message);
            }
        }
        #endregion
        #region getbyid
        public Marca GetById(Marca marca){
            try{
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idMarca", marca.IdMarca);
                string query = "stp_marcas_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);
                if (resultado.Rows.Count > 0){
                    marca = new Marca(){
                        IdMarca = (int)resultado.Rows[0]["idMarca"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                }
                return marca;
            }
            catch (Exception){

                throw;
            }
        }
        #endregion
        #region update
        public int Update(Marca marca){
            try{
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idMarca", marca.IdMarca);
                parameters[1] = new SqlParameter("@descripcion", marca.descripcion);
                string query = "stp_marcas_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception){
                throw;
            }
        }
        #endregion
    }
}
