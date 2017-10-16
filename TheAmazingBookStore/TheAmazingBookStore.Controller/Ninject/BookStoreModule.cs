using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Core;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Ninject
{
    class BookStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBookStoreContext>().To<BookStoreContext>();
            
            this.Bind<IParser>().To<CommandParser>();

            this.Bind<IBookStoreFactory>().To<BookStoreFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
        }
    }
}
