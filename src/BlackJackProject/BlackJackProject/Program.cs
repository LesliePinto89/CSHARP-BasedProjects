using System;

namespace BlackJackProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJackSolver();
        }

        public static void BlackJackSolver()
        {
            new Deck(); //Deck created and randomly shuffled
            Player aPlayer = new Player();
            Dealer aDealer = new Dealer();
            int playerScore = aPlayer.getCurrentScore();
            int dealerScore = aDealer.getCurrentScore();
            string winner = "";
            int winnerScore = 0;

            while (playerScore >21 ==false || dealerScore >21 == false)
            {
                Console.WriteLine("Hit one or more than one? Type hit or more");
                string choice = Console.ReadLine();
                if (choice == "hit") {
                    playerScore = aPlayer.Hit();
                }

                else if (choice == "more")
                 {
                    Console.WriteLine("How many Cards?");
                   string choiceNumber = Console.ReadLine();
                    int number = Int32.Parse(choiceNumber);
                    playerScore = aPlayer.MoreCards(number);

                }
                winner = new string (dealerScore < playerScore? "Player" : "Dealer");

                if (winner == "Player") {
                    if (playerScore > 21) {
                        winner = "Dealer";
                        winnerScore = dealerScore;
                        break; }
                   else  {
                        winnerScore = playerScore;
                        if (winnerScore == 21)
                        {
                            break;
                        }
                    }
                }
                dealerScore = aDealer.Hit(); //Either increased number or same if pass
                winner = new string (playerScore <  dealerScore ? "Dealer" : "Player");
                if (winner == "Dealer")
                {
                    if (dealerScore > 21) {
                        winner = "Player";
                        winnerScore = playerScore;
                        break; }
                    else { 
                        winnerScore = dealerScore;
                        if (winnerScore == 21) {
                            break;
                        }
                    }
                }
                Console.WriteLine($"Player score so far: {playerScore} " + $"| Dealer score so far: {dealerScore}");
                Console.WriteLine($"The leader so far is {winner} with a score of {winnerScore}");
            }
            Console.WriteLine($"The winner is: {winner} with a score of {winnerScore}");
        }
    }
}
