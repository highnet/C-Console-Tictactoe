using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicTacToe.GameState;
using static TicTacToe.Board;

namespace TicTacToe
{
    class Program
    {
        public GameManager gameManager;
        public Board board;

        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager(true);
            Board board = new Board();
            board.PrintBoard();
            while (gameManager.gameState != State.GameOver)
            {
                if (board.winner == Winner.Player1)
                {
                    gameManager.gameState = State.Player1Victory;
                } else if (board.winner == Winner.Player2)
                {
                    gameManager.gameState = State.Player2Victory;
                } else if (board.winner == Winner.Tie)
                {
                    gameManager.gameState = State.Tie;
                }
                if (gameManager.gameState == State.Player1Victory || gameManager.gameState == State.Player2Victory || gameManager.gameState == State.Tie)
                {
                    if (gameManager.gameState == State.Player1Victory)
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else if (gameManager.gameState == State.Player1Victory)
                    {
                        Console.WriteLine("Player 2 Wins!");
                    } else if (gameManager.gameState == State.Tie)
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    gameManager.gameState = State.GameOver;
                }

                if (gameManager.gameState == State.GameIntro)
                {
                    Console.WriteLine("Welcome to the game");
                    if (gameManager.player1Starts)
                    {
                        Console.WriteLine("Player 1(x) Starts");
                        gameManager.gameState = State.Player1Turn;
                    } else
                    {
                        Console.WriteLine("Player 2(0) Starts");
                        gameManager.gameState = State.Player2Turn;
                    }
                }
                if (gameManager.gameState == State.Player1Turn || gameManager.gameState == State.Player2Turn)
                {
                    if (gameManager.gameState == State.Player1Turn)
                    {
                        Console.WriteLine("Player 1: input a valid square with the format ^[0-2].[0-2]");
                    } else
                    {
                        Console.WriteLine("Player 2: input a valid square with the format ^[0-2].[0-2]");
                    }
                    string input = Console.ReadLine();
                    int i;
                    int.TryParse(input[0].ToString(), out i);
                    int j;
                    int.TryParse(input[2].ToString(), out j);
                    if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
                    {
                        if (board.gameBoard[i,j] == " ")
                        {
                            if (gameManager.gameState == State.Player1Turn)
                            {
                                board.gameBoard[i, j] = "x";
                                board.turnsPlayed++;
                                board.CheckVictoryConditions();
                                gameManager.gameState = State.Player2Turn;
                            }
                            else
                            {
                                board.gameBoard[i, j] = "o";
                                board.turnsPlayed++;
                                board.CheckVictoryConditions();
                                gameManager.gameState = State.Player1Turn;
                            }
                        } else
                        {
                            Console.WriteLine("ERR: Square is non-empty. Try Again.");
                        }
                    } else
                    {
                        Console.WriteLine("ERR: Invalid Input. Try again.");
                    }
                }
                board.PrintBoard();
                Console.WriteLine();
            }
            Console.Write("Hope you had fun!");
            Console.ReadLine();
        }

    }


}
