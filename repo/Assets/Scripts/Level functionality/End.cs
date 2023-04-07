using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    //tell gm that level under current index (add 2 bcs of first two scenes) has been finished, proceed to next level

    //when player is on end object, disable p movement, trigger 'block start' animation, switch level 

    Player_new player;
    GameManager_new gMan;

    public Animator transition;

    float transTime = 1.9f;

    private void Start()
    {
        player = FindObjectOfType<Player_new>();
        gMan = FindObjectOfType<GameManager_new>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        player.canMove = false;
        gMan.levelsCompleted[SceneManager.GetActiveScene().buildIndex - 2] = true;
        gMan.Save();
        yield return new WaitForSeconds(0.7f);
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
