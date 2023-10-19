using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class BruteForceTwoPlayerPureNashEquilibrium
    {
        public bool BruteForceTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool player1HasBestStrategy = true;
                    bool player2HasBestStrategy = true;

                    // Check if player 1 has a better response
                    for (int k = 0; k < n; k++)
                    {
                        if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                        {
                            player1HasBestStrategy = false;
                        }
                    }

                    // Check if player 2 has a better response
                    for (int l = 0; l < n; l++)
                    {
                        if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i, j])
                        {
                            player2HasBestStrategy = false;
                        }
                    }

                    // If both players don't have a better response, then it's a Nash Equilibrium
                    if (player1HasBestStrategy && player2HasBestStrategy)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 
    }
}
