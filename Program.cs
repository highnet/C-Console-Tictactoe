using System;
using System.Text.RegularExpressions;
using static TicTacToe.Board;
using static TicTacToe.GameManager;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager(true);
            Board board = new Board();
            Regex regex = new Regex("^[0-2],[0-2]");

            gameManager.gameState = DisplayWelcomeMessage(gameManager);
            board.PrintBoardCoordinates();
            board.PrintBoard(); 
            while (!gameManager.GameOver())
            {
                gameManager.gameState = CheckForBoardVictoryConditions(board,gameManager);
                gameManager.gameState = CheckForGameEndingConditions(gameManager);
                ProcessUserInput(board, gameManager, regex);
                board.PrintBoard();
            }
            Console.Write("Hope you had fun!");
            Console.ReadLine();
        }

        private static void ProcessUserInput(Board board, GameManager gameManager, Regex regex)
        {
            if (gameManager.gameState == GameState.Player1Turn || gameManager.gameState == GameState.Player2Turn)
            {
                if (gameManager.gameState == GameState.Player1Turn)
                {
                    Console.WriteLine("Player 1 (x): input a valid and empty square with the regex format ^[0-2].[0-2] -> examples: 0,0 0,1 0,2 1,0 1,1 1,2 2,0 2,1 2,2");
                }
                else
                {
                    Console.WriteLine("Player 2 (o): input a valid and empty square with the regex format ^[0-2].[0-2] -> example: 0,0");
                }
                string input = Console.ReadLine();
                Console.WriteLine();
                if (regex.Match(input).Success)
                {
                    int i;
                    int.TryParse(input[0].ToString(), out i);
                    int j;
                    int.TryParse(input[2].ToString(), out j);
                    if (board.IsEmptySquare(i,j))
                    {
                        board.SetSquare(i, j, gameManager.gameState == GameState.Player1Turn ? "x" : "o");
                        board.turnsPlayed++;
                        TogglePlayerTurn(gameManager);
                        Console.WriteLine("Square entered successfuly");
                        Console.WriteLine();
                    } else
                    {
                        Console.WriteLine("Square is occupied, try another square");
                        Console.WriteLine();

                    }
                } else
                {
                    Console.WriteLine("Regex Mismatch: Try Again ");
                    Console.WriteLine();

                }
            }
        }

        private static void TogglePlayerTurn(GameManager gameManager)
        {
            if (gameManager.gameState == GameState.Player1Turn)
            {
                gameManager.gameState = GameState.Player2Turn;
            }
            else
            {
                gameManager.gameState = GameState.Player1Turn;
            }
        }

        private static GameState DisplayWelcomeMessage(GameManager gameManager)
        {
            Console.WriteLine("Welcome to 2 Player TicTacToe by Joaquin Telleria(2022) www.highnet.xyz");
            Console.WriteLine();
            Console.WriteLine("Player 1(x) Starts:");
            Console.WriteLine();
            return GameState.Player1Turn;
        }

        private static GameState CheckForGameEndingConditions(GameManager gameManager)
        {
            if (gameManager.gameState == GameState.Player1Victory)
            {
                Console.WriteLine("Player 1 Wins!");
                return GameState.GameOver;
            }
            else if (gameManager.gameState == GameState.Player1Victory)
            {
                Console.WriteLine("Player 2 Wins!");
                return GameState.GameOver;
            }
            else if (gameManager.gameState == GameState.Tie)
            {
                Console.WriteLine("It's a tie!");
                return GameState.GameOver;
            }
            return gameManager.gameState;
        }

        private static GameState CheckForBoardVictoryConditions(Board board, GameManager gameManager)
        {

            BoardState result = board.CheckVictoryConditions();
            if (result == BoardState.Player1Wins)
            {
                return GameState.Player1Victory;
            }
            else if (result == BoardState.Player2Wins)
            {
                gameManager.gameState = GameState.Player2Victory;
            }
            else if (result == BoardState.Tie)
            {
                gameManager.gameState = GameState.Tie;
            }
            return gameManager.gameState;
        }


    }



}
