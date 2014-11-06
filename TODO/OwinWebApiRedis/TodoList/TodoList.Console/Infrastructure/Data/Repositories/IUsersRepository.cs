using System;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public interface IUsersRepository
    {
        User Save(User user);
        User GetById(Guid Id);

        IList<User> GetAll();
        User Update(User user);
        void Delete(Guid id);
    }
}
