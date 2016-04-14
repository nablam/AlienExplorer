using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace nabspace {

    public class GM_restartScript : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.RestartLevelEvent += restartLevel;

        }

        void OnDisable()
        {
            _gameManager.RestartLevelEvent -= restartLevel;
        }
        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void restartLevel() { SceneManager.LoadScene("GameScene"); }
    }

}
