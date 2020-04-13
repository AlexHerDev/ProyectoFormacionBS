using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFormacion
{
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Get All objects	
		/// </summary>
		/// <returns></returns>
		IEnumerable<T> GetAll();
		
		/// <summary>
		/// Get Object by Id
		/// </summary>
		/// <returns></returns>
		T GetById(Guid id);

		/// <summary>
		/// Get Object by name and pass 
		/// </summary>
		/// <returns></returns>
		T GetByNameAndPass(string name, string pass);
		
		/// <summary>
		/// Create the object 
		/// </summary>
		/// <param name="entity"></param>
		void Create(T entity);

		/// <summary>
		/// Delete object 
		/// </summary>
		/// <param name="entity"></param>
		void Delete(T entity);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(Guid id);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		void DeleteByName(string name);

		/// <summary>
		/// Update  the object
		/// </summary>
		/// <param name="entity"></param>
		void Update(T entity);

	}
}
