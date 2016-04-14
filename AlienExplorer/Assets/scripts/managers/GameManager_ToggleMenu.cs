using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
namespace nabspace
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master _gameManager;
        public GameObject menu;
        public GameObject InventoryButton;
        
    
        void Start()
        {
            ToggleMenu();
        }
 
        void Update()
        {
            CheckForMenuToggleRequest();
        }


        void OnEnable()
        {
            SetInitialReferences();
            _gameManager.GameOverEvent += ToggleMenu;    
        }


        void OnDisable()
        {
            _gameManager.GameOverEvent -= ToggleMenu;          
        }

        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            if (CrossPlatformInputManager.GetButtonUp("OnButtonEscape")  && !_gameManager.isGameOver && !_gameManager.isInvetoryUiOn) {
                ToggleMenu();
                print("escape");
            }
        }

        void ToggleMenu() {
            if (menu != null) { 
                menu.SetActive(!menu.activeSelf); //if it is deactivatred it will be activated
                _gameManager.isMenueOn = !_gameManager.isMenueOn;
                _gameManager.CAllEventMenueToggel(); //will cause menue toggle to happen, and the pause to follow
                InventoryButton.SetActive(!InventoryButton.activeSelf);
            }
            else
            {
                Debug.Log("need to assigne a ui GO to the toggle menuu script ");
            }
        }



    }

}
