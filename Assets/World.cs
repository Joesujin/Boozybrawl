using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public  GameObject Player1;
    public  GameObject Hold1;
    public static Vector3 H1Pos;
    public GameObject Player2;
    public GameObject Hold2;
    public static Vector3 H2Pos;
    public  GameObject Player3;
    public  GameObject Hold3;
    public static Vector3 H3Pos;
    public  GameObject Player4;
    public  GameObject Hold4;
    public static Vector3 H4Pos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H1Pos = transform.localPosition;
        
    }


}
