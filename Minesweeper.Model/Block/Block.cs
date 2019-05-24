using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class Block
    {
        public BlockType BlockType { get; set; }
        public BlockState BlockState { get; set; }
        public Point Position { get; set; }
        public int NeighbourMines { get; set; }

        public BlockResult Reveal()
        {
            BlockResult result;
            switch (this.BlockType)
            {
                case BlockType.Mine:
                    result = BlockResult.Fail;
                    break;
                case BlockType.Normal:
                    result = BlockResult.Success;
                    break;
                default:
                    result = BlockResult.Fail;
                    break;
            }
            this.BlockState = BlockState.Opened;
            return result;
        }

        public BlockResult MarkAsMine()
        {
            this.BlockState = BlockState.Flagged;
            return BlockResult.Success;
        }

        public override string ToString()
        {
            var result = string.Empty;
            if (this.BlockState == BlockState.Unopened)
                result = ".";

            if (this.BlockState == BlockState.Flagged)
                result = "?";

            if (this.BlockState == BlockState.Opened)
            {
                switch (this.BlockType)
                {
                    case BlockType.Mine:
                        result = "X";
                        break;
                    case BlockType.Normal:
                        result = this.BlockState == BlockState.Opened ? this.NeighbourMines.ToString() : ".";
                        break;
                    default:
                        result = ".";
                        break;
                }
            }

            return result;
        }
    }
}
