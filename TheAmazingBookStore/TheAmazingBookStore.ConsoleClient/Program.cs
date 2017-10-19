using Ninject;
using System.Data.Entity;
using TheAmazingBookStore.ConsoleClient.Ninject;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Migrations;

namespace TheAmazingBookStore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());

            IKernel kernel = new StandardKernel(new BookStoreConsoleModule());
            IEngine engine = kernel.Get<IEngine>();

            engine.Start();

        }
    }
}
