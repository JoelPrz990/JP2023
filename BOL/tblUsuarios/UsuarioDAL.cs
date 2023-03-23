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
    public class UsuarioDAL
    {
        #region Singleton
        private static volatile UsuarioDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private UsuarioDAL() { }

        public static UsuarioDAL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new UsuarioDAL();
            return instance;
        }
        #endregion
        #region Add
        public int Add(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", usuario.nombre);
                parameters[1] = new SqlParameter("@password", usuario.password);
                String query = "stp_usuario_add";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new AccessViolationException("Error" + ex.Message);
            }
        }
#endregion
        #region Delete
        public int Delete(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@IDUsuario", usuario.IdUsuario);
                parameters[1] = new SqlParameter("@password", usuario.password);
                parameters[2] = new SqlParameter("@nombre", usuario.nombre);

                String query = "stp_usuario_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {

                throw new AccessViolationException("Error" + ex.Message);
            }
        }
#endregion
        #region GetAll
        public Usuarios GetAll()
        {
            try
            {
                string query = "stp_usuario_getall";
                DataTable resultado = dataAccess.Query(query);
                Usuarios usuarios = new Usuarios();
                foreach (DataRow item in resultado.Rows)
                {
                    usuarios.Add(new Usuario()
                    {
                        IdUsuario = (int)item["IdUsuario"],
                        nombre = (String)item["nombre"],
                        password = (String)item["Password"],
                        activo = (bool)item["activo"]

                    });
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new AccessViolationException("Error" + ex.Message);

            }
        }
#endregion
        #region getbyid
        public Usuario GetById(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdUsuario", usuario.IdUsuario);
                string query = "stp_usuario4_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = (int)resultado.Rows[0]["IdUsuario"],
                        nombre = (String)resultado.Rows[0]["nombre"],
                        password = (String)resultado.Rows[0]["Password"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw new AccessViolationException("Error" + ex.Message);
            }
        }
#endregion
        #region Update
        public int Update(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@IdUsuario", usuario.IdUsuario);
                parameters[1] = new SqlParameter("@nombre", usuario.nombre);
                parameters[2] = new SqlParameter("@password", usuario.password);
                String query = "stp_usuarios_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new AccessViolationException("Error" + ex.Message);

            }
        }
        #endregion 
        #region login
        public Usuario Login(Usuario usuario)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", usuario.nombre);
                parameters[1] = new SqlParameter("Password", usuario.password);
                String query = "stp_usuario_login";
                DataTable resultado = dataAccess.Query(query, parameters);
                if (resultado.Rows.Count > 0)
                {
                    Usuario objUsuario = new Usuario()
                    {
                        IdUsuario = (int)resultado.Rows[0]["idUsuario"],
                        nombre = (string)resultado.Rows[0]["nombre"],
                        password = (string)resultado.Rows[0]["password"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                    return objUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }return null;
        }
        #endregion
    }
}
        
    
