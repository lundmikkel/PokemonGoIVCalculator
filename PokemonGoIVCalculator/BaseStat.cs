using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using CsvHelper;
using static System.Math;

namespace PokemonGoIVCalculator
{
    public class BaseStat
    {
        private const int NumberOfPokemon = 151;
        private static readonly BaseStat[] BaseStats;
        private static readonly Dictionary<string, int> NameToId;

        static BaseStat()
        {
            BaseStats = new BaseStat[NumberOfPokemon + 1];
            NameToId = new Dictionary<string, int>(NumberOfPokemon);

            // TODO: Fix path
            const string path = "/Users/lundmikkel/RiderProjects/PokemonGoIVCalculator/PokemonGoIVCalculator/Resources/stats.csv";

            var csv = new CsvReader(File.OpenText(path));
            while (csv.Read())
            {
                var name = csv.GetField<string>("Nickname");
                var id = csv.GetField<int>("Id");
                var hp = csv.GetField<int>("Hp");
                var attack = csv.GetField<int>("Attack");
                var defense = csv.GetField<int>("Defense");
                var specialAttack = csv.GetField<int>("Special attack");
                var specialDefense = csv.GetField<int>("Special defense");
                var speed = csv.GetField<int>("Speed");
                var family = csv.GetField<string>("Family");
                var evolutions = csv.GetField<string>("Evolutions").Split(';').Select(s => int.Parse(s));
                var requiredCandyToEvolve = csv.GetField<int>("Candy to evolve");

                BaseStats[id] = new BaseStat(name, id, hp, attack, defense, specialAttack, specialDefense, speed, family, evolutions, requiredCandyToEvolve);
                NameToId.Add(name.ToLower(), id);
            }
        }

        private BaseStat(string name, int id, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed, string family, IEnumerable<int> evolutions, int requiredCandyToEvolve)
        {
            Name = name;
            Id = id;
            Hp = hp;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            Family = family;
            Evolutions = evolutions;
            RequiredCandyToEvolve = requiredCandyToEvolve;
        }

        public string Name { get; }
        public int Id { get; }
        public int Hp { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int SpecialAttack { get; }
        public int SpecialDefense { get; }
        public int Speed { get; }
        public int BaseAttack => (int) (2 * Round(Sqrt(Attack) * Sqrt(SpecialAttack) + Sqrt(Speed)));
        public int BaseDefense => (int) (2 * Round(Sqrt(Defense) * Sqrt(SpecialDefense) + Sqrt(Speed)));
        public int BaseStamina => 2 * Hp;
        public string Family { get; }
        public IEnumerable<int> Evolutions { get; }
        public int RequiredCandyToEvolve { get; }

        public static BaseStat GetStatForPokemon(int id)
        {
            Contract.Requires(1 <= id && id <= NumberOfPokemon);

            return BaseStats[id];
        }

        public static string GetNameFromId(int id) => GetStatForPokemon(id).Name;

        public static int GetIdFromName(string name) => NameToId[name];

        public static BaseStat GetStatForPokemon(string name)
        {
            Contract.Requires(PokemonWithNameExists(name), "No Pokémon with that name exists! Did you spell it correctly?");

            return GetStatForPokemon(NameToId[name.ToLower()]);
        }

        public static bool PokemonWithNameExists(string name) => NameToId.ContainsKey(name.ToLower());
    }
}