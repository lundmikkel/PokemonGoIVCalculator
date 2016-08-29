namespace PokemonGoIVCalculator
{
    public static class PokemonTotalRange
    {
        public static Range Great { get; } = new Range(37, 45);
        public static Range Good { get; } = new Range(30, 36);
        public static Range Average { get; } = new Range(23, 29);
        public static Range Bad { get; } = new Range(0, 22);
        public static Range Unknown { get; } = new Range(0, 45);
    }
}