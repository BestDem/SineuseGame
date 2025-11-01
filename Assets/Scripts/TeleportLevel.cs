using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLevel : MonoBehaviour
{
    [SerializeField] private int idLevel;
    private Screen_fader screen;

    private void Start()
    {
        screen = FindAnyObjectByType<Screen_fader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Invoke("ChangeLevel", 1f);
            //StartCoroutine(FadeInCoroutine(1));
            TeleportOnLevel(idLevel);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TeleportOnLevel(int level)
    {
        screen.FadeIn();

        StartCoroutine(FadeInCoroutine(level));
    }

    private IEnumerator FadeInCoroutine(int level)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(level);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
