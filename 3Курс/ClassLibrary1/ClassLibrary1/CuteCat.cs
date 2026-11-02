using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraevskoyAndrey_CatFramework
{
    public  class CuteCat : Cat
    {
        public override int Fluffiness { get; }
        public CuteCat(int fluffiness = 50)
        {
            if (fluffiness < 0 || fluffiness > 140)
            {
                throw new CatException($"Unable to create a cute cat with fluffiness: {fluffiness}");
            }

            Fluffiness = fluffiness;
        }

        public override string FluffinessCheck()
        {
            if (Fluffiness == 0)
            {
                return "Sphynx";
            }

            if (Fluffiness <= 20)
            {
                return "Slightly";
            }

            if (Fluffiness <= 50)
            {
                return "Medium";
            }

            if (Fluffiness <= 75)
            {
                return "Heavy";
            }

            return "OwO";
        }

        public override string ToString()
        {
            return $"A cute cat with fluffiness: {Fluffiness}";
        }
    }
}
