using ApplicationCore.Commands;
using ApplicationCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var query = new GetAllPersonsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Person/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var query = new GetPersonByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"Person with Id = {id} not found.");

            return Ok(result);
        }


        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPersonById), new { id = result }, result);
        }

        // PUT: api/Person/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] UpdatePersonCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(command);
            return NoContent(); // 204 No Content
        }

        // DELETE: api/Person/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var command = new DeletePersonCommand { Id = id };
            await _mediator.Send(command);
            return NoContent(); // 204 No Content
        }
    }
}
