using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class MagicSquare
    {
        public static void createMagicSquare(int n)
        {
            if (n%2 == 1) //n is odd
            {
                OddSquare(n);
            }
            else // n is even
            {
                if (n % 4 == 0) //doubly even order
                    doublyEvenMagicSquare();
                else
                    singlyEvenMagixSquare();
            }
                
        }

        private static void doublyEvenMagicSquare()
        {
            throw new NotImplementedException();
        }

        private static void singlyEvenMagixSquare()
        {
            throw new NotImplementedException();
        }

        public static void OddSquare(int n)
        {
            int[,] matrix = new int[n, n];

            int nsqr = n * n;
            int i = 0, j = n / 2;     // start position

            for (int k = 1; k <= nsqr; ++k)
            {
                matrix[i, j] = k;

                --i;
                ++j;

                if (k % n == 0)
                {
                    i += 2;
                    --j;
                }
                else
                {
                    if (j == n)
                        j -= n;
                    else if (i < 0)
                        i += n;
                }
            }  
        }
    }
}


