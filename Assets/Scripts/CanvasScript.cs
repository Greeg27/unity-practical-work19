using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] Image playerHealthImage;
    [SerializeField] GameObject DeathPanel;

    public void PlayerHealthDisplay(float health)
    {
        playerHealthImage.fillAmount = health;
    }

    public void DeathPanelSetActiv()
    {
        DeathPanel.SetActive(true);
    }
}
