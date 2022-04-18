using System;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Guys
            Guy Andrew = new Guy() { Name = "Andrew", Account = 50 };
            Guy Bob = new Guy() { Name = "Bob", Account = 100 };

            //Enter program until user breaks out.
            while (true)
            {
                Andrew.AccountStatement();
                Bob.AccountStatement();
                Console.WriteLine("");
                Console.Write("Please enter an amount to transfer or leave blank to exit: ");
                string strAmount = Console.ReadLine();

                //check for user break out.
                if (strAmount == "") return;

                //checks if amount is a number
                if (int.TryParse(strAmount, out int amount))
                {
                    string personRecievingMoney;

                    //loops until user enters either Andrew or Bob
                    do
                    {
                        Console.Write("Send to Andrew or Bob: ");
                        personRecievingMoney = Console.ReadLine();
                    } while (personRecievingMoney != "Andrew" && personRecievingMoney != "Bob");

                    //checks who is sending money to who
                    if (personRecievingMoney == "Andrew")
                    {
                        handleTransferingMoney(Bob, Andrew, amount);
                    }
                    else if (personRecievingMoney == "Bob")
                    {
                        handleTransferingMoney(Andrew, Bob, amount);
                    }

                    //logic for transfer of money
                    void handleTransferingMoney(Guy personSending, Guy personRecieving, int amount)
                    {
                        //if person doesn't have enough ££ restarts program
                        if (!personSending.CanGiveCash(amount))
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"{personSending.Name} does not have £{amount} to send. Please try again.");
                            Console.WriteLine("");
                            return;
                        };

                        //loging out info
                        personRecieving.AccountStatement();
                        personSending.AccountStatement();

                        Console.WriteLine("");
                        Console.WriteLine($"Sending £{amount} to {personRecieving.Name}");
                        Console.WriteLine("Updating...");
                        Console.WriteLine("");

                        //transfering money
                        personSending.SendCashTo(personRecieving, amount);
                        personRecieving.RecieveAmount(amount);
                    }

                }


            }

        }
    }

    class Guy
    {
        public string Name;
        public int Account;

        public bool CanGiveCash(int amountOfCash)
        {
            return Account >= amountOfCash;
        }

        private void RemoveCashFromAccount(int amountOfCash)
        {
            if (CanGiveCash(amountOfCash))
            {
                Account -= amountOfCash;
            }
        }

        public int SendCashTo(Guy person, int amountOfCash)
        {
            RemoveCashFromAccount(amountOfCash);
            return person.Account + amountOfCash;
        }

        public void RecieveAmount(int amountOfCash)
        {
            Account += amountOfCash;
        }

        public void AccountStatement()
        {
            Console.WriteLine("{0} has £{1} in their account.", Name, Account);
        }
        //GiveCash ✅
        //recieve cash
        //log cash amount✅


    }
}

