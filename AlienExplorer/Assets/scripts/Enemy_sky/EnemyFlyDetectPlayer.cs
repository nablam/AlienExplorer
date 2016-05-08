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

        SpaceManager sm;
        ConstantForce cf;

        public Transform par;
        public Transform cur;
        public bool AGRO;
        void Start()
        {
            sm = GameObject.Find("Space_The_Final_Frontier").GetComponent<SpaceManager>();
            cf = GetComponent<ConstantForce>();
            AGRO = false;
            initialposition = transform.position;
            player = GameObject.Find("rocketprefab");
            _gameManager = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
        }

        void Update()
        {
           
            par = transform.parent;
            cur = sm.currquad.transform;
            if (!_gameManager.isGameOver) {
                if (player != null)
                {

                    if (transform.parent == sm.currquad.transform)
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
                    else
                    if (transform.parent != sm.currquad.transform && AGRO) {
                        startFindPlayermovetoPlayer();
                        AGRO = true;
                    }
                    else
                    {
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


        void faceThisPOsition(Vector3 here)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(here - transform.position, Vector3.back), enemyshipRotationSpeed * Time.deltaTime);
        }

        void moveForward() {
            cf.relativeForce = new Vector3(0f, 0f, enemyshipForwardSpeed);
        }




 


    }
}
