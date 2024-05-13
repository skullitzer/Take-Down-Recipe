using Final_Project;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseUser
{
    SQLiteAsyncConnection _database;

    public DatabaseUser(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<User>().Wait();
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _database.Table<User>().ToListAsync();
    }

    public Task<User> GetUserByUsernameAsync(string username)
    {
        return _database.Table<User>()
                        .Where(u => u.Username == username)
                        .FirstOrDefaultAsync();
    }

    public Task<int> SaveUserAsync(User user)
    {
        if (user.Id != 0)
        {
            return _database.UpdateAsync(user);
        }
        else
        {
            return _database.InsertAsync(user);
        }
    }
}
