using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject level;
    [SerializeField] private MovementController movementController;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private SoundController soundController;
    private float position = 0;
    private bool isDelay = true;

    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(5.4f);
        soundController.Play2DSongByIndex(2);
        isDelay = false;
    }

    void Update()
    {
        if (isDelay == false)
        {
            position -= speed * Time.deltaTime;

            Vector3 levelPos = level.transform.position;
            level.transform.position = new Vector3(position, levelPos.y, levelPos.z);
        }

    }

}
