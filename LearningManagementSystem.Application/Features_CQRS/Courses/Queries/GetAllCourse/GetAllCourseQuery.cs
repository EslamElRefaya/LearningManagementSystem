using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Queries.GetAllCourse
{
    public class GetAllCourseQuery : IRequest<List<DetailsCourseDto>>
    {
    }
}
