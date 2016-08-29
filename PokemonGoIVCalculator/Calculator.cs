using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using static System.Diagnostics.Contracts.Contract;
using static System.Math;
using static PokemonGoIVCalculator.Value;

namespace PokemonGoIVCalculator
{
    public class Calculator
    {
        private static readonly double[] Multipliers;
        private const float MaxLevel = 40;

        static Calculator()
        {
            var size = (int) (MaxLevel * 2) + 1;
            Multipliers = new double[size];

            // TODO: Fix path
            const string path =
                "/Users/lundmikkel/RiderProjects/PokemonGoIVCalculator/PokemonGoIVCalculator/Resources/multipliers.csv";

            var csv = new CsvReader(File.OpenText(path));
            csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("en-US");

            while (csv.Read()) {
                var level = csv.GetField<float>("Level");
                var multiplier = csv.GetField<double>("Multiplier");

                Multipliers[(int) (level * 2)] = multiplier;
            }
        }


        public static IEnumerable<IndividualValueSet> FindPossibleIndividualValues(string name, Stage stage, Range totalIndividualValuesRange, Value bestValues, Range maxIndividualValueRange)
        {
            var possibleIndividualValues = new List<IndividualValueSet>();

            var baseStat = BaseStat.GetStatForPokemon(name);

            var maxAttack = maxIndividualValueRange.Max;
            var maxDefense = maxIndividualValueRange.Max;
            var maxStamina = maxIndividualValueRange.Max;

            for (var individualAttack = maxAttack; individualAttack >= 0; --individualAttack)
            {
                for (var individualDefense = maxDefense; individualDefense >= 0; --individualDefense)
                {
                    for (var individualStamina = maxStamina; individualStamina >= 0; --individualStamina)
                    {
                        if (!AllowedIndividualValues(totalIndividualValuesRange, bestValues, individualAttack, individualDefense, individualStamina))
                            continue;

                        var attack = baseStat.BaseAttack + individualAttack;
                        var defense = baseStat.BaseDefense + individualDefense;
                        var stamina = baseStat.BaseStamina + individualStamina;

                        var hp = ComputeHp(stamina, stage.Level);
                        var cp = ComputeCp(attack, defense, stamina, stage.Level);

                        if (hp == stage.MaxHp && cp == stage.Cp)
                        {
                            possibleIndividualValues.Add(new IndividualValueSet(individualAttack, individualDefense,
                                individualStamina));
                        }
                    }
                }
            }

            return possibleIndividualValues;
        }

        public static int ComputeCp(int attack, int defense, int stamina, float level)
            => Max(10, (int) (attack * Sqrt(defense) * Sqrt(stamina) * Pow(GetMultiplier(level), 2) / 10));

        public static int ComputeHp(int stamina, float level)
            => Max(10, (int) (stamina * GetMultiplier(level)));

        private static bool AllowedIndividualValues(Range totalIndividualValuesRange, Value bestValues, int attack, int defense, int stamina)
        {
            // Check if the sum of individual values lies within the possible range
            if (!totalIndividualValuesRange.WithinRange(attack + defense + stamina))
                return false;

            if (bestValues != Unknown) {
                if (bestValues.HasFlag(Attack) && (attack < defense || attack < stamina))
                    return false;

                if (bestValues.HasFlag(Defense) && (defense < attack || defense < stamina))
                    return false;

                if (bestValues.HasFlag(Stamina) && (stamina < attack || stamina < defense))
                    return false;

                if ((bestValues.HasFlag(Attack) && bestValues.HasFlag(Defense)) != (attack == defense))
                    return false;

                if ((bestValues.HasFlag(Defense) && bestValues.HasFlag(Stamina)) != (defense == stamina))
                    return false;

                if ((bestValues.HasFlag(Attack) && bestValues.HasFlag(Stamina)) != (attack == stamina))
                    return false;
            }

            return true;
        }

        private static double GetMultiplier(float level)
        {
            Requires(1 <= level && level <= MaxLevel);
            return Multipliers[(int) (level * 2)];
        }
    }
}