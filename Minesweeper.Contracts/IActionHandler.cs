using Minesweeper.Model;
namespace Minesweeper.Contracts
{
    /// <summary>
    /// IActionHandler interface provides API to process the user action on a particular block of the board.
    /// </summary>
    public interface IActionHandler
    {
        /// <summary>
        /// Process method is used to perform the user action on a particular block of the board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        void Process(Board board, Point position);
    }
}
