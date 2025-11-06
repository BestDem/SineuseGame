using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float targetSpeed;
    [SerializeField] private GameObject level;
    [SerializeField] private SoundController soundController;
    [SerializeField] private GameObject timer;
    private float position = 0;
    private bool isDelay = true;

    void Awake()
    {
        targetSpeed = speed;
    }

    public void StartLevel()
    {
        AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        soundController.Play2DSongByIndex(2);
        isDelay = false;
        //Destroy(timer);
        timer.SetActive(false);
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

    }

    void FixedUpdate()
    {
        //if (isDelay == false)
        //{
        //    speed = Mathf.Lerp(speed, targetSpeed, smooth * Time.fixedDeltaTime);
        //}
    }

}
