using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class PureNashEquilibrium
    {
        private int[,] player1PayoffMatrix = { { 3, 0 }, { 5, 1 } };
        private int[,] player2PayoffMatrix = { { 3, 5 }, { 0, 1 } };

        public bool BruteForceTwoPlayerNashEquilibrium()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bool player1BestResponse = true;
                    bool player2BestResponse = true;

                    // Check if player 1 has a better response
                    for (int k = 0; k < 2; k++)
                    {
                        if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                        {
                            player1BestResponse = false;
                            break;
                        }
                    }

                    // Check if player 2 has a better response
                    for (int l = 0; l < 2; l++)
                    {
                        if (player2PayoffMatrix[i, l] > player2PayoffMatrix[i, j])
                        {
                            player2BestResponse = false;
                            break;
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
