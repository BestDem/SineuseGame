using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject canvasPause;
    public bool isPause = false;
    public bool isPauseDeath = false;
    private CameraController cameraController;

    private void Start()
    {
        cameraController = FindAnyObjectByType<CameraController>();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canvasPause.activeSelf && isPause) return;
            {
                GetInput();
            }
        }
        else if(isPauseDeath) 
            deathMenu.SetActive(true); 
    }

    public void GetInput()
    {
        isPause = !isPause;

        if (isPause == true)
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            canvasPause.SetActive(false);
            deathMenu.SetActive(false); 
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}