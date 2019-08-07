using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public float throwForce = 100000;
    public bool picked1 = false;
    public bool picked2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picked1 == true)
           
            {
                 if (Input.GetKeyDown(KeyCode.Space))
                //  other.gameObject.transform.parent = null;
                {
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    transform.parent = null;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce*2);
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    picked1 = false;
                }
            }
        if(picked2 == true)


            {
            if (Input.GetKeyDown(KeyCode.RightShift))
            //  other.gameObject.transform.parent = null;
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                transform.parent = null;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -throwForce * 2);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                picked2 = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       if( other.tag == "Player1")
        {
            picked1 = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        if (other.tag == "Player2")
        {
            picked2 = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        if (other.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;

            }
        }
    }

   
}
