using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] 
    private GameObject _winPrefab;
    
    [SerializeField]
    private GameObject _gameOverPrefab;
    
    [SerializeField] 
    [CanBeNull]
    private Canvas _canvas;
    
    public void Win()
    {
        Time.timeScale = 0;
        Instantiate(_winPrefab, _canvas.transform, false);
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        Instantiate(_gameOverPrefab, _canvas.transform, false);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
