namespace PokemonGoIVCalculator
{
    public class IndividualValueRange
    {
        public static Range Great { get; } = new Range(15);
        public static Range Good { get; } = new Range(13, 14);
        public static Range Average { get; } = new Range(8, 12);
        public static Range Bad { get; } = new Range(0, 7);
        public static Range Unknown { get; } = new Range(0, 15);
    }
}