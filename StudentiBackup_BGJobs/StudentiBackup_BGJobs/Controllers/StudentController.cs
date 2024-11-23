using Microsoft.AspNetCore.Mvc;
using StudentiBackup_BGJobs.Models;

namespace StudentiBackup_BGJobs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController  : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentController(StudentDbContext context)
        {
            this.context = context;
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> RegisterStudent(Student student)
        {
            if(student == null)
            {
                return BadRequest();
            }

            var newStudent = new Student
            {
                ImePrezime = student.ImePrezime,
                DatumRodjenja = student.DatumRodjenja,
                Index = student.Index,
                Smer = student.Smer
            };

            await context.Students.AddAsync(newStudent);
            await context.SaveChangesAsync();

            return Ok(newStudent);

        }
    }
}
