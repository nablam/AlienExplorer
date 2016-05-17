using UnityEngine;
using System.Collections;

namespace nabspace
{
    public class GameManager_Master : MonoBehaviour
    {

        public delegate void GAmeManagerEventHandler();
        public event GAmeManagerEventHandler MenueToggelEvent;
        public event GAmeManagerEventHandler RestartLevelEvent;
        public event GAmeManagerEventHandler InventoryUiToggle;
        public event GAmeManagerEventHandler GoToMenuScreenEvent;
        public event GAmeManagerEventHandler playerAskedtoLand;
        public event GAmeManagerEventHandler playerAskedtoTakeOff;
        public event GAmeManagerEventHandler ChangeModeEvent;
        public event GAmeManagerEventHandler playerTookOff;
        public event GAmeManagerEventHandler playerdied;
        public event GAmeManagerEventHandler GameOverEvent;


        public delegate void EnemyManagerEventHandler(GameObject thisenemy);
        public event EnemyManagerEventHandler EnemyHasDied;

        public delegate void playerIsbeingPulledHAndler(GameObject bythisplanet);
        public event playerIsbeingPulledHAndler playerIsBeingPulled;
        public event playerIsbeingPulledHAndler playerIsNOTBeingPulled;

        public delegate void nearestPlanetIsBeingInqueried(Vector3 here);
        public event nearestPlanetIsBeingInqueried inquireNearestPlanet;






        public bool isGameOver;
        public bool isInvetoryUiOn;
        public bool isMenueOn;
        public bool isAskedToLandl;
        public bool isAskedToTakeOff;
        public bool isRoverMode;
        public bool isRocketMode;
        public bool isLanded;
        public bool playerIsBeigPulledin;
        public bool useAndroidControls;




        public void CAllPlayerisBeingpulled(GameObject thisplanet)
        {
            if (playerIsBeingPulled != null)
            {
                playerIsBeingPulled(thisplanet);
            }
        }
        public void CAllplayerEscapedPull(GameObject thisplanet)
        {
            if (playerIsNOTBeingPulled != null)
            {
                playerIsNOTBeingPulled(thisplanet);
            }
        }



        public void CAllEnemyDied(GameObject thisGuy)
        {
            if (EnemyHasDied != null)
            {
                EnemyHasDied(thisGuy);
            }
        }

        public void CAllEventMenueToggel()
        {
            if (MenueToggelEvent != null)
            {
                MenueToggelEvent();
            }
        }

        public void CAllRestartLevel()
        {
            if (RestartLevelEvent != null)
            {
                RestartLevelEvent();
            }
        }


        public void CAllInventoryUi()
        {
            if (InventoryUiToggle != null)
            {
                InventoryUiToggle();
            }
        }
        public void CAllGoToMenuScreenEvent()
        {
            if (GoToMenuScreenEvent != null)
            {
                GoToMenuScreenEvent();
            }
        }



        
        public void CAllPlayerASkedToTakeOff()
        {
            if (playerAskedtoTakeOff != null)
            {
                playerAskedtoTakeOff();
            }
        }

        public void CAllPlayerASkedToLand()
        {
            if (playerAskedtoLand != null)
            {
                playerAskedtoLand();
            }
        }


        public void CAllChangeMode()
        {
            if (ChangeModeEvent != null)
            {
                ChangeModeEvent();
            }
        }


        public void CAllGamePlayerTookOff()
        {
            if (playerTookOff != null)
            {
                playerTookOff();
            }
        }


        public void CAllGameOverEvent()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }

        public void CAllPlayerDied()
        {
            if (playerdied != null)
            {
                playerdied();
            }
        }



        public void CAllNearestPlanetIsBEingInquired(Vector3 thisplanetHere)
        {
            if (inquireNearestPlanet != null)
            {
                inquireNearestPlanet(thisplanetHere);
            }
        }
    }
}