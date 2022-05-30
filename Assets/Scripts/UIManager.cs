using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button PlayButton;
    public Button OptionsButton;
    public Button QuitButton;
    public Button BackButton;

    public GameObject MainMenu;
    public GameObject OptionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
        OptionsButton.onClick.AddListener(Options);
        QuitButton.onClick.AddListener(QuitGame);

        BackButton.onClick.AddListener(BackToMenu);
    }

    // Update is called once per frame
    void PlayGame(){
        SceneManager.LoadScene("GameScene");
    }
    void Options(){
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    void QuitGame(){
        Application.Quit();
    }
    void BackToMenu(){
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
