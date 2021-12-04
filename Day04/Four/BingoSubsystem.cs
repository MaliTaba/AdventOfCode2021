namespace Four
{
    public class BingoSubsystem
    {
        public class Cell
        {
            public string value;
            public bool called;

            public Cell(string value, bool isCalled)
            {
                this.value = value;
                this.called = isCalled;
            }

            public void setCalled(bool isCalled)
            {
                this.called = isCalled;
            }
        }

        public static List<List<List<Cell>>> ReadBoardsFromFile(string filePath)
        {
            var inputData = File.ReadAllLines(filePath);
            var board = new List<List<Cell>>();
            var boards = new List<List<List<Cell>>>();

            foreach (var line in inputData)
            {
                if (string.IsNullOrEmpty(line))
                {
                    boards.Add(board);
                    board = new List<List<Cell>>();
                    continue;
                }

                var rowValues = line.Split(' ');
                var boardCells = rowValues
                    .Where(st => !string.IsNullOrEmpty(st))
                    .Select(s => new Cell(s, false))
                    .ToList();

                board.Add(boardCells);

            }
            boards.Add(board);
            return boards;
        }

        public static int CalculateScore(List<List<List<Cell>>> boards, string calledNumbersCsv, int targetPosition)
        {
            List<List<List<Cell>>> winners = new List<List<List<Cell>>>();
            string lastCalledNumber = null;

            foreach (var calledNumber in calledNumbersCsv.Split(',').ToArray())
            {
                foreach (var board in boards)
                {
                    if (winners.Contains(board))
                    {
                        continue;
                    }

                    foreach (var row in board)
                    {
                        foreach (var cell in row)
                        {
                            if (string.Equals(cell.value, calledNumber))
                            {
                                cell.called = true;

                                if (isWinner(board))
                                {
                                    winners.Add(board);
                                    lastCalledNumber = calledNumber;

                                    if (winners.Count == targetPosition || winners.Count == boards.Count)
                                    {
                                        goto foundTargetWinner;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }


            if (winners.Count == 0)
            {
                return 0;
            }

            foundTargetWinner:

            var winner = winners[Math.Max(targetPosition - 1, winners.Count - 1)];

            int sum = 0;

            foreach (var row in winner)
            {
                foreach (var cell in row)
                {
                    if (!cell.called)
                    {
                        sum += int.Parse(cell.value);
                    }
                }
            }

            return sum * int.Parse(lastCalledNumber);
        }

        private static bool isWinner(List<List<Cell>> board)
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[i].All(cell => cell.called))
                {
                    return true;
                }

                bool allColumnCellsCalled = true;

                foreach (var row in board)
                {
                    if (!row[i].called)
                    {
                        allColumnCellsCalled = false;
                        break;
                    }
                }

                if (allColumnCellsCalled)
                {
                    return true;
                }
            }

            return false;
        }

        private Tuple<int, int[], int[,]> GetFirstBingoBoardWinnerAndLastCalledNum(int[] bingoSetNumbers, int[,] bingoBoards)
        {
            throw new NotImplementedException();
        }

        public int CalculateSumUnmarkedNumbers(int[] unmarkedNums)
        {
            return unmarkedNums.Select(i => (int)i).Sum();
        }
    }
}
