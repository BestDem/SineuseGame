using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject canvasPause;
    [SerializeField][CanBeNull] private PlayableDirector tartDelayTimeline;
    public bool isPause = false;
    public bool isPauseDeath = false;

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
            if (!canvasPause.activeSelf && isPause) return;
            {
                GetInput();
            }
        }
        else if (isPauseDeath)
            deathMenu.SetActive(true);
    }


    public void GetInput()
    {
        isPause = !isPause;

        if (isPause && !isPauseDeath)
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (isPause == false && !isPauseDeath)
        {
            canvasPause.SetActive(false);
            deathMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}