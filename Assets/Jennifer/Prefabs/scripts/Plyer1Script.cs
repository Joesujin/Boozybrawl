using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyer1Script : MonoBehaviour
{
    public GameObject item;
    public GameObject HoldingPosition;
    public Vector3 ObjPos;
    public Quaternion ObjRot;
    public bool picked = false;
    public bool thrown = false;
    public bool check = false;
    //public RigidbodyConstraints origConstraints;
    public Rigidbody origbody;

    float throwForce = 1000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjPos = HoldingPosition.transform.position;
        ObjRot = HoldingPosition.transform.rotation;

        if (Input.GetKeyUp(KeyCode.Space) && thrown == true)
        {
            item = null;
            check = false;
            thrown = false;
            picked = false;
            Debug.Log(" thrown and ready - step 3");

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pickUp")
        {
            Debug.Log(" item detected");
        }
        //  if (gameObject.tag == "Player1") // -- PLAYER 1
        { // pick up - 1
            if (other.tag == "pickUp" && picked == false && Input.GetKeyDown(KeyCode.Space))
            {
                item = other.gameObject;
                origbody = item.GetComponent<Rigidbody>();
                picked = true;
                pickUp();
                Debug.Log("picked - step 1");
            }
            // after pickup - 2
            if (Input.GetKeyUp(KeyCode.Space) && check == false && picked == true)
            {
                check = true;
                picked = false;

                Debug.Log("picked - step 1.5");
            }

            if (picked)
            {// Throw - 3
                if (Input.GetKeyDown(KeyCode.Space) && check == true)
                {
                    thrown = true;
                    check = false;
                    Throwing();
                    Debug.Log("Thrown - step 2");
                }

            }
        }
    }
    void pickUp()
    {
        item.transform.parent = transform;
        item.transform.position = ObjPos;
        item.transform.rotation = ObjRot;
        //origConstraints = item.GetComponent<Rigidbody>().constraints;

        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.GetComponent<MeshCollider>().enabled = false;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    void Throwing()
    {
        item.GetComponent<MeshCollider>().enabled = true;
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().useGravity = true;
        //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //item.transform.position = transform.localPosition;
        //item.transform.rotation = transform.localRotation;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.GetComponent<Rigidbody>().constraints = origbody.constraints;
        item.GetComponent<Rigidbody>().velocity = origbody.velocity;
        item.GetComponent<Rigidbody>().angularVelocity = origbody.angularVelocity;
        item.GetComponent<Rigidbody>().AddForce(Vector3.forward * -throwForce * 2);



        //item.transform.position = transform.localPosition;
        //item.transform.rotation = transform.localRotation;
    }
}

