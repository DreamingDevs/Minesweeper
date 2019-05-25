using Minesweeper.Contracts;
using Minesweeper.Model;
namespace Minesweeper.Core
{
    /// <summary>
    /// Validator class provides methods to validate the user action on a board more specifically on a block.
    /// </summary>
    public class Validator  : IValidator
    {
        /// <summary>
        /// ValidateAction method will validate the user action on a block.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        /// <param name="action">Type of the action which user intends to perform on a block.</param>
        /// <returns></returns>
        public bool ValidateAction(Board board, Point position, BlockAction action)
        {
            var block = IsValidIndex(board, position);
            if (block == null)
                return false;

            if (block.BlockState == BlockState.Opened)
                return false;

            return true;
        }

        private Block IsValidIndex(Board board, Point position)
        {
            var result = board.IndexOf(position.X, position.Y);
            return result;
        }
    }
}
