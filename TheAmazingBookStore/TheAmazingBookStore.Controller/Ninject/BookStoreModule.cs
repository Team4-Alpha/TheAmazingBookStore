using Ninject.Modules;
using TheAmazingBookStore.Controller.Commands;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.Creating;
using TheAmazingBookStore.Controller.Commands.Deleting;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Controller.Core;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Seeding;
using TheAmazingBookStore.Controller.Commands.Updating.BookUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.CountryUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands;
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
            this.Bind<ICommand>().To<CreateCountryCommand>().Named("createcountry");
            this.Bind<ICommand>().To<CreateGenreCommand>().Named("creategenre");
            this.Bind<ICommand>().To<CreatePdfCommand>().InSingletonScope().Named("createpdf");
            
            this.Bind<ICommand>().To<CreateAuthorCommand>().Named("createauthor");

            //READ COMMANDS
            this.Bind<ICommand>().To<FindBookCommand>().InSingletonScope().Named("findbook");

            //UPDATE COMMANDS
            this.Bind<ICommand>().To<UpdateBookDescription>().Named("updatebookdescription");
            this.Bind<ICommand>().To<UpdateBookPrice>().Named("updatebookprice");
            this.Bind<ICommand>().To<UpdateBookRating>().Named("updatebookrating");
            this.Bind<ICommand>().To<UpdateBookTitle>().Named("updatebooktitle");
            this.Bind<ICommand>().To<UpdateCountryName>().Named("updatecountryname");
            this.Bind<ICommand>().To<UpdateGenreDescription>().Named("updategenredescription");
            this.Bind<ICommand>().To<UpdateGenreName>().Named("updategenrename");
            
            this.Bind<ICommand>().To<UpdateAuthorFirstName>().Named("updateauthorfirstname");
            this.Bind<ICommand>().To<UpdateAuthorLastName>().Named("updateauthorlastname");
            this.Bind<ICommand>().To<UpdateAuthorCountry>().Named("updateauthorcountry");
            this.Bind<ICommand>().To<UpdateAuthorBook>().Named("updateauthorbook");
           
            //DELETE COMMANDS
            this.Bind<ICommand>().To<DeleteBookCommand>().Named("deletebook");
            this.Bind<ICommand>().To<SeedJsonCommand>().Named("seedjson");
            this.Bind<ICommand>().To<DeleteAuthorCommand>().Named("deleteauthor");

        }
    }
}
