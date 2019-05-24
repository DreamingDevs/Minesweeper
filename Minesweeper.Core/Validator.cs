using Minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    public class Validator
    {
        private Board _board;
        public Validator(Board board)
        {
            _board = board;
        }

        public bool ValidateAction(Point position, BlockAction action)
        {
            var block = IsValidIndex(position);
            if (block == null)
                return false;

            if (block.BlockState == BlockState.Opened)
                return false;

            return true;
        }

        private Block IsValidIndex(Point position)
        {
            var result = _board.IndexOf(position.X, position.Y);
            return result;
        }
    }
}
