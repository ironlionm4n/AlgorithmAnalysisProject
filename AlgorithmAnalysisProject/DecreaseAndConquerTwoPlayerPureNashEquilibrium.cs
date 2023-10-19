using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAnalysisProject
{
    class DecreaseAndConquerTwoPlayerPureNashEquilibrium
    {
        public bool DecreaseAndConquerTwoPlayerNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int startRow, int endRow, int startColumn, int endColumn)
        {
            if(startRow == endRow && startColumn == endColumn)
            {
                return IsNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, startColumn, player1PayoffMatrix.GetLength(0));
            }

            int midRow = (startRow + endRow) / 2;
            int midColumn = (startColumn + endColumn) / 2;

            if (startRow < midRow || startColumn < midColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, midRow, startColumn, midColumn)) return true;
            }
            if (startRow < midRow || midColumn < endColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, startRow, midRow, midColumn + 1, endColumn)) return true;
            }
            if (midRow < endRow || startColumn < midColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, midRow + 1, endRow, startColumn, midColumn)) return true;
            }
            if (midRow < endRow || midColumn < endColumn)
            {
                if (DecreaseAndConquerTwoPlayerNashEquilibrium(player1PayoffMatrix, player2PayoffMatrix, midRow + 1, endRow, midColumn + 1, endColumn)) return true;
            }

            return false;

        }

        private bool IsNashEquilibrium(int[,] player1PayoffMatrix, int[,] player2PayoffMatrix, int i, int j, int n)
        {
            var player1HasBestStrategy = true;
            var player2HasBestStrategy = true;

            for(int k = 0; k < n; k++)
            {
                if (player1PayoffMatrix[k, j] > player1PayoffMatrix[i, j])
                {
                    player1HasBestStrategy = false;
                }
            }

            for(int k = 0; k < n; k++)
            {
                if (player2PayoffMatrix[i, k] > player2PayoffMatrix[i, j])
                {
                    player2HasBestStrategy = false;
                }
            }

            return player1HasBestStrategy && player2HasBestStrategy;
        }
    }
}
