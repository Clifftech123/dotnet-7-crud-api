using dotnet_7_crud_api.Entitiles;
using dotnet_7_crud_api.Models.Users;
using System;

namespace dotnet_7_crud_api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Create(CreateRequest model);
        Task Update(Guid id, UpdateRequest model);
        Task Delete(Guid id);
    }
}