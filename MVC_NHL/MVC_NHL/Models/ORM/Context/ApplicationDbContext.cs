using System.Data.Entity;
using MVC_NHL.Models.ORM.Entities.Concrete;


namespace MVC_NHL.Models.ORM.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            Database.Connection.ConnectionString = @"Server=DOĞU\SQLEXPRESS;Database=NHL_Db;Integrated Security=true;";
        }

        public DbSet<Team>Teams { get; set; }
    }
}