using UnityEngine;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private PauseUI pauseUI;
    private Vector3 movement;
    private Rigidbody _rb;

    private void Start()
    {
        pauseUI = FindFirstObjectByType<PauseUI>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement.x = -Input.GetAxis("Horizontal");
        movement.z = -Input.GetAxis("Vertical");

        //Move();
    }

    private void Move()
    {
        Vector3 moveRight = new Vector3(1, 0, 0) * movement.x * speed * Time.fixedDeltaTime;
        Vector3 moveForvard = new Vector3(0, 0, 1) * movement.z * speed * Time.fixedDeltaTime;
        if (movement.x == 0f && movement.z == 0f)
            AnimatorController.singltonAnim.PlayAnimations("isRun", false);
        else  
            AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        transform.Translate(moveRight, Space.World);
        transform.Translate(moveForvard, Space.World);
        //transform.localPosition += moveRight;
        //transform.localPosition += moveForvard;
    }

    private void FixedUpdate()
    {
        if (GameManager.isPause) return;
        Move();

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
            _rb.rotation = Quaternion.RotateTowards(
            _rb.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
        }
    }
}

