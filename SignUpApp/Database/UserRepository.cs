using System;
using SignUpApp.Model;
using SignUpApp.Utility;

namespace SignUpApp.Database
{
    public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }
    public async Task<User> GetUser(LoginModel model)
    {
       var user = await _userRepository.GetByEmail(model.Username);
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
       // await Repository<User>.create(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }


    public async Task<User> SearchUser(string searchKey){


        var userSearched = await GetAllUsersAsync();

          var result = userSearched.FirstOrDefault(x => x.Name==searchKey);

          return result;
    }
}

}
