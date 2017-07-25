using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.API.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {

        }

        public DbSet<Pokemon> DbPokemon { get; set; }
        public DbSet<Move> DbMove { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().ToTable("Pokemon");
            modelBuilder.Entity<Move>().ToTable("Move");
        }
    }
}
