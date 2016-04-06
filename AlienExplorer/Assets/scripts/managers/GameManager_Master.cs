using UnityEngine;
using System.Collections;

namespace S3
{
    public class GameManager_Master : MonoBehaviour
    {

        public delegate void GAmeManagerEventHandler();
        public event GAmeManagerEventHandler MenueToggelEvent;
        public event GAmeManagerEventHandler RestartLevelEvent;
        public event GAmeManagerEventHandler InventoryUiToggle;
        public event GAmeManagerEventHandler GoToMenuScreenEvent;
        public event GAmeManagerEventHandler playerLanded;
        public event GAmeManagerEventHandler playerTookOff;
        public event GAmeManagerEventHandler playerdied;
        public event GAmeManagerEventHandler GameOverEvent;

        public bool isGameOver;
        public bool isInvetoryUiOn;
        public bool isMenueOn;

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


        public void CAllPlayerLanded()
        {
            if (playerLanded != null)
            {
                playerLanded();
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