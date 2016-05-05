using UnityEngine;
using System.Collections;


namespace nabspace {
    public class enemySkyMissileScript : MonoBehaviour
    {
        int damageanount;
        Player_Master pm;
        GameManager_Master gm;
        float enemyrocketspeed = 200;
        void Start()
        {

            damageanount = 5;
            gm = GameObject.Find("GameManager_Object").GetComponent<GameManager_Master>();
            if (!gm.isGameOver)
            {
                pm = GameObject.Find("rocketprefab").GetComponent<Player_Master>();
                StartCoroutine("killmissilein5seconds");
            }
          
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * enemyrocketspeed, Space.Self);
            if (gm.isGameOver) Destroy(gameObject);
        }

        IEnumerator killmissilein5seconds()
        {

            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "playerTAG")
            {
                pm.CALLEventPlayerHealthDown(damageanount);
                Instantiate(Resources.Load("Explosions/enemyMissileExplosion"), transform.position, transform.rotation );
                Destroy(this.gameObject);

            }
        }

        //void OnCollisionEnter(Collision collider)
        //{
        //    if (collider.gameObject.tag == "playerTAG")
        //    {
        //        pm.CALLEventPlayerHealthDown(10);
        //        Destroy(this.gameObject);
        //    }
        //}

    }
}
