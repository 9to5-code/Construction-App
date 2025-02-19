using System;
using SignUpApp.Model;
namespace SignUpApp.Database
{
public interface IUserService
{  // interface by defaukt as public acess specifier , but other acess specifiers can be used , so to check that.
     Task<IEnumerable<User>> GetAllUsersAsync();
     Task<User> GetUserByIdAsync(int id);
     Task<User> GetUser(LoginModel model);
    public Task CreateUserAsync(User user);
     Task UpdateUserAsync(User user);
     Task DeleteUserAsync(int id);

    public Task<User> SearchUser(string searchKey);


    protected void test(){



    }

}

}
