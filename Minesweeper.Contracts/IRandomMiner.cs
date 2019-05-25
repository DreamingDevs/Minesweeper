using Minesweeper.Model;
namespace Minesweeper.Contracts
{
    /// <summary>
    /// IRandomMiner Interface provides methods to randomize a given board by placing mines at random locations based on the selected difficulty level.
    /// </summary>
    public interface IRandomMiner
    {
        /// <summary>
        /// GenerateRandomMines method generated random mines on a given board.
        /// </summary>
        /// <param name="board">Board object which holds all the blocks.</param>
        void GenerateRandomMines(Board board);
    }
}
