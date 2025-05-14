using System;

namespace TicTacToe
{

    class GameManager
    {
        public enum GameState { GameIntro, Player1Turn, Player2Turn, Player1Victory, Player2Victory, Tie, GameOver }

        public GameState gameState;

        public GameManager(bool _player1Starts)
        {
            gameState = GameState.GameIntro;
        }

        internal bool GameOver()
        {
            return gameState == GameState.GameOver;
        }
    }
}
