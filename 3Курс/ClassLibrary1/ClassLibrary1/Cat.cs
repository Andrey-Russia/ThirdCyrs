using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraevskoyAndrey_CatFramework
{
    public abstract class Cat
    {
        public abstract int Fluffiness { get; }
        public abstract string FluffinessCheck();
        public override string ToString()
        {
            return $"A cat with fluffiness: {Fluffiness}";
        }
    }
}
