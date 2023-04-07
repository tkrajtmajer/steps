using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float waitTime = 0.2f;
    public int moveAmount;
    public int moveTo; //1-up 2-down 3-left 4-right

    Player_new player;
    Rigidbody2D pBody;

    GameObject pushBlock;

    float rayLength = 1.4f;

    public LayerMask colliders;
    public LayerMask checkPls;

    void Start()
    {
        player = FindObjectOfType<Player_new>();
        pBody = player.GetComponent<Rigidbody2D>();

    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //when collide, start coroutine to move player by x in y
            StartCoroutine(TranslatePlayer());
        }
        if(collision.tag == "red" || collision.tag == "green" || collision.tag == "blue")
        {
            pushBlock = collision.gameObject;
            StartCoroutine(TranslateBlock());
        }
    }

    IEnumerator TranslatePlayer()
    {
        player.canMove = false;

        yield return new WaitForSeconds(waitTime); //mozda bolje ovako? no<3

        switch (moveTo)
        {
            case (1):
                if (!Physics2D.Raycast(transform.position, Vector2.up, rayLength * (moveAmount) ,colliders))
                {
                    pBody.position += Vector2.up * moveAmount;
                }
                break;
            case (2):
                if (!Physics2D.Raycast(transform.position, Vector2.down, rayLength * (moveAmount), colliders))
                {
                    pBody.position += Vector2.down * moveAmount;
                }
                break;
            case (3):
                if (!Physics2D.Raycast(transform.position, Vector2.left, rayLength * (moveAmount), colliders))
                {
                    pBody.position += Vector2.left * moveAmount;
                }
                break;
            case (4):
                if (!Physics2D.Raycast(transform.position, Vector2.right, rayLength * (moveAmount), colliders))
                {
                    pBody.position += Vector2.right * moveAmount;
                }
                break;
        }

        player.canMove = true;
    }

    IEnumerator TranslateBlock()
    {
        yield return new WaitForSeconds(waitTime); 

        switch (moveTo)
        {
            case (1):
                if (!Physics2D.Raycast(transform.position, Vector2.up, rayLength * (moveAmount), colliders))
                {
                    pushBlock.transform.position += Vector3.up * moveAmount;
                }
                break;
            case (2):
                if (!Physics2D.Raycast(transform.position, Vector2.down, rayLength * (moveAmount), colliders))
                {
                    pushBlock.transform.position += Vector3.down * moveAmount;
                }
                break;
            case (3):
                if (!Physics2D.Raycast(transform.position, Vector2.left, rayLength * (moveAmount), colliders))
                {
                    pushBlock.transform.position += Vector3.left * moveAmount;
                }
                break;
            case (4):
                if (!Physics2D.Raycast(transform.position, Vector2.right, rayLength * (moveAmount), colliders))
                {
                    pushBlock.transform.position += Vector3.right * moveAmount;
                }
                break;
        }

    }
}
