namespace Minesweeper.Model
{
    /// <summary>
    /// NormalBlock class represents an a normal block (other than a mine) within the board.
    /// </summary>
    public class NormalBlock : Block
    {
        /// <summary>
        /// NormalBlock class constructor which initiates the current block as normal block with a given position on the board.
        /// </summary>
        /// <param name="position">Position of the block on the board.</param>
        public NormalBlock(Point position)
        {
            this.BlockType = BlockType.Normal;
            this.BlockState = BlockState.Unopened;
            this.Position = position;
        }
    }
}
