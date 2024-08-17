using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using todoApi.Models;

//REMEMBER INSTANCES ARE NOTHING BUT OBJECTS 
namespace todoApi.AppDataContext
{
    //TodoDbContext class inherits from DbContext
    //This class is the primary class that interacts with the database.
    public class TodoDbContext: DbContext
    {
        //Dbsetting field to store the connection string
        private readonly DbSetting _dbSettings;
        
        //Constructor to inject the DbSetting model
        //Here we need to access options related to connectionstring which is 
        //defined in DbSettings class
        public TodoDbContext(IOptions<DbSetting> dbSetting)
        {
            _dbSettings = dbSetting.Value;
        }

        //DbSet property to represent the Todo table
        //It is the Dbset of Todo objects
        //This allows us to query and save instances of Todo
        public DbSet<Todo> Todos { get; set; }

        // Configuring the database provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
           
        }

        //Configuring the model for the Todo entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("TodoAPI").HasKey(x => x.Id);
        }
    }
}
