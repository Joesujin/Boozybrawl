using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripta : MonoBehaviour
{
    public static GameObject item;
    public GameObject HoldingPosition;
    public Vector3 ObjPos;
    public Quaternion ObjRot;
    public static bool picked1p = false, picked2p = false;
    public static bool thrown1 = false, thrown2 = false;
    public static bool check1p = false , check2p = false;
   
    float throwForce = 1000; 
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjPos = HoldingPosition.transform.position;
        ObjRot = HoldingPosition.transform.rotation;

        // After throw - 4
        if (Input.GetKeyUp(KeyCode.Space) && check1p == true && thrown1 == true)
        {
            item = null;
            check1p = false;
            thrown1 = false;
            picked1p = false;
            Debug.Log(" thrown and ready - step 3");

            }
        // After throw - 4
        if (Input.GetKeyUp(KeyCode.RightShift) && check2p == true && thrown2 == true)
        {
            item = null;
            check2p = false;
            thrown2 = false;
            picked2p = false;
            Debug.Log(" thrown and ready - step 3");

        }
    }
    private void OnTriggerStay(Collider other)
    {if (gameObject.tag == "Player1")
        { // pick up - 1
            if (other.tag == "pickUp" && picked1p == false && Input.GetKeyDown(KeyCode.Space) && check1p == false) 
            {
                item = other.gameObject;
                pickUp();
                Debug.Log("picked - step 1");
            }
            // after pickup - 2
            if (Input.GetKeyUp(KeyCode.Space) && check1p == false && picked1p == false)
            {
                check1p = true;
                picked1p = true;
                Debug.Log("picked - step 1.5");
            }

            if (picked1p)
            {// Throw - 3
                if (Input.GetKeyDown(KeyCode.Space) && check1p == true && picked1p == true)
                {
                    thrown1 = true;
                    Throwing();
                    Debug.Log("Thrown - step 2");
                }

            }
        }
        if (gameObject.tag == "Player2")
        { // pick up - 1
            if (other.tag == "pickUp" && picked1p == false && Input.GetKeyDown(KeyCode.RightShift) && check2p == false)
            {
                item = other.gameObject;
                pickUp();
                Debug.Log("picked - step 1");
            }
            // after pickup - 2
            if (Input.GetKeyUp(KeyCode.RightShift) && check2p == false && picked2p == false)
            {
                check2p = true;
                picked2p = true;
                Debug.Log("picked - step 1.5");
            }

            if (picked2p)
            {// Throw - 3
                if (Input.GetKeyDown(KeyCode.RightShift) && check2p == true && picked2p == true)
                {
                    thrown2 = true;
                    Throwing();
                    Debug.Log("Thrown - step 2");
                }

            }
        }
    }
    void pickUp()
    {
        item.GetComponent<Rigidbody>().transform.parent = transform;
        item.GetComponent<Rigidbody>().transform.position = ObjPos;
        item.GetComponent<Rigidbody>().transform.rotation = ObjRot;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    void Throwing()
    {
       
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.GetComponent<Rigidbody>().AddForce(transform.forward * -throwForce * 2);
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.transform.position = transform.localPosition;
    }
}
