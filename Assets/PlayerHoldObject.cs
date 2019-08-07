using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldObject : MonoBehaviour
{
    public GameObject HoldingPosition;
    public Vector3 ObjPos;
    public Quaternion ObjRot;
   public static bool picked = false;

    void Update()
    {
        ObjPos = HoldingPosition.transform.position;
        ObjRot = HoldingPosition.transform.rotation;

        if (picked)
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (Input.GetKeyDown(KeyCode.Space))

        
            
            if (other.tag == "pickUp" )
            {
                other.gameObject.transform.parent= transform;
                other.gameObject.transform.position = ObjPos;
                other.gameObject.transform.rotation = ObjRot;
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                picked = true;
            Debug.Log("picked");



             if (Input.GetKeyDown(KeyCode.Space))
              {
                  //  other.gameObject.transform.parent = null;
                 // transform.parent = null;
              }
        }
       

    }
   

    void Pickup()

    {

    }


}


    
