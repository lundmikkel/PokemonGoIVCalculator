using System;

namespace PokemonGoIVCalculator
{
    public class IndividualValueSet : IEquatable<IndividualValueSet>
    {
        public int Attack { get; }
        public int Defense { get; }
        public int Stamina { get; }

        public IndividualValueSet(int attack, int defense, int stamina)
        {
            Attack = attack;
            Defense = defense;
            Stamina = stamina;
        }

        private int Sum => Attack + Defense + Stamina;

        public override string ToString() => $"{Attack:D2}/{Defense:D2}/{Stamina:D2} ({Sum:D2}/45 ≈ {Sum/0.45d:N1}%)";

        #region Equality

        public bool Equals(IndividualValueSet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Stamina == other.Stamina && Defense == other.Defense && Attack == other.Attack;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IndividualValueSet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Stamina;
                hashCode = (hashCode * 397) ^ Defense;
                hashCode = (hashCode * 397) ^ Attack;
                return hashCode;
            }
        }

        public static bool operator ==(IndividualValueSet left, IndividualValueSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IndividualValueSet left, IndividualValueSet right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}