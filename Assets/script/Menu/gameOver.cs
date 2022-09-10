using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{   
    public GameObject optionButton;
    public GameObject noteButton;
    public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Man1");
    }

    public void RestartButton2(){
        SceneManager.LoadScene("Man2");
    }

    public void RestartButton3(){
        SceneManager.LoadScene("Man3");
    }
    
    public void MenuButton(){
        Debug.Log("Load menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void OptionButton(){
        optionButton.SetActive(true);
    }

    public void NoteButton(){
        noteButton.SetActive(true);
    }
}
