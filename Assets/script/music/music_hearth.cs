using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_hearth : MonoBehaviour
{
    public static AudioSource aus;
    // Start is called before the first frame update
    void Start()
    {   
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void healthup(){
        aus.Play();
    }
}
