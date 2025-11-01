using UnityEngine;

public class SceneSpeedTrigger : MonoBehaviour
{
    [SerializeField] private float speed;
    private SceneController sceneController;

    void Start()
    {
        sceneController = FindAnyObjectByType<SceneController>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sceneController.targetSpeed = speed;
        }
    }
}
