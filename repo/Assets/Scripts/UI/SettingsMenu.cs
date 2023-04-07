using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixerGroup music;
    public AudioMixerGroup SFX;

    /*string raveButtonTxt = "on";
    bool raveOn = true;

    public Button raveButton;*/

    string fullscreenButtonTxt;
    bool fullscreenOn;

    public Button fullscreenButton;

    GameManager_new gMan;

    void Start()
    {
        gMan = FindObjectOfType<GameManager_new>();

        if(Screen.fullScreen)
        {
            fullscreenButtonTxt = "off";
            fullscreenButton.GetComponentInChildren<Text>().text = fullscreenButtonTxt;
            fullscreenOn = true;
        }
        else
        {
            fullscreenButtonTxt = "on";
            fullscreenButton.GetComponentInChildren<Text>().text = fullscreenButtonTxt;
            fullscreenOn = false;
        }
    }

    public void SetVolumeMusic(float volume)
    {
        music.audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        SFX.audioMixer.SetFloat("volumeSFX", volume);
    }

    /*
    public void ToggleRaveMode()
    {
        if(raveOn)
        {
            raveOn = false;
            raveButtonTxt = "off";
            raveButton.GetComponentInChildren<Text>().text = raveButtonTxt;
            //gManager.raveOn = false;
        }
        else
        {
            raveOn = true;
            raveButtonTxt = "on";
            raveButton.GetComponentInChildren<Text>().text = raveButtonTxt;
            //gManager.raveOn = true;
        }
    }*/

    public void ToggleFullscreenMode()
    {
        if(fullscreenOn)
        {
            fullscreenOn = false;
            fullscreenButtonTxt = "off";
            fullscreenButton.GetComponentInChildren<Text>().text = fullscreenButtonTxt;
            SetFullscreen(false);
        }
        else
        {
            fullscreenOn = true;
            fullscreenButtonTxt = "on";
            fullscreenButton.GetComponentInChildren<Text>().text = fullscreenButtonTxt;
            SetFullscreen(true);
        }
    }

    void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void ResetProgress()
    {
        for(int i = 0; i < 10; i++)
        {
            gMan.levelsCompleted[i] = false;
        }

        gMan.Save();
    }
}
