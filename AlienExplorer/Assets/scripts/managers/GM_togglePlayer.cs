using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace S3
{
    public class GM_togglePlayer : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        public GameObject androidActionController;

        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.MenueToggelEvent += TogglePlayerControl;
            _gameManager.InventoryUiToggle += TogglePlayerControl;
        }


        void OnDisable()
        {
            _gameManager.MenueToggelEvent -= TogglePlayerControl;
            _gameManager.InventoryUiToggle -= TogglePlayerControl;
        }

        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void TogglePlayerControl()
        {
            if (androidActionController != null)
            {
                androidActionController.SetActive(!androidActionController.activeSelf);
            }
        }


    }

}
