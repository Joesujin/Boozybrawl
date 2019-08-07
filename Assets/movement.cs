using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float throwForce = 1600f;
    Vector3 objectPos;
    float distance;

    public bool throwing = false;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    public static float HoldingObject = 0;



    // Update is called once per frame
    void Update()

    {


        // distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            // item.transform.SetParent(tempParent.transform);
            // item.transform.position =new  Vector3 (tempParent.transform);
            //  item.GetComponent<Transform>().position = tempParent.transform.position;
            item.transform.position = tempParent.transform.position;
            if (!throwing)
            {
                HoldingObject = 1;

            }

            // if(Input.GetMouseButtonDown(1))
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isHolding = false;
                throwing = true;
                HoldingObject = 0;
                if (throwing)
                {
                    item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * -throwForce);
                    //  item.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    Debug.Log(" thrown");

                }

            }

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
          //  item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
            HoldingObject = 0;



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
           // if (Input.GetKeyDown(KeyCode.Space))

           // {
                
                    if (isHolding == false)
                    {
                    // if (distance <= 2f)
                    // {
                    isHolding = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                   // item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    Debug.Log(" has to pick up");
                    //   }
                    
               }
         //   }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isHolding == false)
            {
                // if (Input.GetKeyDown(KeyCode.Space))
                //  {
                // if (distance <= 2f)
                // {
                isHolding = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log(" has to pick up");
                //   }
                // }
            }

        }
    }
}
   


