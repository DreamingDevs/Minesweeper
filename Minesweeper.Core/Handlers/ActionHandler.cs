using Minesweeper.Contracts;
using Minesweeper.Model;
namespace Minesweeper.Core.Handlers
{
    /// <summary>
    /// ActionHandler class provides the abstract methods to process the user action on a particular block of the board.
    /// This class should be inherited by respective handlers to handle different user actions.
    /// </summary>
    public abstract class ActionHandler : IActionHandler
    {
        /// <summary>
        /// Process method is an abstract method which needs to be overriden by respective handler classes
        /// through which respecitve user action can be handled on particular block of the board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        public abstract void Process(Board board, Point point);
    }
}
