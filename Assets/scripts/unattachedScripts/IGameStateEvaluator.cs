using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.unattachedScripts
{
    public enum GameState {
        PLAYING, WON, LOST
    }

    public interface IGameStateEvaluator {

        GameState TestGameState(GameState CurrentState);
    }
}
