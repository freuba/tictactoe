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
            int number = 1;
            int i = 0;
            int j = 0;
            int ia, ja, ib, jb;
            ia = 0;
            ja = 0;
            ib = 0;
            jb = 1;
            bool turn = true;

            //ia = 

            
            // mitte
            quadrat[n / 2, n / 2] = (n * n + 1) / 2;

            for (int k = 0; k < (n*n); k++)
            {
                // ich fange bereits mit der 1 position an
                i = ib - ia;
                j = jb - ja;
                ia = ib;
                ja = jb;

                i = i < 0 ? i += n : i = i;
                j = j < 0 ? j += n : j = j;
                 
                ib = i;
                jb = j;
                if (turn)
                    quadrat[i, j] = number;
                else 
                    quadrat[i, j] = (n * n + 1) - number;
                number++;
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


