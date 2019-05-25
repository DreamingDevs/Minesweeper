using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Contracts;

namespace Minesweeper.Tests
{
    [TestClass]
    public class GameTests
    {
        public GameTests()
        {
        }

        [TestMethod]
        public void GameWithMines()
        {
            var game = GameConfiguration.CreateGame(3, 3, Model.Difficulty.Low);
            Assert.IsTrue(game.CurrentBoard.FlattenBlocks.Count(p => p.BlockType == Model.BlockType.Mine) > 0);
        }

        [TestMethod]
        public void OpenNormalBlockSuccessTest()
        {
            var game = GameConfiguration.CreateGame(3, 3, Model.Difficulty.Low);
            var normalBlock = game.CurrentBoard.FlattenBlocks.FirstOrDefault(p => p.BlockType == Model.BlockType.Normal && p.BlockState == Model.BlockState.Unopened);
            game.ExecuteAction(normalBlock.Position, Model.BlockAction.Open);
            Assert.AreEqual(Model.BlockState.Opened, game.CurrentBoard.Blocks[normalBlock.Position.X, normalBlock.Position.Y].BlockState);
            Assert.IsTrue(!game.CurrentBoard.ToString().Contains("X"));
        }

        [TestMethod]
        public void OpenMineBlockFailTest()
        {
            var game = GameConfiguration.CreateGame(3, 3, Model.Difficulty.Low);
            var totalMines = game.CurrentBoard.FlattenBlocks.Count(p => p.BlockType == Model.BlockType.Mine);

            var normalBlock = game.CurrentBoard.FlattenBlocks.FirstOrDefault(p => p.BlockType == Model.BlockType.Mine && p.BlockState == Model.BlockState.Unopened);
            game.ExecuteAction(normalBlock.Position, Model.BlockAction.Open);

            Assert.AreEqual(Model.BlockState.Errored, game.CurrentBoard.Blocks[normalBlock.Position.X, normalBlock.Position.Y].BlockState);
            Assert.AreEqual(true, game.IsCompleted);
            Assert.AreEqual(totalMines - 1, game.CurrentBoard.FlattenBlocks.Count(p => p.BlockType == Model.BlockType.Mine && p.BlockState == Model.BlockState.Opened));
            Assert.IsTrue(game.CurrentBoard.ToString().Contains("X"));
        }

        [TestMethod]
        public void FlagBlockTest()
        {
            var game = GameConfiguration.CreateGame(3, 3, Model.Difficulty.Low);
            var normalBlock = game.CurrentBoard.FlattenBlocks.FirstOrDefault(p => p.BlockType == Model.BlockType.Mine && p.BlockState == Model.BlockState.Unopened);
            game.ExecuteAction(normalBlock.Position, Model.BlockAction.Flag);
            Assert.AreEqual(Model.BlockState.Flagged, game.CurrentBoard.Blocks[normalBlock.Position.X, normalBlock.Position.Y].BlockState);
            Assert.IsTrue(game.CurrentBoard.ToString().Contains("?"));
        }


    }
}
