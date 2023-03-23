using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Singleton
        private static volatile UsuarioBLL instance = null;
        private static readonly object padlock = new object();
        private UsuarioDAL usuarioDAL = UsuarioDAL.Instance();
        private UsuarioBLL() { }
        public static UsuarioBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new UsuarioBLL();
            return instance;
        }
        #endregion
        public bool Add(Usuario usuario)
        {
            return usuarioDAL.Add(usuario) > 0;
        }
        public bool Delete(Usuario usuario)
        {
            return usuarioDAL.Delete(usuario) > 0;
        }
        public Usuarios GetAll()
        {
            return usuarioDAL.GetAll();
        }
        public Usuario GetById(Usuario usuario)
        {
            return usuarioDAL.GetById(usuario);
        }
        public bool Update(Usuario usuario)
        {
            if (usuarioDAL.Update(usuario) > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool Login(Usuario usuario) { 
            if(usuarioDAL.Login(usuario)!= null)
                return true;
            else 
                return false;
        }
    }
}
