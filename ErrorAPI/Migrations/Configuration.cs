using ErrorAPI.DB.Entities;

namespace ErrorAPI.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DB.ErrorAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DB.ErrorAppContext context)
        {
            // TODO Just for testing
            context.Programs.AddOrUpdate(new Program
            {
                Name = "ErrorForm",
                ContactEmail = "gugdav@gmail.com"
            });
        }
    }
}
