using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicValueChanged : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerMusic;
    [SerializeField] private AudioMixer audioMixerSound;
    [SerializeField] private Slider volumeAudioMusic;
    [SerializeField] private Slider volumeAudioSound;
    private float musicVolume = 0.2f;
    private float soundVolume = 1f;

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        soundVolume = PlayerPrefs.GetFloat("SoundVolume", soundVolume);
        volumeAudioMusic.value = musicVolume;
        volumeAudioSound.value = soundVolume;
        audioMixerMusic.SetFloat("MusicVolume", musicVolume);
        audioMixerSound.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.Save();
    }

    public void SetVolumeMusic(float newVolume)
    {
        musicVolume = Mathf.Clamp01(newVolume);
        if (musicVolume <= 0)
        {
            musicVolume = -80;
        }
        else
        {
           
        }
        audioMixerMusic.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 50);

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }
    public void SetVolumeSound(float newVolume)
    {
        soundVolume = Mathf.Clamp01(newVolume);
        if (soundVolume <= 0)
        {
            soundVolume = -80;
        }
        else
        {
            
        }
        audioMixerSound.SetFloat("SoundVolume", Mathf.Log10(soundVolume) * 50);

        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.Save();
    }
}
