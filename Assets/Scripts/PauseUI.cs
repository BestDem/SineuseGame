using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField][CanBeNull] private PlayableDirector tartDelayTimeline;

    private void Awake()
    {
        GameManager.isPause = false;
        GameManager.isPauseDeath = false;
        GameManager.OnDeath += ShowDeathMenu;
    }

    private void OnDestroy()
    {
        GameManager.OnDeath -= ShowDeathMenu;
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (tartDelayTimeline != null)
            tartDelayTimeline.Play();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canvasPause.activeSelf && GameManager.isPause) return;
            {
                GetInput();
            }
        }
//        else if (GameManager.isPauseDeath)
//            deathMenu.SetActive(true);
    }


    public void GetInput()
    {
        GameManager.isPause = !GameManager.isPause;

        if (GameManager.isPause && !GameManager.isPauseDeath)
        {
            canvasPause.SetActive(true);
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!GameManager.isPause && !GameManager.isPauseDeath)
        {
            canvasPause.SetActive(false);
//            deathMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void ShowDeathMenu()
    {
        deathMenu.SetActive(true);
    }
}