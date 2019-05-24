using Minesweeper.Model;
using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Height : ");
            int height = Int32.Parse(Console.ReadLine());

            Console.Write("Enter Width : ");
            int width = Int32.Parse(Console.ReadLine());

            Console.Write("Enter Difficulty (low = 1, medium = 2, high = 3) : ");
            var inputLevel = Console.ReadLine();
            Difficulty level;
            switch(inputLevel)
            {
                case "1":
                    level = Difficulty.Low;
                    break;
                case "2":
                    level = Difficulty.Medium;
                    break;
                case "3":
                    level = Difficulty.High;
                    break;
                default:
                    level = Difficulty.Low;
                    break;
            }

            CreateGameAndPlay(height, width, level);

            Console.ReadLine();
        }

        private static void CreateGameAndPlay(int height, int width, Difficulty level)
        {
            var game = new Game(height, width, level);
            Print(game);

            while (!game.IsCompleted)
            {
                Console.Write("Enter your selection in f(x,y) | o(x,y) format. (f|o) => (flag|open) : ");
                var selection = Console.ReadLine();
                var formattedInput = TryParseValidate(selection);

                if (!formattedInput.Item1)
                {
                    Console.WriteLine("Please correct your input.");
                    continue;
                }

                var result = game.ExecuteAction(new Point(formattedInput.Item2, formattedInput.Item3), formattedInput.Item4);
                if (result == BlockResult.Error)
                    Console.WriteLine("Input selection in wrong.");

                Print(game);
            }
        }

        private static Tuple<bool, int, int, BlockAction> TryParseValidate(string input)
        {
            var regex = new Regex(@"^(f|o)\((\d),(\d)\)$");
            var match = regex.Match(input);
            if(!match.Success)
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            var inputArr = new string[3];
            inputArr[0] = match.Groups[1].Value;
            inputArr[1] = match.Groups[2].Value;
            inputArr[2] = match.Groups[3].Value;

            var selectedAction = inputArr[0] == "o" ? BlockAction.Open : BlockAction.Flag;

            int selectedX;
            if(!int.TryParse(inputArr[1], out selectedX))
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            int selectedY;
            if (!int.TryParse(inputArr[2], out selectedY))
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            return new Tuple<bool, int, int, BlockAction>(true, selectedX, selectedY, selectedAction);
        }

        private static void Print(Game game)
        {
            Console.WriteLine("Current State : ");
            Console.WriteLine(game.CurrentBoard.ToString());
        }
    }
}
