using Minesweeper.Model;
namespace Minesweeper.Contracts
{
    /// <summary>
    /// IGame Interface describes the Game API through which one can initiate and play a minesweeper game.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// IsCompleted property returns a bool indicating whether the current game is completed or in-progress.
        /// </summary>
        bool IsCompleted { get; }
       
        /// <summary>
        /// CurrentBoard property returns the board instance of current game.
        /// </summary>
        Board CurrentBoard { get; }

        /// <summary>
        /// CreateBoard method creates a board and randomizes mines on the board.
        /// </summary>
        /// <param name="height">Height of the board.</param>
        /// <param name="width">Width of the board.</param>
        /// <param name="level">Difficult level of the game.</param>
        void CreateBoard(int height, int width, Difficulty level);

        /// <summary>
        /// ExecuteAction method executes the user action (flag|open) on a particular block of the board.
        /// </summary>
        /// <param name="point">Position of the block.</param>
        /// <param name="blockAction">Action of the user on the block.</param>
        /// <returns>Block result describes whether the action is resulted in a success or error result.</returns>
        BlockResult ExecuteAction(Point point, BlockAction blockAction);
    }
}
