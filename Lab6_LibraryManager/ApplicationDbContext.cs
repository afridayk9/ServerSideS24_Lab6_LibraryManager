using Microsoft.EntityFrameworkCore;
using TableModels;


namespace Lab6_LibraryManager;

    /// <summary>
    /// A class to manage and handle the connection to the database
    /// </summary>
public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

//create the tables using the data models we made in the 2nd project    
public virtual DbSet<Users> Users { get; set; }
public virtual DbSet<Books> Books { get; set; }
}

