using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GameTest()
        {
            game = new Game("C:\\Users\\oleg\\GitHub\\spbu-homework-sem-2\\DogGame\\DogGame\\NoCharacter.txt");
            game.Start();
        }

        [TestMethod()]
        public void UpTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DownTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LeftTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RightTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PrintTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StartTest()
        {
            Assert.Fail();
        }
    }
}