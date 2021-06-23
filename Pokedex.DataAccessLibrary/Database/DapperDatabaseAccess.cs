using Dapper;
using Microsoft.Extensions.Configuration;
using Pokedex.DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Pokedex.DataAccessLibrary.Database
{
    public class DapperDatabaseAccess : IDapperDatabaseAccess
    {
        private IDbConnection db;
        public DapperDatabaseAccess(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("Pokedex"));
        }

        public List<Pokemon> GetAllPokemons()
        {
            var sql = "Select * from Pokemons";
            return db.Query<Pokemon>(sql).ToList();
        }

        public Pokemon GetPokemonById(int id)
        {
            var sql = "Select * from Pokemons where id = @id";
            return db.Query<Pokemon>(sql, new { @id = id }).Single();
        }

        public Pokemon AddPokemon(Pokemon pokemon)
        {

            DateTime Date = DateTime.Now;

            pokemon.Added = Date;
            pokemon.Modified = Date;

            var sql = "Insert into Pokemons values(@Name, @Type, @Abilities, @Hp, @Attack, @SpecialAttack, @Defense, @SpecialDefense, @Speed, @Height, @Weight, @Description, @PicturePath, @Added, @Modified)";

            var record = db.Query(sql, new
            {
                pokemon.Name,
                pokemon.Type,
                pokemon.Abilities,
                pokemon.Hp,
                pokemon.Attack,
                pokemon.SpecialAttack,
                pokemon.Defense,
                pokemon.SpecialDefense,
                pokemon.Speed,
                pokemon.Height,
                pokemon.Weight,
                pokemon.Description,
                pokemon.PicturePath,
                pokemon.Added,
                pokemon.Modified
            });

            return pokemon;
        }

        public Pokemon UpdatePokemon(Pokemon pokemon)
        {
            var sql = @"Update Pokemons set Name = @Name, Type = @Type, Abilities = @Abilities, Hp = @Hp, Attack = @Attack, SpecialAttack = @SpecialAttack,
                        Defense = @Defense, SpecialDefense = @SpecialDefense, Speed = @Speed, Height = @Height, Weight = @Weight, Description = @Description,
                        PicturePath = @PicturePath, Added = @Added, Modified = @Modified where Id = @Id";

            db.Execute(sql, pokemon);
            return pokemon;

        }

        public void DeletePokemonById(int id)
        {
            var sql = "Delete from Pokemons where id = @id";
            db.Execute(sql, new { id });
        }

        public bool DoesPokemonIdExists(int id)
        {
            var sql = "Select count(1) from Pokemons where id = @id";
            return db.ExecuteScalar<bool>(sql, new { id });
        }

        public bool DoesPokemonNameExists(string name)
        {
            var sql = "Select count(1) from Pokemons where name = @name";
            return db.ExecuteScalar<bool>(sql, new { name });
        }

    }
}
