using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class MagicSquare
    {
        public static void createNSquare(int n)
        {
            /*
            6,1,8 
            7,5,3
            2,9,4
            */

            // initiaze
            int[,] quadrat = new int[n, n];

            // kann durch k ersetzt werden
            // int number = 1;
            // keine initialisierung erforderlich
            //int i = 0;
            //int j = 0;
            int i, j, ia, ja, ib, jb;

            //
            ia = 1; //1; 
            ja = 2; // 0;
            // 9 = 2,1
            // 1 = 0,1
            // 2 = 2,0
            // 

            ib = 1; //1; // 0
            jb = 0; //2; // 1
            bool turn = true;

            //ia = 

            
            // mitte
            quadrat[n / 2, n / 2] = (n * n + 1) / 2;

            for (int k = 1; k < (n*n); k++)
            {
                // anstatt auf 2,2 für 4 lande ich bei 0,1 wodurch die 1 dort überschrieben wird
                // die 6 überschreibt zwar dann die 9 auf der 2,1 ist aber dem Muster entsprechend richtig
                i = ib - ia;
                j = jb - ja;
                ia = ib; 
                ja = jb;

                if (k/2+1 > n+1)
                {
                    i = n-1;
                    j = n-1;
                }
                i = i < 0 ? i += n : i = i;
                j = j < 0 ? j += n : j = j;
                 
                ib = i;
                jb = j;
                if (turn)
                    quadrat[i, j] = k/2+1;
                else
                    quadrat[i, j] = (n * n + 1) - (k/2);
                 //   quadrat[i, j] = (n * n) - (k / 2);
                 
                

                turn = !turn;

                Console.WriteLine(quadrat[i, j]);
            }
            Console.ReadKey();

            /*
            int[,] quadrat = new int[n,n];
            int i = 0;
            int j = 0;
            int ia, ja, ib, jb;
            int number = 1;
            // mitte
            quadrat[n / 2, n / 2] = (n * n + 1) / 2;

            // 1
            //quadrat[0, 1] = number;
            j = n / 2 - j; //j = 0 n = 3 ==> j = 1
            ia = 0;
            ja = 1;
            quadrat[i, j] = number;
            // 9
            //quadrat[2, 1] = (n * n + 1) - number;
            i = n - 1;
            ib = 2;
            jb = 1;
            quadrat[i, j] = (n * n + 1) - number;

            // zähler erhöhen
            number++;
            //2
            //quadrat[2, 0] = number;
            //j = n / 2 - j; // j = 1 n = 3 ==> j = 0;
            i = ib - ia; 
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            //  mark = turn ? "X" : "O";


            ib = i;
            jb = j;
            

            quadrat[i, j] = number;

            //8
            i = ib - ia;
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            ib = i;
            jb = j;

            quadrat[i, j] = (n * n + 1) - number;
            // zähler erhöhen
            number++;
            //3
            i = ib - ia;
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            ib = i;
            jb = j;

            quadrat[i, j] = number;

            //7
            i = ib - ia;
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            ib = i;
            jb = j;

            quadrat[i, j] = (n * n + 1) - number;
            // zähler erhöhen
            number++;
            //4
            i = ib - ia;
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            ib = i;
            jb = j;

            quadrat[i, j] = number;
            //6
            i = ib - ia;
            j = jb - ja;
            ia = ib;
            ja = jb;

            i = i < 0 ? i += n : i = i;
            j = j < 0 ? j += n : j = j;

            ib = i;
            jb = j;


            quadrat[i, j] = (n * n + 1) - number;
            */
        }
    }
}


