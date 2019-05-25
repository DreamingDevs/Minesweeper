namespace Minesweeper.Model
{
    /// <summary>
    /// Block class represents an individual block within the board.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// BlockType property represents whether the given block is a mine or normal block.
        /// </summary>
        public BlockType BlockType { get; set; }

        /// <summary>
        /// BlockState property gives the current condition of the block - Opened, UnOpened, Flagged.
        /// </summary>
        public BlockState BlockState { get; set; }

        /// <summary>
        /// Position property defines the position (X,Y) of the block within a board.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// NeightbourMines property holds the total number of mines surrounding the current block.
        /// </summary>
        public int NeighbourMines { get; set; }

        /// <summary>
        /// Reveal method opens the current block and returns the Block result success/fail based on block type.
        /// </summary>
        public BlockResult Reveal()
        {
            BlockResult result;
            switch (this.BlockType)
            {
                case BlockType.Mine:
                    result = BlockResult.Fail;
                    this.BlockState = BlockState.Errored;
                    break;
                case BlockType.Normal:
                    result = BlockResult.Success;
                    this.BlockState = BlockState.Opened;
                    break;
                default:
                    result = BlockResult.Fail;
                    this.BlockState = BlockState.Errored;
                    break;
            }
            
            return result;
        }

        /// <summary>
        /// MarkAsMine method marks the current block as mine.
        /// </summary>
        public BlockResult MarkAsMine()
        {
            this.BlockState = BlockState.Flagged;
            return BlockResult.Success;
        }

        /// <summary>
        /// The ToString method overrides the default behaviour and represents a block as .|?|X based on the current block's type and state.
        /// </summary>
        public override string ToString()
        {
            var result = string.Empty;
            if (this.BlockState == BlockState.Unopened)
                result = ".";

            if (this.BlockState == BlockState.Flagged)
                result = "?";

            if (this.BlockState == BlockState.Errored)
                result = "X";

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
