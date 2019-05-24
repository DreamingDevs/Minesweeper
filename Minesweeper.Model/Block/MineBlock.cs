using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class MineBlock : Block
    {
        public MineBlock(Point position)
        {
            this.BlockType = BlockType.Mine;
            this.BlockState = BlockState.Unopened;
            this.Position = position;
        }
    }
}
