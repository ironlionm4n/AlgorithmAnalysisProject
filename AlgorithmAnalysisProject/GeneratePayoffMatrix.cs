using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class GeneratePayoffMatrix
    {
        public static readonly Random random = new Random();
        public int[,] GenerateRandomPayoffMatrices(int n)
        {
    
            int[,] payoffMatrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    // Payoff value when Player 1 chooses strategy i and Player 2 chooses strategy j
                    payoffMatrix[i, j] = random.Next(0, 20);
                }
            }

            return payoffMatrix;
        }
    }
}
