using dotnet_7_crud_api.Entitiles;

namespace dotnet_7_crud_api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
          Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task Create(User user);
    Task Update(User user);
    Task Delete(int id);
    }
}
