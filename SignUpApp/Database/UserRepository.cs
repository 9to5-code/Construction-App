using System;
using Microsoft.EntityFrameworkCore;
using SignUpApp.Model;
using  SignUpApp.ApplicationLayer.Dto;

namespace SignUpApp.Database
{
    public class UserRepository
    {
        

        private  SignUpAppDbContext _context;
        private  DbSet<User> _dbSet;

        public UserRepository(SignUpAppDbContext context)
        {
           _context = context;
           _dbSet = context.Set<User>();
        }

        public async Task<List<UserDto>> GetMembership(string username)
        {
        
         return await _dbSet.Include(a =>a.Membership).Where(b=>b.Name == username && b.Membership!=null).Select(c =>new  UserDto{
            Name = c.Name,
            Role = ((RoleType)c.Membership.Role).ToString()}).ToListAsync();
  
        }

}

       
    }

