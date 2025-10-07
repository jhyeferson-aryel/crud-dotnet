// src/UserCRUD.Application/Interfaces/IUserRepository.cs

using UserCRUD.Domain.Entities;

namespace UserCRUD.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}