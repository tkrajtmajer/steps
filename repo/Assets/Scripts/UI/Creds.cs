using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creds : MonoBehaviour
{
    public float credsSpeed;

    public float waitAmount;

    public GameObject optionsMenu;

    void Start()
    {
        StartCoroutine(Choose());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, credsSpeed * Time.deltaTime, 0);   
    }


    IEnumerator Choose()
    {
        yield return new WaitForSeconds(waitAmount);

        optionsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
