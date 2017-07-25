using PokemonGame.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PokemonContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.DbPokemon.Any())
            {
                return; // db has already been seeded
            }

            var tackle  = new Move() { Name = "Tackle", Power = 35 };
            var scratch = new Move() { Name = "Scratch", Power = 35 };
            var ember   = new Move() { Name = "Ember", Power = 35 };

            var seedMoves = new Move[]
            {
                tackle,
                scratch,
                ember
            };
            foreach (Move m in seedMoves)
            {
                context.DbMove.Add(m);
            }
            context.SaveChanges();




            var seedPokemon = new Pokemon[]
            {
                new Pokemon{BreedNumber = 1, Name = "Bulbasaur", Level = 5, Move1ID = context.DbMove.First(m => m.Name == "Scratch").ID },
                new Pokemon{BreedNumber = 4, Name = "Squirtle", Level = 5 },
                new Pokemon{BreedNumber = 7, Name = "Charmander", Level = 5 },
            };

            foreach (Pokemon p in seedPokemon)
            {
                context.DbPokemon.Add(p);
            }

            context.SaveChanges();
        }
    }
}
