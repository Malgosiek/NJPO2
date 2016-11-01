using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    public class Symulator
    {
        int boardSize;
        Random r = new Random();
        UzytkownikDrogi user1;
        UzytkownikDrogi user2;
        UzytkownikDrogi user3;

        public Symulator(int boardSize)
        {
            this.boardSize = boardSize;
        }

        public void Play()
        {
            Console.Clear();
            //pieszy
            user1 = new Pieszy();
            Console.WriteLine("Szybkosc pieszego: " + user1.Speed());
            //rowerzysta
            user2 = new Pieszy();
            user2 = new DekoratorRower(user2);
            Console.WriteLine("Szybkosc rowerzysty: " + user2.Speed());
            //kierowca
            user3 = new Pieszy();
            user3 = new DekoratorSamochod(user3);
            Console.WriteLine("Szybkosc kierowcy: " + user3.Speed());
            Console.WriteLine("Wciśnij Enter, aby zacząć.");
            Console.ReadLine();
            Console.Clear();

            bool kraksa = false;
            string[,] board = new string[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = "-";
                }
            }

            //pozycje startowe
            user1.X = r.Next(boardSize);
            user1.Y = r.Next(boardSize);

            do
            {
                user2.X = r.Next(boardSize);
                user2.Y = r.Next(boardSize);
            } while (user2.X == user1.X && user2.Y == user1.Y);

            do
            {
                user3.X = r.Next(boardSize);
                user3.Y = r.Next(boardSize);
            } while ((user3.X == user1.X && user3.Y == user1.Y) || (user3.X == user2.X && user3.Y == user2.Y));

            do
            {
                Console.Clear();
                Console.Write("User1: ");
                user1 = Change(user1);
                Console.WriteLine("User1 to: " + user1.GetType().Name);
                //Console.WriteLine("User2 Speed: " + user1.Speed());

                Console.Write("User2: ");
                user2 = Change(user2);
                Console.WriteLine("User2 to: " + user2.GetType().Name);
                //Console.WriteLine("User2.Speed: " + user2.Speed());

                Console.Write("User3: ");
                user3 = Change(user3);
                Console.WriteLine("User3 to: " + user3.GetType().Name);
                //Console.WriteLine("User3 Speed: " + user3.Speed());

                Console.WriteLine();

                user1 = CalculatePos(user1);
                user2 = CalculatePos(user2);
                user3 = CalculatePos(user3);

                
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if ((user1.X == i && user1.Y == j) && (user2.X == i && user2.Y == j)
                            || (user1.X == i && user1.Y == j) && (user3.X == i && user3.Y == j)
                            || (user1.X == i && user1.Y == j) && (user2.X == i && user2.Y == j)
                            || (user3.X == i && user3.Y == j) && (user2.X == i && user2.Y == j)
                            || ((user1.X == i && user1.Y == j) && (user2.X == i && user2.Y == j)) && (user3.X == i && user3.Y == j))
                        {
                            Console.Write("X");
                            kraksa = true;
                        }
                        else if (user1.X == i && user1.Y == j)
                            Console.Write(user1.GetName());
                        else if (user2.X == i && user2.Y == j)
                            Console.Write(user2.GetName());
                        else if (user3.X == i && user3.Y == j)
                            Console.Write(user3.GetName());
                        else
                            Console.Write(board[i, j].ToString());
                    }
                    Console.Write("\n");
                }
                Thread.Sleep(1000);
                //Console.ReadLine();
            } while (kraksa == false);

            Console.WriteLine("Kraksa!");
            Console.WriteLine("Wciśnij Enter.");
            Console.ReadLine();
            Console.Clear();
        }

        UzytkownikDrogi CalculatePos(UzytkownikDrogi user)
        {
            for (int i = 0; i < user.Speed(); i++)
            {
                int tmp = r.Next(4);

                switch (tmp)
                {
                    //w lewo
                    case 0:
                        if (user.Y > 0)
                            user.Y -= 1;
                        else i--;
                        break;
                    //w prawo
                    case 1:
                        if (user.Y < boardSize - 1)
                            user.Y += 1;
                        else i--;
                        break;
                    //do gory
                    case 2:
                        if (user.X > 0)
                            user.X -= 1;
                        else i--;
                        break;
                    //w dol
                    case 3:
                        if (user.X < boardSize - 1)
                            user.X += 1;
                        else i--;
                        break;
                }
            }
            return user;
        }

        UzytkownikDrogi Change(UzytkownikDrogi user)
        {
            double chance = r.NextDouble();
            if (0.8 < chance && chance <= 0.9 && !(user is DekoratorRower))
            {
                Console.WriteLine("Przesiada się na rower.");
                user = new DekoratorRower(user);
            }
            else if (0.9 < chance && !(user is DekoratorSamochod))
            {
                Console.WriteLine("Przesiada się na samochód.");
                user = new DekoratorSamochod(user);
            }
            else if (0.5 < chance && chance <= 0.8 && (user is DekoratorRower || user is DekoratorSamochod))
            {
                Console.WriteLine("Zaczyna iść pieszo.");
                user = new Pieszy(user);
            }
            else
                Console.WriteLine("Pozostaje przy swoim środku transportu.");
            return user;
        }
    }
}
