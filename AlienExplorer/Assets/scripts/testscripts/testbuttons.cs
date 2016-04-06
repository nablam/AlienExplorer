﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class testbuttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        buttontester();
    }

    void buttontester() {

        //escape
        if (CrossPlatformInputManager.GetButton("OnButtonEscape"))
        {
            Debug.Log("ESCAPE");
        }

        //Menu
        if (CrossPlatformInputManager.GetButton("OnButtonMainMenu"))
        {
            Debug.Log("mainMenu");
        }
        if (CrossPlatformInputManager.GetButton("OnButtonRestart"))
        {
            Debug.Log("restart");
        }

        //controls
        if (CrossPlatformInputManager.GetButton("OnButtonBoost"))
        {
            Debug.Log("boost");
        }

        if (CrossPlatformInputManager.GetButton("OnButtonShoot"))
        {
            Debug.Log("pew pew");
        }

        if (CrossPlatformInputManager.GetButton("OnButtonLeft"))
        {
            Debug.Log("left");
        }

        if (CrossPlatformInputManager.GetButton("OnButtonRight"))
        {
            Debug.Log("right");
        }




    }
}