using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public Button PlayButton;
    public Button HowToPlayButton;
    public Button QuitButton;
    public Button BackButton;

    public GameObject MainMenu;
    public GameObject HowToPlayMenu;


    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
        HowToPlayButton.onClick.AddListener(HowToPlay);
        QuitButton.onClick.AddListener(QuitGame);

        BackButton.onClick.AddListener(BackToMenu);
    }

    // Update is called once per frame
    void PlayGame(){
        SceneManager.LoadScene("GameScene");
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    void HowToPlay(){
        MainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }
    void QuitGame(){
        Application.Quit();
    }
    void BackToMenu(){
        HowToPlayMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
