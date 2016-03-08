using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsExample.Enums;

namespace RockPaperScissorsExample.Implementations
{
    public class WeightedPlayer : Player
    {
        private static Random _randomGenerator = new Random();

        public WeightedPlayer(string Name) : base(Name)
        {
        }

        public override Choice GetChoice()
        {
            int i = _randomGenerator.Next(1, 11);

            return (Choice) i;
        }
    }
}

