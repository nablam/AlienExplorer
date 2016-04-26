using UnityEngine;
using System.Collections;
namespace nabspace {
    public class AreaManager : MonoBehaviour
    {
        GameObject playership;
 
        void Start()
        {
           // spacecell c = new spacecell(100, 100, 100, 100, 100, 100, true);
        }

 
        void Update()
        {

        }


        private GameManager_Master _gameManager;
        void OnEnable()
        {


        }

        void OnDisable()
        {

        }

        void SetInitialReferences()
        {
            _gameManager = GetComponent<GameManager_Master>();
            playership = GameObject.Find("rocketprefab");
        }

    }
}
