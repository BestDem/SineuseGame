using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    [Header("Settings")]
    public ViewSideController viewSide;
    public ViewUpController viewUp;
    [SerializeField] public PauseUI pauseUI;
    private bool ViweUp = true;

    private void Start()
    {
        viewSide = FindFirstObjectByType<ViewSideController>();
        viewUp = FindFirstObjectByType<ViewUpController>();
    }
    private void Update()
    {
        if (pauseUI.isPause) return;
        if (ViweUp)
            MovementUp();
        else
            MovementSide();
    }


    public void MovementSide()
    {
        if (Input.GetKeyDown(KeyCode.W))
            viewSide.Move(1);
        else if (Input.GetKeyDown(KeyCode.S))
            viewSide.Move(0);
        else if (Input.GetKeyUp(KeyCode.S))
            viewSide.Move(2);
        else 
            viewSide.Move(3);
    }

    public void MovementUp()
    {
        if (Input.GetKeyDown(KeyCode.W))
            viewUp.Move(1);
        else if (Input.GetKeyDown(KeyCode.S))
            viewUp.Move(0);
        else
            viewUp.Move(2);
    }

    public void ChangeController()
    {
        ViweUp = !ViweUp;
    }
}