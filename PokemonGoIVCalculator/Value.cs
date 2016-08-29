using System;

namespace PokemonGoIVCalculator
{
    [Flags]
    public enum Value
    {
        Unknown = 0,
        Attack = 1,
        Defense = 2,
        Stamina = 4,
        All = Attack | Defense | Stamina
    }
}