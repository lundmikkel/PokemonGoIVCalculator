using System.Collections.Generic;

namespace PokemonGoIVCalculator
{
    /// <summary>Represents a given Pokémon that can be powered up and/or evolved.</summary>
    public class Pokemon
    {
        // Given nickname (null if not set)
        private string _nickname;
        public string Nickname {
            get { return _nickname ?? DefaultName; }
            set { _nickname = DefaultName.Equals(value) ? null : value; }
        }

        private string DefaultName => BaseStat.GetNameFromId(CurrentStage.PokemonId);

        public Stage CurrentStage { get; }
        public List<Stage> Stages { get; } = new List<Stage>();

        public Range OverallRange { get; }
        public Value BestValues { get; }
        public Range BestValuesRange { get; }
        public IndividualValueSet IndividualValueSet { get; }

        public Pokemon(string nickname, int id, int cp, int maxHp, float level, Range overallRange, Value bestValues, Range bestValuesRange, IndividualValueSet individualValueSet = null)
        {
            CurrentStage = new Stage(id, cp, maxHp, level);
            Nickname = nickname;
            Stages.Add(CurrentStage);
            OverallRange = overallRange;
            BestValues = bestValues;
            BestValuesRange = bestValuesRange;
            IndividualValueSet = individualValueSet;
        }

        public IEnumerable<IndividualValueSet> FindPossibleIndividualValues()
            => Calculator.FindPossibleIndividualValues(Nickname, CurrentStage, OverallRange, BestValues, BestValuesRange);

        public override string ToString() => $"{Nickname} - {CurrentStage} - {IndividualValueSet}";
    }
}