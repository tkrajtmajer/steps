using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_new : MonoBehaviour
{
    //setting properties//
        GameManager_new gMan;

        int playerIcon;
        Color red;
        Color green;
        Color blue;
        public Sprite p1;
        public Sprite p2;
        public Sprite p3;

        SpriteRenderer sRenderer;

        //for changing
        public int currentColor = 1;
        public event Action OnPlayerChangeColor;
    //setting properties//

    //movement//
        public float speed = 3f;
        Vector2 targetPosition;
        bool moving;
        Vector2 startPosition;
        Rigidbody2D pBody;
        float rayLength = 1.4f;

        public bool canMove = true;

        public LayerMask colliders;
        public LayerMask push;
        GameObject pushBlockInContact;
        Vector3 pushPos;
    //movement//


    //being fancy
    AudioSource aSource;

    void Awake()
    {
        gMan = FindObjectOfType<GameManager_new>();
        sRenderer = GetComponent<SpriteRenderer>();
        
        //load chosen colors and player image
        playerIcon = gMan.customizedPlayer;
        red = gMan.customizedColors[0];
        green = gMan.customizedColors[1];
        blue = gMan.customizedColors[2];

        //set chosen colors and icon
        sRenderer.color = red;

        switch (playerIcon)
        {
            case (1):
                sRenderer.sprite = p1;
                break;
            case (2):
                sRenderer.sprite = p2;
                break;
            case (3):
                sRenderer.sprite = p3;
                break;
        }
    }


    void Start()
    {
        pBody = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && currentColor != 1)
        {
            ChangeColor(1);
        }
        else if (Input.GetKeyDown(KeyCode.W) && currentColor != 2)
        {
            ChangeColor(2);
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentColor != 3)
        {
            ChangeColor(3);
        }
        
        PlayerMovement();
    }


    void ChangeColor(int color)
    {
        if (color == 1)
        {
            sRenderer.color = red;
        }
        else if (color == 2)
        {
            sRenderer.color = green;
        }
        else if (color == 3)
        {
            sRenderer.color = blue;
        }

        currentColor = color;
        OnPlayerChangeColor?.Invoke();
    }


    
    void PlayerMovement()
    {
        if(moving)
        {
            if(Vector2.Distance(startPosition, pBody.position) > 1f)
            { 
                pBody.position = targetPosition;
                moving = false;
                aSource.Play();
                return;
            }

            pBody.position += (targetPosition - startPosition) * speed * Time.deltaTime;
            return;
        }

        if (canMove)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!Physics2D.Raycast(pBody.position, Vector2.up, rayLength, colliders))
                {
                    targetPosition = pBody.position + Vector2.up;
                    startPosition = pBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!Physics2D.Raycast(pBody.position, Vector2.down, rayLength, colliders))
                {
                    targetPosition = pBody.position + Vector2.down;
                    startPosition = pBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!Physics2D.Raycast(pBody.position, Vector2.left, rayLength, colliders))
                {
                    targetPosition = pBody.position + Vector2.left;
                    startPosition = pBody.position;
                    moving = true;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!Physics2D.Raycast(pBody.position, Vector2.right, rayLength, colliders))
                {
                    targetPosition = pBody.position + Vector2.right;
                    startPosition = pBody.position;
                    moving = true;
                }
            }
        }
    }

    /*
    void PlayerMovement()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 velocity = input * speed;
        pBody.moveAmount(pBody.position + velocity * Time.deltaTime);
    }*/

}
