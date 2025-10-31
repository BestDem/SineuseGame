using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLevel : MonoBehaviour
{
    [SerializeField] private int idLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(idLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    public void TeleportOnLevel(int idLevel)
    {
        SceneManager.LoadScene(idLevel);
    }
}
