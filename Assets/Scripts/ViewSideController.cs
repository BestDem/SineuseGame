using UnityEngine;

public class ViewSideController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody player;

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

    private void Jump()
    {
        player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    private void Dend()
    {
        Debug.Log("Пригнулся");
        //AnimatorController.singltonAnim.PlayAnimations("isDend", true);
    }
}
