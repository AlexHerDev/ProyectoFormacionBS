using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFormacion
{
    class UserController
    {
        private readonly IRepository<User> userrepo; 
        public UserController()
        {
            userrepo = new EfUserRepository();
        }

        public void Crear(User usuario)
        {
            userrepo.Create(usuario);
        }

        public IEnumerable<User> ObtenerUsuarios()
        {
            return userrepo.GetAll();
        }

        public User ObtnerUsuarioPorId(Guid idUsuario)
        {
            return userrepo.GetById(idUsuario); 
        }

        public void BorrarUsuario(Guid idUsuario)
        {
            userrepo.Delete(idUsuario);
        }
        
        public void BorrarUsuarioPorNombre(string nombre)
        {
            userrepo.DeleteByName(nombre);
        }

        public User ObtenerUsuarioPorNombrePass(string nombre, string pass)
        {
            return userrepo.GetByNameAndPass(nombre, pass); 
        }

        public void ActualizarUsuario(User usuario)
        {
            userrepo.Update(usuario);
        }
    }
}
