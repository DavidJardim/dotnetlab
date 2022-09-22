using Ficha13.Models;
using Ficha13.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService service;

        public ActorController(IActorService service)
        {
            this.service = service;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            return service.GetAll();
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {
            var actor = service.GetById(id);
            if (actor is null)
            {               
                return NotFound($"Id: {id} not found");
            }
            else
            {
                return Ok(actor);
            }            
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}/films")]
        public IEnumerable<Film> GetFilms(short id)
        {
            return service.GetFilms(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] Actor actor)
        {
            var createdActor = service.Create(actor);

            if(createdActor is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(createdActor);
            }            
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(short id, [FromBody] Actor actor)
        {
            var actorToUpdate = service.GetById(id);
            if (actor is not null && actorToUpdate is not null)
            {
                service.Update(id, actor);
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var actor = service.GetById(id);

            if (actor is not null)
            {
                service.DeleteByID(id);
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
