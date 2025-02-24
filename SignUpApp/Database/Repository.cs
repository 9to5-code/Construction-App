using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignUpApp.Model;

namespace SignUpApp.Database
{
   public  class Repository<T> : IRepository<T> where T : class
{
    private readonly SignUpAppDbContext _context;
    private readonly DbSet<T> _dbSet;

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
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
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

    public async Task create(T entity)
    {
         _dbSet.FromSqlRaw("EXEC insertUser @p0,@p2","taru","taru@gmail.com");
        await _context.SaveChangesAsync();
}

}
}