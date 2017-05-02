using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.unattachableScripts
{
    class StandardStateEvaluator : IGameStateEvaluator {

        spawner[] spawners;

        public StandardStateEvaluator()
        {
            spawners = UnityEngine.Object.FindObjectsOfType<spawner>();
        }

        public GameState TestGameState(GameState CurrentState)
        {
            bool SpawnersFinished = true;
            foreach (spawner spw in spawners)
            {
                bool SpawnerFinished = (spw.count == 0);
                SpawnersFinished &= SpawnerFinished;
            }

            GameObject PlayerBase = GameObject.FindGameObjectWithTag("PlayerBase");
            if (PlayerBase == null)
            {
                return GameState.LOST;
            }

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
                if (EnemyTanks.Length == 0 && SpawnersFinished)
                {
                    return GameState.WON;
                }
            }
            return CurrentState;
        }
    }
}
