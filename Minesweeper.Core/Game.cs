using Minesweeper.Contracts;
using Minesweeper.Model;
using System.Linq;

namespace Minesweeper.Core
{
    /// <summary>
    /// Game class defines the methods through which one can initiate and play a minesweeper game.
    /// </summary>
    public class Game : IGame
    {
        private Board _board;
        private readonly IValidator _validator;
        private readonly IRandomMiner _randomMiner;
        private IBlockActionHandlers _blockActionHandlers;

        /// <summary>
        /// Game class constructor takes RandomMiner, Validator and BlockActionHandlers objects which are used in 
        /// creating, validating and playing the minesweeper game.
        /// </summary>
        /// <param name="randomMiner"></param>
        /// <param name="validator"></param>
        /// <param name="blockActionHandlers"></param>
        public Game(IRandomMiner randomMiner, IValidator validator, IBlockActionHandlers blockActionHandlers)
        {
            _randomMiner = randomMiner;
            _validator = validator;
            _blockActionHandlers = blockActionHandlers;
        }

        /// <summary>
        /// CurrentBoard property returns the board instance of current game.
        /// </summary>
        public Board CurrentBoard
        {
            get
            {
                return _board;
            }
        }

        /// <summary>
        /// IsCompleted property returns a bool indicating whether the current game is completed or in-progress.
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return _board.FlattenBlocks.Any(p => p.BlockState == BlockState.Errored) ||
                    !_board.FlattenBlocks.Any(p => p.BlockState == BlockState.Unopened);
            }
        }

        /// <summary>
        /// CreateBoard method creates a board and randomizes mines on the board.
        /// </summary>
        /// <param name="height">Height of the board.</param>
        /// <param name="width">Width of the board.</param>
        /// <param name="level">Difficult level of the game.</param>
        public void CreateBoard(int height, int width, Difficulty level)
        {
            _board = new Board(height, width, level);
            _randomMiner.GenerateRandomMines(_board);
        }

        /// <summary>
        /// ExecuteAction method executes the user action (flag|open) on a particular block of the board.
        /// </summary>
        /// <param name="point">Position of the block.</param>
        /// <param name="blockAction">Action of the user on the block.</param>
        /// <returns>Block result describes whether the action is resulted in a success or error result.</returns>
        public BlockResult ExecuteAction(Point point, BlockAction blockAction)
        {
            if (!_validator.ValidateAction(_board, point, blockAction))
                return BlockResult.Error;

            var handler = _blockActionHandlers.Handlers.First(p => p.Key == blockAction).Value;
            handler.Process(CurrentBoard, point);

            return BlockResult.Success;
        }
    }
}
