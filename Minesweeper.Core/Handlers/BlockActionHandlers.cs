using Minesweeper.Contracts;
using Minesweeper.Model;
using System.Collections.Generic;
namespace Minesweeper.Core.Handlers
{
    /// <summary>
    /// BlockActionHandlers class provide API to map BlockActions with their corresponding IActionHandlers.
    /// </summary>
    public class BlockActionHandlers : IBlockActionHandlers
    {
        /// <summary>
        /// BlockActionHandlers constructor to initialize the mappings construct.
        /// </summary>
        public BlockActionHandlers()
        {
            Handlers = new Dictionary<BlockAction, IActionHandler>();
        }

        /// <summary>
        /// Handlers property holds the mappings between BlockActions and IActionHandlers.
        /// </summary>
        public Dictionary<BlockAction, IActionHandler> Handlers { get; set; }
    }
}
