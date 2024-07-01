using UnityEngine;

public class BackgroundManagerScript : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Transform[] layer;
    [SerializeField] CameraMovementScript cameraMovementScript;

    private float[] coef;
    private Vector2 _position;

    private void Awake()
    {
        coef = new float[layer.Length];

        for (int i = 0; i < layer.Length; i++)
        {
            coef[i] = 1 - layer[i].localScale.x;
        }
    }

    void Update()
    {
        _position = new Vector2(_camera.transform.position.x, _camera.transform.position.y - cameraMovementScript.minPos);

        for (int i = 0; i < layer.Length; i++)
        {
            layer[i].position = _position * coef[i];
        }
    }
}
