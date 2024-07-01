using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] Image playerHealthImage;
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject scorePanel;
    [SerializeField] TMP_Text playerScore;
    [SerializeField] TMP_Text levelScore;
    [SerializeField] TMP_Text totalScore;

    public void PlayerHealthDisplay(float health)
    {
        playerHealthImage.fillAmount = health;
    }

    public void PlayerScoreDisplay(float score)
    {
        playerScore.text = ((int)score).ToString();
    }

    public void DeathPanelSetActiv()
    {
        deathPanel.SetActive(true);
    }

    public void PausePanelSetActiv(bool activ)
    {
        pausePanel.SetActive(activ);
    }

    public void scorePanelSetActiv()
    {
        levelScore.text = playerScore.text;
        totalScore.text = ((int)ScoreScript.TotalScore).ToString();
        scorePanel.SetActive(true);
    }
}
