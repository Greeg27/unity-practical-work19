using UnityEngine;

public class DeleteAfterAnimScript : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public void Delete()
    {
        Destroy(obj);
    }
}
