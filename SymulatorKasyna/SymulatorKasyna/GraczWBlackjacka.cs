using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    public class GraczWBlackjacka
    {
        static string[] deck;
        Random r = new Random();
        int cash;
        int bet;

        private struct value
        {
            public string cardName;
            public int cardValue;
            public value(string cn, int cv)
            {
                this.cardName = cn;
                this.cardValue = cv;
            }
        }
        static List<value> values = new List<value>();

        public GraczWBlackjacka(int cash)
        {
            this.cash = cash;
        }

        public int Play()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] hearts = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            for (int i = 0; i < 13; i++)
                hearts[i] += "\u2665";

            string[] diamonds = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            for (int i = 0; i < 13; i++)
                diamonds[i] += "\u2666";

            string[] clubs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            for (int i = 0; i < 13; i++)
                clubs[i] += "\u2663";

            string[] spades = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            for (int i = 0; i < 13; i++)
                spades[i] += "\u2660";

            for (int i = 2; i <= 10; i++)
                values.Add(new value(""+i, i));
            values.Add(new value("J", 10));
            values.Add(new value("Q", 10));
            values.Add(new value("K", 10));
            values.Add(new value("A", 11));

            string playAgain = null;


            do
            {
                if (cash > 0)
                {
                    Console.WriteLine("Grasz (g) czy nie grasz (n)?");
                    playAgain = Console.ReadLine();
                    if (playAgain.ToLower() == "g")
                    {
                        Console.Clear();
                        Console.WriteLine("Stan Twojego konta: ${0}", cash);

                        do
                        {
                            Console.WriteLine("Podaj stawkę: ");
                            if (int.TryParse(Console.ReadLine(), out bet) && bet <= cash && bet > 0)
                            {
                                Console.WriteLine("Postawiłeś: ${0}", bet);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nie masz tylu pieniędzy lub wpisałeś niepoprawne dane.");
                            }
                        } while (true);
                    }
                }
                else
                    playAgain = "n";


                if (playAgain == "g")
                {
                    deck = hearts.Concat(diamonds).Concat(clubs).Concat(spades).ToArray();
                    deck = deck.OrderBy(x => r.NextDouble()).ToArray();

                    string[] dealersHand = deck.Take(2).ToArray();
                    deck = deck.Except(dealersHand).ToArray();

                    string[] playersHand = deck.Take(2).ToArray();
                    deck = deck.Except(playersHand).ToArray();

                    int dealersScore = dealersHand.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);
                    if (dealersScore == 22)
                        dealersScore = 12;
                    int playersScore = playersHand.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);
                    if (playersScore == 22)
                        playersScore = 12;

                    showCards("Twoje karty: ", playersHand);

                    Console.WriteLine();

                    if (playersScore == 21 & !(dealersScore == 21))
                    {
                        Console.WriteLine("21! Wygrałeś!");
                        Console.WriteLine();
                        showCards("Karty krupiera: ", dealersHand);
                        changeAccountBalance("player");
                    }
                    else if (playersScore == 21 & dealersScore == 21)
                    {
                        showCards("Karty krupiera: ", dealersHand);
                        Console.WriteLine("Remis");
                        changeAccountBalance("draw");
                    }
                    else if ((!(playersScore == 21) & !(dealersScore == 21)) || (!(playersScore == 21) & dealersScore == 21))
                    {
                        playGame("player", playersScore, dealersScore, playersHand, dealersHand);
                    }
                }
                Console.WriteLine();
            } while (playAgain == "g");

            return cash;
        }

        private void playGame(string player, int playersScore, int dealersScore, string[] playersHand, string[] dealersHand)
        {
            string response = "";
            if (player == "player")
            {
                Console.WriteLine("Dociągnąć karty? tak (t), nie (n)");
                response = Console.ReadLine();
                Console.WriteLine();
            }
            else
            {
                response = "t";
            }

            if (response == "t")
            {
                string [] newCards = deck.Take(1).ToArray();
                deck = deck.Except(newCards).ToArray();

                playersHand = playersHand.Concat(newCards).ToArray();

                if (player == "player")
                {
                    showCards("Twoje karty: ", playersHand);
                    Console.WriteLine();
                }

                playersScore = playersHand.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);

                if (player == "player")
                {
                    if (playersScore > 21 & !(playersScore - (playersHand.Count(c => c.StartsWith("A")) * 10) <= 21))
                    {
                        showCards("Karty krupiera: ", player == "player" ? dealersHand : playersHand);
                        Console.WriteLine();
                        changeAccountBalance(findWinner(player, playersHand, dealersHand));
                    }
                    else if (playersScore > 21 & (playersScore - (playersHand.Count(c => c.StartsWith("A")) * 10) <= 21))
                    {
                        int count = 0;
                        while (count < playersHand.Count(c => c.StartsWith("A")) & playersScore > 21)
                        {
                            count += 1;
                            playersScore -= 10;
                        }
                        if (playersScore < 21)
                        {
                            playGame("player", playersScore, dealersScore, playersHand, dealersHand);
                        }
                        else
                        {
                            showCards("Karty krupiera: ", dealersHand);
                            changeAccountBalance(findWinner(player, playersHand, dealersHand));
                        }
                    }
                    else if (playersScore < 21)
                    {
                        playGame("player", playersScore, dealersScore, playersHand, dealersHand);
                    }
                    else if (playersScore == 21)
                    {
                        playGame("dealer", dealersScore, playersScore, dealersHand, playersHand);
                    }
                }
                else
                {
                    if (playersScore < 17)
                    {
                        playGame("dealer", playersScore, dealersScore, playersHand, dealersHand);
                    }
                    else
                    {
                        if (playersScore < 20)
                        {
                            if (r.Next(0, 4) == 1)
                            {
                                playGame("dealer", playersScore, dealersScore, playersHand, dealersHand);
                            }
                            else
                            {
                                showCards("Karty krupiera: ", playersHand);
                                changeAccountBalance(findWinner(player, playersHand, dealersHand));
                            }
                        }
                        else if (playersScore > 21 & (playersScore - (playersHand.Count(c => c.StartsWith("A")) * 10) <= 21))
                        {
                            int count = 0;
                            while (count < playersHand.Count(c => c.StartsWith("A")) & playersScore > 21)
                            {
                                count += 1;
                                playersScore -= 10;
                            }
                            if (playersScore < 21)
                            {
                                playGame("dealer", playersScore, dealersScore, playersHand, dealersHand);
                            }
                            else
                            {
                                showCards("Karty krupiera: ", playersHand);
                                changeAccountBalance(findWinner(player, playersHand, dealersHand));
                            }
                        }
                        else
                        {
                            showCards("Karty krupiera: ", playersHand);
                            changeAccountBalance(findWinner(player, playersHand, dealersHand));
                        }
                    }
                }
            }
            else
            {
                if (dealersScore < 17)
                {
                    playGame("dealer", dealersScore, playersScore, dealersHand, playersHand);
                }
                else
                {
                    if (dealersScore < 20)
                    {
                        if (r.Next(0, 4) == 1)
                        {
                            playGame("dealer", dealersScore, playersScore, dealersHand, playersHand);
                        }
                        else
                        {
                            showCards("Karty krupiera: ", dealersHand);
                            changeAccountBalance(findWinner(player, playersHand, dealersHand));
                        }
                    }
                    else
                    {
                        showCards("Karty krupiera: ", dealersHand);
                        changeAccountBalance(findWinner(player, playersHand, dealersHand));
                    }
                }
            }
        }

        private string findWinner(string player, string[] playersHand, string[] dealersHand)
        {
            int playersScore = playersHand.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);

            int count = 0;
            while (count < playersHand.Count(currCard => currCard.StartsWith("A")) & playersScore > 21)
            {
                count += 1;
                playersScore -= 10;
            }

            int dealersScore = dealersHand.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);

            count = 0;
            while (count < dealersHand.Count(c => c.StartsWith("A")) & dealersScore > 21)
            {
                count += 1;
                dealersScore -= 10;
            }

            if (player == "player")
            {
                if (playersScore <= 21 && dealersScore <= 21)
                {
                    if (playersScore > dealersScore)
                    {
                        Console.WriteLine("Wygrałeś!");
                        return "player";
                    }
                    else if (dealersScore > playersScore)
                    {
                        Console.WriteLine("Przegrałeś!");
                        return "dealer";
                    }
                    else
                    {
                        Console.WriteLine("Remis!");
                        return "draw";
                    }
                }
                else
                {
                    Console.WriteLine(playersScore > 21 ? "Przedobrzyłeś! Przegrałeś!" : "Krupier przedobrzył! Wygrałeś!");
                    return playersScore > 21 ? "dealer" : "player";
                }
            }
            else
            {
                if (playersScore <= 21 && dealersScore <= 21)
                {
                    if (dealersScore > playersScore)
                    {
                        Console.WriteLine("Wygrałeś!");
                        return "player";
                    }
                    else if (playersScore > dealersScore)
                    {
                        Console.WriteLine("Przegrałeś!");
                        return "dealer";
                    }
                    else
                    {
                        Console.WriteLine("Remis!");
                        return "draw";
                    }
                }
                else
                {
                    Console.WriteLine(dealersScore > 21 ? "Przedobrzyłeś! Przegrałeś!" : "Krupier przedobrzył! Wygrałeś!");
                    return playersScore > 21 ? "dealer" : "player";
                }
            }
        }

        private void showCards(string label, string[] cards)
        {
            Console.Write(label);

            for (int x = 0; x <= cards.GetUpperBound(0); x++)
                Console.Write(cards[x] + " ");

            int cardSum = cards.Sum(currCard => values.First(v => noShapes(currCard) > 0 ? noShapes(currCard).ToString() == v.cardName : currCard.StartsWith(v.cardName)).cardValue);

            int count = 0;
            while (count < cards.Count(c => c.StartsWith("A")) & cardSum > 21)
            {
                count += 1;
                cardSum -= 10;
            }

            Console.Write("({0})", cardSum);
            Console.WriteLine();
        }

        private void changeAccountBalance(string winner) => cash += winner == "player" ? bet : winner == "dealer" ? -bet : 0;

        private int noShapes(string currCard)
        {
            int currCardValue;
            Int32.TryParse(currCard.Replace(((Char)3).ToString(), "").Replace(((Char)4).ToString(), "").Replace(((Char)5).ToString(), "").Replace(((Char)6).ToString(), ""), out currCardValue);
            return currCardValue;
        }        
    }
}
