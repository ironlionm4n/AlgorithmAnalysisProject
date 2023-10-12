using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class DynamicProgrammingTwoPlayerNashEquilibrium
    {
        private int[,] player1PayoffMatrix = { { 3, 0 }, { 5, 1 } };
        private int[,] player2PayoffMatrix = { { 3, 5 }, { 0, 1 } };
        private int?[,] memoizationTable;

        public bool FindNashEquilibrium()
        {
            int n = player1PayoffMatrix.GetLength(0);
            int m = player2PayoffMatrix.GetLength(0);
            memoizationTable = new int?[n, m];

            return CheckForNashEquilibrium(0, 0);
        }

        private bool CheckForNashEquilibrium(int i , int j)
        {
            if(i >= player1PayoffMatrix.GetLength(0) || j >= player2PayoffMatrix.GetLength(0))
            {
                return false;
            }

            if (memoizationTable[i,j].HasValue)
            {
                return memoizationTable[i, j] == 1;
            }

            var player1BestStrategy = true;
            var player2BestStrategy = true;

            for(int k = 0; k < 2; k++)
            {
                if (player1PayoffMatrix[k,j] > player1PayoffMatrix[i,j])
                {
                    player1BestStrategy = false;
                    break;
                }
            }

            for(int l = 0; l < 2; l++)
            {
                if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i,j])
                {
                    player2BestStrategy = false;
                    break;
                }
            }

            var foundNashEquilibrium = player1BestStrategy && player2BestStrategy;

            memoizationTable[i, j] = !foundNashEquilibrium ? 0 : 1;


            if(foundNashEquilibrium)
            {
                return true;
            }

            return CheckForNashEquilibrium(i + 1, j) || CheckForNashEquilibrium(i, j + 1);
        }

    }
}
