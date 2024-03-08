using UnityEngine;

[RequireComponent (typeof(PlayerMovementScript))]

public class PlayerInputScript : MonoBehaviour
{
    private PlayerMovementScript playerMovement;
    private ShooterScript shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
        shooter = GetComponent<ShooterScript>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
