using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class DecreaseAndConquerTwoPlayerPureNashEquilibrium
    {
        /// <summary>
        /// Recursively checks for pure Nash Equilibrium by dividing the payoff matrices in sections and checking those sections individually
        /// </summary>
        /// <param name="player1PayoffMatrix">Player1's payoffs</param>
        /// <param name="player2PayoffMatrix">Player2's payoffs</param>
        /// <param name="startRow">Starting row index</param>
        /// <param name="endRow">Ending row index</param>
        /// <param name="startColumn">Starting column index</param>
        /// <param name="endColumn">Ending column index</param>
        /// <returns></returns>
        public bool DecreaseAndConquerTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int startRow, int endRow, int startColumn, int endColumn)
        {
            // Base case for when there is just a single cell left to check
            if(startRow == endRow && startColumn == endColumn)
            {
                return IsNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, startColumn, player1PayoffMatrix.GetLength(0));
            }

            // Calculating middle cell index for row and column
            int midRow = (startRow + endRow) / 2;
            int midColumn = (startColumn + endColumn) / 2;

            // Checks the top left section of the matrices
            if (startRow < midRow || startColumn < midColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, midRow, startColumn, midColumn))
                {
                    return true;
                }
            }

            // Checks the top right of the matrices
            if (startRow < midRow || midColumn < endColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, midRow, midColumn + 1, endColumn))
                {
                    return true;
                }
            }

            // Checks the bottom left of the matrices
            if (midRow < endRow || startColumn < midColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, midRow + 1, endRow, startColumn, midColumn))
                {
                    return true;
                }
            }

            // Checks the bottom right of the matrices
            if (midRow < endRow || midColumn < endColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, midRow + 1, endRow, midColumn + 1, endColumn))
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Checks if there is a pure Nash Equilibrium for the given position of the payoff matrices
        /// </summary>
        /// <param name="player1PayoffMatrix"></param>
        /// <param name="player2PayoffMatrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool IsNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int i, int j, int n)
        {
            // If both players have a best strategy then there is a Nash Equilibrium
            var player1HasBestStrategy = true;
            var player2HasBestStrategy = true;

            // Check if player 1 has a better payoff available compared to the current payoff
            for (int k = 0; k < n; k++)
            {
                if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                {
                    player1HasBestStrategy = false;
                }
            }

            // Check if player 2 has a better payoff available compared to the current payoff
            for (int k = 0; k < n; k++)
            {
                if (player2PayoffMatrix[i, k] > player2PayoffMatrix[i, j])
                {
                    player2HasBestStrategy = false;
                }
            }

            // If both have a best strategy then there is a Nash Equilibrium
            return player1HasBestStrategy && player2HasBestStrategy;
        }
    }
}
