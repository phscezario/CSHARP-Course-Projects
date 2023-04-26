using Course.API.Business.Entities;
using Course.API.Business.Repositories;
using Course.API.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Course.API.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRpository)
        {
            _courseRepository = courseRpository;
        }

        /// <summary>
        /// This service allows you to create courses.
        /// </summary>
        /// <param name="courseViewModelInput"></param>
        /// <returns>Return code 201 and user course data</returns>
        [SwaggerResponse(statusCode: 201, description: "Course successfully registered.")]
        [SwaggerResponse(statusCode: 401, description: "Not authorized")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            Courses course = new Courses();
            course.Name = courseViewModelInput.Name;
            course.Description = courseViewModelInput.Description;

            var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            course.UserId = userCode;

            _courseRepository.Add(course);
            _courseRepository.Commit();

            return Created("", courseViewModelInput);
        }

        /// <summary>
        /// This service allows you to get all active user cuorses.
        /// </summary>
        /// <returns>Return status ok and user course data</returns>
        [SwaggerResponse(statusCode: 200, description: "Success in obtaining courses")]
        [SwaggerResponse(statusCode: 401, description: "Not authorized")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var courses = _courseRepository.GetByUser(userCode).Select(s => new CourseViewModelOutput()
            {
                Name = s.Name,
                Description = s.Description,
                Login = s.User.Login
            }) ;

            return Ok(courses);
        }
    }
}
