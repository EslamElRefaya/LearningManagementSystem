using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Infrastructure.Persistence.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _context.lessons
                  .Include(l => l.Course)
                  .AsNoTracking()
                  .ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(Guid id)
        {
            return await _context.lessons
                  .Include(l => l.Course)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Lesson>> GetLessByLessonTypeAsync(LessonType LessonType)
        {
            return await _context.lessons
                .Include(l => l.Course)
                .Where(lt => lt.LessonType == LessonType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonByCourseIdAsync(Guid courseId)
        {
            return await _context.lessons
                 .Include(l => l.Course)
                 .AsNoTracking()
                 .Where(l => l.CourseId == courseId)
                 .ToListAsync();
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _context.lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Lesson lesson)
        {
            _context.Update(lesson);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Lesson lesson)
        {
            _context.lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
