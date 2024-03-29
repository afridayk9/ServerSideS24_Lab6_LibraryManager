using Lab6_LibraryManager.Interfaces;

namespace Lab6_LibraryManager.Services;

/// <summary>
/// A generic service that inherits from the generic interface
/// </summary>
/// <typeparam name="T">The class/data model we are manipulating</typeparam>
public class GenericCrudService<T> : IGenericCrud<T> where T : class
{
    //creates an instance of the DbContext
    readonly ApplicationDbContext context;
    /// <summary>
    /// sets the name of the generic to entities and retrieves the instance of the DbContext
    /// </summary>
    protected IQueryable<T> Entities { get => context.Set<T>(); }

    /// <summary>
    /// a constructor that sets the db context when its instantiated
    /// </summary>
    /// <param name="context">the instance of the db context we are pulling in</param>
    public GenericCrudService(ApplicationDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// retrieves the context created in the context class
    /// </summary>
    /// <returns>Db Context</returns>
    public ApplicationDbContext GetContext()
    {
        return context;
    }

    /// <summary>
    /// Adds a record to a table
    /// </summary>
    /// <param name="entity">a generic value that will change depending on the class we use to plug into the services T</param>
    /// <returns>true of entity added, false if unable to add</returns>
    public bool Add(T entity)
    {
        try
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges() != 0;
        }
        catch { return false; }
    }

    /// <summary>
    /// Deletes a record from a table
    /// </summary>
    /// <param name="entity">a generic value that will change depending on the class we use to plug into the services T</param>
    /// <returns>true if entity added, false if unable to remove</returns>
    public bool Delete(T entity)
    {
        try
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges() != 0;
        }
        catch { return false; }
    }

    /// <summary>
    /// Creates a list of all records in the Class we are plugging in to T
    /// </summary>
    /// <returns>all records that belong to a given table</returns>
    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    /// <summary>
    /// a class to retrieve a record based off primary key
    /// </summary>
    /// <param name="id">the primary key for a given table</param>
    /// <returns>the record that contains the primary key</returns>
    public T GetById(int id)
    {
        return context.Set<T>().Find(id);
    }

    /// <summary>
    /// updates a record in a given tale
    /// </summary>
    /// <param name="entity">a generic value that will change depending on the class we use to plug into the services T</param>
    /// <returns>true if updated, false if unable to update</returns>
    public bool Update(T entity)
    {
        try
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges() != 0;
        }
        catch { return false; }
    }
}
