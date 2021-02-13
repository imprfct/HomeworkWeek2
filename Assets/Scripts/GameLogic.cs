using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject winPrefab;
    [SerializeField] private GameObject gameOverPrefab;
    [SerializeField] [CanBeNull] private Canvas canvas;
    
    public void Win()
    {
        Time.timeScale = 0;
        Instantiate(winPrefab, canvas.transform, false);
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        Instantiate(gameOverPrefab, canvas.transform, false);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
