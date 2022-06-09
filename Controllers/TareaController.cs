using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        readonly private ITareasServices tareasService; 
        public TareaController(ITareasServices tareasService)
        {
            this.tareasService = tareasService;
        }        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareasService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareasService.SaveAsync(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Tarea tarea)
        {
            tareasService.UpdateAsync(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareasService.DeleteAsync(id);
            return Ok();
        }
    }
}