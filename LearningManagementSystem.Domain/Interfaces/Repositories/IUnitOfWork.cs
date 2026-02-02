namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        //ICourseRepository Courses { get; }

        //IInstractorRepository Instructors { get; }
        // IEnrollmentRepository Enrollments { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync(); // method abstract
        Task CommitAsync();
        Task RollbackAsync();
       
    }
}
