using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Minesweeper.Model
{
    /// <summary>
    /// Board class represents a board of blocks.
    /// </summary>
    public class Board
    {
        private int _height;
        private int _width;
        private List<Block> _blocks;
        /// <summary>
        /// Board class constructor which initiates a board with given height, width and difficulty,
        /// </summary>
        /// <param name="height">Height of the board</param>
        /// <param name="width">Width of the board</param>
        /// <param name="level">Difficulty level of the board</param>
        public Board(int height, int width, Difficulty level)
        {
            _height = height;
            _width = width;
            Level = level;
            Construct();
        }

        /// <summary>
        /// Height of the board.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Width of the board.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Flattened structure of blocks in a board.
        /// </summary>
        public List<Block> FlattenBlocks
        {
            get
            {
                if(_blocks == null)
                    _blocks = Blocks.Cast<Block>().ToList();

                return _blocks;
            }
        }

        /// <summary>
        /// Two dimensional array of the blocks in a board.
        /// </summary>
        public Block[,] Blocks { get; set; }

        /// <summary>
        /// Difficulty level of the board.
        /// </summary>
        public Difficulty Level { get; set; }

        /// <summary>
        /// IndexOf method retrieves a block from the given index position.
        /// </summary>
        /// <param name="x">X coordinate of the block</param>
        /// <param name="y">Y coordinate of the block</param>
        /// <returns>Block object</returns>
        public Block IndexOf(int x, int y)
        {
            return this.FlattenBlocks.FirstOrDefault(p => p.Position.X == x && p.Position.Y == y);
        }

        /// <summary>
        /// OpenAll method opens all pending mines blocks in the board.
        /// </summary>
        public void OpenAllPendingMines()
        {
            this.FlattenBlocks.ForEach(p =>
            {
                if(p.BlockType == BlockType.Mine && (p.BlockState == BlockState.Flagged || p.BlockState == BlockState.Unopened))
                    p.BlockState = BlockState.Opened;
            });
        }

        /// <summary>
        /// The ToString method overrides the default behaviour and represents the board as a cummulative strnig of blocks,
        /// where every block is represented with .|?|X based on the block's type and state.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var boardString = new StringBuilder();
            for (int i = 0; i < _height; i++)
            {
                var rowString = new StringBuilder();
                for (int j = 0; j < _width; j++)
                {
                    rowString.Append(string.Format("{0} ", Blocks[i, j].ToString())); 
                    if(j == (this.Width - 1))
                        boardString.Append(string.Format("{0} \r\n", rowString));
                }
            }
            return boardString.ToString();
        }

        private void Construct()
        {
            Blocks = new Block[_height, _width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Blocks[i, j] = new NormalBlock(new Point(i, j));
                }
            }
        }
    }
}
