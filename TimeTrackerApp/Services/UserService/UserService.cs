using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.UserService;

namespace TimeTrackerApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public UserService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                Phone = u.Phone
            }).ToList();

            return users;
        }

        public UserDto GetUserById(int userId)
        {
            var user = _dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password,
                    Phone = u.Phone
                })
                .FirstOrDefault();

            return user;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User updatedUser)
        {
            var existingUser = _dbContext.Users.Find(updatedUser.Id);

            if (existingUser != null)
            {
                // Update user properties
                existingUser.Id = updatedUser.Id;
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                existingUser.Phone = updatedUser.Phone;

                _dbContext.SaveChanges();
            }
            // Handle the case where the user is not found (optional)
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            // Handle the case where the user is not found (optional)
        }
    }
}
