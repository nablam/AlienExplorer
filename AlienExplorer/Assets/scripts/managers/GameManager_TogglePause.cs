using UnityEngine;
using System.Collections;
namespace S3
{
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        private bool _isPaused;

        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.MenueToggelEvent += TogglePause; //if this event happens, pausetoggle fires
            _gameManager.InventoryUiToggle += TogglePause;
            _gameManager.playerAskedtoLand += TogglePause;
        }


        void OnDisable()
        {
            _gameManager.MenueToggelEvent -= TogglePause;
            _gameManager.InventoryUiToggle -= TogglePause;
            _gameManager.playerAskedtoLand -= TogglePause;
        }

        void SetInitialReferences() {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void TogglePause() {
            if (_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
            }
        }

        public void DoPublicTogglePause() { TogglePause(); }
    }
}
