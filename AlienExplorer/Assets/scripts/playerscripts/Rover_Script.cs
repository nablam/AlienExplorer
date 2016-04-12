using UnityEngine;
using System.Collections;

public class Rover_Script : MonoBehaviour {


    public GameObject curplanet;

    public void setCurPlanet(GameObject go) { curplanet = go; }


    public float movespeed = 10f;
    private Vector3 moveDir;

    ConstantForce cf;

	void Start () {
        cf = GetComponent<ConstantForce>();
        isGrounded = false;

    }

    bool isGrounded;

    void DoJump() {
        //if (isGrounded)
        //{
        //    if (Input.GetButton("up"))
        //    {
        //        moveDirection.y = jumpSpeed;
        //    }
        //    else {
        //        moveDirection.y = 0.0;
        //    }
        //}
        //else {
        //    // Apply gravity
        //    moveDirection.y -= gravity * Time.deltaTime;
        //}
        //transform.translate(moveDirection);
    }

	void Update () {
        if (curplanet != null) {
            Vector3 diff = curplanet.transform.position - transform.position;

            Debug.DrawLine(transform.position, transform.position + diff, Color.blue);


            Vector3 myup = transform.position- curplanet.transform.position ;
            Debug.DrawLine(transform.position, transform.position + (myup.normalized*2), Color.black);
         

        }
         



        if (Input.GetKey("up"))
        {
           
        }
        if (Input.GetKey("down"))
        {
            
        }

        if (Input.GetKey("right"))
        {
            if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, -Time.deltaTime * 10); }
        }
     


        if (Input.GetKey("left"))
        {
            if (curplanet != null) { transform.RotateAround(curplanet.transform.position, curplanet.transform.forward, Time.deltaTime * 10); }
           
        }
        

    }

    void FixedUpdate() {
      //  GetComponent<Rigidbody>().MovePosition(transform.position + transform.TransformDirection(moveDir) * movespeed * Time.deltaTime);
    }
}
