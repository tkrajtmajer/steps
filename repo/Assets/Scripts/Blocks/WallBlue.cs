using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlue : MonoBehaviour
{
    //colors
    Color blue;
    Color black = new Color(0f, 0f, 0f, 255f);

    SpriteRenderer wallRenderer;
    Rigidbody2D wallBody;

    Player p;
    int currentPcol;

    GameManager gManager;

    void Awake()
    {
        p = FindObjectOfType<Player>();
        p.OnPlayerChangeColor += ChangeWallColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        wallRenderer = GetComponent<SpriteRenderer>();
        wallBody = GetComponent<Rigidbody2D>();

        gManager = FindObjectOfType<GameManager>();
        blue = gManager.customizedColors[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWallColor()
    {
        currentPcol = p.currentColor;

        if (currentPcol == 3)
        {
            wallRenderer.color = blue;
            wallBody.isKinematic = false;
            gameObject.layer = 0;
        }
        else
        {
            wallRenderer.color = black;
            wallBody.isKinematic = true;
            gameObject.layer = 13;
        }
    }
}
