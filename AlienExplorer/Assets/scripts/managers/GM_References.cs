using UnityEngine;
using System.Collections;

namespace S3 {
    public class GM_References : MonoBehaviour
    {
        public string playerTagref;
        public static string playerTagRefStatic;

        public string enemyShipTagref;
        public static string enemyShipTagRefStatic;

        public string enemyLandTagref;
        public static string enemyLandTagRefStatic;

        public string planetTagref;
        public static string planetTagRefStatic;

        public static GameObject PlayerStatic;

        void OnEnable()
        {
           
            if (string.IsNullOrEmpty(playerTagref))
            {
                Debug.LogError("please type player tag in manager ref inspector");
            }
            else
                playerTagRefStatic = playerTagref;


            if (string.IsNullOrEmpty(enemyShipTagref))
            {
                Debug.LogError("please type ENEMYship tag in manager ref inspector");
            }
            else
                enemyShipTagRefStatic = enemyShipTagref;


            if (string.IsNullOrEmpty(enemyLandTagref))
            {
                Debug.LogError("please type ENEMYLand tag in manager ref inspector");
            }

            else
                enemyLandTagRefStatic = enemyLandTagref;

            if (string.IsNullOrEmpty(planetTagref))
            {
                Debug.LogError("please type PLANET tag in manager ref inspector");
            }
            else
                planetTagRefStatic = planetTagref;

                PlayerStatic = GameObject.FindGameObjectWithTag(playerTagRefStatic);
        }


    }
}

