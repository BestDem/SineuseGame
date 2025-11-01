using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject player;
    [SerializeField] private MovementController movementController;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private SoundController soundController;
    private PlayerController playerController;
    private float position = 0;

    void Awake()
    {
        player.TryGetComponent(out PlayerController pc);
        playerController = pc;
    }

    void Start()
    {
        soundController.Play2DSongByIndex(2);
    }

    void Update()
    {
        if (pauseUI.isPause) return;
        if (playerController.isDead)
        {
            playerController.isDead = false;
            position = 0;
            movementController.Reset();
        }
        else
        {
            position -= speed * Time.deltaTime;
        }
        Vector3 levelPos = level.transform.position;
        level.transform.position = new Vector3(position, levelPos.y, levelPos.z);

    }

}
