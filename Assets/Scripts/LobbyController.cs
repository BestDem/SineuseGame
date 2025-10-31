using UnityEngine;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movement;

    private void Update()
    {
        movement.z = Input.GetAxis("Horizontal");
        movement.x = Input.GetAxis("Vertical");

        Move();
    }

    private void Move()
    {
        Vector3 moveRight = transform.right * movement.x * speed * Time.deltaTime;
        Vector3 moveForvard = -transform.forward * movement.z * speed * Time.deltaTime;

        transform.position += moveRight;
        transform.position += moveForvard;
    }
}

