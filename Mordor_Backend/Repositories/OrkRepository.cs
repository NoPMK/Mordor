using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mordor_Backend.Models;

namespace Mordor_Backend.Repositories
{
    public class OrkRepository : IOrkRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Ork>> GetAllOrksAsync()
        {
            return await _appDbContext.Orks.Include(ork => ork.Weapons).ToListAsync();
        }

        public async Task SaveOrkAsync(Ork ork)
        {
            _ = await _appDbContext.Orks.AddAsync(ork);
            _ = await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrkAsync(Ork ork)
        {
            _appDbContext.Orks.Remove(ork);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Ork?> GetOrkByIdAsync(int id)
        {
            return await _appDbContext.Orks.FirstOrDefaultAsync(ork => ork.Id == id);
        }
    }
}