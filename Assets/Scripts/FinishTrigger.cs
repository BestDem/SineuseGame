using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject canvasFinish;
    [SerializeField] private AccuracyController accuracyController;
    [SerializeField] private int level;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasFinish.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        accuracyController.SaveAccuracy(level);
    }
}
