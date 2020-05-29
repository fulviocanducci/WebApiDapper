using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDapper.Models;
using WebApiDapper.Repositories;

namespace WebApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        public TodoRepositoryAbstract TodoRepository { get; }

        public TodosController(TodoRepositoryAbstract todoRepositoryAbstract)
        {
            TodoRepository = todoRepositoryAbstract;
        }

        [HttpGet]
        public async Task<IEnumerable<Todos>> Get()
        {
            return await TodoRepository.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Todos> Get(int id)
        {
            return await TodoRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todos value)
        {
            await TodoRepository.InsertAsync(value);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Todos value)
        {
            if (await TodoRepository.UpdateAsync(value))
            {
                return Ok(new { Status = "Change model", Todos = value });
            }
            return BadRequest(new { Status = "No updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await TodoRepository.RemoveAsync(id))
            {
                return Ok(new { Status = "Ok deleted" });
            }
            return BadRequest(new { Status = "Not found" });
        }
    }
}
