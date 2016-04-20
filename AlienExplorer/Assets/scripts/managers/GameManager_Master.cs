﻿using UnityEngine;
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
   



        public bool isGameOver;
        public bool isInvetoryUiOn;
        public bool isMenueOn;
        public bool isAskedToLandl;
        public bool isAskedToTakeOff;
        public bool isRoverMode;
        public bool isRocketMode;
        public bool isLanded;
        public bool what;
        public bool useAndroidControls;




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
    }
}