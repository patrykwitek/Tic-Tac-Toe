using System;

namespace tictactoe
{
    class TicTacToe
    {
        public char winner;

        public bool isWin;

        public char[] position = new char[9];

        public void BoardRefresh()
        {
            Console.WriteLine(" {0} | {1} | {2} ", position[0], position[1], position[2]);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", position[3], position[4], position[5]);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", position[6], position[7], position[8]);
        }

        public bool CheckWin()
        {
            // check for vertical win
            for (int i = 0; i < 3; i++)
            {
                if ((position[i] == 'X') && (position[i + 3] == 'X') && (position[i + 6] == 'X'))
                {
                    isWin = true;
                    winner = 'X';
                    return isWin;
                }
                if ((position[i] == 'Y') && (position[i + 3] == 'Y') && (position[i + 6] == 'Y'))
                {
                    isWin = true;
                    winner = 'Y';
                    return isWin;
                }

                if ((i % 3 == 0) && ((i + (i + 1) + (i + 2)) % 3 == 0) && (position[i] == 'X') && (position[i + 1] == 'X') && (position[i + 2] == 'X'))
                {
                    isWin = true;
                    winner = 'X';
                    return isWin;
                }
                if ((i % 3 == 0) && ((i + (i + 1) + (i + 2)) % 3 == 0) && (position[i] == 'Y') && (position[i + 1] == 'Y') && (position[i + 2] == 'Y'))
                {
                    isWin = true;
                    winner = 'Y';
                    return isWin;
                }
            }

            // check for horizontal win
            for (int i = 0; i < 7; i = i + 3)
            {
                if ((i % 3 == 0) && ((i + (i + 1) + (i + 2)) % 3 == 0) && (position[i] == 'X') && (position[i + 1] == 'X') && (position[i + 2] == 'X'))
                {
                    isWin = true;
                    winner = 'X';
                    return isWin;
                }
                if ((i % 3 == 0) && ((i + (i + 1) + (i + 2)) % 3 == 0) && (position[i] == 'Y') && (position[i + 1] == 'Y') && (position[i + 2] == 'Y'))
                {
                    isWin = true;
                    winner = 'Y';
                    return isWin;
                }
            }

            // check for diagonals win
            if ((position[0] == 'X') && (position[4] == 'X') && (position[8] == 'X'))
            {
                isWin = true;
                winner = 'X';
                return isWin;
            }
            if ((position[0] == 'Y') && (position[4] == 'Y') && (position[8] == 'Y'))
            {
                isWin = true;
                winner = 'Y';
                return isWin;
            }
            if ((position[2] == 'X') && (position[4] == 'X') && (position[6] == 'X'))
            {
                isWin = true;
                winner = 'X';
                return isWin;
            }
            if ((position[2] == 'Y') && (position[4] == 'Y') && (position[6] == 'Y'))
            {
                isWin = true;
                winner = 'Y';
                return isWin;
            }

            return false;
        }

        public bool error;

        static void Main()
        {
            TicTacToe tictactoe = new TicTacToe();

            int movesCount = 0;
            char currentPlayer = 'X';
            int positionToChoose;
            tictactoe.error = false;

            for (int i = 0; i < 9; i++)
            {
                tictactoe.position[i] = ' ';
            }

            Console.WriteLine("Tic Tac Toe");

            while (!tictactoe.isWin)
            {
                if (movesCount == 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("The end. No winner.");
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

                Console.Clear();
                tictactoe.BoardRefresh();
                Console.WriteLine();
                Console.WriteLine("Current player: {0}", currentPlayer);
                Console.WriteLine("Choose position (1-9): ");

                Int32.TryParse(Console.ReadLine(), out positionToChoose);

                if (positionToChoose >= 1 && positionToChoose <= 9)
                {
                    if (tictactoe.position[positionToChoose - 1] == ' ')
                    {
                        tictactoe.position[positionToChoose - 1] = currentPlayer;
                        movesCount++;
                    }
                    else
                    {
                        tictactoe.error = true;
                        Console.WriteLine();
                        Console.WriteLine("This position is taken!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong character! Choose character 0-9");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    tictactoe.error = true;
                }

                if (tictactoe.error)
                {
                    tictactoe.error = !tictactoe.error;
                }
                else
                {
                    if (currentPlayer == 'X') currentPlayer = 'Y';
                    else currentPlayer = 'X';
                }

                tictactoe.CheckWin();
            }

            Console.Clear();
            tictactoe.BoardRefresh();
            Console.WriteLine();
            Console.WriteLine("{0} won!", tictactoe.winner);
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}