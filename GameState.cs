using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameState
    {
        public enum State {GameIntro,Player1Turn, Player2Turn, Player1Victory, Player2Victory,Tie, GameOver }
        public State gameState;

        public GameState()
        {
            gameState = State.GameIntro;
        }
    }
}
