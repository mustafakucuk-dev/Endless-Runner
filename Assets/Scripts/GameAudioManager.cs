using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{

    public AudioSource gameAudio;
    public AudioSource deathAudio;

    public GameObject ScoreMenu;

    bool gameAudioPlay;
    bool deathAudioPlay;

    // Start is called before the first frame update
    void Start()
    {
        deathAudioPlay = false;
        deathAudio.Stop();

        gameAudioPlay = true;
        gameAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameAudioPlay){
            if(ScoreMenu.activeSelf){
                gameAudioPlay = false;
                gameAudio.Stop();
                deathAudioPlay = true;
                deathAudio.Play();
            }
        }
        else if(deathAudioPlay){
            if(!ScoreMenu.activeSelf){
                deathAudioPlay = false;
                deathAudio.Stop();
                gameAudioPlay = true;
                gameAudio.Play();
            }
        }
    }
}
