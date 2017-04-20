using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.unattachableScripts
{
    public enum GameState {
        PLAYING, WON, LOST
    }

    public interface IGameStateEvaluator {

        GameState TestGameState(GameState CurrentState);
    }
}
