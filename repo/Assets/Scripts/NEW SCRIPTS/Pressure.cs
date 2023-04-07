using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pressure : MonoBehaviour
{

    public int pressureIndex;
    public event Action PressureIsTriggered;
    public event Action PressureIsDeactivated;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "red" || collision.tag == "green" || collision.tag == "blue" || collision.tag == "pushable")
        {
            PressureIsTriggered?.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "red" || collision.tag == "green" || collision.tag == "blue" || collision.tag == "pushable")
        {
            PressureIsDeactivated?.Invoke();
        }

    }
}
