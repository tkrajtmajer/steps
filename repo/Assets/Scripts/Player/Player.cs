using System;
using UnityEngine;

/// <summary>
/// *player controlls*
/// arrow keys - movement
/// qwe - rgb
/// asd for powers? eeeeh
/// 
/// 1:
/// r #D65A4E (214 / 255.0f, 90 / 255.0f, 78 / 255.0f)
/// g #9FE288 (159 / 255.0f, 226 / 255.0f, 136 / 255.0f)
/// b #5FADD9 (95 / 255.0f, 173 / 255.0f, 217 / 255.0f)
/// 
/// 2:
/// r #98F3FC (152 / 255.0f, 243 / 255.0f, 252 / 255.0f)
/// g #FC97B0 (252 / 255.0f, 151 / 255.0f, 176 / 255.0f)
/// b #FCC197 (252 / 255.0f, 193 / 255.0f, 151 / 255.0f)
/// 
/// 3:
/// r (248 / 255.0f, 188 / 255.0f, 100 / 255.0f)
/// g (252 / 255.0f, 60 / 255.0f, 104 / 255.0f)
/// b (186 / 255.0f, 137 / 255.0f, 193 / 255.0f)
/// 
/// 4:
/// r (42 / 255.0f, 157 / 255.0f, 143 / 255.0f)
/// g (244 / 255.0f, 162 / 255.0f, 97 / 255.0f)
/// b (231 / 255.0f, 111 / 255.0f, 81 / 255.0f)
/// 
/// 5:
/// r (0 / 255.0f, 150 / 255.0f, 161 / 255.0f)
/// g (255 / 255.0f, 168 / 255.0f, 202 / 255.0f)
/// b (51 / 255.0f, 161 / 255.0f, 67 / 255.0f)
/// 
/// 6:
/// r #541388 (84 / 255.0f, 19 / 255.0f, 136 / 255.0f)
/// g #D90368 (217 / 255.0f, 3 / 255.0f, 104 / 255.0f)
/// b #FFD400 (255 / 255.0f, 212 / 255.0f, 0 / 255.0f)
/// </summary>
/// 
public class Player : MonoBehaviour
{
    GameManager gManager;

    //temp
    public float[] pos = new float[2];
    //temp

    public float speed = 7f;
    public float distance = 1f;


    SpriteRenderer sRenderer;
    public int currentColor;
    public event Action OnPlayerChangeColor;

    //all colors
    public Color red;
    public Color green;
    public Color blue;

    //all sprites
    public Sprite p1;
    public Sprite p2;
    public Sprite p3;



    // Start is called before the first frame update
    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        // get rgb from gmanager
        gManager = FindObjectOfType<GameManager>();
        red = gManager.customizedColors[0];
        green = gManager.customizedColors[1];
        blue = gManager.customizedColors[2];

        ChangeColor(1);
        ChangePlayer(gManager.customizedPlayer);

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
    }


    public void ChangeColor(int desiredColor)
    {
        if (desiredColor == 1)
        {
            sRenderer.color = red;
        }
        else if (desiredColor == 2)
        {
            sRenderer.color = green;
        }
        else if (desiredColor == 3)
        {
            sRenderer.color = blue;
        }

        currentColor = desiredColor;
        OnPlayerChangeColor?.Invoke();
    }

    void ChangePlayer(int desiredP)
    {
        if (desiredP == 1)
        {
            sRenderer.sprite = p1;
        }
        else if (desiredP == 2)
        {
            sRenderer.sprite = p2;
        }
        else if (desiredP == 3)
        {
            sRenderer.sprite = p3;
        }
    }


}