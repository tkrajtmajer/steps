using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPoint : MonoBehaviour
{
    public bool canDuplicate = true;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
        {
            canDuplicate = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
        {
            canDuplicate = true;
        }
    }
}
