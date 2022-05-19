using System;

namespace TicTacToe
{
    class Board
    {
        public enum BoardState {Undecided, Player1Wins, Player2Wins, Tie};

        public String[,] board;
        public int turnsPlayed;


        public Board()
        {
            board = new String[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   Console.Write(board[i, j]);
                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                    if (j == 2)
                    {
                        Console.WriteLine();
                    }
                }
                if (i < 2)
                {
                    Console.WriteLine("-|-|-");

                }
            }
            Console.WriteLine();
        }

        internal void PrintBoardCoordinates()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(i + "," + j );
                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                    if (j == 2)
                    {
                        Console.WriteLine();
                    }
                }
                if (i < 2)
                {
                    Console.WriteLine("---|---|---");

                }
            }
            Console.WriteLine();
        }

        public BoardState CheckVictoryConditions()
        {

            for (int i = 0; i < 2; i++)
            {
                if (board[i, 0] == "x" && board[i, 1] == "x" && board[i, 2] == "x")
                {
                    return BoardState.Player1Wins;
                }
                else if (board[i, 0] == "o" && board[i, 1] == "o" && board[i, 2] == "o")
                {
                    return BoardState.Player2Wins;
                }
                if (board[0, i] == "x" && board[1, i] == "x" && board[2, i] == "x")
                {
                    return BoardState.Player1Wins;
                }
                else if (board[0, i] == "o" && board[1, i] == "o" && board[2, i] == "o")
                {
                    return BoardState.Player2Wins;
                }

                if (board[0, 0] == "x" && board[1, 1] == "x" && board[2, 2] == "x")
                {
                    return BoardState.Player1Wins;
                }
                else if (board[0, 0] == "o" && board[1, 1] == "o" && board[2, 2] == "o")
                {
                    return BoardState.Player2Wins;
                }

            }

            if (board[0, 2] == "x" && board[1, 1] == "x" && board[2, 0] == "x")
            {
                return BoardState.Player1Wins;
            }
            else if (board[0, 2] == "o" && board[1, 1] == "o" && board[2, 0] == "o")
            {
                return BoardState.Player2Wins;
            }

            if (turnsPlayed == 9)
            {
                return BoardState.Tie;
            }
            return BoardState.Undecided;

        }

        internal bool IsEmptySquare(int i, int j)
        {
            return GetSquare(i, j) == " ";
        }

        public bool SetSquare(int i, int j, string v)
        {
            if (board != null)
            {
                board[i, j] = v;
                return true;
            }
            return false;
        }

        public string GetSquare(int i, int j)
        {
            if (board != null)
            {
                return board[i, j];
            }
            return "ERROR";
        }
    }
}
