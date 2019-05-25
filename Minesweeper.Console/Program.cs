using Minesweeper.Model;
using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity;
using Minesweeper.Contracts;
using Minesweeper.Core.Handlers;

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
            switch (inputLevel)
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

            var container = ConfigureContainer();
            var game = container.Resolve<IGame>();
            ConfigureGameAndPlay(game, height, width, level);

            Console.ReadLine();
        }

        /// <summary>
        /// ConfigureGameAndPlay method configures the game instance with user inputs - Height, Width and difficulty levels. 
        /// It initiates, starts and plays the game until it is finished. 
        /// </summary>
        /// <param name="game">Game instance which is configured at the unity container.</param>
        /// <param name="height">Height of the board.</param>
        /// <param name="width">Width of the board.</param>
        /// <param name="level">Difficult level of the board.</param>
        private static void ConfigureGameAndPlay(IGame game, int height, int width, Difficulty level)
        {
            game.CreateBoard(height, width, level);
            Print(game);

            while (!game.IsCompleted)
            {
                Console.Write("Enter your selection in f(x,y) | o(x,y) format. (f|o) => (flag|open) : ");
                var selection = Console.ReadLine();
                var formattedInput = TryParseValidateInput(selection);

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
            Console.WriteLine("Game is over!!!");
        }

        /// <summary>
        /// TryParseValidateInput method is used to parse and validate the user input which is captured from the console.
        /// </summary>
        /// <param name="input">Raw input from the console.</param>
        /// <returns>A tuple of True|False defining the validation process, X, Y Coordinates of the block and BlockAction which user wants to perform.</returns>
        private static Tuple<bool, int, int, BlockAction> TryParseValidateInput(string input)
        {
            var regex = new Regex(@"^(f|o)\((\d),(\d)\)$");
            var match = regex.Match(input);
            if (!match.Success)
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            var inputArr = new string[3];
            inputArr[0] = match.Groups[1].Value;
            inputArr[1] = match.Groups[2].Value;
            inputArr[2] = match.Groups[3].Value;

            var selectedAction = inputArr[0] == "o" ? BlockAction.Open : BlockAction.Flag;

            int selectedX;
            if (!int.TryParse(inputArr[1], out selectedX))
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            int selectedY;
            if (!int.TryParse(inputArr[2], out selectedY))
                return new Tuple<bool, int, int, BlockAction>(false, 0, 0, BlockAction.Open);

            return new Tuple<bool, int, int, BlockAction>(true, selectedX, selectedY, selectedAction);
        }

        private static void Print(IGame game)
        {
            Console.WriteLine("Current State : ");
            Console.WriteLine(game.CurrentBoard.ToString());
        }

        /// <summary>
        /// ConfigureContainer configures the Unit Container through which all the dependencies are resolved at runtime for 
        /// the minesweeper game.
        /// </summary>
        /// <returns>The container which holds all the resolved types.</returns>
        private static IUnityContainer ConfigureContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRandomMiner, RandomMiner>();
            container.RegisterType<IValidator, Validator>();
            container.RegisterType<IGame, Game>();
            var handlers = LoadHandlers();
            container.RegisterInstance<IBlockActionHandlers>(handlers);

            return container;
        }

        /// <summary>
        /// LoadHandlers method is used to load all the Action handles in to the BlockActionHandlers dictionary.
        /// </summary>
        /// <returns>And instanc of IBlockActionHandlers containing all action handlers.</returns>
        private static IBlockActionHandlers LoadHandlers()
        {
            var handlers = new BlockActionHandlers
            {
                Handlers = new Dictionary<BlockAction, IActionHandler>()
                {
                    { BlockAction.Flag, new FlagActionHandler() },
                    { BlockAction.Open, new OpenActionHandler() }
                }
            };
            return handlers;
        }
    }
}
