using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace S3 {
    public class MainMenuScript : MonoBehaviour
    {



        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("OnButtonPlayGame"))
            {
                PlayGame();
            }

            if (CrossPlatformInputManager.GetButtonDown("OnButtonExit"))
            {
                ExitGame();
            }
        }


        public void PlayGame() { SceneManager.LoadScene("GameScene"); }

        public void ExitGame() { Application.Quit();}
    }
}
