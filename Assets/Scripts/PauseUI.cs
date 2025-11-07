using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject canvasPause;
    [SerializeField][CanBeNull] private PlayableDirector tartDelayTimeline;

    private void Awake()
    {
        GameManager.isPause = false;
        GameManager.isPauseDeath = false;
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
        else if (GameManager.isPauseDeath)
            deathMenu.SetActive(true);
    }


    public void GetInput()
    {
        GameManager.isPause = !GameManager.isPause;

        if (GameManager.isPause && !GameManager.isPauseDeath)
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!GameManager.isPause && !GameManager.isPauseDeath)
        {
            canvasPause.SetActive(false);
            deathMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}