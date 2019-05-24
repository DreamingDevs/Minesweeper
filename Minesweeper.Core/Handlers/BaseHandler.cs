using Minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Handlers
{
    public abstract class BlockHandler
    {
        public abstract void Process(Board board, Point point);
    }
}
