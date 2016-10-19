using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    class JednorekiBandyta
    {
        int[,] board;
        GraczWJednorekiegoBandyte player;

        public JednorekiBandyta()
        {
            board = new int[3, 3];
        }

        public void Play(GraczWJednorekiegoBandyte player)
        {
            this.player = player;
            while(true)
            {
                Console.WriteLine("Twoja gotówka: " + player.Cash +"$");
                Console.WriteLine("Wpisz \"PULL\" aby zagrać (50$), \"EXIT\" aby wyjść");
                switch (Console.ReadLine())
                {
                    case "PULL":
                        Console.Clear();
                        player.Cash -= 50;
                        Pull();
                        break;
                    case "EXIT":
                        Console.Clear();
                        Console.WriteLine("Dziękujemy za przewalenie pieniędzy w Jednorękim Bandycie! Zapraszamy ponownie!");
                        return;
                }
            }
        }

        private void Pull()
        {
            Random r = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    board[i, j] = r.Next(0, 9);
                Console.WriteLine(board[i,0]+"   "+board[i,1]+"   "+board[i,2]);
            }

            Check();
        }

        private void Check()
        {
            for(int i=0; i<3; i++)
                if(board[i,0] == board[i,1] && board [i,0] == board[i,2])
                {
                    Console.WriteLine("Trafienie w wierszu " + (i + 1) + "! $500 na Twoje konto!");
                    player.Cash += 500;
                }
                else if(board[0,i] == board[1, i] && board[0, i] == board[2, i])
                {
                    Console.WriteLine("Trafienie w kolumnie " + (i + 1) + "! $500 na Twoje konto!");
                    player.Cash += 500;
                }
            if(board[0,0] == board[1,1] && board[0,0] == board[2,2])
            {
                Console.WriteLine("Trafienie po skosie w dół! $500 na Twoje konto!");
                player.Cash += 500;
            }
            else if (board[0, 2] == board[1, 1] && board[0, 0] == board[2, 0])
            {
                Console.WriteLine("Trafienie po skosie w górę! $500 na Twoje konto!");
                player.Cash += 500;
            }
        }
    }
}
