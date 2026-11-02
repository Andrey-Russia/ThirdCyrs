using System;

namespace KraevskoyAndrey_CatFramework
{
    public class CatException : ArgumentException
    {
        public CatException(string message) : base(message)
        {

        }
    }
}