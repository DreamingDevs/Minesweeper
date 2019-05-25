using Minesweeper.Contracts;
using Minesweeper.Core;
using Minesweeper.Core.Handlers;
using Minesweeper.Model;
using System.Collections.Generic;
namespace Minesweeper.Tests
{
    public class GameConfiguration
    {
        public static IGame CreateGame(int height, int width, Difficulty level)
        {
            var randomMiner = new RandomMiner();
            var validator = new Validator();
            var handlers = LoadHandlers();
            var game = new Game(randomMiner, validator, handlers);
            game.CreateBoard(height, width, level);
            return game;
        }
        
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
