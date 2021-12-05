using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five
{
    public static class OverlappingLines
    {
        public static int CalculateOverlappingLines(Tuple<List<Coordinate>, int> inputData, int NumberOfLines, bool includeDiagonals)
        {
            var board = CreateBoard(inputData, includeDiagonals);
            var count = 0;

            var maxLength = Math.Sqrt(board.Length);


            for (int y = 0; y < maxLength; y++)
            {
                for (int x = 0; x < maxLength; x++)
                {
                    var cell = board[x, y];

                    if (cell >= NumberOfLines)
                    {
                        count++;
                    }

                }

            }

            return count;
        }

        public static int[,] CreateBoard(Tuple<List<Coordinate>, int> inputData, bool includeDiagonals)
        {
            var coordinates = inputData.Item1;
            var maxValue = inputData.Item2;
            var board = new int[maxValue + 1, maxValue + 1];


            foreach (var coordinate in coordinates)
            {
                if (coordinate.Start.Item2 == coordinate.End.Item2)
                {
                    var yIndex = coordinate.Start.Item2;
                    if (coordinate.Start.Item1 < coordinate.End.Item1)
                    {
                        for (int i = coordinate.Start.Item1; i <= coordinate.End.Item1; i++)
                        {
                            int currentValue = board[i, yIndex];
                            board[i, yIndex] = ++currentValue;
                        }
                    }
                    else
                    {
                        for (int i = coordinate.End.Item1; i <= coordinate.Start.Item1; i++)
                        {
                            int currentValue = board[i, yIndex];
                            board[i, yIndex] = ++currentValue;
                        }
                    }
                }
                else if (coordinate.Start.Item1 == coordinate.End.Item1)
                {
                    var xIndex = coordinate.Start.Item1;
                    if (coordinate.Start.Item2 < coordinate.End.Item2)
                    {
                        for (int i = coordinate.Start.Item2; i <= coordinate.End.Item2; i++)
                        {
                            int currentValue = board[xIndex, i];
                            board[xIndex, i] = ++currentValue;
                        }
                    }
                    else
                    {
                        for (int i = coordinate.End.Item2; i <= coordinate.Start.Item2; i++)
                        {
                            int currentValue = board[xIndex, i];
                            board[xIndex, i] = ++currentValue;
                        }
                    }
                }
                else if (includeDiagonals)
                {
                    var deltaX = coordinate.Start.Item1 > coordinate.End.Item1 ? -1 : 1;
                    var deltaY = coordinate.Start.Item2 > coordinate.End.Item2 ? -1 : 1;

                    for (int i = 0; i <= Math.Abs(coordinate.Start.Item1 - coordinate.End.Item1); i++)
                    {
                        int x = coordinate.Start.Item1 + (deltaX * i);
                        int y = coordinate.Start.Item2 + (deltaY * i);
                        int currentValue = board[x, y];
                        board[x, y] = ++currentValue;
                    }
                }

            }
            return board;
        }

        public static string ConvertBoardToString(int[,] board)
        {
            var result = new StringBuilder();
            var maxLength = Math.Sqrt(board.Length);

            for (int y = 0; y < maxLength; y++)
            {
                for (int x = 0; x < maxLength; x++)
                {
                    var cell = board[x, y];

                    if (cell == 0)
                    {
                        result.Append('.');
                    }
                    else
                    {
                        result.Append(cell);
                    }
                }

                result.Append("\r\n");
            }

            return result.ToString().Trim();
        }
    }
}


