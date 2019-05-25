using Minesweeper.Model;
namespace Minesweeper.Contracts
{
    /// <summary>
    /// IValidator Interface provides methods to validate the user action on a board more specifically on a block.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// ValidateAction method will validate the user action on a block.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        /// <param name="action">Type of the action which user intends to perform on a block.</param>
        /// <returns></returns>
        bool ValidateAction(Board board, Point position, BlockAction action);
    }
}
