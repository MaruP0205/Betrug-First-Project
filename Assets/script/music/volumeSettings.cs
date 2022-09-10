using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectSlider;

    public const string Mixer_Music = "MusicVolume";
    public const string Mixer_effect = "EffectVolume";

   void Awake(){
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);
   }

    void Start(){
        musicSlider.value = PlayerPrefs.GetFloat(audioManager.Music_Key,1f);
        effectSlider.value = PlayerPrefs.GetFloat(audioManager.Effect_Key,1f);
    }

   void OnDisable(){
        PlayerPrefs.SetFloat(audioManager.Music_Key, musicSlider.value);
        PlayerPrefs.SetFloat(audioManager.Effect_Key, effectSlider.value);
   }

   void SetMusicVolume(float value){
        mixer.SetFloat(Mixer_Music, Mathf.Log10(value)*20);
   }

   void SetEffectVolume(float value){
        mixer.SetFloat(Mixer_effect, Mathf.Log10(value)*20);
   }
}
