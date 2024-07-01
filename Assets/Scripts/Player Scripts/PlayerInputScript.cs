using UnityEngine;

[RequireComponent (typeof(PlayerMovementScript))]
[RequireComponent(typeof(ShooterScript))]
[RequireComponent(typeof(GameManagerScript))]

public class PlayerInputScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;
    private PlayerMovementScript playerMovement;
    private ShooterScript shooter;

    public bool cancel;
    public bool hold;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
        shooter = GetComponent<ShooterScript>();
        gameManagerScript = GetComponent<GameManagerScript>();
        cancel = false;
        hold = false;
    }

    private void Update()
    {
        if (!hold)
        {
            float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetButtonDown(GlobalStringVars.CANCEL))
            {
                cancel = !cancel;
                gameManagerScript.Pause(cancel);
            }

            if (!cancel)
            {
                if (Input.GetButtonDown(GlobalStringVars.FIRE))
                {
                    shooter.ShootingStart();
                }

                if (Input.GetButtonUp(GlobalStringVars.FIRE))
                {
                    shooter.ShootingStop();
                }

                playerMovement.Move(horizontalDirection, isJumpButtonPressed, target);
            }
        }
        
    }

    
}
