using System;
using SignUpApp.Model;
using SignUpApp.Utility;
using SignUpApp.Model;
using System.Collections.Generic;
using System.Linq;
namespace SignUpApp.Database
{
    public class UserService : IUserService
{
    private  readonly IRepository<User> _Repository ;
    //private readonly Repository<User> _repository;
   public  Guid Id { get; } = Guid.NewGuid();
 // public SignUpAppDbContext DbContext{get;set;} = new SignUpAppDbContext();
   
   private  readonly UserRepository _userRepository ;
    public UserService(IRepository<User> userRepository,UserRepository repository)
    {
        
         _userRepository = repository;
        _Repository = userRepository;
    }
    

public async Task<List<User>> GetAllUsersAsync()
{
 var fetchedValue = await _Repository.GetAllAsync();

  var  result = fetchedValue
        .GroupBy(x => x.Name)
        .Select(g => g.FirstOrDefault())
        .ToList();

    return result;
}

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _Repository.GetByIdAsync(id);
    }
    public async Task<User> GetUser(LoginModel model)
    {
       var user = await _Repository.GetByEmail(model.Username);
       var isvalid = PasswordHash.ValidatePassword(model.Password,user.Password);
       if(isvalid)
        return user;
        else
         return null;
    }


    public async Task CreateUserAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        //user.Password = PasswordHash.HashPassword(user.Password);
       await  _Repository.AddAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        await _Repository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _Repository.DeleteAsync(id);
    }


    public async Task<User> SearchUser(string searchKey){


        var userSearched = await GetAllUsersAsync();

          var result = userSearched.FirstOrDefault(x => x.Name==searchKey);

          return result;
    }


    public async Task<dynamic> FetchRole(string userName){


        var  membership = await _userRepository.GetMembership(userName);

         // var result = userSearched.FirstOrDefault(x => x.Name==searchKey);

          return membership;
    }
}

}

