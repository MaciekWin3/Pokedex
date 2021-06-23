using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.DataAccessLibrary.Database;
using Pokedex.DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonController : ControllerBase
    {
        public IDapperDatabaseAccess _db;

        public PokemonController(IDapperDatabaseAccess db)
        {
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Pokemon>> GetPokemons()
        {
            try
            {
                return _db.GetAllPokemons();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Pokemon> GetPokemonById(int id)
        {
            try
            {
                bool exists = _db.DoesPokemonIdExists(id);
                
                if (exists)
                {
                    return _db.GetPokemonById(id);
                }
                else
                {
                    return NotFound($"Pokemon number {id} was not caught yet! Catch 'Em All :)");
                }
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Pokemon> AddPokemonToPokedex(Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool exists = _db.DoesPokemonNameExists(pokemon.Name);
                if (!exists)
                {
                    return _db.AddPokemon(pokemon);
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Pokemon with that name already exists!");
                }
            }
            catch (Exception e)
            {
                //return BadRequest(e.Message);
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }




    }
}
