using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public interface IUsersRepository
    {
        User Save(User user);
    }
}
