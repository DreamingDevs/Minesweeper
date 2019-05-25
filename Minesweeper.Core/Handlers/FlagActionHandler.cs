using System.Linq;
using Minesweeper.Model;
namespace Minesweeper.Core.Handlers
{
    /// <summary>
    /// OpenActionHandler class handles the flag action of the block
    /// </summary>
    public class FlagActionHandler : ActionHandler
    {
        /// <summary>
        /// Process method is used to flag the block on a board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        public override void Process(Board board, Point point)
        {
            var block = board.FlattenBlocks.First(p => p.Position.X == point.X && p.Position.Y == point.Y);
            block.BlockState = BlockState.Flagged;
        }
    }
}
