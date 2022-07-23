using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Models.Entites;
using ToDoListApi.Repositories;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasRepository repos;
        public TarefasController(ITarefasRepository _repos)
        {
            repos = _repos;
        }
        [HttpGet("{Id}")]
        public IActionResult Get( [FromRoute]TarefaId tarefa)
        {
            var tarefas_db = repos.Read(tarefa.Id);
            return Ok(tarefas_db);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PostTarefa tarefas)
        {
            if (repos.Create(tarefas))
                return Ok();

            return BadRequest();
        }
       [HttpPut]
       public IActionResult Put(PutTarefas tarefas)
        {
            if(repos.Update(tarefas))
                return(Ok());
            return BadRequest();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] TarefaId tarefas)
        {
            if (repos.Delete(tarefas.Id))
                return Ok();

            return BadRequest();
        }
    }
}
