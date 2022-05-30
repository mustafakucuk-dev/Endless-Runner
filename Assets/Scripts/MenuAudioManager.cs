using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{

    public AudioSource menuAudio;
    public AudioSource deathAudio;

    public GameObject MainMenu;
    public GameObject ScoreMenu;

    bool menuAudioPlay;
    bool deathAudioPlay;

    // Start is called before the first frame update
    void Start()
    {
        deathAudioPlay = false;
        deathAudio.Stop();

        menuAudioPlay = true;
        menuAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(menuAudioPlay){
            if(ScoreMenu.activeSelf){
                menuAudioPlay = false;
                menuAudio.Stop();
                deathAudioPlay = true;
                deathAudio.Play();
            }
        }
        else if(deathAudioPlay){
            if(!ScoreMenu.activeSelf){
                deathAudioPlay = false;
                deathAudio.Stop();
                menuAudioPlay = true;
                menuAudio.Play();
            }
        }
    }
}
