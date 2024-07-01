using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            LoadScene(1);
        }
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
