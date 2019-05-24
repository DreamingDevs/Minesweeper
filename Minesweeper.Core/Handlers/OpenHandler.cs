using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;

namespace Minesweeper.Core.Handlers
{
    public class OpenHandler : BlockHandler
    {
        public override void Process(Board board, Point point)
        {
            var block = board.FlattenBlocks.First(p => p.Position.X == point.X && p.Position.Y == point.Y);
            var result = block.Reveal();

            if(result == BlockResult.Success)
                ComputeNeighbouringMines(board, block, point);
            else if(result == BlockResult.Fail)
                OpenAllBlocks(board);
        }

        private void ComputeNeighbouringMines(Board board, Block block, Point point)
        {
            var neighbourBlocksCount = board.FlattenBlocks.Count(p => 
                (p.Position.X == point.X + 1 || p.Position.X == point.X - 1) && 
                (p.Position.Y == point.Y + 1 || p.Position.Y == point.Y - 1) && 
                p.BlockType == BlockType.Mine);
            block.NeighbourMines = neighbourBlocksCount;
        }

        private void OpenAllBlocks(Board board)
        {
            board.OpenAll();
        }
    }
}
