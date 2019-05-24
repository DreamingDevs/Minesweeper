using Minesweeper.Core.Handlers;
using Minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    public class Game
    {
        private readonly Board _board;
        private readonly Validator _validator;
        private Dictionary<BlockAction, BlockHandler> _handlers;
        public Game(int height, int width, Difficulty level)
        {
            _board = new Board(height, width, level);
            RandomMiner.GenerateRandomMines(_board);
            _validator = new Validator(_board);
            RegisterHandlers();
        }

        public Board CurrentBoard
        {
            get
            {
                return _board;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return !_board.FlattenBlocks.Any(p => p.BlockState == BlockState.Unopened);
            }
        }

        public BlockResult ExecuteAction(Point point, BlockAction blockAction)
        {
            if (!_validator.ValidateAction(point, blockAction))
                return BlockResult.Error;

            var handler = _handlers.First(p => p.Key == blockAction).Value;
            handler.Process(CurrentBoard, point);

            return BlockResult.Success;
        }

        private void RegisterHandlers()
        {
            _handlers = new Dictionary<BlockAction, BlockHandler>();
            _handlers.Add(BlockAction.Flag, new FlagHandler());
            _handlers.Add(BlockAction.Open, new OpenHandler());
        }
    }
}
