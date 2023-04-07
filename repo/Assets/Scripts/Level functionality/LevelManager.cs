using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Player_new player;
    int currentColor;

    public Transform red;
    public Transform green;
    public Transform blue;

    // arrays instead yay
    Coord[] originalGreen;
    Coord[] originalBlue;
    Coord[] atGreen;
    Coord[] atBlue;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_new>();
        currentColor = player.currentColor;

        player.OnPlayerChangeColor += LoadCoords;

        originalGreen = new Coord[green.childCount];
        originalBlue = new Coord[blue.childCount];
        atGreen = new Coord[green.childCount];
        atBlue = new Coord[blue.childCount];

        GetCoords();
        
    }

    // Update is called once per frame
    void Update()
    {
        // update the coordslist based on current color
        UpdateCoords();

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }


    // handle coord loading
    struct Coord
    {
        public float tileX;
        public float tileY;

        public Coord(float x, float y)
        {
            tileX = x;
            tileY = y;
        }
    }

    // set coords at start
    void GetCoords()
    {


        // save original position of green 
        for (int i = 0; i < green.childCount; i++)
        {
            if (originalGreen[i].tileX == 0)
            {
                originalGreen[i] = (new Coord(green.GetChild(i).position.x, green.GetChild(i).position.y));
            }
        }

        // and blue
        for (int i = 0; i < blue.childCount; i++)
        {
            if (originalBlue[i].tileX == 0)
            {
                originalBlue[i] = (new Coord(blue.GetChild(i).position.x, blue.GetChild(i).position.y));
            }
        }

        // setatgreen and atblue bcs they're at zero, thas where the error was, or at least part
        for (int i = 0; i < green.childCount; i++)
        {
            if (atGreen[i].tileX == 0)
            {
                atGreen[i] = (new Coord(green.GetChild(i).position.x, green.GetChild(i).position.y));
            }
        }

        // and blue
        for (int i = 0; i < blue.childCount; i++)
        {
            if (atBlue[i].tileX == 0)
            {
                atBlue[i] = (new Coord(blue.GetChild(i).position.x, blue.GetChild(i).position.y));
            }
        }


    }

    public void GetDuplicateCoords(int parentIndex, int index)
    {
        //duplicate passes parent and new child index, so coord can be added to existing at the new index
        switch(parentIndex)
        {
            case 2:
                // ovo je bas glupo al avaj

                Coord[] temp = new Coord[green.childCount];
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i != index)
                    {
                        temp[i] = originalGreen[i];
                    }
                    else
                    {
                        temp[index] = (new Coord(green.GetChild(i).position.x, green.GetChild(i).position.y));
                    }
                }
                originalGreen = new Coord[green.childCount];
                originalGreen = temp;

                //
                Coord[] temp3 = new Coord[green.childCount];
                for (int i = 0; i < temp3.Length; i++)
                {
                    if (i != index)
                    {
                        temp3[i] = atGreen[i];
                    }
                    else
                    {
                        temp3[index] = (new Coord(green.GetChild(i).position.x, green.GetChild(i).position.y));
                    }
                }
                atGreen = new Coord[green.childCount];
                atGreen = temp3;

                break;

            case 3:
                
                Coord[] temp2 = new Coord[blue.childCount];
                for (int i = 0; i < temp2.Length; i++)
                {
                    if (i != index)
                    {
                        temp2[i] = originalBlue[i];
                    }
                    else
                    {
                        temp2[index] = (new Coord(blue.GetChild(i).position.x, blue.GetChild(i).position.y));
                    }
                }
                originalBlue = new Coord[blue.childCount];
                originalBlue = temp2;

                //
                Coord[] temp4 = new Coord[blue.childCount];
                for (int i = 0; i < temp4.Length; i++)
                {
                    if (i != index)
                    {
                        temp4[i] = atBlue[i];
                    }
                    else
                    {
                        temp4[index] = (new Coord(blue.GetChild(i).position.x, blue.GetChild(i).position.y));
                    }
                }
                atBlue = new Coord[blue.childCount];
                atBlue = temp4;

                break;
        }
    }

    void UpdateCoords()
    {
        if (currentColor == 2)
        {
            // save green at green
            for (int i = 0; i < green.childCount; i++)
            {
                atGreen[i] = new Coord(green.GetChild(i).position.x, green.GetChild(i).position.y);
            }

        }
        else if (currentColor == 3)
        {
            for (int i = 0; i < blue.childCount; i++)
            {
                atBlue[i] = (new Coord(blue.GetChild(i).position.x, blue.GetChild(i).position.y));
            }
        }
    }

    void LoadCoords()
    {
        currentColor = player.currentColor;
        // load original
        // set transform of child at index [i] to desired position
        if (currentColor == 1)
        {

            // load original G and B
            for (int i = 0; i < originalGreen.Length; i++)
            {
                // apply to what?
                green.GetChild(i).transform.position = new Vector2(originalGreen[i].tileX, originalGreen[i].tileY);
            }
            for (int i = 0; i < originalBlue.Length; i++)
            {
                blue.GetChild(i).transform.position = new Vector2(originalBlue[i].tileX, originalBlue[i].tileY);
            }
        }
        //+load affected
        else if (currentColor == 2)
        {

            // load orig B
            for (int i = 0; i < originalBlue.Length; i++)
            {
                blue.GetChild(i).transform.position = new Vector2(originalBlue[i].tileX, originalBlue[i].tileY);
            }

            // load saved atGreen 
            // nesto nije uredu ovdje!
            for (int i = 0; i < atGreen.Length; i++)
            {
                green.GetChild(i).transform.position = new Vector2(atGreen[i].tileX, atGreen[i].tileY);
            }
        }
        else if (currentColor == 3)
        {

            // load saved atBlue
            for (int i = 0; i < atGreen.Length; i++)
            {
                green.GetChild(i).transform.position = new Vector2(atGreen[i].tileX, atGreen[i].tileY);
            }

            for (int i = 0; i < atBlue.Length; i++)
            {
                blue.GetChild(i).transform.position = new Vector2(atBlue[i].tileX, atBlue[i].tileY);
            }
        }
    }


    void RestartLevel() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
