using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using WebApplication1.models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            student.Id = nextId++;
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Student not found");

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Student not found");

            students.Remove(student);
            return Ok("Deleted successfully");
        }
    }
}
