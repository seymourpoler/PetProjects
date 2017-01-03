using System;

namespace Domain.Commands.Repositories
{
    public interface ITodoDeleteRepository
    {
        void Delete(int id);
    }

    public class TodoNotFoundException : Exception { }
}
