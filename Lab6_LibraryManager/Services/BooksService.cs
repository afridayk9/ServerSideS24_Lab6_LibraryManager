using Microsoft.EntityFrameworkCore;
using TableModels;

namespace Lab6_LibraryManager.Services;

/// <summary>
/// a service that inherits its functionality from the Generic service
/// where the generic service takes in the table model we wish to manipulate
/// </summary>
public class BooksService : GenericCrudService<Books>
{
    private readonly ApplicationDbContext _context;
    public BooksService(ApplicationDbContext options) : base(options) 
    { 
        _context = options;
    }

    public async Task<bool> CheckOut(int bookId, int userId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null || book.CheckedOutBy != null)
        {
            return false;
        }

        book.CheckedOutBy = userId;
        var saveResult = await _context.SaveChangesAsync();
        return saveResult > 0;
    }

    public async Task<bool> Return(int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null || book.CheckedOutBy == null)
        {
            return false;
        }

        book.CheckedOutBy = null;
        var saveResult = await _context.SaveChangesAsync();
        return saveResult > 0;
    }
}
