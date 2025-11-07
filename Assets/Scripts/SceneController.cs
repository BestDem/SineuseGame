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

    void Awake()
    {
        GameManager.delayBeforeStart = true;
        targetSpeed = speed;
    }

    public void StartLevel()
    {
        AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        soundController.Play2DSongByIndex(2);
        GameManager.delayBeforeStart = false;
        //Destroy(timer);
        timer.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.delayBeforeStart)
        {
            speed = targetSpeed;
            position -= speed * Time.deltaTime;

            Vector3 levelPos = level.transform.position;
            level.transform.position = new Vector3(position, levelPos.y, levelPos.z);
        }

    }

    void FixedUpdate()
    {
        //if (GameManager.delayBeforeStart == false)
        //{
        //    speed = Mathf.Lerp(speed, targetSpeed, smooth * Time.fixedDeltaTime);
        //}
    }

}
