using System;

namespace ConsoleCards_DotNet5
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck activeDeck = new Deck();
            char[] charsToTrim = {'(',')','1','2','3','4','5','6','7','8','9','0'};

            string UserOption()
            {
                Console.Write("Please choose your operation to perform on our deck of cards.");
                Console.WriteLine();
                Console.Write("Your options are: CreateDeck(), ShuffleDeck(), SortBy(rank or suit), DealOneCard(), DealCards(int count), or Quit()");
                Console.WriteLine();

                return Console.ReadLine();
            }
            
            void CreateDeck()
            {
                activeDeck = new Deck();
                
                for(int x = 0; x < 52; x++)
                {
                    Console.Write("{0,-19}", activeDeck.DealCard().ToString());

                    if((x + 1) % 4 == 0)
                        Console.WriteLine();
                }
            }

            void Loop() 
            {
                string userInput = UserOption();

                if(userInput == "CreateDeck()")
                {
                    CreateDeck();
                    Loop();
                }
                else if(userInput == "ShuffleDeck()")
                {
                    activeDeck.ShuffleDeck();
                    activeDeck.PrintDeck(activeDeck);
                    Loop();
                }
                else if(userInput.Substring(0,6) == "SortBy")
                {                    
                    string type = userInput.Substring(7,4);
                    if( type == "rank" || type == "suit")
                    {
                        Deck sortedDeck = activeDeck.Sort(type, activeDeck);
                        for(int x = 0; x < 52; x++)
                        {
                            Console.Write("{0,-19}", sortedDeck.DealCard().ToString());

                            if((x + 1) % 4 == 0)
                                Console.WriteLine();
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                    Loop();
                }
                else if (userInput == "DealOneCard()")
                {
                    Card card = activeDeck.DealCard();
                    Console.Write("Your card is...   the " + card);
                    Console.WriteLine();
                    Loop();
                }
                else if (userInput.Trim(charsToTrim) == "DealCards")
                {
                    string countString = userInput.Substring(10,1);
                    int count = int.Parse(countString);
                    activeDeck.DealCards(count);
                    Loop();
                }
                else{
                    return;
                }
            }

            Console.Write("Welcome to the great Deck of Cards Machine!");
            Console.WriteLine();
            Console.Write("------------------------------------------");
            Console.WriteLine();
            
            Loop();
        }
    }
}
