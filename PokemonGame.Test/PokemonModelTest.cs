using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Library.Models;
using PokemonGame.Library.Models.Pokemon;

namespace PokemonGame.Test
{
    [TestClass]
    public class PokemonModelTest
    {
        [TestMethod]
        public void NameIsSetCorrectly()
        {
            BasePokemon p = new Pikachu(15);

            Assert.AreEqual("Pikachu", p.Name);
        }

        [TestMethod]
        public void PokemonStatsAssignedSuccessfully()
        {
            BasePokemon p = new Pikachu(15);
            Assert.AreEqual(p.Stat.HP, p.HP.Max);

        }
    }
}
