using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer; 
    public static audioManager instance;
    
    public const string Music_Key = "musicVolume";
    public const string Effect_Key = "effectVolume";

    void Awake(){
        if (instance == null){
            instance = this;

            DontDestroyOnLoad(gameObject);
        }else {
            Destroy(gameObject);
        }

        LoadVolume();
    }
    
    void LoadVolume(){
        float musicVolume = PlayerPrefs.GetFloat(Music_Key,1f);
        float effectVolume = PlayerPrefs.GetFloat(Effect_Key,1f);

        mixer.SetFloat(volumeSettings.Mixer_Music, Mathf.Log10(musicVolume)*20);
        mixer.SetFloat(volumeSettings.Mixer_effect, Mathf.Log10(effectVolume)*20);
    }
}

