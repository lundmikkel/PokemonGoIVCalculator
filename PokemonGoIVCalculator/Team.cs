using System;
using static PokemonGoIVCalculator.Team;

namespace PokemonGoIVCalculator
{
    public enum Team
    {
        Mystic,
        Valor,
        Instinct
    }

    public static class TeamExtensions
    {
        public static string[] GetOverallStatement(Team team)
        {
            switch (team)
            {
                case Mystic:
                    return new[] {
                        "Overall, your Pokemon is a wonder! What a breathtaking Pokemon!",
                        "Overall, your Pokemon has certainly caught my attention.",
                        "Overall, your Pokemon is above average.",
                        "Overall, your Pokemon is not likely to make much headway in battle.",
                    };

                case Valor:
                    return new[] {
                        "Overall, your Pokemon simply amazes me. It can accomplish anything!",
                        "Overall, your Pokemon is a strong Pokemon. You should be proud!",
                        "Overall, your Pokemon is a decent Pokemon",
                        "Overall, your Pokemon may not be great in battle, but I still like it!",
                    };

                case Instinct:
                    return new[] {
                        "Overall, your Pokemon looks like it can really battle with the best of them!",
                        "Overall, your Pokemon is really strong!",
                        "Overall, your Pokemon is pretty decent!",
                        "Overall, your Pokemon has room for improvement as far as battling goes.",
                    };
            }
            throw new Exception("Unknown team!");
        }
    }
}