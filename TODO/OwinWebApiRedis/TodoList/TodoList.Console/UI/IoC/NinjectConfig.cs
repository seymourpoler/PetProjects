using Ninject;
using TodoList.Console.UI.Mappers;
using TodoList.Console.Domain.Services;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Console.UI.IoC
{
    public class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<ITasksService>().To<TasksService>();
            kernel.Bind<ITasksRepository>().To<TasksRepository>();
            kernel.Bind<ITaskMapper>().To<TaskMapper>();
            return kernel;
        }
    }
}
