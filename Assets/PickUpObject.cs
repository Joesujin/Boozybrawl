using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    
    public static Vector3 itemPos;
    public bool IsPicked = false;
    float throwForce = 100;
    int Throw;
    // Start is called before the first frame update
    void Start()
    {
        Throw = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPicked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Throw = 1;
                //isHolding = false;
               // throwing = true;
               // HoldingObject = 0;
                if (Throw == 1)
                {
                    
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    //  item.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    Debug.Log(" thrown");

                }

            }
        }
        else
        {
            gameObject.GetComponent<Transform>().position = transform.localPosition;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player1")
        {
           // Debug.Log("Picked");
           //// if (Input.GetKeyDown(KeyCode.E))
           // {
            //    Debug.Log("Picked");
                itemPos = World.H1Pos;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                IsPicked = true;
                Throw = 1;
               
           // }

        }
      /*  if (other.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                itemPos = World.H2Pos;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                IsPicked = true;
            }

        }
        if (other.tag == "Player3")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                itemPos = World.H3Pos;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                IsPicked = true;
            }

        }

        if (other.tag == "Player4")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                itemPos = World.H4Pos;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                IsPicked = true;
            }

        }*/
    }
}
