using System;

namespace BettingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Player
            Player player = new Player() { Name = "The Player", Account = 100 };
            double odds = 0.75;

            //Enter program until user breaks out.
            while (true)
            {
                Console.Write($"\nWelcome to the casino. The odds are {odds}\n");
                player.AccountStatement();
                Console.Write("\nHow much do you want to bet: ");
                string strAmount = Console.ReadLine();

                //check for user break out.
                if (strAmount == "") return;

                //checks if amount is a number
                if (int.TryParse(strAmount, out int amount) && player.CanBet(amount))
                {
                    int pot = amount * 2;
                    Random random = new Random();

                    if (odds >= random.NextDouble())
                    {
                        //handle win
                        Console.WriteLine($"\nYou win {pot}\n");
                        player.Account += pot;
                    } else
                    {
                        Console.WriteLine("\nBad Luck, you lose.\n");
                        player.Account -= amount;
                    }

                }


            }

        }
    }

    class Player
    {
        public string Name;
        public int Account;

        public bool CanBet(int amountOfCash)
        {
            return Account >= amountOfCash;
        }

        public void LoseMoney(int amountOfCash)
        {
            if (CanBet(amountOfCash))
            {
                Account -= amountOfCash;
            }
        }

        public void WinMoney(int amountOfCash)
        {
            Account += amountOfCash;
        }

        public void AccountStatement()
        {
            Console.WriteLine($"{Name} has {Account} bucks");
        }
    }
}

