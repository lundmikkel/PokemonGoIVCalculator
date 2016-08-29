using System;
using System.Linq;
using NUnit.Framework.Constraints;

namespace PokemonGoIVCalculator.Tests
{
    public class IndividualValueConstraint : Constraint
    {
        public static IndividualValueConstraint HasValidIndicidualValues() => new IndividualValueConstraint();

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (!(actual is Pokemon))
                throw new Exception(); //$"{nameof(IndividualValueConstraint)} only works with {nameof(Pokemon)}");

            var pokemon = actual as Pokemon;
            var possibleIndividualValues = pokemon.FindPossibleIndividualValues();

            var isSuccessful = possibleIndividualValues.Contains(pokemon.IndividualValueSet);

            foreach (var individualValues in possibleIndividualValues)
                Console.WriteLine(individualValues);

            return new ConstraintResult(this, possibleIndividualValues, isSuccessful);
        }
    }
}