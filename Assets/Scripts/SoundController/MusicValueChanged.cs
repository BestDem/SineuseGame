using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicValueChanged : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerMusic;
    [SerializeField] private AudioMixer audioMixerSound;
    [SerializeField] private Slider volumeAudioMusic;
    [SerializeField] private Slider volumeAudioSound;
    private float musicVolume = 1f;
    private float soundVolume = 1f;

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        soundVolume = PlayerPrefs.GetFloat("SoundVolume");
        volumeAudioMusic.value = musicVolume;
        volumeAudioSound.value = soundVolume;
        audioMixerMusic.SetFloat("MusicVolume", musicVolume);
        audioMixerMusic.SetFloat("SoundVolume", soundVolume);
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
            musicVolume = Mathf.Log10(musicVolume) * 20;
        }
        audioMixerMusic.SetFloat("MusicVolume", musicVolume);

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
            soundVolume = Mathf.Log10(soundVolume) * 20;
        }
        audioMixerSound.SetFloat("SoundVolume", soundVolume);

        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.Save();
    }
}
