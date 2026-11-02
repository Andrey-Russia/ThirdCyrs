using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraevskoyAndrey_CatFramework
{
    public class Tiger : Cat
    {
        public override int Fluffiness { get; }
        public double Weight { get; }

        public Tiger(double weight, int fluffiness = 50)
        {
            string errorMessage = string.Empty;

            if (weight < 75.0 || weight > 140.0)
            {
                errorMessage += $"Unable to create a tiger with weight: {weight}";
            }

            if (fluffiness < 0 || fluffiness > 100)
            {
                if (errorMessage.Length > 0)
                {
                    errorMessage += Environment.NewLine;
                }

                errorMessage += $"Unable to create a tiger with fluffiness {fluffiness}";
            }

            if (errorMessage.Length > 0)
            {
                throw new CatException(errorMessage);
            }

            Weight = weight;
            Fluffiness = fluffiness;
        }

        public override string FluffinessCheck()
        {
            return "Kycь!";
        }

        public override string ToString()
        {
            return $"A tiger with weight: {Weight} fluffiness: {Fluffiness}";
        }
    }
}
