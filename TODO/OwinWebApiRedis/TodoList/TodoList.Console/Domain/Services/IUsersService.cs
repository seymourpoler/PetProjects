using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Domain.Services
{
    public interface IUsersService
    {
        bool Login(User user);
    }
}
