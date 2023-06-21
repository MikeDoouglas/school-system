
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.Repositories.Interfaces;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _repository;

        public SchoolController(ISchoolRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SchoolModel>>> List()
        {
            List<SchoolModel> schools = await _repository.List();
            return Ok(schools);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolModel>> Get(int id)
        {
            SchoolModel schoolModel = await _repository.FindOne(id);
            return Ok(schoolModel);
        }

        [HttpPost]
        public async Task<ActionResult<SchoolModel>> Create(SchoolModel schoolInput)
        {
            SchoolModel school = await _repository.Create(schoolInput);
            return Ok(school);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SchoolModel>> Update([FromBody] SchoolModel schoolInput, int id)
        {
            schoolInput.Id = id;
            SchoolModel school = await _repository.Update(schoolInput, id);
            return Ok(school);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _repository.Delete(id);
            return Ok(deleted);
        }
    }
}
