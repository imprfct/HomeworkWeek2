using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public void Win()
    {
        Time.timeScale = 0;
        UIManager.Instance.SpawnWinPanel();
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.SpawnGameOverPanel();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
