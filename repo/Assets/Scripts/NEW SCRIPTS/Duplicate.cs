using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    //if detects collision with [pushable] layer + if end point is empty -> create same object at end point

    OtherPoint otherPoint;
    Vector3 otherPointPosition;
    bool otherPointFree;

    GameObject objectToDuplicate;

    public Transform redParent;
    public Transform greenParent;
    public Transform blueParent;

    LevelManager lMan;

    // Start is called before the first frame update
    void Start()
    {
        otherPoint = FindObjectOfType<OtherPoint>();
        otherPointPosition = otherPoint.transform.position;

        lMan = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        otherPointFree = otherPoint.canDuplicate;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(otherPointFree && (collision.tag == "red" || collision.tag == "green" || collision.tag == "blue"))
        {
            //then duplicate!
            objectToDuplicate = collision.gameObject;
            GameObject duplicate = Instantiate(objectToDuplicate); //hierarchy also needs to be handled
            duplicate.transform.position = otherPointPosition;
            if(collision.tag == "red")
            {
                duplicate.transform.SetParent(redParent);

            }
            if (collision.tag == "green")
            {
                duplicate.transform.SetParent(greenParent);

                lMan.GetDuplicateCoords(2, duplicate.transform.GetSiblingIndex());
            }
            if (collision.tag == "blue")
            {
                duplicate.transform.SetParent(blueParent);

                lMan.GetDuplicateCoords(3, duplicate.transform.GetSiblingIndex());
            }

        }
    }

}
