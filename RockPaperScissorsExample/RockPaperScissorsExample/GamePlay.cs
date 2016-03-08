using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsExample.Enums;
using RockPaperScissorsExample.Implementations;

namespace RockPaperScissorsExample
{
    public class GamePlay
    {
        public void PlayRound()
        {
            Player p1 = new HumanPlayer("Player 1");
            //Player p2 = new ComputerPlayer("Player 2");
            //Player p3 = new RockOnly("Rock only player");
            Player p4 = new WeightedPlayer("Dirty Cheater");

            MatchResult result = new MatchResult();
            result.Player1_Choice = p1.GetChoice();
            //result.Player2_Choice = p2.GetChoice();
            //result.Player2_Choice = p3.GetChoice();
            result.Player2_Choice = p4.GetChoice();

            if (result.Player1_Choice == result.Player2_Choice)
            {
                result.Match_Result = Result.Tie;
            }
            else if ((result.Player1_Choice == Choice.Rock && result.Player2_Choice == Choice.Scissors) ||
                     (result.Player1_Choice == Choice.Paper && result.Player2_Choice == Choice.Rock) ||
                     (result.Player1_Choice == Choice.Scissors && result.Player2_Choice == Choice.Paper))
            {
                result.Match_Result = Result.Win;
            }
            else
            {
                result.Match_Result = Result.Loss;
            }

            ProcessResult(p1, p4, result);
        }

        private void ProcessResult(Player Player1, Player Player2, MatchResult Result)
        {
            Console.WriteLine("{0} picked {1}, {2} picked {3}", Player1.Name, Result.Player1_Choice,
                Player2.Name, Result.Player2_Choice);

            switch (Result.Match_Result)
            {
                case Enums.Result.Win:
                    Console.WriteLine("{0} Wins!", Player1.Name);
                    break;
                case Enums.Result.Loss:
                    Console.WriteLine("{0} Wins!", Player2.Name);
                    break;
                default:
                    Console.WriteLine("You both Tie!");
                    break;
            }
        }
    }
}
