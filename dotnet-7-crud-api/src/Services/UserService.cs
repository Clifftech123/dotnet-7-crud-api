namespace dotnet_7_crud_api.Services
{
    using AutoMapper;
    using BCrypt.Net;
    using dotnet_7_crud_api.Entitiles;
    using dotnet_7_crud_api.Helpers;
    using dotnet_7_crud_api.Models.Users;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using dotnet_7_crud_api.Data;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }


//   get bt id
        public async Task<User> GetById(Guid id)
{
    try
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            Console.WriteLine($"User with id {id} not found");
            throw new KeyNotFoundException("User not found");
        }

        return user;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while getting user with id {id}: {ex.Message}");
        throw;
    }
}
        public async Task Create(CreateRequest model)
        {
            if (model.Email != null)
            {
                ValidateEmail(model.Email);
            }
            var user = _mapper.Map<User>(model);
            if (model.Password != null)
            {
                user.PasswordHash = HashPassword(model.Password);
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, UpdateRequest model)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found");
            if (!string.IsNullOrEmpty(model.email) && user.Email != model.email)
            {
                if (model.email != null)
                {
                    ValidateEmail(model.email);
                }
            }
            if (!string.IsNullOrEmpty(model.password))
            {
                user.PasswordHash = HashPassword(model.password);
            }
            _mapper.Map(model, user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



       public async Task Delete(Guid id)
{
    var user = await _context.Users.FindAsync(id);
    if (user != null)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    else
    {
        throw new Exception("User not found");
    }
}

        private void ValidateEmail(string email)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                throw new AppException($"User with the email '{email}' already exists");
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.HashPassword(password);
        }
    }
}
