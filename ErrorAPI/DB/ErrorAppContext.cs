using System.Data.Entity;
using ErrorAPI.DB.Entities;

namespace ErrorAPI.DB
{
    public class ErrorAppContext : DbContext
    {
        // Your context has been configured to use a 'ErrorAppContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ErrorAPI.ErrorAppContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ErrorAppContext' 
        // connection string in the application configuration file.
        public ErrorAppContext()
            : base("name=ErrorAppContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ErrorDetails> ErrorDetails { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}