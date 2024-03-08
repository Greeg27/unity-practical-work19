using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void FixedUpdate()
    {
        transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y + 1, transform.position.z);
    }
}
