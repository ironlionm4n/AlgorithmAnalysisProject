using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class DynamicProgrammingTwoPlayerNashEquilibrium
    {
        int[,] player1PayoffMatrix, player2PayoffMatrix;

        // Memoize previous calculated values to avoid redundant calculations
        private int?[,] memoizationTable;
      
        // Constructor
        public DynamicProgrammingTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix)
        {
            this.player1PayoffMatrix = player1PayoffMatrix;
            this.player2PayoffMatrix = player2PayoffMatrix;
            int n = player1PayoffMatrix.GetLength(0);
            memoizationTable = new int?[n, n];
        }

        // Initialize the memoization table and begin the recursive approach for finding NashEquilibrium
        public bool FindNashEquilibrium()
        {
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

            // Assume there exists a pure nash equilibrium
            var player1HasBestStrategy = true;
            var player2HasBestStrategy = true;

            // Check if player 1 has a better payoff available compared to the current payoff
            for (int k = 0; k < player1PayoffMatrix.GetLength(0); k++)
            {
                if (player1PayoffMatrix[k,j] > player1PayoffMatrix[i,j])
                {
                    player1HasBestStrategy = false;
                }
            }

            // Check if player 2 has a better payoff available compared to the current payoff
            for (int l = 0; l < player2PayoffMatrix.GetLength(0); l++)
            {
                if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i,j])
                {
                    player2HasBestStrategy = false;
                }
            }

            // If both players have a best strategy then there is a Nash Equilibrium
            var foundNashEquilibrium = player1HasBestStrategy && player2HasBestStrategy;

            // Assign the value for this position in the memoization table to 0 if there is not a nashEquilibrium at this point or 1 if there is.
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