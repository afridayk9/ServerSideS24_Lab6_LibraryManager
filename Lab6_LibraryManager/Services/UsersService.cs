using Microsoft.EntityFrameworkCore;
using TableModels;

namespace Lab6_LibraryManager.Services;

/// <summary>
/// a service that inherits its functionality from the Generic service
/// where the generic service takes in the table model we wish to manipulate
/// </summary>
public class UsersService : GenericCrudService<Users>
{
    private readonly ApplicationDbContext _context;
    
    public UsersService(ApplicationDbContext options) : base(options) 
    { 
        _context = options;
    }

    public async Task<Users> GetByUsername(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
    }

    public async Task<List<Books>> GetCheckedOutBooks(int userId)
    {
        return await _context.Books.Where(book => book.CheckedOutBy == userId).ToListAsync();
    }

    public async Task<bool> Delete(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || _context.Books.Any(book => book.CheckedOutBy == userId))
        {
            return false;
        }

        _context.Users.Remove(user);
        var saveResult = await _context.SaveChangesAsync();
        return saveResult > 0;
    }


}
