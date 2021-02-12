using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPrefab;
    [SerializeField] [CanBeNull] private Canvas canvas;
    
    public void GameOver()
    {
        Time.timeScale = 0;
        Instantiate(gameOverPrefab, canvas.transform, false);
    }

    public void Restart()
    {
        var scene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
