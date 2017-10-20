using Ninject.Modules;
using TheAmazingBookStore.Controller.Commands;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.Creating;
using TheAmazingBookStore.Controller.Commands.Deleting;
using TheAmazingBookStore.Controller.Commands.Seeding;
using TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.BookUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.CountryUpdateCommands;
using TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands;
using TheAmazingBookStore.Controller.Core;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Updating.SellerUpdateCommands;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Controller.Commands.PDF;

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
            this.Bind<ICommand>().To<CreateAuthorCommand>().Named("createauthor");
            this.Bind<ICommand>().To<CreateSellerCommand>().Named("createseller");

            //READ COMMANDS
            this.Bind<ICommand>().To<FindBookCommand>().Named("findbook");
            this.Bind<ICommand>().To<FindAuthorCommand>().Named("findauthor");
            this.Bind<ICommand>().To<FindSellerCommand>().Named("findseller");
            this.Bind<ICommand>().To<FindCountryCommand>().Named("findcountry");
            this.Bind<ICommand>().To<FindGenreCommand>().Named("findgenre");

            //UPDATE COMMANDS

            //BOOK
            this.Bind<ICommand>().To<UpdateBookDescription>().Named("updatebookdescription");
            this.Bind<ICommand>().To<UpdateBookPrice>().Named("updatebookprice");
            this.Bind<ICommand>().To<UpdateBookRating>().Named("updatebookrating");
            this.Bind<ICommand>().To<UpdateBookTitle>().Named("updatebooktitle");
            //COUNTRY
            this.Bind<ICommand>().To<UpdateCountryName>().Named("updatecountryname");
            //GENRE
            this.Bind<ICommand>().To<UpdateGenreDescription>().Named("updategenredescription");
            this.Bind<ICommand>().To<UpdateGenreName>().Named("updategenrename");
            //AUTHOR
            this.Bind<ICommand>().To<UpdateAuthorFirstName>().Named("updateauthorfirstname");
            this.Bind<ICommand>().To<UpdateAuthorLastName>().Named("updateauthorlastname");
            this.Bind<ICommand>().To<UpdateAuthorCountry>().Named("updateauthorcountry");
            this.Bind<ICommand>().To<UpdateAuthorBooks>().Named("updateauthorbooks");
            //SELLER
            this.Bind<ICommand>().To<UpdateSellerFirstName>().Named("updatesellerfirstname");
            this.Bind<ICommand>().To<UpdateSellerLastName>().Named("updatesellerlastname");
            this.Bind<ICommand>().To<UpdateSellerCountry>().Named("updatesellercountry");
            this.Bind<ICommand>().To<UpdateSellerBooks>().Named("updatesellerbooks");

            //DELETE COMMANDS
            this.Bind<ICommand>().To<DeleteBookCommand>().Named("deletebook");
            this.Bind<ICommand>().To<DeleteAuthorCommand>().Named("deleteauthor");
            this.Bind<ICommand>().To<DeleteSellerCommand>().Named("deleteseller");
            this.Bind<ICommand>().To<DeleteCountryCommand>().Named("deletecountry");
            this.Bind<ICommand>().To<DeleteGenreCommand>().Named("deletegenre");

            //UTILS
            this.Bind<ICommand>().To<SeedJsonCommand>().Named("seedjson");
            this.Bind<ICommand>().To<CreatePdfBookCommand>().Named("createpdfbook");
            this.Bind<ICommand>().To<CreatePdfAuthorCommand>().Named("createpdfauthor");
            this.Bind<ICommand>().To<CreatePdfSellerCommand>().Named("createpdfseller");
        }
    }
}


