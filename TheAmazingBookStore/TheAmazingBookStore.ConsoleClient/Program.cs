using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using TheAmazingBookStore.ConsoleClient.Ninject;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Migrations;
using TheAmazingBookStore.Models;

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
