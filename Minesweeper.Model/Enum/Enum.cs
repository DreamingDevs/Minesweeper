using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public enum BlockType
    {
        Mine, Normal
    }

    public enum BlockState
    {
        Unopened, Opened, Flagged
    }

    public enum BlockResult
    {
        Success, Fail, Error
    }

    public enum Difficulty
    {
        Low = 30,
        Medium = 50,
        High = 70
    }

    public enum BlockAction
    {
        Open, Flag
    }
}
