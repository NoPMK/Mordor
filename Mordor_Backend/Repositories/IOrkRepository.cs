using Mordor_Backend.Models;

namespace Mordor_Backend.Repositories
{
    public interface IOrkRepository
    {
        Task DeleteOrkAsync(Ork ork);
        public Task<IEnumerable<Ork>> GetAllOrksAsync();
        Task<Ork?> GetOrkByIdAsync(int id);
        Task SaveOrkAsync(Ork ork);
    }
}