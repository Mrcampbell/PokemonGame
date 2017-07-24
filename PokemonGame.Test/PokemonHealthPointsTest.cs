using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGame.Library.Models;
using PokemonGame.Library.Models.Pokemon;
using PokemonGame.Library.Models.Health;

namespace PokemonGame.Test
{
    [TestClass]
    public class PokemonHealthPointsTest
    {
        [TestMethod]
        public void ConstructorWorksCorrectly()
        {
            int testMax = 35;
            HealthPoints HP = new HealthPoints(testMax);
            Assert.AreEqual(testMax, HP.Current);
            Assert.AreEqual(testMax, HP.Max);
        }

        [TestMethod]
        public void NegativeMaxHPInConstructorShouldThrowError()
        {
            try
            {
                HealthPoints HP = new HealthPoints(0);
            } catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }

        [TestMethod]
        public void TestAllIncrementAndDecrementFunctions()
        {
            int testMax = 80;
            HealthPoints HP = new HealthPoints(testMax);

            HP.ReduceEighthOfMax();
            Assert.AreEqual(70, HP.Current);

            HP.ReduceHalfOfMax();
            Assert.AreEqual(30, HP.Current);

            HP.ReduceQuarterOfMax();
            Assert.AreEqual(10, HP.Current);

            HP.ReduceHealthToZero();
            Assert.AreEqual(0, HP.Current);

            HP.ReduceHalfOfMax();
            Assert.AreEqual(0, HP.Current);
        }
    }
}
