using UnityEngine;
using System.Collections;


namespace nabspace {
    public class EnemyFlyDetectPlayer : MonoBehaviour
    {

        GameObject player;
        GameManager_Master _gameManager;
        Vector3 initialposition;
        Vector3 curplayerpos;
        float mindistanceTotriggerattack = 100f;
        float speed = 2;

        public bool AGRO;
        void Start()
        {
            AGRO = false;
            initialposition = transform.position;
            player = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }

        void Update()
        {

            if (!_gameManager.isGameOver) {
                if (player != null)
                {
                    if (disttoplayer() < mindistanceTotriggerattack)
                    {
                        startFindPlayermovetoPlayer();
                        AGRO = true;
                    }
                    else {
                        AGRO = false;
                        startGotoinitpos();
                    }
                }

            }

        }


        void startGotoinitpos() {
            curplayerpos = player.transform.position;
            faceThisPOsition(initialposition);
            moveForward();
        }

        void startFindPlayermovetoPlayer()
        {
            curplayerpos = player.transform.position;
            faceThisPOsition(curplayerpos);
            moveForward();
        }

        float disttoplayer()
        {
            Vector3 diff = curplayerpos - transform.position;
            return diff.magnitude;
        }



        void facePlayer() {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position, Vector3.back), 1 * Time.deltaTime);
        }

        void faceThisPOsition(Vector3 here)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(here - transform.position, Vector3.back), 1 * Time.deltaTime);
        }

        void moveForward() {


           transform.position += transform.forward * speed * Time.deltaTime;
        }




 


    }
}
