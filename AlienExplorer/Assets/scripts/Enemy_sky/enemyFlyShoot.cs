using UnityEngine;
using System.Collections;
namespace nabspace
{
    public class enemyFlyShoot : MonoBehaviour
    {

        string EnemyMissilepath;

        EnemyFlyDetectPlayer efdp;
        public GameObject cannon;
        void Start()
        {
            efdp = GetComponent<EnemyFlyDetectPlayer>();
            EnemyMissilepath = "weapons/enemySkyMissile1";

        }

        // Update is called once per frame
        void Update()
        {
         //   if(efdp.AGRO) spawnmissile();
             
        }


        IEnumerator dofor5seconds()
        {
            InvokeRepeating("spawnmissile", 0, 3);
            yield return new WaitForSeconds(12);
            CancelInvoke("spawnmissile");
        }

        int counter = 0;

        void spawnmissile()
        {
            counter++;
            if(counter >= 200) {
                print(" PEWWWWW");
                counter = 0;

                GameObject go = Instantiate(Resources.Load(EnemyMissilepath), cannon.transform.position, cannon.transform.rotation) as GameObject;
            }
            
        }
    }
}
   
