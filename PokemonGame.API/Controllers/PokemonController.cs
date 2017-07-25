using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonGame.API.Models;

namespace PokemonGame.API.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        private readonly PokemonContext _context;

        public PokemonController(PokemonContext context)
        {
            _context = context;
        }

        // GET /api/todo
        [HttpGet]
        public IEnumerable<Pokemon> GetAll()
        {
            return _context.DbPokemon.ToList();
        }

        // GET /api/todo/{id}
        [HttpGet("{id}", Name = "GetPokemon")]
        public IActionResult GetByID(long id)
        {
            var item = _context.DbPokemon.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest();
            }

            _context.DbPokemon.Add(pokemon);
            _context.SaveChanges();

            return CreatedAtRoute("GetPokemon", new { id = pokemon.ID }, pokemon);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pokemon pokemon)
        {
            if (pokemon == null || pokemon.ID != id)
            {
                return BadRequest();
            }

            var pokemonToUpdate = _context.DbPokemon.FirstOrDefault(p => p.ID == id);
            if (pokemonToUpdate == null)
            {
                return NotFound();
            }

            pokemonToUpdate.Level = pokemon.Level;
            pokemonToUpdate.Name = pokemon.Name;

            _context.DbPokemon.Update(pokemonToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pokemon = _context.DbPokemon.First(t => t.ID == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.DbPokemon.Remove(pokemon);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
