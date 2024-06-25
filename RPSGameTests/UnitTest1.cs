using RPS_Game;
using System.Collections;

namespace RPSGameTests
{
    public class UnitTest1
    {
        [Fact]
        public void determineRoundWinner_RockPaperTest()
        {
            RPSGame game = new RPSGame();
            game.user.move = RPSGame.enChoice.Paper;
            game.AI.move = RPSGame.enChoice.Rock;

            RPSGame.enWinner winner= game.determineRoundWinner();

            Assert.Equal(RPSGame.enWinner.User, winner);
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