using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class musicMain : MonoBehaviour
{
    [SerializeField] AudioSource music; 
    [SerializeField] GameObject musicOn;
    [SerializeField] GameObject musicOff;
    // Start is called before the first frame update
    public void OnMusic()
    {   
        music.Stop();
        musicOff.SetActive(true);
        musicOn.SetActive(false);
        
    }

    // Update is called once per frame
    public void OffMusic()
    {
        music.Play();
        musicOff.SetActive(false);
        musicOn.SetActive(true);
    }
}
