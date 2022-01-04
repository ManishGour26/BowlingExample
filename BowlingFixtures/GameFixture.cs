

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BowlingWithFrame
    {
        [TestClass]
        public class BowlingTest 
        {
            BowlingGame game;

            public BowlingTest()
            {
            }


           [TestMethod]
            public void Hookup()
            {
                Assert.IsTrue(true);
            }

           [TestMethod]
            public void GutterBalls()
            {
            BowlingGame game = new BowlingGame();
            ManyOpenFrames(10, 0, 0);
               Assert.AreEqual(0, game.Score());
            }

           [TestMethod]
            public void Threes()
            {
            BowlingGame game = new BowlingGame();
            ManyOpenFrames(10, 3, 3);
                Assert.AreEqual(0, game.Score());
            }

           [TestMethod]
            public void Spare()
            {
            BowlingGame game = new BowlingGame();
            game.Spare(4, 6);
                game.OpenFrame(3, 5);
                ManyOpenFrames(8, 0, 0);
                Assert.AreEqual(21, game.Score());
            }

           [TestMethod]
            public void Spare2()
            {
            BowlingGame game = new BowlingGame();
            game.Spare(4, 6);
                game.OpenFrame(5, 3);
                ManyOpenFrames(8, 0, 0);
                Assert.AreEqual(23, game.Score());
            }

           [TestMethod]
            public void Strike()
            {
            BowlingGame game = new BowlingGame();
            game.Strike();
                game.OpenFrame(5, 3);
                ManyOpenFrames(8, 0, 0);
                Assert.AreEqual(26, game.Score());
            }

           [TestMethod]
            public void StrikeFinalFrame()
            {
            BowlingGame game = new BowlingGame();
            ManyOpenFrames(9, 0, 0);
                game.Strike();
                game.BonusRoll(5);
                game.BonusRoll(3);
                Assert.AreEqual(18, game.Score()); // note that this is different from test Strike()
            }

           [TestMethod]
            public void SpareFinalFrame()
            {
            BowlingGame game = new BowlingGame();
            ManyOpenFrames(9, 0, 0);
                game.Spare(4, 6);
                game.BonusRoll(5);
                Assert.AreEqual(15, game.Score());
            }

           [TestMethod]
            public void Perfect()
            {
            BowlingGame game = new BowlingGame();
            for (int i = 0; i < 10; i++)
                    game.Strike();
                game.BonusRoll(10);
                game.BonusRoll(10);
                Assert.AreEqual(300, game.Score());
            }

           [TestMethod]
            public void Alternating()
            {
            BowlingGame game = new BowlingGame();
                for (int i = 0; i < 5; i++)
                {
                    game.Strike();
                    game.Spare(4, 6);
                }
                game.BonusRoll(10);
                Assert.AreEqual(200, game.Score());
            }

            private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
            {
            BowlingGame game = new BowlingGame();
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                    game.OpenFrame(firstThrow, secondThrow);
            }
        }
    }
