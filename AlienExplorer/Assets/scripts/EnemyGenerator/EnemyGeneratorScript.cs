using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace nabspace {
    public class EnemyGeneratorScript : MonoBehaviour
    {

        string pathtoenemy;
        GameObject player;
        private GameManager_Master _gameManager;
        public List<GameObject> listofbadies;


        void OnEnable()
        {
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            _gameManager.EnemyHasDied += TakeOutThisEnemy;
        }

        void OnDisable()
        {
            _gameManager.EnemyHasDied -= TakeOutThisEnemy;
        } 


        void Start()
        {
           
            player = GameObject.Find("rocketprefab");
            pathtoenemy = "EnemySkyResources/SkyEnemy1";
            listofbadies = new List<GameObject>();
            for (int x = 1; x < 5; x++)
            {
                GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(-400, 100*x ,0),  transform.rotation ) as GameObject;
                listofbadies.Add(go);
            }

            for (int x = 0; x < 5; x++)
            {
                GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(400, 100 * x, 0), transform.rotation) as GameObject;
                listofbadies.Add(go);
            }
       

            for (int x = 0; x < 5; x++)
            {
                GameObject go = Instantiate(Resources.Load(pathtoenemy), new Vector3(-400, -100 * x, 0), transform.rotation) as GameObject;
                listofbadies.Add(go);
            }
        }
        void TakeOutThisEnemy(GameObject go) {
          
            listofbadies.Remove(go);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
