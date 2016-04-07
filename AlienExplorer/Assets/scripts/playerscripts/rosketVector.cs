﻿using UnityEngine;
using System.Collections;

public class rosketVector : MonoBehaviour {

    ConstantForce cf;
       Vector3 mypos;
    float x = 0;
    float moveCtrl ;
    float moveSpeed = 60f;

    BoxCollider bottomcollider;

    void Start () {
        cf = GetComponent<ConstantForce>();
        print(transform.GetChild(1).name);
        print(transform.GetChild(0).name);

        bottomcollider = transform.GetChild(0).GetComponent<BoxCollider>();
    }
	
 
	void Update () {
 
        normalcontrols(5,4);
    }

    void normalcontrols(float forwardValue, float rotationValue)
    {
        cf.relativeForce = new Vector3(0f, 0f, 0f);
        
        if (Input.GetKey("up"))
        {
            cf.relativeForce = new Vector3(0f, 0f, forwardValue);
        }


        if (Input.GetKey("down"))
        {
            cf.relativeForce = new Vector3(0f, 0f, -forwardValue);
        }

        if (Input.GetKey("left"))
        {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            cf.relativeTorque = new Vector3(0f, -rotationValue, 0f);          
        }
        else
        if (Input.GetKeyUp("left")) {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation=true;
        }


        if (Input.GetKey("right"))
        {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            cf.relativeTorque = new Vector3(0f, rotationValue,  0f);
        }
        else
        if (Input.GetKeyUp("right"))
        {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }

        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }


    void OnTriggerStay(Collider other)
    {
        print("boom");
        // if (other == collider1) { }
    }

    void OnCollisionEnter(Collision collider)
    {

         
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
       // print(this.gameObject.GetComponent<Rigidbody>().velocity);
    }


}


    //    if (Input.GetKey("left"))  {}
    //    if (Input.GetKey("right"))  {}

    //if (Input.GetKey("up"))  {}
    //if (Input.GetKey("down"))  {}

 