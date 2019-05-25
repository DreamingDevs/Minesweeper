using Minesweeper.Model;
using System.Collections.Generic;
namespace Minesweeper.Contracts
{
    /// <summary>
    /// IBlockActionHandlers interface provide API to map BlockActions with their corresponding IActionHandlers.
    /// </summary>
    public interface IBlockActionHandlers
    {
        /// <summary>
        /// Handlers property holds the mappings between BlockActions and IActionHandlers.
        /// </summary>
        Dictionary<BlockAction, IActionHandler> Handlers { get; set; }
    }
}
