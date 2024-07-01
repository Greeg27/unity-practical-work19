using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] CanvasScript canvasScript;
    private float LavelScore;

    public void Pause(bool pause)
    {
        canvasScript.PausePanelSetActiv(pause);
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ScoreÑalculation(float Score)
    {
        LavelScore += Score;
        canvasScript.PlayerScoreDisplay(LavelScore);
    }

    public void TotalScoreÑalculation()
    {
        ScoreScript.TotalScore += LavelScore;
    }
}
