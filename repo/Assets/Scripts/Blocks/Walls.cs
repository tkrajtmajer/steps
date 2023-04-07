using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    PlayerGrid player;

    void Start()
    {
        player = FindObjectOfType<PlayerGrid>();    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "pushable")
        {
            Debug.Log("movepoint is on pushable");
            player.blockInQuestion = collision.transform;
        }    */
        //ne znam sta ovaj kod radi ni na cemu je lolmao
    }
}
