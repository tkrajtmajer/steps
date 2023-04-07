using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB : MonoBehaviour
{
    
    public int wallId;

    Color red;
    Color green;
    Color blue;
    Color black = new Color(0f, 0f, 0f, 255f);

    GameManager_new gMan;
    SpriteRenderer pushSRenderer;
    Rigidbody2D pushRBody;

    Player_new player;
    int pCurrentColor;

    CircleCollider2D circleCollider;

    //movement//
    
        public float speed = 3f;
        Vector2 targetPosition;
        bool moving;
        Vector2 startPosition;
        float rayLength = 1.4f;
        int moveTo;
        bool canMove = false;

        public LayerMask colliders;

    //movement//

    void Awake()
    {
        
        gMan = FindObjectOfType<GameManager_new>();
        pushSRenderer = GetComponent<SpriteRenderer>();

        //load chosen colors 
        red = gMan.customizedColors[0];
        green = gMan.customizedColors[1];
        blue = gMan.customizedColors[2];

        //set color to individual
        switch(wallId)
        {
            case (1):
                pushSRenderer.color = red;
                break;
            case (2):
                pushSRenderer.color = green;
                break;
            case (3):
                pushSRenderer.color = blue;
                break;
        }
    }

    void Start()
    {
        pushRBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player_new>();
        player.OnPlayerChangeColor += ChangePushColor;
        ChangePushColor();

        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        PlayerMovement();
    }


    //event -when player changes color, coords should update (LM) and colors should match (zis)
    public void ChangePushColor()
    {
        pCurrentColor = player.currentColor;

        switch (wallId)
        {
            case (1):
                if(pCurrentColor == 1 || pCurrentColor == 0)
                {
                    pushSRenderer.color = red;
                    //circleCollider.enabled = true;
                    gameObject.layer = 14;
                }
                else
                {
                    pushSRenderer.color = black;
                    //circleCollider.enabled = false;
                    gameObject.layer = 13;
                }
                break;
            case (2):
                if (pCurrentColor == 2)
                {
                    pushSRenderer.color = green;
                    //circleCollider.enabled = true;
                    gameObject.layer = 14;
                }
                else
                {
                    pushSRenderer.color = black;
                    //circleCollider.enabled = false;
                    gameObject.layer = 13;
                }
                break;
            case (3):
                if (pCurrentColor == 3)
                {
                    pushSRenderer.color = blue;
                    //circleCollider.enabled = true;
                    gameObject.layer = 14;
                }
                else
                {
                    pushSRenderer.color = black;
                    //circleCollider.enabled = false;
                    gameObject.layer = 13;
                }
                break;
        }
    }

    //ovo myb uspije a myb bude epic fail

    void PlayerMovement()
    {
        
        if (moving)
        {
            if (Vector2.Distance(startPosition, pushRBody.position) > 1f)
            {
                pushRBody.position = targetPosition;
                moving = false;
                return;
            }

            pushRBody.position += (targetPosition - startPosition) * speed * Time.deltaTime;
            return;
        }

        if (canMove)
        {
            if (Input.GetKey(KeyCode.UpArrow) && moveTo == 1)
            {
                if (!Physics2D.Raycast(pushRBody.position, Vector2.up, rayLength, colliders))
                {
                    targetPosition = pushRBody.position + Vector2.up;
                    startPosition = pushRBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && moveTo == 2)
            {
                if (!Physics2D.Raycast(pushRBody.position, Vector2.down, rayLength, colliders))
                {
                    targetPosition = pushRBody.position + Vector2.down;
                    startPosition = pushRBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && moveTo == 3)
            {
                if (!Physics2D.Raycast(pushRBody.position, Vector2.left, rayLength, colliders))
                {
                    targetPosition = pushRBody.position + Vector2.left;
                    startPosition = pushRBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) && moveTo == 4)
            {
                if (!Physics2D.Raycast(pushRBody.position, Vector2.right, rayLength, colliders))
                {
                    targetPosition = pushRBody.position + Vector2.right;
                    startPosition = pushRBody.position;
                    moving = true;
                }
            }
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canMove = true;
            FindMoveDirection();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canMove = false;
        }
    }

    void FindMoveDirection()
    {
        Vector3 playerPos = player.transform.position;
        if(playerPos.x > transform.position.x && Mathf.RoundToInt(playerPos.y) == Mathf.RoundToInt(transform.position.y))
        {
            //player is to the right
            moveTo = 3;
        }
        else if (playerPos.x < transform.position.x && Mathf.RoundToInt(playerPos.y) == Mathf.RoundToInt(transform.position.y))
        {
            //player is to the left
            moveTo = 4;
        }
        if (playerPos.y > transform.position.y && Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(transform.position.x))
        {
            //player is above
            moveTo = 2;
        }
        else if (playerPos.y < transform.position.y && Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(transform.position.x))
        {
            //player is below
            moveTo = 1;
        }
    }

    
    
}
