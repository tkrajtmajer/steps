using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Collider2D doorCollider;
    SpriteRenderer doorSRender;
    public bool isOpenByDefault = false;

    public int pressureIndexIsWhat; //????
    Pressure[] plateList;

    AudioSource dSource;

    void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorSRender = GetComponent<SpriteRenderer>();

        plateList = FindObjectsOfType<Pressure>();
        foreach(Pressure plate in plateList)
        {
            if(plate.pressureIndex == pressureIndexIsWhat)
            {
                plate.PressureIsTriggered += PressureDown;
                plate.PressureIsDeactivated += PressureUp;
            }
        }

        dSource = GetComponent<AudioSource>();


        if (isOpenByDefault)
        {
            doorCollider.enabled = false;
            doorSRender.color = new Color(255, 255, 255, 0.2f);
            gameObject.layer = 0;
            dSource.Play();
        }

        
    }

    void PressureDown()
    {
        if(isOpenByDefault)
        {
            //close door if its open by default, cool
            doorCollider.enabled = true;
            doorSRender.color = new Color(255, 255, 255, 255);
            gameObject.layer = 13;
        }
        else
        {
            //disable door how?
            doorCollider.enabled = false;
            doorSRender.color = new Color(255, 255, 255, 0.2f);
            gameObject.layer = 0;
            dSource.Play();
        }
    }

    void PressureUp()
    {
        if (!isOpenByDefault)
        {
            //close door if its not open by default, cool
            doorCollider.enabled = true;
            doorSRender.color = new Color(255, 255, 255, 255);
            gameObject.layer = 13;
        }
        else
        {
            //disable door how?
            doorCollider.enabled = false;
            doorSRender.color = new Color(255, 255, 255, 0.2f);
            gameObject.layer = 0;
            dSource.Play();
        }
    }

}
