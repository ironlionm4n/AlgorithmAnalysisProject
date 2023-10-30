using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    internal class DivideConquerTwoPlayerNashEquilibrium
    {
        public bool DivideConquerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int start, int end)
        {
            var n = player1PayoffMatrix.GetLength(0);

            var mid = (end + start) / 2;

            for(int i = start; i <= mid; i++)
            {
                for(int j = 0; j < player1PayoffMatrix.GetLength(0); j++)
                {
                    if(IsNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, i, j, n))
                    {
                        Console.WriteLine("Divide And Conquer Nash Equilibrium Fround - First Half");
                        return true;
                    }
                }
            }


            for (int i = mid + 1; i <= end; i++)
            {
                for (int j = 0; j < player1PayoffMatrix.GetLength(0); j++)
                {
                    if (IsNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, i, j, n))
                    {
                        Console.WriteLine("Divide And Conquer Nash Equilibrium Fround - Second Half");
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if there is a pure Nash Equilibrium for the given position of the payoff matrices
        /// For a Nash Equilibrium to be true then Player 1 cannot improve by switching to a different strategy in row i,
        /// Player 2 cannot improve by switching to a different strategy in column j
        /// Still have to check each cell in payoff matrices for a better strategy in the row i for Player 1 and column j for Player 2
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
                    break;
                }
            }

            // Check if player 2 has a better payoff available compared to the current payoff
            for (int k = 0; k < n; k++)
            {
                if (player2PayoffMatrix[i, k] > player2PayoffMatrix[i, j])
                {
                    player2HasBestStrategy = false;
                    break;
                }
            }

            // If both have a best strategy then there is a Nash Equilibrium
            if( player1HasBestStrategy && player2HasBestStrategy)
            {
                Console.WriteLine($"Strategy Combination: Player 1 uses strategy {i} with payoff {player1PayoffMatrix[i, j]}, " +
                    $"Player 2 uses strategy {j} with payoff {player2PayoffMatrix[i, j]}");

                return true;
            }

            return false;
        }
    }
}