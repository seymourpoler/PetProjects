using System;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public interface IUsersRepository
    {
        User Save(User user);
        User GetById(Guid Id);
        User Update(User user);
        void Delete(Guid id);
    }
}
