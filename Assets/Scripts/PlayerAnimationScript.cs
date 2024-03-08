using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField] Animator bodyAnimator;

    public void Walk(float direction, bool isGrounded, bool forvard)
    {
        if (isGrounded && direction > 0 && forvard)
        {
            bodyAnimator.SetInteger("WalkInt", 1);
        }
        else if (isGrounded && direction < 0 && !forvard)
        {
            bodyAnimator.SetInteger("WalkInt", 1);
        }
        else if (isGrounded && direction < 0 && forvard)
        {
            bodyAnimator.SetInteger("WalkInt", -1);
        }
        else if (isGrounded && direction > 0 && !forvard)
        {
            bodyAnimator.SetInteger("WalkInt", -1);
        }
        else
        {
            bodyAnimator.SetInteger("WalkInt", 0);
        }
    }

    public void Jump(bool isGrounded)
    {
        bodyAnimator.SetBool("JumpBool", isGrounded);
    }

    public void SuperJump()
    {
        bodyAnimator.SetTrigger("SuperJumpTrigger");
    }
}
