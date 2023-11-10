using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactwithApiCrud.Models;

namespace ReactwithApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudents(Student objstudent)
        {

            _studentDbContext.Student.Add(objstudent);
          await _studentDbContext.SaveChangesAsync();
            return objstudent;
                
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]

        public async Task<Student> UpdateStudents(Student objstudent)
        {
         _studentDbContext.Entry(objstudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objstudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a=false;
            var student = _studentDbContext.Student.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State= EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a= false;
            }
            return a;   
        }
    }
}
