﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace S3
{
    public class GM_togglePlayer : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        public GameObject androidActionController;
        public GameObject androidROVERActionController;

        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.MenueToggelEvent += TogglePlayerControl;
            _gameManager.InventoryUiToggle += TogglePlayerControl;
            _gameManager.ChangeModeEvent += TogglePlayerControl;
        }


        void OnDisable()
        {
            _gameManager.MenueToggelEvent -= TogglePlayerControl;
            _gameManager.InventoryUiToggle -= TogglePlayerControl;
            _gameManager.ChangeModeEvent -= TogglePlayerControl;
        }

        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void TogglePlayerControl()
        {
            if (_gameManager.isRocketMode) {
                if (androidActionController != null)
                {
                    androidActionController.SetActive(!androidActionController.activeSelf);
                }
            }
            else
                  if (_gameManager.isRoverMode)
            {
                if (androidROVERActionController != null)
                {
                    androidROVERActionController.SetActive(!androidROVERActionController.activeSelf);
                }
            }
        }


    }

}
