using UnityEngine;
using System.Collections;


namespace nabspace {
    public class EnemyFlyDetectPlayer : MonoBehaviour
    {

        GameObject player;
        GameManager_Master _gameManager;
        Vector3 initialposition;
        Vector3 curplayerpos;
        float mindistanceTotriggerattack = 200f;
        float enemyshipForwardSpeed = 12f;
        float enemyshipRotationSpeed = 10f;


        ConstantForce cf;
        public bool AGRO;
        void Start()
        {
            cf = GetComponent<ConstantForce>();
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position, Vector3.back), enemyshipRotationSpeed * Time.deltaTime);
        }

        void faceThisPOsition(Vector3 here)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(here - transform.position, Vector3.back), enemyshipRotationSpeed * Time.deltaTime);
        }

        void moveForward() {

            cf.relativeForce = new Vector3(0f, 0f, enemyshipForwardSpeed);
            // transform.position += transform.forward * enemyshipForwardSpeed * Time.deltaTime;
        }




 


    }
}
