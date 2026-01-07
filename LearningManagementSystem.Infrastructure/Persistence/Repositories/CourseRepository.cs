using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c=>c.Instractor)
                .ToListAsync();
        }
        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses
                .Include(c=>c.Instractor)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Course entity)
        {
            _context.Courses.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
        public async Task<Course?> GetCourseByInstractorAsync(Guid instractorId)
        {
            return await _context.Courses
                .Include(c => c.Instractor)
                .SingleOrDefaultAsync(c => c.InstractorId == instractorId);
        }
        public async Task<Course?> GetCourseByTitleAsync(string title)
        {
            return await _context.Courses
                .SingleOrDefaultAsync(c => c.Title == title);
        }
        public async Task<List<Course>> GetCoursesByStatusAsync(CourseStatus status)
        {
            return await _context.Courses
                .Where(c => c.Status == status)
                .ToListAsync();
        }
        public async Task PublishCourseAsync(Guid courseId)
        {
            var course = await GetByIdAsync(courseId);
         
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with Id {courseId} not found.");
            }
            course.Status = CourseStatus.Published;
            await _context.SaveChangesAsync();

        }

    }
}
