namespace PokemonGoIVCalculator
{
    // Closed interval
    public class Range
    {
        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public Range(int value)
        {
            Min = Max = value;
        }

        public int Min { get; }
        public int Max { get; }

        public bool WithinRange(double value) => Min <= value && value <= Max;
    }
}