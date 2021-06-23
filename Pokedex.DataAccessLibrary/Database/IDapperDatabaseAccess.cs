using Pokedex.DataAccessLibrary.Models;
using System.Collections.Generic;

namespace Pokedex.DataAccessLibrary.Database
{
    public interface IDapperDatabaseAccess
    {
        Pokemon AddPokemon(Pokemon pokemon);
        void DeletePokemonById(int id);
        bool DoesPokemonIdExists(int id);
        bool DoesPokemonNameExists(string name);
        List<Pokemon> GetAllPokemons();
        Pokemon GetPokemonById(int id);
        Pokemon UpdatePokemon(Pokemon pokemon);
    }
}