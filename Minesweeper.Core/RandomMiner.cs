using Minesweeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    public class RandomMiner
    {
        public static void GenerateRandomMines(Board board)
        {
            var totalRandomPositions = Math.Round((board.Height * board.Width) * ((double)board.Level / 100), 0, MidpointRounding.AwayFromZero);
            var currentMinesCount = 0;
            while(currentMinesCount < totalRandomPositions)
            {
                Random r = new Random();
                var x = r.Next(0, board.Width);
                var y = r.Next(0, board.Height);

                var block = board.Blocks[x, y];
                if (block.BlockType == BlockType.Mine)
                    continue;

                block.BlockType = BlockType.Mine;
                currentMinesCount++;
            }
        }
    }
}
