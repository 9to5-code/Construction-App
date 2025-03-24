using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignUpApp.Model;
using MySqlConnector;


namespace SignUpApp.Database
{
   public  class Repository<T> : IRepository<T> where T : class
{
    private  readonly SignUpAppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public Repository(){}

    public Repository(SignUpAppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<User> GetByEmail(string email)
    {
          return await _context.Users.Where(x => x.EmailId == email).FirstOrDefaultAsync();
    }

    

   public async Task AddAsync(T entity)
{
    if (entity is User user)
    {
        try
        {
            var nameParam = new MySqlParameter("@p0", MySqlDbType.VarChar, 100) { Value = user.Name };
            var emailParam = new MySqlParameter("@p1", MySqlDbType.VarChar, 255) { Value = user.EmailId };

            await _context.Database.ExecuteSqlRawAsync("CALL insertUser(@p0, @p1)", nameParam, emailParam);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            throw;
        }
    }
    else
    {
        throw new InvalidOperationException("Entity is not of type User");
    }
}




    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public  async Task create(T entity)
    {
         if (entity is User user)
    {
        try
        {
            var nameParam = new MySqlParameter("@p0", MySqlDbType.VarChar, 100) { Value = user.Name };
            var emailParam = new MySqlParameter("@p1", MySqlDbType.VarChar, 255) { Value = user.EmailId };

            await _context.Database.ExecuteSqlRawAsync("CALL insertUser(@p0, @p1)", nameParam, emailParam);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            throw;
        }
    }
    else
    {
        throw new InvalidOperationException("Entity is not of type User");
    }

}
}
}