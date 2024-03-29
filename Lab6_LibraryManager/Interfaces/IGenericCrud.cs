namespace Lab6_LibraryManager.Interfaces;

public interface IGenericCrud<T> where T : class
{
    /// <summary>
    /// allows us to add an entity
    /// </summary>
    /// <param name="entity">the entity we are adding according the the data model we are manipulating</param>
    /// <returns>true if adding</returns>
    bool Add(T entity);

    /// <summary>
    /// allows us to update an entity
    /// </summary>
    /// <param name="entity">the entity we are updating according the the data model we are manipulating</param>
    /// <returns>a true if updating</returns>
    bool Update(T entity);
    /// <summary>
    /// allows us to delete an entity
    /// </summary>
    /// <param name="entity">the entity we are deleting according the the data model we are manipulating</param>
    /// <returns>true of deleting</returns>
    bool Delete(T entity);

    /// <summary>
    /// allows us to retrieve an entity from a table based off of its primary key
    /// </summary>
    /// <param name="id">the primary key of the entity</param>
    /// <returns>the tuple associated with the primary key</returns>
    T GetById(int id);

    /// <summary>
    /// allows us retrieve all rows of a table in a list data structure
    /// </summary>
    /// <returns>all rows in the table</returns>
    List<T> GetAll();
}
