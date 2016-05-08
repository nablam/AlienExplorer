using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace nabspace {
    public class RocketFire : MonoBehaviour
    {

        private GameManager_Master _gameManager;
        GameObject rightbooster;
        GameObject leftbooster;

        EllipsoidParticleEmitter leftemitor;
        EllipsoidParticleEmitter rightemitor;

        b_rocket_Vector rv;
        void Awake()
        {
            SetInitialReferences();
        }

        void OnEnable()
        {


        }

        void Start()
        {

        }

        void OnDisable()
        {

        }
        void SetInitialReferences()
        {
            //  _gameManager = GetComponent<GameManager_Master>();
            rightbooster = this.transform.GetChild(2).gameObject;
            leftbooster = this.transform.GetChild(3).gameObject;
            rightemitor = rightbooster.GetComponent<EllipsoidParticleEmitter>();
            leftemitor = leftbooster.GetComponent<EllipsoidParticleEmitter>();
            rv = transform.GetComponent<b_rocket_Vector>();
        }



        void Update() {
            activateEmmitors();          
        }


        void doturns(float side)
        {

            rightemitor.localVelocity = new Vector3(side, 0, 5);
            leftemitor.localVelocity = new Vector3(side, 0, 5);
        }

 

        float start = 0f;
        float maxboost = 5f;
        float currentpower = 0f;
        void activateEmmitors() {


            if (rv.ismoving)
            {
                rightemitor.maxEmission = 50f;
                leftemitor.maxEmission = 50f;
                currentpower += 0.02f;
                if (currentpower > maxboost) currentpower = maxboost;

            }
            else
            {
                currentpower = 0.02f;
                rightemitor.maxEmission = 0f;
                leftemitor.maxEmission = 0f;

            }

            if (rv.turningRIGHT || rv.turningLEFT)
            {
                rightemitor.maxEmission = 50f;
                leftemitor.maxEmission = 50f;
                currentpower = 5f;
            } 




                rightemitor.localVelocity = new Vector3(rv.valSide, 0, currentpower);
                leftemitor.localVelocity = new Vector3(rv.valSide, 0, currentpower);
          


            //if ( rv.turningRIGHT || rv.turningLEFT)
            //{

            //    rightemitor.localVelocity = new Vector3(rv.valSide, 0, 5);
            //    leftemitor.localVelocity = new Vector3(rv.valSide, 0, 5);
            //}

             
        }

        void putBreakson() {
            currentpower = 0.02f;
            rightemitor.maxEmission = 0f;
            leftemitor.maxEmission = 0f;
        }
    }
}
