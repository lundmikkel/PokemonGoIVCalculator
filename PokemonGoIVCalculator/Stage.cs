using static System.Diagnostics.Contracts.Contract;

namespace PokemonGoIVCalculator
{
    public class Stage
    {
        public Stage(string name, int cp, int maxHp, float level) : this(BaseStat.GetIdFromName(name), cp, maxHp, level)
        {
            Requires(name != null);
            Requires(cp >= 10);
            Requires(maxHp >= 10);
            Requires(level * 2 == (int) (level * 2));
        }

        public Stage(int id, int cp, int maxHp, float level)
        {
            Requires(cp >= 10);
            Requires(maxHp >= 10);
            Requires(level * 2 == (int) (level * 2));

            PokemonId = id;
            Cp = cp;
            MaxHp = maxHp;
            Level = level;
        }

        public int PokemonId { get; }
        public int Cp { get; }
        public int MaxHp { get; }
        public float Level { get; }

        public override string ToString() => $"CP: {Cp}, max HP: {MaxHp}, level: {Level:N1}";
    }
}