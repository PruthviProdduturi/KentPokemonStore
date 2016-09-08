using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStoreTest
{
    [TestClass]
    public class StoreUnitTest
    {
        /// <summary>
        /// Example One passing number of pokemons bought
        /// </summary>
        [TestMethod]
        public void ExampleOne()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(1, 0, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(6.00, result);
        }
        [TestMethod]
        public void ExampleTwo()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(2, 0, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(12.00, result);
        }
        [TestMethod]
        public void ExampleThree()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(1, 1, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(9.90, result);
        }
        [TestMethod]
        public void ExampleFour()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(2, 2, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(19.80, result);
        }
        [TestMethod]
        public void ExampleFive()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(3, 3, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(29.70, result);
        }
        [TestMethod]
        public void ExampleSix()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(2, 1, 0); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(15.90, result);
        }
        [TestMethod]
        public void ExampleSeven()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(1, 1, 1); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(12.80, result);
        }
        [TestMethod]
        public void ExampleEight()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(2, 1, 1); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(18.80, result);
        }

        /// <summary>
        /// Number of Pokemons : Pikachu =7 , Squirtle =3 , Charmander =1
        /// Actual Total Price : 39.00 $
        /// Discounted Price : 56.60 $ (20% dicount 12.80$ + 10% Discount 19.80$ + No Discount 24$)
        /// </summary>
        [TestMethod]
        public void SelfExample1()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(7, 3, 1); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(56.6, result);
        }

        /// <summary>
        /// Number of Pokemons : Pikachu =4 , Squirtle =2 , Charmander =1
        /// Actual Total Price : 39.00 $
        /// Discounted Price : 34.70 $ (20% dicount 12.80$ + 10% Discount 9.90$ + No Discount 12$)
        /// </summary>
        [TestMethod]
        public void SelfExample2()
        {
            PokemonStoreForm poke = new PokemonStoreForm();
            double result = poke.PriceCalculator(4, 2, 1); // Pikachu,Squirtle,Charmander
            Assert.AreEqual(34.70, result);
        }
    }
}
