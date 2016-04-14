using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace nabspace {
    public class GM_gotoMenuScene : MonoBehaviour
    {

        private GameManager_Master _gameManager;
        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.GoToMenuScreenEvent += gotoMaineMenuScene;

        }
 
        void OnDisable()
        {
            _gameManager.GoToMenuScreenEvent -= gotoMaineMenuScene;
        }
        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void gotoMaineMenuScene() { SceneManager.LoadScene("MainMenuScene"); }

        //setting up button with a script: 39
       // https://www.youtube.com/watch?v=FwAWMQ7Fi6k&nohtml5=False
    }
}
