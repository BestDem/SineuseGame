using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float targetSpeed;
    private float smooth = 5f;
    [SerializeField] private GameObject level;
    [SerializeField] private MovementController movementController;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private SoundController soundController;
    private float position = 0;
    private bool isDelay = true;
    private float velocity;


    void Awake()
    {
        targetSpeed = speed;
    }

    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        soundController.Play2DSongByIndex(2);
        isDelay = false;
    }

    void Update()
    {
        if (isDelay == false)
        {
            speed = targetSpeed;
            position -= speed * Time.deltaTime;

            Vector3 levelPos = level.transform.position;
            level.transform.position = new Vector3(position, levelPos.y, levelPos.z);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(position);
        }

    }

    void FixedUpdate()
    {
        //if (isDelay == false)
        //{
        //    speed = Mathf.Lerp(speed, targetSpeed, smooth * Time.fixedDeltaTime);
        //}
    }

}
