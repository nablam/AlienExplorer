using UnityEngine;
using System.Collections;


namespace nabspace {

    public class EnemyExplode : MonoBehaviour
    {
        GameManager_Master _gameManager;

        void Awake()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }


   

        void OnCollisionEnter(Collision collider)
        {
            if (collider.gameObject.tag == "missileTAG")
            {
                _gameManager.CAllEnemyDied(this.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
