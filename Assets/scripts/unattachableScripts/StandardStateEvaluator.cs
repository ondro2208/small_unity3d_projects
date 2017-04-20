using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.unattachableScripts
{
    class StandardStateEvaluator : IGameStateEvaluator {

        public GameState TestGameState(GameState CurrentState)
        {
            GameObject[] PlayerTanks = GameObject.FindGameObjectsWithTag("Player");
            bool ArePlayersAlive = false;
            foreach (GameObject PlayerTank in PlayerTanks)
            {
                ArePlayersAlive |= PlayerTank.activeInHierarchy;
            }
            if (!ArePlayersAlive)
            {
                return GameState.LOST;
            }
            else
            {
                GameObject[] EnemyTanks = GameObject.FindGameObjectsWithTag("EnemyTank");
                if (EnemyTanks.Length == 0)
                {
                    return GameState.WON;
                }
            }
            return CurrentState;
        }
    }
}
