using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class rocketScript : MonoBehaviour {

    public ConstantForce cf;
    public GameObject myarrow;

    void Start () {
 
        cf = GetComponent<ConstantForce>();

       
	}


    float ARRrollSpeed = 60f;
    float ARRfilterSpeed =1f;  //how fast to turn
    float ARRrollDir = 0;

    void rotatearrow()
    {
        var ARRrollCtrl = 0;
        if (Input.GetKey("left")) ARRrollCtrl = -1;
        if (Input.GetKey("right")) ARRrollCtrl = 1;
        
        myarrow.transform.Rotate(0, ARRrollCtrl*ARRrollSpeed * Time.deltaTime, 0);
    }


    void moveInDirOfArrow() {
        //  Vector3 dir = new Vector3( myarrow.transform.localRotation.x, myarrow.transform.localRotation.y, myarrow.transform.localRotation.z) ;//.eulerAngles.normalized;
        //Vector3 dir = new Vector3(myarrow.transform.forward);
        if (Input.GetKey("up")) {
         //   Vector3 dirspeed = dir * Time.deltaTime*10;
            transform.Translate(myarrow.transform.right);
        }

    }


 
 


    void Update () {
        rotatearrow();
        moveInDirOfArrow();
      //  driftcontrolPC();
    }















    float rollSpeed = 60f;
    float filterSpeed = 0.5f;  //how fast to turn
    float rollDir = 0;

    float moveSpeed = 60f;
    float filtermoveSpeed = 0.1f;  //how fast to move
    float moveDir = 0;


    void Roller()
    {
        var rollCtrl = 0;
        if (Input.GetKey("left")) rollCtrl = -1;
        if (Input.GetKey("right")) rollCtrl = 1;
        rollDir = Mathf.Lerp(rollDir, rollCtrl, Time.deltaTime * filterSpeed);
        transform.Rotate(0, rollDir * rollSpeed * Time.deltaTime, 0);
    }

    void Mover()
    {
        var moveCtrl = 0;
        if (Input.GetKey("up")) moveCtrl = 1;
        if (Input.GetKey("down")) moveCtrl = -1;
        moveDir = Mathf.Lerp(moveDir, moveCtrl, Time.deltaTime * filtermoveSpeed);
        transform.Translate(0, 0, moveDir * moveSpeed * Time.deltaTime);
    }

    void Moverwithoutdir()
    {
        var moveCtrl = 0;
        if (Input.GetKey("up")) moveCtrl = 1;
        if (Input.GetKey("down")) moveCtrl = -1;
        moveDir = Mathf.Lerp(moveDir, moveCtrl, Time.deltaTime * filtermoveSpeed);
        transform.Translate(0, moveDir * moveSpeed * Time.deltaTime, 0, Space.World);
    }



    void driftcontrolPC() {
        if (Input.GetKey("up") || (Input.GetKey("down"))) { Mover(); }
        else
            Moverwithoutdir();
         Roller();
    }


    /*
    void normalcontrols()
    {
        cf.relativeForce = new Vector3(0f, 0f, 0f);
        cf.relativeForce = new Vector3(0f, 0f, 0f);
        if (Input.GetKey("up"))
        {
            cf.relativeForce = new Vector3(0f, 0f, 10f);
        }


        if (Input.GetKey("down"))
        {
            cf.relativeForce = new Vector3(0f, 0f, -10f);
        }

        if (Input.GetKey("left"))
        {

            //  cf.relativeTorque = new Vector3(0f, -2f, 0f);
            transform.Rotate(new Vector3(0f, -0.5f, 0f));
        }


        if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0f, 0.5f, 0f));
            //  cf.relativeTorque = new Vector3(0f, 2f,  0f);
        }
    }
    void androidcontrols() {
        cf.relativeForce = new Vector3(0f, 0f, 0f);
        cf.relativeForce = new Vector3(0f, 0f, 0f);

        if (CrossPlatformInputManager.GetButton("OnButtonBoost"))
        {
            cf.relativeForce = new Vector3(0f, 0f, 10f);
        }

        if (CrossPlatformInputManager.GetButton("OnButtonShoot"))
        {
            Debug.Log("pew pew");
        }

        if (CrossPlatformInputManager.GetButton("OnButtonLeft"))
        {
            transform.Rotate(new Vector3(0f, -0.5f, 0f));
        }

        if (CrossPlatformInputManager.GetButton("OnButtonRight"))
        {
            transform.Rotate(new Vector3(0f, 0.5f, 0f));
        }
    }

    */
}
