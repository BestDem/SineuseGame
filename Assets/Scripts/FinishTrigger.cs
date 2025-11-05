using UnityEngine;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject canvasFinish;
    [SerializeField] private Text accText;
    [SerializeField] private AccuracyController accuracyController;
    [SerializeField] private int level;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasFinish.SetActive(true);
            accText.text = "Точность: " + accuracyController.getAccuracy().ToString("F2") + "%";;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            accuracyController.SaveAccuracy(level);
        }
    }
}
