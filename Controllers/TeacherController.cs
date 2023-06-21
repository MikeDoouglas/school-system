
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SchoolSystem.Models;
using SchoolSystem.Repositories.Interfaces;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherModel>>> List()
        {
            List<TeacherModel> teachers = await _repository.List();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherModel>> Get(int id)
        {
            TeacherModel teacherModel = await _repository.FindOne(id);
            return Ok(teacherModel);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherModel>> Create(TeacherModel teacherInput)
        {
            TeacherModel teacher = await _repository.Create(teacherInput);
            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherModel>> Update([FromBody] TeacherModel teacherInput, int id)
        {
            teacherInput.Id = id;
            TeacherModel teacher = await _repository.Update(teacherInput, id);
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
