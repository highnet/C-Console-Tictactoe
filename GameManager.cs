using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicTacToe.GameState;

namespace TicTacToe
{
    class GameManager
    {
        public bool player1Starts;
        public State gameState;

        public GameManager(bool _player1Starts)
        {
            player1Starts = _player1Starts;
            gameState = State.GameIntro;
        }

    }
}
