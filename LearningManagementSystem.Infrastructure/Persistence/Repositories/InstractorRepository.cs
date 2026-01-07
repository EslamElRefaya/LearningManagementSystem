using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Infrastructure.Persistence.Repositories
{
    public class InstractorRepository : IInstractorRepository
    {
        private readonly ApplicationDbContext _context;

        public InstractorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Instractor>> GetAllAsync()
        {
            return await _context.Instractors.AsNoTracking().ToListAsync();
        }

        public async Task<Instractor?> GetByIdAsync(Guid instractorId)
        {
            return await _context.Instractors
                .AsNoTracking()
                .SingleOrDefaultAsync(i => i.Id == instractorId);
        }

        public async Task<Instractor?> GetInstractorByFullNameAsync(string instractorName)
        {
            return await _context.Instractors
                            .AsNoTracking()
                            .Where(i => i.FullName == instractorName)
                            .FirstOrDefaultAsync();
        }
        public async Task AddAsync(Instractor instractor)
        {
            await _context.AddAsync(instractor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Instractor instractor)
        {
            _context.Update(instractor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Instractor instractor)
        {
            _context.Remove(instractor);
            await _context.SaveChangesAsync();
        }

    }
}
