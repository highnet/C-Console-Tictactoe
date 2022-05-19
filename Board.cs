using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        public enum Winner { Nobody, Player1, Player2, Tie };

        public String[,] gameBoard;
        public Winner winner;
        public int turnsPlayed;


        public Board()
        {
            gameBoard = new String[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = " ";
                }
            }
            winner = Winner.Nobody;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   Console.Write(gameBoard[i, j] + "|");
                    if (j == 2)
                    {
                        Console.WriteLine();
                    }
                }
                if (i < 2)
                {
                    Console.WriteLine("-------");

                }
            }
        }

        public void CheckVictoryConditions()
        {
            if (turnsPlayed == 8)
            {
                winner = Winner.Tie;
            }
            for (int i = 0; i < 2; i++)
            {
                if (gameBoard[i, 0] == "x" && gameBoard[i, 1] == "x" && gameBoard[i, 2] == "x")
                {
                    winner = Winner.Player1;
                    return;
                }
                else if (gameBoard[i, 0] == "o" && gameBoard[i, 1] == "o" && gameBoard[i, 2] == "o")
                {
                    winner = Winner.Player2;
                    return;
                }
                if (gameBoard[0, i] == "x" && gameBoard[1, i] == "x" && gameBoard[2, i] == "x")
                {
                    winner = Winner.Player1;
                    return;
                }
                else if (gameBoard[0, i] == "o" && gameBoard[1, i] == "o" && gameBoard[2, i] == "o")
                {
                    winner = Winner.Player2;
                    return;
                }

                if (gameBoard[0,0] == "x" && gameBoard[1,1] == "x" && gameBoard [2,2] == "x")
                {
                    winner = Winner.Player1;
                    return;
                } else if (gameBoard[0, 0] == "o" && gameBoard[1, 1] == "o" && gameBoard[2, 2] == "o")
                {
                    winner = Winner.Player2;
                    return;
                }

                if (gameBoard[0, 2] == "x" && gameBoard[1, 1] == "x" && gameBoard[2, 0] == "x")
                {
                    winner = Winner.Player1;
                    return;
                }
                else if (gameBoard[0, 2] == "o" && gameBoard[1, 1] == "o" && gameBoard[2, 0] == "o")
                {
                    winner = Winner.Player2;
                    return;
                }


            }
        }
    }
}
