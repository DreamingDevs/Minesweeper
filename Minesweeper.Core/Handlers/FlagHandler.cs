using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;

namespace Minesweeper.Core.Handlers
{
    public class FlagHandler : BlockHandler
    {
        public override void Process(Board board, Point point)
        {
            var block = board.FlattenBlocks.First(p => p.Position.X == point.X && p.Position.Y == point.Y);
            block.BlockState = BlockState.Flagged;
        }
    }
}
