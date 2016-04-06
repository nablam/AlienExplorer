using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

//vid 36
namespace S3 {
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {

        [Tooltip("does this even have an inventory? if so set true")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleinventoryButton;
        private GameManager_Master _gameManager;
        void Start()
        {
            SetInitialRefs();
        }

        // Update is called once per frame
        void Update()
        {
            checkforInventoryUItoggleRequest();
        }

        void SetInitialRefs() {
            _gameManager = GetComponent<GameManager_Master>();
            if (toggleinventoryButton == "") {
                Debug.LogError("please set name of button used to toggle inventory");
                this.enabled = false; //anything in update will not be running
            }
        }

        void checkforInventoryUItoggleRequest() {

         //   if (CrossPlatformInputManager.GetButtonUp("OnButtonInventory"))  toggleInventoryUI();
            if (CrossPlatformInputManager.GetButtonUp("OnButtonInventory") && !_gameManager.isMenueOn && !_gameManager.isGameOver && hasInventory)
            {
                toggleInventoryUI();
            }
        }
        void toggleInventoryUI() {
            if (inventoryUI != null) {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                _gameManager.isInvetoryUiOn = !_gameManager.isInvetoryUiOn;
                _gameManager.CAllInventoryUi();
            }
        }
    }
}
