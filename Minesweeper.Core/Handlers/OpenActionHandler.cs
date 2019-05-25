using System.Linq;
using Minesweeper.Model;
namespace Minesweeper.Core.Handlers
{
    /// <summary>
    /// OpenActionHandler class handles the open action of the block
    /// </summary>
    public class OpenActionHandler : ActionHandler
    {
        /// <summary>
        /// Process method is used to open the block on a board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        /// <param name="position">Position of the block on which user performs an action.</param>
        public override void Process(Board board, Point point)
        {
            var block = board.FlattenBlocks.First(p => p.Position.X == point.X && p.Position.Y == point.Y);
            var result = block.Reveal();

            if(result == BlockResult.Success)
                ComputeNeighbouringMines(board, block, point);
            else if(result == BlockResult.Fail)
                OpenAllPendingMines(board);
        }

        private void ComputeNeighbouringMines(Board board, Block block, Point point)
        {
            var neighbourBlocksCount = board.FlattenBlocks.Count(p => 
                (p.Position.X == point.X + 1 || p.Position.X == point.X - 1 || p.Position.X == point.X) && 
                (p.Position.Y == point.Y + 1 || p.Position.Y == point.Y - 1 || p.Position.Y == point.Y) && 
                p.BlockType == BlockType.Mine);
            block.NeighbourMines = neighbourBlocksCount;
        }

        private void OpenAllPendingMines(Board board)
        {
            board.OpenAllPendingMines();
        }
    }
}
