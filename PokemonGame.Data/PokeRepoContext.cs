using PokemonGame.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame.Data
{
    public class PokeRepoContext : DbContext
    {
        public DbSet<BasePokemon> DbPokemon { get; set; }

        public PokeRepoContext()
        {
            
        }
    }



}
