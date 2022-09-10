using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject saved;
    public GameObject optionButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPause){
                Resume();
                saved.SetActive(false);
            }else {
                Pause();
            }
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        saved.SetActive(false);
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void MenuButton(){
        Debug.Log("Load menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ButtonPause(){
        if (GameIsPause){
                Resume();
                saved.SetActive(false);
            }else {
                Pause();
            }
    }

    public void OptionButton(){
        pauseMenuUI.SetActive(false);
        optionButton.SetActive(true);
    }
}
