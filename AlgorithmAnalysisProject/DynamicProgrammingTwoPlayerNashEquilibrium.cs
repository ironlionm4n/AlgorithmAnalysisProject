using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class DynamicProgrammingTwoPlayerNashEquilibrium
    {
        // Payoffs represent the different strategies available to choose from for each player
        private int[,] player1PayoffMatrix = { { 3, 0 }, { 5, 1 } };
        private int[,] player2PayoffMatrix = { { 3, 5 }, { 0, 1 } };

        // Memoize previous calculated values to avoid redundant calculations
        private int?[,] memoizationTable;

        // Initialize the memoization table and begin the recursive approach for finding NashEquilibrium
        public bool FindNashEquilibrium()
        {
            int n = player1PayoffMatrix.GetLength(0);
            int m = player2PayoffMatrix.GetLength(0);
            memoizationTable = new int?[n, m];

            return CheckForNashEquilibrium(0, 0);
        }

        // Checks for a Nash Equilibrium for the given strategies for player 1 and player 2
        private bool CheckForNashEquilibrium(int i , int j)
        {
            // Return false if we have gone out of bounds of the payoff matrix
            if(i >= player1PayoffMatrix.GetLength(0) || j >= player2PayoffMatrix.GetLength(0))
            {
                return false;
            }

            // Returns true if the value in the memoization table equals 1 as a Nash Equilibrium was found
            if (memoizationTable[i,j].HasValue)
            {
                return memoizationTable[i, j] == 1;
            }

            var player1BestStrategy = true;
            var player2BestStrategy = true;

            // Check if a better strategy exists compared to the current strategy
            for(int k = 0; k < 2; k++)
            {
                if (player1PayoffMatrix[k,j] > player1PayoffMatrix[i,j])
                {
                    player1BestStrategy = false;
                    break;
                }
            }

            // Check if a better strategy exists compared to the current strategy
            for (int l = 0; l < 2; l++)
            {
                if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i,j])
                {
                    player2BestStrategy = false;
                    break;
                }
            }

            // If both players have a best strategy then there is a Nash Equilibrium
            var foundNashEquilibrium = player1BestStrategy && player2BestStrategy;
            memoizationTable[i, j] = !foundNashEquilibrium ? 0 : 1;

            // If a Nash Equilibrium is found then return true
            if(foundNashEquilibrium)
            {
                return true;
            }

            // If the current strategies do not form a Nash Equilibrium then check the next strategy for each player
            return CheckForNashEquilibrium(i + 1, j) || CheckForNashEquilibrium(i, j + 1);
        }

    }
}