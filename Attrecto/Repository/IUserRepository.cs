using Attrecto.Data;

namespace Attrecto.Respositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        List<User> GetAdultUsersAsync();
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> UpdateAsync(int id, User data);
    }
}