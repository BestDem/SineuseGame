using UnityEngine;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 movement;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        movement.x = -Input.GetAxis("Horizontal");
        movement.z = -Input.GetAxis("Vertical");

        Move();
    }

    private void Move()
    {
        Vector3 moveRight = new Vector3(1, 0, 0) * movement.x * speed * Time.deltaTime;
        Vector3 moveForvard = new Vector3(0, 0, 1) * movement.z * speed * Time.deltaTime;

        transform.Translate(moveRight, Space.World);
        transform.Translate(moveForvard, Space.World);
        //transform.localPosition += moveRight;
        //transform.localPosition += moveForvard;
    }

    private void FixedUpdate()
    {
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            _rb.rotation = Quaternion.Slerp(_rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}

