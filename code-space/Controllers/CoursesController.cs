using AutoMapper;
using code_space.Auth;
using code_space.Models;
using Domain.Models;
using Domain.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace code_space.Controllers
{
    //[AllowAnonymous]
    //[Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;
        public CoursesController(ApplicationDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        public async Task<IActionResult> GetCourses(TableRequest request)
        {
            var query = db.Courses.AsQueryable(); // Add Where Filters Here.
            var resultsTask = query.OrderBy(p => p.Id).Skip(request.Offset).Take(request.Limit).ToArrayAsync();
            var countTask = query.CountAsync();
            var courses = await resultsTask;
            //var courses = await db.Courses.ToListAsync();
            var result = new ResponseType() {
                Data = _mapper.Map<List<Course>, List<CourseDto>>(courses.ToList()),
                TotalCount = await countTask
            };
            return Ok(result); 
        }


    }
}
