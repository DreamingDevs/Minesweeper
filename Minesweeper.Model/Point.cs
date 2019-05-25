namespace Minesweeper.Model
{
    /// <summary>
    /// Point class represents a point based on X and Y coordinates.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Point class constructor defines the X and Y coordinates of a point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
