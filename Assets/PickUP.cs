using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    float throwForce = 1000;
    public bool picked1 = false;
    public bool picked2 = false;
    bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {//if (picked1)
       if(PlayerHoldObject.picked1p)
        {
            if (Input.GetKeyDown(KeyCode.Space) && PlayerHoldObject.check1p == true) //&& PlayerHoldObject.picked1p == true)
            //  other.gameObject.transform.parent = null;
            {
                Debug.Log("Thrown - step 2");
                transform.parent = null;
                PlayerHoldObject.item.GetComponent<Rigidbody>().useGravity = true;
                PlayerHoldObject.item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                PlayerHoldObject.item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                PlayerHoldObject.item.GetComponent<Rigidbody>().AddForce(Vector3.forward * -throwForce * 2);
                PlayerHoldObject.item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //PlayerHoldObject.picked1p = false;
                thrown = true;
                //PlayerHoldObject.check = false;
                

            }
            if (Input.GetKeyUp(KeyCode.Space) && PlayerHoldObject.check1p == true && thrown == true)
            {
                PlayerHoldObject.check1p = false;
                PlayerHoldObject.picked1p = false;
                PlayerHoldObject.item = null;
                transform.parent = null;
                thrown = false;
                gameObject.transform.position = transform.localPosition;
                Debug.Log(" thrown and ready - step 3");

                // PlayerHoldObject.picked1p = false;

            }
        }



        if (picked2)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && PlayerHoldObject.check2p == true && PlayerHoldObject.picked2p == true)
            //  other.gameObject.transform.parent = null;
            {

                transform.parent = null;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -throwForce * 2);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                PlayerHoldObject.picked2p = false;

            }
            if (Input.GetKeyUp(KeyCode.RightShift) && PlayerHoldObject.picked2p == false)
            {
                PlayerHoldObject.check2p = false;



            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" && PlayerHoldObject.picked1p == true)
        {
            //picked1 = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("freezepos - step 1.5");
        }
        if (other.tag == "Player2" && PlayerHoldObject.picked2p == false)
        {
            picked2 = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

        if(other.tag != "Player1" || other.tag != "Player2")
        {
           // gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 0);
        }
    }
}
        /*  if (other.tag == "Ground")
           {
               if (Input.GetKey(KeyCode.Space))
               {
                   gameObject.GetComponent<BoxCollider>().isTrigger = true;

               }
           }


   */

       /* public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1" && PlayerHoldObject.picked1p == false)//&& Input.GetKeyDown(KeyCode.Space))
        {
            // picked1 = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerHoldObject.check1p == true && PlayerHoldObject.picked1p == true && other.tag == "Player1")
            //  other.gameObject.transform.parent = null;
            {

                transform.parent = null;
                PlayerHoldObject.item.GetComponent<Rigidbody>().useGravity = true;
                PlayerHoldObject.item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                PlayerHoldObject.item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                PlayerHoldObject.item.GetComponent<Rigidbody>().AddForce(transform.forward * -throwForce * 2);
                PlayerHoldObject.item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                PlayerHoldObject.picked1p = false;
                //PlayerHoldObject.check = false;
                Debug.Log("Thrown");
            }
            if (Input.GetKeyUp(KeyCode.Space) && PlayerHoldObject.picked1p == false)
            {
                PlayerHoldObject.check1p = false;
                // PlayerHoldObject.picked1p = false;

            }
        }
}*/

    
    



