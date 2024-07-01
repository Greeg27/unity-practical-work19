using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] CanvasScript canvasScript;
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] PlayerInputScript playerInputScript;
    [SerializeField] PlayerMovementScript playerMovementScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInputScript.hold = true;
            playerMovementScript.Move(1, false, transform.position);
            gameManagerScript.TotalScore—alculation();
            canvasScript.scorePanelSetActiv();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementScript.Move(0, false, transform.position);
    }
}
