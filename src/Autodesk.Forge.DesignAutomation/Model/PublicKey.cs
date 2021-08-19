using System;
using System.Linq;

namespace Autodesk.Forge.DesignAutomation.Model
{
    partial class PublicKey
    {
        public override bool Equals(object obj)
        {
            var other = obj as PublicKey;
            if (other == null)
                return false;
            return this.Exponent.SequenceEqual(other.Exponent) && this.Modulus.SequenceEqual(other.Modulus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Exponent, Modulus);
        }
    }
}
