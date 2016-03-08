using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsExample.Enums;

namespace RockPaperScissorsExample.Implementations
{
    public class RockOnly : Player
    {
        public RockOnly(string Name) : base(Name)
        {
        }

        public override Choice GetChoice()
        {
           return Choice.Rock;
        }
    }
}
