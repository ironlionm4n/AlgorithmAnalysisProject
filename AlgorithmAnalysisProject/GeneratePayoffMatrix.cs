using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class GeneratePayoffMatrix
    {
        public int[,] GenerateRandomPayoffMatrices(int n)
        {
            Random random = new Random();
            int[,] payoffMatrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    payoffMatrix[i, j] = random.Next(0, 10);
                }
            }

            return payoffMatrix;
        }
    }
}
