using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionMenu : MonoBehaviour
{   
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject saved;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameObject.SetActive(false);
            saved.SetActive(false);
            return;
        }
    }

    public void BackButton(){
        pauseMenuUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackMenu(){
        gameObject.SetActive(false);
    }
}
