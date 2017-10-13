using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Migrations;

namespace TheAmazingBookStore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO Configuration - Not Found
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());
        }
    }
}
