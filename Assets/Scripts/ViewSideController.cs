using UnityEngine;

public class ViewSideController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;
    private Rigidbody player;
    private bool isGround;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    public void Move(float direction)
    {
        if (direction == 0)    //пригнулся
        {
            Dend();
        }
        else if (direction == 1)         //прыгнул
        {
            Jump();
        }
        else if (direction == 2)
        {
            //AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        }
    }

    private void CheackGround()
    {
        RaycastHit hit;
        isGround = Physics.SphereCast(transform.position, 1f, -Vector3.forward, out hit, layerMask);
    }

    private void Jump()
    {
        RaycastHit hit;
        isGround = Physics.SphereCast(transform.position, 3f, Vector3.forward, out hit, layerMask);
        if(isGround)
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    private void Dend()
    {
        //AnimatorController.singltonAnim.PlayAnimations("isDend", true);
    }
}
