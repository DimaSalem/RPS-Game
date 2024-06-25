using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Game
{
    public class RPSGame
    {
        public enum enChoice { Rock, Paper, Scissors}
        public enum enWinner { User, AI, Draw}
        public enum enMode { noraml=1, hard=2}

        public Player user= new Player("user");
        public Player AI= new Player("AI");
        Random random = new Random();
        enMode mode;
       
        enChoice readUserChoice()
        {
            Console.WriteLine("Your turn: Enter R for Rock, P for Paper, and S for Scissors: ");
            string input = Console.ReadLine().ToUpper();
            while (input != "R" && input != "P" && input != "S")
            {
                Console.WriteLine("Invalid input, try again");
                input= Console.ReadLine().ToUpper();
            }
            switch (input)
            {
                case "R":
                    return enChoice.Rock;
                case "P":
                    return enChoice.Paper;
                case "S":
                    return enChoice.Scissors;
                default:
                    return enChoice.Rock;
            }
        }
        enChoice getAIChoice()
        { 
            int randomChoice= random.Next(0,3);
            return (enChoice)randomChoice;
        }
        enChoice getAICheatChoice(enChoice userChoice)
        {
            switch (userChoice)
            {
                case enChoice.Rock:
                    return enChoice.Paper;
                case enChoice.Paper:
                    return enChoice.Scissors;
                case enChoice.Scissors:
                    return enChoice.Rock;
                default:
                    return enChoice.Rock;
            }
        }
        public enWinner determineRoundWinner()
        {
            if (user.move == AI.move)
               return enWinner.Draw;
            switch (user.move)
            {
                case enChoice.Rock:
                    if (AI.move == enChoice.Scissors)
                        return enWinner.User;
                    break;
                case enChoice.Paper:
                    if(AI.move == enChoice.Rock)
                        return enWinner.User;
                    break;
                case enChoice.Scissors:
                    if(AI.move == enChoice.Paper)
                        return enWinner.User;
                    break;
            }
            return enWinner.AI;
        }
        void printRoundInfo(enWinner roundWinner)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Your Choice: {user.move}");
            Console.WriteLine($"AI Choice: {AI.move}");
            Console.Write("Winner: ");
            Console.ForegroundColor = (roundWinner == enWinner.User ? ConsoleColor.Green :
                (roundWinner == enWinner.Draw? ConsoleColor.Yellow : ConsoleColor.Red));
           
            Console.Write(roundWinner.ToString()+"\n");
            Console.ResetColor();
            Console.WriteLine("----------------------");
        }
        public void playRound()
        {          
            enWinner roundWinner= determineRoundWinner();
            printRoundInfo(roundWinner);

            if (roundWinner == enWinner.User)
                user.score++;
            else if(roundWinner == enWinner.AI)
                AI.score++;        
        }

        enWinner determineGameWinner()
        {
            if (user.score > AI.score)
                return enWinner.User;
            else if (AI.score > user.score)
                return enWinner.AI;
            else
                return enWinner.Draw;
        }
        void printFinalResult()
        {
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("--------Result--------");
            Console.WriteLine($"Your Score: {user.score}");
            Console.WriteLine($"AI Score: {AI.score}");
            Console.WriteLine($"Game Winner: {determineGameWinner()}");
            Console.WriteLine("----------------------");
            Console.ResetColor ();
        }

        enMode readMode()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !input.All(char.IsDigit) || (input != "1" && input != "2"))
            {
                Console.WriteLine("Invalid input!, try again");
                input = Console.ReadLine();
            }
            bool success = Int16.TryParse(input, out Int16 output);
            return (enMode)output;
        }
        void mainScreen()
        {
            Console.WriteLine("Select the Mode");
            Console.WriteLine("1. Normal Mode");
            Console.WriteLine("2. Hard Mode");
            mode= readMode();
            Console.Clear();
        }
        public void startGame()
        {
            mainScreen();
            for (int i = 0; i < 3; i++)
            {
                user.move = readUserChoice();
                AI.move = (mode == enMode.hard ? getAICheatChoice(user.move) : getAIChoice());
                playRound();
            }
            printFinalResult();
        }

        
        
    }
}
