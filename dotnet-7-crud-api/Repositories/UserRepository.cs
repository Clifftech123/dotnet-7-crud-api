namespace WebApi.Repositories;

using Dapper;
using dotnet_7_crud_api.Data;
using dotnet_7_crud_api.Entitiles;
using dotnet_7_crud_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Users
        """;
        return await connection.QueryAsync<User>(sql);
    }


     // Get user by id
private const string GetByIdSql = "SELECT * FROM Users WHERE Id = @id";

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    public async Task<User?> GetById(int id)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    {
    using var connection = _context.CreateConnection();
    try
    {
        return await connection.QuerySingleOrDefaultAsync<User>(GetByIdSql, new { id });
    }
    catch (Exception)
    {
            // Log the exception, return null, or rethrow, depending on your application's needs
            throw ;
    }
}

    // Get user by email
#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    public async Task<User?> GetByEmail(string email)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Users 
            WHERE Email = @email
        """;
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
    }

    // Create user
    public async Task Create(User user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Users (Title, FirstName, LastName, Email, Role, PasswordHash)
            VALUES (@Title, @FirstName, @LastName, @Email, @Role, @PasswordHash)
        """;
        await connection.ExecuteAsync(sql, user);
    }

    // Update user
    public async Task Update(User user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Users 
            SET Title = @Title,
                FirstName = @FirstName,
                LastName = @LastName, 
                Email = @Email, 
                Role = @Role, 
                PasswordHash = @PasswordHash
            WHERE Id = @Id
        """;
        await connection.ExecuteAsync(sql, user);
    }

    // Delete user
    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Users 
            WHERE Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
}