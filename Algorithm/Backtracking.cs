namespace Algorithm
{
    public class Backtracking
    {
        // The Knight’s tour problem 
        /* Backtracking Time Complexity O(8^(N^2))
         * If all squares are visited (value is the step order for the visited square, 0 for the unvisited)
         *      return result
         * Else
         *      1. Add one of the next moves to result vector 
         *          and recursively check if this move leads to a solution
         *              A Knight can make eight moves, need to check next move is safe (within the board and unvisited): 
         *                  (x + 1, y + 2), (x + 1, y - 2), 
         *                  (x - 1, y + 2), (x - 1, y - 2),
         *                  (x + 2, y + 1), (x + 2, y - 1), 
         *                  (x - 2, y + 1), (x - 2, y - 1).
         *      2. If the move chosen in the above step doesn't lead to a solution 
         *          then remove this move from the result vector and try other alternative moves.
         *      3. If none of the alternatives work then return false (Backtrack)
         *          and keep removing the added moves in the result vector.
         *      4. If false is returned by the initial call of recursive 
         *          then there is no solution, return an empty result.
         */
        public int[,] KnightsTourBacktracking(int n)
        {
            var result = new int[n, n];

            var xMove = new int[8] { 1, 1, 2, 2, -1, -1, -2, -2 };
            var yMove = new int[8] { 2, -2, 1, -1, 2, -2, 1, -1 };

            result[0, 0] = 1;

            if (KnightsTourHasSolution(result, 0, 0, xMove, yMove, 2))
            {
                return result;
            }
            else
            {
                Console.WriteLine("No Solution!");
                return new int[n, n];
            }
        }

        private bool KnightsTourHasSolution(int[,] result, int x, int y, int[] xMove, int[] yMove, int step)
        {
            if (result[x, y] == result.Length)
            {
                PrintBoard(result);
                return true;
            }

            for (var i = 0; i < xMove.Length; i++)
            {
                var xNextMove = x + xMove[i];
                var yNextMove = y + yMove[i];
                if (NextMoveIsSafe(xNextMove, yNextMove, result))
                {
                    result[xNextMove, yNextMove] = step;
                    if (KnightsTourHasSolution(result, xNextMove, yNextMove, xMove, yMove, step + 1))
                    {
                        return true;
                    }
                    else
                    {
                        result[xNextMove, yNextMove] = 0;
                    }
                }
            }

            return false;
        }

        private bool NextMoveIsSafe(int x, int y, int[,] result)
        {
            var length = result.GetLength(0);
            return x >= 0 && y >= 0 && x < length && y < length && result[x, y] == 0;
        }

        private void PrintBoard(int[,] board)
        {
            var n = board.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------------------");
        }


        /* 
         * Warnsdorff’s algorithm for Knight’s tour problem
         *      always move the knight to the square
         *          from which the knight will have the fewest onward moves (Minimal Degree).
         * Pros: Time Complexity O(N^2)
         * Cons: a heuristic approach doesn't guarantee an optimal solution. 
         *          It makes decisions based on the current state without considering the overall future impact, 
         *              which can sometimes lead to dead ends. (lack of backtracking)
        */

        // Declare move rules
        private readonly int[,] nextMove = new int[8, 2]
        {
                {1, 2 }, {1, -2 },
                {-1, 2 }, {-1, -2 },
                {2, 1 }, {2, -1 },
                {-2, 1 }, {-2, -1 },
        };

        public int[,]? KnightsTourWarnsdorff(int n)
        {
            var board = new int[n, n];

            // Start from any random position on the chessboard
            var x = new Random().Next(0, n - 1);
            var y = new Random().Next(0, n - 1);
            board[x, y] = 1;

            // iternate all step numbers from 2 to n * n
            for (int i = 2; i <= n * n; i++)
            {
                if (!CanMoveNext(board, ref x, ref y))
                {
                    Console.WriteLine("No Solution!");
                    return null;
                }
                else
                {
                    board[x, y] = i;
                }
            }

            PrintBoard(board);
            return board;
        }

        private bool CanMoveNext(int[,] board, ref int x, ref int y)
        {
            // find the min degree
            int minDegree = 9;
            int minDegree_Nextx = 0;
            int minDegree_Nexty = 0;

            for (int i = 0; i < 8; i++)
            {
                int next_x = x + nextMove[i, 0];
                int next_y = y + nextMove[i, 1];
                if (IsValidMove(next_x, next_y, board, board.GetLength(0)))
                {
                    int degree = GetDegree(next_x, next_y, board);
                    if (degree < minDegree)
                    {
                        minDegree = degree;
                        minDegree_Nextx = next_x;
                        minDegree_Nexty = next_y;
                    }
                }
            }

            if (minDegree == 9)
            {
                // lead to a dead end
                PrintBoard(board);
                return false;
            }
            else
            {
                x = minDegree_Nextx;
                y = minDegree_Nexty;
                return true;
            }
        }

        private int GetDegree(int x, int y, int[,] board)
        {
            int degree = 0;
            for (int i = 0; i < 8; i++)
            {
                int next_x = x + nextMove[i, 0];
                int next_y = y + nextMove[i, 1];
                if (IsValidMove(next_x, next_y, board, board.GetLength(0)))
                {
                    degree++;
                }
            }
            return degree;
        }

        private bool IsValidMove(int x, int y, int[,] board, int length)
        {
            return x >= 0 && x < length && y >= 0 && y < length && board[x, y] == 0;
        }
    }
}
