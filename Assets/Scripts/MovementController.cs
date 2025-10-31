using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] ViewSideController viewSide;
    [SerializeField] ViewUpController viewUp;
    private bool ViweUp = true;

    private void Update()
    {
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
}