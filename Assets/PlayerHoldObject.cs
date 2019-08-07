using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldObject : MonoBehaviour
{
    public GameObject HoldingPosition;
    public Vector3 ObjPos;
    public Quaternion ObjRot;
    public static bool picked1p = false;
    public static bool picked2p = false;
    public static bool check1p = false;
    public static bool check2p = false;
    public static GameObject item;

    void Update()
    {
        ObjPos = HoldingPosition.transform.position;
        ObjRot = HoldingPosition.transform.rotation;
/*
        if (picked && gameObject.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Space)  && check == true)
            {
                picked = false;
                Debug.Log("can pick again");
            }
            if(Input.GetKeyUp(KeyCode.Space)&& picked == false)
            {
                
                check = false;
            }
        }
        if (picked && gameObject.tag == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                picked = false;
            }
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        //if (Input.GetKeyDown(KeyCode.Space))



        if (other.tag == "pickUp" && picked1p == false && Input.GetKeyDown(KeyCode.Space) && check1p == false && gameObject.tag == "Player1")
        {
            item = other.gameObject;
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = ObjPos;
            other.gameObject.transform.rotation = ObjRot;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            
            Debug.Log("picked - step 1");
     
        }
        if(Input.GetKeyUp(KeyCode.Space)&& check1p == false && picked1p== false)
        {
            check1p = true;
            picked1p = true;

        }
        if (other.tag == "pickUp" && picked2p == false && Input.GetKeyDown(KeyCode.RightShift) && check2p == false && gameObject.tag == "Player2")
        {
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = ObjPos;
            other.gameObject.transform.rotation = ObjRot;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            picked2p = true;
            Debug.Log("picked");

        }
        if (Input.GetKeyUp(KeyCode.RightShift) && picked2p == true)
        {
            check2p = true;
        }

    }


  

}



