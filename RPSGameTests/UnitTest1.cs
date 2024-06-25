using RPS_Game;
using System.Collections;

namespace RPSGameTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(RPSGame.enChoice.Rock, RPSGame.enChoice.Paper, RPSGame.enWinner.AI)]
        [InlineData(RPSGame.enChoice.Scissors, RPSGame.enChoice.Rock, RPSGame.enWinner.AI)]
        [InlineData(RPSGame.enChoice.Paper, RPSGame.enChoice.Scissors, RPSGame.enWinner.AI)]

        [InlineData(RPSGame.enChoice.Paper, RPSGame.enChoice.Rock, RPSGame.enWinner.User)]
        [InlineData(RPSGame.enChoice.Rock, RPSGame.enChoice.Scissors, RPSGame.enWinner.User)]
        [InlineData(RPSGame.enChoice.Scissors, RPSGame.enChoice.Paper, RPSGame.enWinner.User)]

        [InlineData(RPSGame.enChoice.Paper, RPSGame.enChoice.Paper, RPSGame.enWinner.Draw)]
        [InlineData(RPSGame.enChoice.Rock, RPSGame.enChoice.Rock, RPSGame.enWinner.Draw)]
        [InlineData(RPSGame.enChoice.Scissors, RPSGame.enChoice.Scissors, RPSGame.enWinner.Draw)]

        public void determineRoundWinner_AllCases(RPSGame.enChoice userMove, RPSGame.enChoice AIMove, RPSGame.enWinner expectedWinner)
        {
            RPSGame game = new RPSGame();
            game.user.move = userMove;
            game.AI.move = AIMove;

            RPSGame.enWinner actualWinner = game.determineRoundWinner();

            Assert.Equal(expectedWinner, actualWinner);
        }

    
        [Fact]
        public void updatePlayerScoreTest()
        {
            RPSGame game = new RPSGame();
            game.user.move = RPSGame.enChoice.Paper;
            game.AI.move = RPSGame.enChoice.Rock;

            game.playRound();
            int expectedUserScore = 1;
            int actualUserScore = game.user.score;

            Assert.Equal(expectedUserScore, actualUserScore);
        }
    }
}