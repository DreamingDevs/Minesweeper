using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class Board
    {
        private int _height;
        private int _width;
        private List<Block> _blocks;
        public Board(int height, int width, Difficulty level)
        {
            _height = height;
            _width = width;
            Level = level;
            Construct();
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public List<Block> FlattenBlocks
        {
            get
            {
                if(_blocks == null)
                    _blocks = Blocks.Cast<Block>().ToList();

                return _blocks;
            }
        }

        public Block[,] Blocks { get; set; }
        public Difficulty Level { get; set; }

        public Block IndexOf(int x, int y)
        {
            return this.FlattenBlocks.FirstOrDefault(p => p.Position.X == x && p.Position.Y == y);
        }

        public void OpenAll()
        {
            this.FlattenBlocks.ForEach(p =>
            {
                p.BlockState = BlockState.Opened;
            });
        }

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
