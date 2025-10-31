using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public static AnimatorController singltonAnim { get; private set; }
    private Animator animator;

    private void Awake()
    {
        singltonAnim = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimations(string animationNames, bool isAnimation)
    {

        if (animationNames == "isAttack")
            animator.SetTrigger("isAttack");
        if (animationNames == "isJump")
            animator.SetTrigger("isJump");
        if (animationNames == "isDend")
            animator.SetTrigger("isJump");
        else
            animator.SetBool("isRun", true);

        animator.SetBool(animationNames, isAnimation);
    }
}
