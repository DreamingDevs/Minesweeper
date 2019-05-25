using Minesweeper.Contracts;
using Minesweeper.Model;
using System;
namespace Minesweeper.Core
{
    /// <summary>
    /// RandomMiner class provides methods to randomize a given board by placing mines at random locations based on the selected difficulty level.
    /// </summary>
    public class RandomMiner : IRandomMiner
    {
        /// <summary>
        /// GenerateRandomMines method generated random mines on a given board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        public void GenerateRandomMines(Board board)
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
