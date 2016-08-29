using System;
using NUnit.Framework;
using static PokemonGoIVCalculator.Value;
using static PokemonGoIVCalculator.Tests.IndividualValueConstraint;

namespace PokemonGoIVCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Bulbasaur_15_15_15()
        {
            var pokemon = new Pokemon(
                "bulbasaur",
                1,
                321,
                45,
                10.5f,
                PokemonTotalRange.Great,
                All,
                IndividualValueRange.Great,
                new IndividualValueSet(15, 15, 15)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Squirtle_0_11_11()
        {
            var pokemon = new Pokemon(
                "Squirtle",
                7,
                541,
                62,
                22f,
                PokemonTotalRange.Bad,
                Stamina | Defense,
                IndividualValueRange.Average,
                new IndividualValueSet(0, 11, 11)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Bulbasaur_10_15_14()
        {
            var pokemon = new Pokemon(
                "Bulbasaur",
                1,
                587,
                62,
                20f,
                PokemonTotalRange.Great,
                Defense,
                IndividualValueRange.Great,
                new IndividualValueSet(10, 15, 14)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Charmander_12_14_10()
        {
            var pokemon = new Pokemon(
                "Charmander",
                4,
                284,
                38,
                11f,
                PokemonTotalRange.Good,
                Defense,
                IndividualValueRange.Great,
                new IndividualValueSet(12, 14, 10)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Blastoise_0_7_2()
        {
            var pokemon = new Pokemon(
                "Blastoise",
                9,
                601,
                65,
                9.5f,
                PokemonTotalRange.Bad,
                Defense,
                IndividualValueRange.Bad,
                new IndividualValueSet(0, 7, 2)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Pikachu_4_10_15()
        {
            var pokemon = new Pokemon(
                "Pikachu",
                25,
                320,
                42,
                14f,
                PokemonTotalRange.Average,
                Stamina,
                IndividualValueRange.Great,
                new IndividualValueSet(4, 10, 15)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void Primeape_8_14_1()
        {
            var pokemon = new Pokemon(
                "Primeape",
                57,
                729,
                67,
                15f,
                PokemonTotalRange.Average,
                Defense,
                IndividualValueRange.Good,
                new IndividualValueSet(8, 14, 1)
            );

            Assert.That(pokemon, HasValidIndicidualValues());
        }

        [Test]
        public void VulpixEvolve()
        {
            var baseStats = BaseStat.GetStatForPokemon("Ninetales");
            var attack = baseStats.BaseAttack + 12;
            var defense = baseStats.BaseDefense + 12;
            var stamina = baseStats.BaseStamina + 12;
            var level = 20f;

            var cp = Calculator.ComputeCp(attack, defense, stamina, level);
            var hp = Calculator.ComputeHp(stamina, level);

            var stage = new Stage("Ninetales", cp, hp, level);

            Console.WriteLine(stage);
        }
    }
}