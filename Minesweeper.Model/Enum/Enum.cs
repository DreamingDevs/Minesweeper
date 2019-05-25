namespace Minesweeper.Model
{
    /// <summary>
    /// BlockType enum defines the types of blocks - Mine, Normal.
    /// </summary>
    public enum BlockType
    {
        Mine, Normal
    }

    /// <summary>
    /// BlockState enum defines the states of a block - Unopened, Opened, Flagged, Errored.
    /// </summary>
    public enum BlockState
    {
        Unopened, Opened, Flagged, Errored
    }

    /// <summary>
    /// BlockResult enum defines the results of a block on a particular action - Success, Fail, Error.
    /// </summary>
    public enum BlockResult
    {
        Success, Fail, Error
    }

    /// <summary>
    /// Difficulty enum defines the complexity of a board in terms of total blocks to mines ratio - Low (30), Medium (50), High (70).
    /// </summary>
    public enum Difficulty
    {
        Low = 30,
        Medium = 50,
        High = 70
    }

    /// <summary>
    /// BlockAction enum defines the set of actions can be performed on a block - Open, Flag.
    /// </summary>
    public enum BlockAction
    {
        Open, Flag
    }
}
