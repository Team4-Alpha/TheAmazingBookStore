using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Controller.Ninject;

namespace TheAmazingBookStore.ConsoleClient.Ninject
{
    public class BookStoreConsoleModule : BookStoreModule
    {
        public override void Load()
        {
            base.Load();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
        }
    }
}
