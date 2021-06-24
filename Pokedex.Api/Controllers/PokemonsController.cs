using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.DataAccessLibrary.Database;
using Pokedex.DataAccessLibrary.Models;
using System;
using System.Collections.Generic;


namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonsController : ControllerBase
    {
        public IDapperDatabaseAccess _db;

        public PokemonsController(IDapperDatabaseAccess db)
        {
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                    var createdPokemon = _db.AddPokemon(pokemon);
                    return CreatedAtAction(nameof(GetPokemonById), new { id = createdPokemon.Id }, createdPokemon);
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, $"Pokemon with name {pokemon.Name} already exists!");
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Pokemon> EditPokemon(int id, Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                bool exists = _db.DoesPokemonIdExists(id);
                if (exists)
                {
                    return _db.UpdatePokemon(pokemon);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Pokemon with this id does not exists in your pokedex! Go catch him!");
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Pokemon> DeletePokemonm(int id)
        {
            bool exists = _db.DoesPokemonIdExists(id);
            if (exists)
            {
                try
                {
                    _db.DeletePokemonById(id);
                    return Ok("Pokemon deleted from Pokedex!");
                }
                catch(Exception e)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
            return NotFound($"Pokemon with this id does not exists: {id}");
        }

        [HttpGet, Route("counter")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PokemonCounter> PokemonCounter()
        {
            try
            {
                return _db.PokemonCounter();
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

        [HttpGet, Route("searchbyname/{name}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Pokemon> GetPokemonByName(string name)
        {         
            try
            {
                bool exists = _db.DoesPokemonNameExists(name);
                if (exists)
                {
                    return _db.GetPokemonByName(name);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Pokemon {name} does not exists in your pokedex!");
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

        [HttpGet, Route("searchbytype/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Pokemon>> GetPokemonByType(string type)
        {
            try
            {
                var pokemons =  _db.GetPokemonsByType(type);

                if(pokemons.Count == 0)
                {
                    return NotFound();
                }

                return pokemons;
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



    }
}
