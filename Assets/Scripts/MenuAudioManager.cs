using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{

    public AudioSource menuAudio;

    public GameObject MainMenu;


    // Start is called before the first frame update
    void Start()
    {
        menuAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
