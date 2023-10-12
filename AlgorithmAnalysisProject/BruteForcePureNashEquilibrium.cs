using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class BruteForcePureNashEquilibrium
    {
        public bool BruteForceTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool player1BestResponse = true;
                    bool player2BestResponse = true;

                    // Check if player 1 has a better response
                    for (int k = 0; k < n; k++)
                    {
                        if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                        {
                            player1BestResponse = false;
                        }
                    }

                    // Check if player 2 has a better response
                    for (int l = 0; l < n; l++)
                    {
                        if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i, j])
                        {
                            player2BestResponse = false;
                        }
                    }

                    // If both players don't have a better response, then it's a Nash Equilibrium
                    if (player1BestResponse && player2BestResponse)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 
    }
}
