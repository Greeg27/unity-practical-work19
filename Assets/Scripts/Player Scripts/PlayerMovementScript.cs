using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimationScript))]
public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] float Speed = 10;
    [SerializeField] float JumpForce = 3;

    [Header("Components")]
    [SerializeField] Transform headTransform;
    [SerializeField] Transform bodyTransform;
    [SerializeField] Transform armTransform;
    [SerializeField] Transform groundColliderTransform;
    [SerializeField] LayerMask groundMasc;
    [SerializeField] LayerMask platformMasc;

    public float AdditionalSpeed;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool onPlatform;
    private bool superJump;
    private bool forvard;
    private PlayerAnimationScript playerAnimation;

    private float direction;
    private bool jumpButton;
    private Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimationScript>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundColliderTransform.position, 0.05f, groundMasc);
        onPlatform = Physics2D.OverlapCircle(groundColliderTransform.position, 0.05f, platformMasc);

        if (isGrounded || onPlatform)
        {
            superJump = false;
        }

        

        if (isGrounded || direction != 0 || onPlatform)
        {
            HorizontalMovement(direction);
        }

        if (onPlatform)
        {
            OnPlatformMovement(direction);
        }

        Direction(target);

        if (target.x - transform.position.x > 0)
        {
            forvard = true;
        }
        else
        {
            forvard = false;
        }

        MoveAnimation(direction);
    }

    public void Move(float direction, bool jumpButton, Vector3 target)
    {
        this.direction = direction;
        this.jumpButton = jumpButton;
        this.target = target;
        if (jumpButton)
        {
            if (isGrounded || onPlatform)
            {
                Jump();
            }
            else if (!superJump)
            {
                superJump = true;
                SuperJamp();
                playerAnimation.SuperJump();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    private void SuperJamp()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce * 1.5f);
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * Speed, rb.velocity.y);
    }

    private void OnPlatformMovement(float direction)
    {
        rb.velocity = new Vector2(direction * Speed + AdditionalSpeed, rb.velocity.y);
    }

    private void Direction(Vector3 target)
    {
        target.y += 0.35f;

        armTransform.LookAt(new Vector3(target.x, target.y, 0));
        Vector3 rotate = armTransform.eulerAngles;
        
        if (superJump)
        {
            rotate = ArmDirectionLimit(rotate,  55, 90);
        }
        else
        {
            rotate = ArmDirectionLimit(rotate, 12, 90);
        }

        if (rotate.y == 0)
        {
            rotate.y = 90;
        }

        armTransform.rotation = Quaternion.Euler(rotate);
        bodyTransform.rotation = Quaternion.Euler(0, rotate.y, 0);

        HeadDirection(rotate);
    }

    private Vector3 ArmDirectionLimit(Vector3 rotate, int min, int max)
    {
        if (rotate.x > min && rotate.x < max)
        {
            rotate.x = min;
        }

        return rotate;
    }

    private void HeadDirection(Vector3 rotate)
    {
        if (rotate.x > 90)
        {
            rotate.x = (rotate.x - 360) / 2;
        }

        headTransform.rotation = Quaternion.Euler(rotate);
    }

    private void MoveAnimation(float direction)
    {
        if (isGrounded || onPlatform)
        {
            playerAnimation.Jump(true);
            playerAnimation.Walk(direction, true, forvard);
        }
        else
        {
            playerAnimation.Jump(false);
            playerAnimation.Walk(direction, false, forvard);
        }
    }

}
