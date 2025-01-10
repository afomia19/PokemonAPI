using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.Services;

namespace PokemonAPI.Contollers
{ 
    // https://localhost:portnumber/api/pokemon
    [ApiController]
    [Route("api/[Controller]")] //route it to the controller of the pokemon
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        // GET: https://localhost:portnumber/api/pokemon
        [HttpGet]
        public async Task<ActionResult> GetAllPokemon()
        {
            try
            {
                return Ok(await _pokemonService.GetAllPokemon());
            }
            catch (Exception)
            {
                return NotFound("No pokemons found");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPokemonById(string id)
        {
            try
            {
                return Ok(await _pokemonService.GetPokemonById(id));
            }
            catch (Exception)
            {
                return NotFound("pokemon with this id is not found");
            }
        }

        [HttpGet("find/{name}")]
        public async Task<ActionResult> GetPokemonByName(string name)
        {
            try
            {
                return Ok(await _pokemonService.GetPokemonByName(name));
            }
            catch
            {
                return NotFound("Pokemon by this name is not found");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon pokemon)
        {
            try
            {
                return Ok(await _pokemonService.AddPokemon(pokemon));
            }
            catch
            {
                return BadRequest("bad format");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePokemonById(string id, Pokemon pokemon)
        {
            try
            {
                return Ok(await _pokemonService.UpdatePokemonById(id, pokemon));
            }
            catch
            {
                return NotFound("Id not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemonById(string id)
        {
            try
            {
                return Ok(await _pokemonService.DeletePokemonById(id));
            }
            catch
            {
                return NotFound("Id not found");
            }
        }


    }
}


