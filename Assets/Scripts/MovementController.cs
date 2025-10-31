using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private CharacterController characterController;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = new PlayerInput();
    }

    private void Update()
    {
        playerInput.movement = Input.GetAxis("Vertical");
    }


    public void Movement(float speed)
    {
        //движение или спавн уровня
    }
}

[System.Serializable]
public class PlayerInput
{
    public float movement;
    public bool isFire;
}
