using System.Linq;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Console.Domain.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool Login(User credentials)
        {
            var allUsers = _usersRepository.GetAll();
            return allUsers.ToList().Exists(user => user.Email == credentials.Email && user.PassWord == credentials.PassWord);
        }
    }
}
