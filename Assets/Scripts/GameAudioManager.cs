using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{

    public AudioSource playAudio;

    // Start is called before the first frame update
    void Start()
    {
        playAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
