using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    Rigidbody[] playerRB;
    Animator[] animator;
   

    [SerializeField] float speed = 5f;
    [SerializeField] float drunkForce = 4f;
    [SerializeField] float drunkSwerve = 2f;

    public static Action<int> onPressGrab;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = new Rigidbody[players.Length];
        animator = new Animator[players.Length];

       
        for (int i = 0; i < players.Length; i++)
        {
            GameObject player = players[i];
            playerRB[i] = player.GetComponent<Rigidbody>();
            animator[i] = player.GetComponent<Animator>();
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
            Grab(players[i], i);
            // drunkMovement(playerRB[i], i);
        }
    }

    // Basic Movement for a single Object, uses translate and not Rigidbody
    void movement(GameObject player, int i)
    {
        //player.transform.Translate(Input.GetAxis("Horizontal" + i) * speed * Time.deltaTime, 0f, -Input.GetAxis("Vertical" + i) * speed * Time.deltaTime);
        Vector3 movement3 = new Vector3(Input.GetAxis("Horizontal" + i) * speed * Time.deltaTime, 0f, -Input.GetAxis("Vertical" + i) * speed * Time.deltaTime);

        player.transform.position += movement3;
        if (movement3 != Vector3.zero)
            player.transform.rotation =  Quaternion.LookRotation(movement3);

        SetAnimation(i, "walk");
    }



    private void SetAnimation(int i, string condition)
    {
        if (Input.GetAxisRaw("Horizontal" + i) != 0 || Input.GetAxisRaw("Vertical" + i) != 0)
        {
            animator[i].SetInteger(condition, 1);
        }

        else
        {
            animator[i].SetInteger(condition, 0);
        }

    }
    void Grab(GameObject player, int i)
    {
        if (Input.GetButtonDown("Fire" + i) && onPressGrab != null)
        {
            onPressGrab(i);
            Debug.Log("FireButton Working");
        }
    }

    void drunkMovement(Rigidbody playerRB, int i)
    {
        //playerRB.AddForce(new Vector3(Input.GetAxis("Horizontal" + i) * drunkForce * Time.deltaTime, 0f, -Input.GetAxis("Vertical" + i) * drunkForce * Time.deltaTime));
        //playerRB.AddForce( Mathf.Sin(Time.time * drunkSwerve) * drunkForce, 0f, - Mathf.Sin(Time.time) * drunkForce);
        playerRB.AddForce(new Vector3(Input.GetAxis("Horizontal" + i) * Mathf.Sin(Time.time * drunkSwerve) * drunkForce, 0f, -Input.GetAxis("Vertical" + i) * Mathf.Sin(Time.time ) * drunkForce));
    }
}
