using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
