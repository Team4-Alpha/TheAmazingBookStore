using Ninject.Modules;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Controller.Core;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Ninject
{
    public class BookStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBookStoreContext>().To<BookStoreContext>();

            this.Bind<IProcessor>().To<CommandProcessor>();
            this.Bind<IParser>().To<CommandParser>();

            this.Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<ICommand>().To<FindBookCommand>().InSingletonScope().Named("findbook"); ;
            //TODO
            //Command bindings
        }
    }
}
