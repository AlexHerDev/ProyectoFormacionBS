using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFormacion
{
    class EfUserRepository : IRepository<User>
    {
        UserContext context; 
        public EfUserRepository()
        {
            context = new UserContext();
        }
        
        public void Create(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();    
        }

        public void Delete(Guid id)
        {  
            var entity = context.Users.Find(id);
            context.Users.Remove(entity);
            context.SaveChanges(); 
        }

        public void DeleteByName(string name)
        {
            var entity = context.Users.AsQueryable().Where(u => u.Nombre == name);
               
            context.Users.Remove(entity.FirstOrDefault());
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges(); 
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users; 
        }

        public User GetById(Guid id)
        {
            return context.Users.Find(id);
        }
        
        public User GetByNameAndPass(string nombre, string pass)
        {
            var entity = context.Users.AsQueryable().Where(u => u.Nombre == nombre);
            entity.Where(x => x.Pass == pass);
            
            return entity.FirstOrDefault(); 
        }

        public void Update(User entity)
        { 
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();   
        }     
    }
}

