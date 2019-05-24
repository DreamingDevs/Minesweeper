using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class NormalBlock : Block
    {
        public NormalBlock(Point position)
        {
            this.BlockType = BlockType.Normal;
            this.BlockState = BlockState.Unopened;
            this.Position = position;
        }
    }
}
