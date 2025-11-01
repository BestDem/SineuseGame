using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController singletonSound { get; private set; }
    [SerializeField] private GameObject sourse3DPref;
    [SerializeField] private GameObject sourse2DPref;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private AudioMixerGroup audioMixerMusic;

    private void Start()
    {
        if (singletonSound == null)
            singletonSound = this;
        else
            Destroy(gameObject);
    }

    public void Play3DSongByIndex(int index, Vector3 transformSound)
    {
        if (index >= 0 && index < audioClips.Length)
            PlaySound3D(audioClips[index], transformSound);
    }

    public void Play2DSongByIndex(int index)
    {
        if (index >= 0 && index < audioClips.Length)
            PlaySound2D(audioClips[index]);
    }
    
    private void PlaySound3D(AudioClip audioClip, Vector3 transformSound)
    {
        GameObject AudioSource2D = Instantiate(sourse3DPref, transformSound, Quaternion.identity);

        AudioSource2D.TryGetComponent(out AudioSource _audioSource);
        _audioSource.clip = audioClip;
        _audioSource.outputAudioMixerGroup = audioMixerMusic;
        _audioSource.Play();

        StartCoroutine(StopSound(AudioSource2D));
    }

    private void PlaySound2D(AudioClip audioClip)
    {
        GameObject AudioSource2D = Instantiate(sourse2DPref, transform.position, Quaternion.identity);

        AudioSource2D.TryGetComponent(out AudioSource _audioSource);
        _audioSource.clip = audioClip;
        _audioSource.outputAudioMixerGroup = audioMixerMusic;
        _audioSource.Play();

        StartCoroutine(StopSound(AudioSource2D));
    }

    
    IEnumerator StopSound(GameObject _prefSound)   //я не знаю как по другому проверять когда музыка закончилась 
    {
        _prefSound.TryGetComponent(out AudioSource _audioSource);
        while (true) 
        {
            yield return new WaitUntil(() => !_audioSource.isPlaying || pauseUI.isPause);

            if (pauseUI.isPause)
            {
                _audioSource.Pause();
                yield return new WaitUntil(() => !pauseUI.isPause);
                _audioSource.UnPause();
            }
            else
            {
                break;
            }
        }

        Destroy(_prefSound);
    }
}
