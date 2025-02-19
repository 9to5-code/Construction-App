using System;
using SignUpApp.Model;
namespace SignUpApp.Database
{
   public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<User> GetByEmail(string mail);
}

}
