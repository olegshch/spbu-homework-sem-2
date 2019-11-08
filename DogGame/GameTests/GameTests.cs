using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game.Game;

namespace Game.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        [TestMethod()]
        [ExpectedException(typeof(NoCharacterException))]
        public void NoCharacterException()
        {          
            game = new Game("NoCharacter.txt");
            game.Start();
        }

        [TestMethod()]
        [ExpectedException(typeof(DoubleCharacterException))]
        public void DoubleCharacterException()
        {
            game = new Game("DoubleCharacter.txt");
            game.Start();
        }

        [TestMethod()]
        [ExpectedException(typeof(WrongMapException))]
        public void WrongMapException()
        {
            game = new Game("WrongMap.txt");
            game.Start();
        }       
    }
}