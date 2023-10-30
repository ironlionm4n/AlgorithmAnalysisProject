using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class BruteForceTwoPlayerPureNashEquilibrium
    {
        /// <summary>
        /// Takes in each players payoff matrix and the total length of the current input size
        /// For a Nash Equilibrium to be true then Player 1 cannot improve by switching to a different strategy in row i,
        /// Player 2 cannot improve by switching to a different strategy in column j
        /// </summary>
        /// <param name="player1PayoffMatrix">Player1's Strategy Rewards</param>
        /// <param name="player2PayoffMatrix">Player2's Strategy Rewards</param>
        /// <param name="n">Input size</param>
        /// <returns></returns>
        public bool BruteForceTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int n)
        {
            // Nested Loops to iterate over each players strategy payoff matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Assume there exists a pure nash equilibrium
                    bool player1HasBestStrategy = true;
                    bool player2HasBestStrategy = true;

                    // Check if player 1 has a better payoff available compared to the current payoff
                    for (int k = 0; k < n; k++)
                    {
                        // Compare all possible strategies to current strategy given Player 1 & 2 choice
                        if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                        {
                            // Found a better payoff for Player 1 in column j at row element k
                            player1HasBestStrategy = false;

                            // no need to continue checking once a new best strategy is found
                            break;
                        }
                    }

                    // Check if player 2 has a better payoff available compared to the current payoff
                    for (int k = 0; k < n; k++)
                    {
                        // Compare all possible strategies to current strategy given Player 1 & 2 choice
                        if (player2PayoffMatrix[i, k] > player2PayoffMatrix[i, j])
                        {
                            // Found a better payoff for Player 2 in row i at column element k
                            player2HasBestStrategy = false;

                            // no need to continue checking once a new best strategy is found
                            break;
                        }
                    }

                    // If both players don't have a better response, then it's a Nash Equilibrium
                    if (player1HasBestStrategy && player2HasBestStrategy)
                    {
                        Console.WriteLine("Brute Force NashEquilibrium Fround");
                        Console.WriteLine($"Strategy Combination: Player 1 uses strategy {i} with payoff {player1PayoffMatrix[i, j]}, " +
                            $"Player 2 uses strategy {j} with payoff {player2PayoffMatrix[i, j]}");
                        return true;
                    }
                }
            }
            return false;
        } 
    }
}
