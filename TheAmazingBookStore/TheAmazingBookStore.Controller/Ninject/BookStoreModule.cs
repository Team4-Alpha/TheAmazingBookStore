using Ninject.Modules;
using TheAmazingBookStore.Controller.Commands;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.Creating;
using TheAmazingBookStore.Controller.Commands.Deleting;
using TheAmazingBookStore.Controller.Commands.Update.BookUpdateCommands;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Controller.Core;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Seeding;

namespace TheAmazingBookStore.Controller.Ninject
{
    public class BookStoreModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBookStoreContext>().To<BookStoreContext>();

            this.Bind<IProcessor>().To<CommandProcessor>();
            this.Bind<IParser>().To<CommandParser>();
            
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //CREATE COMMANDS
            this.Bind<ICommand>().To<CreateBookCommand>().Named("createbook");
            this.Bind<ICommand>().To<CreatePdfCommand>().InSingletonScope().Named("createpdf");

            //READ COMMANDS
            this.Bind<ICommand>().To<FindBookCommand>().InSingletonScope().Named("findbook");

            //UPDATE COMMANDS
            this.Bind<ICommand>().To<UpdateBookTitle>().Named("updatebooktitle");
            this.Bind<ICommand>().To<UpdateBookDescription>().Named("updatebookdescription");
            this.Bind<ICommand>().To<UpdateBookRating>().Named("updatebookrating");
            this.Bind<ICommand>().To<UpdateBookPrice>().Named("updatebookprice");

            //DELETE COMMANDS
            this.Bind<ICommand>().To<DeleteBookCommand>().Named("deletebook");

            this.Bind<ICommand>().To<SeedJsonCommand>().Named("seedjson");
            
        }
    }
}
