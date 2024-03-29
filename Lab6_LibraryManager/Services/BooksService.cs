using TableModels;

namespace Lab6_LibraryManager.Services;

/// <summary>
/// a service that inherits its functionality from the Generic service
/// where the generic service takes in the table model we wish to manipulate
/// </summary>
public class BooksService : GenericCrudService<Books>
{
    public BooksService(ApplicationDbContext options) : base(options) { }
}
