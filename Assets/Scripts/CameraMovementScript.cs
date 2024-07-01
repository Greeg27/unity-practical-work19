using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float minPosition; 

    public float minPos { get; private set; }

    private void Awake()
    {
        minPos = minPosition;
    }

    private void FixedUpdate()
    {
        if (playerTransform.position.y < minPosition)
        {
            transform.position = new Vector3(playerTransform.position.x, minPosition, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
