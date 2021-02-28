using OSDL;
using OSDL.Entities;
using OSBL;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OSUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("Zachary_French-P0");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            //using statement used to dispose of the context when its no longer used.
            using var context = new StoreDBContext(options);

            IMenu menu = new IDEntryMenu(new StoreBL(new StoreRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
