using NUnit.Framework;
using PokemonGoIVCalculator;

namespace PokemonGoIVCalculator.Tests
{
    [TestFixture]
    public class PokemonStatTests
    {
        [Test]
        public void CheckBulbasaur()
        {
            var bulbasaur = "bulbasaur";
            var stats = BaseStat.GetStatForPokemon(bulbasaur);

            Assert.That(stats.Name, Is.EqualTo("Bulbasaur"));
            Assert.That(stats.Id, Is.EqualTo(1));
            Assert.That(stats.Hp, Is.EqualTo(45));
            Assert.That(stats.Attack, Is.EqualTo(49));
            Assert.That(stats.Defense, Is.EqualTo(49));
            Assert.That(stats.SpecialAttack, Is.EqualTo(65));
            Assert.That(stats.SpecialDefense, Is.EqualTo(65));
            Assert.That(stats.Speed, Is.EqualTo(45));
            Assert.That(stats.BaseAttack, Is.EqualTo(126));
            Assert.That(stats.BaseDefense, Is.EqualTo(126));
            Assert.That(stats.BaseStamina, Is.EqualTo(90));
        }

        [Test]
        public void CheckKoffing()
        {
            var stats = BaseStat.GetStatForPokemon("koffing");

            Assert.That(stats.Name, Is.EqualTo("Koffing"));
            Assert.That(stats.Id, Is.EqualTo(109));
            Assert.That(stats.Hp, Is.EqualTo(40));
            Assert.That(stats.Attack, Is.EqualTo(65));
            Assert.That(stats.Defense, Is.EqualTo(95));
            Assert.That(stats.SpecialAttack, Is.EqualTo(60));
            Assert.That(stats.SpecialDefense, Is.EqualTo(45));
            Assert.That(stats.Speed, Is.EqualTo(35));
            Assert.That(stats.BaseAttack, Is.EqualTo(136));
            Assert.That(stats.BaseDefense, Is.EqualTo(142));
            Assert.That(stats.BaseStamina, Is.EqualTo(80));
        }
    }
}


