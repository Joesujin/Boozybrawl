using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager1 : MonoBehaviour
{
    public float moveSpeed = 30f;//jen
    public float turnSpeed = 50f;//jen
    [SerializeField] GameObject[] players;
    Rigidbody[] playerRB;
   

    [SerializeField] float speed = 100f;
   
    //[SerializeField] float drunkForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = new Rigidbody[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            GameObject player = players[i];
            playerRB[i] = player.GetComponent<Rigidbody>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAllPlayers(); 
    }


    // Move All Player Objects
    private void MoveAllPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            movement(players[i], i);
            //drunkMovement(playerRB[i], i);

        }
    }

    // Basic Movement for a single Object, uses translate and not Rigidbody
    void movement(GameObject player, int i) 
    {
       player.transform.Translate(Input.GetAxis("Horizontal" + i) * speed * Time.deltaTime, 0f, -Input.GetAxis("Vertical" + i) * speed * Time.deltaTime);
   
}

    //void drunkMovement(Rigidbody playerRB, int i)
    //{
    //    playerRB.AddForce(new Vector3(Input.GetAxis("Horizontal" + i) * drunkForce * Time.deltaTime, 0f, -Input.GetAxis("Vertical" + i) * drunkForce * Time.deltaTime));
        
    //}
}
